using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using SING.Data.Controls.GmapControl.Markers;
using SING.Data.Controls.GmapControl.Models;

namespace SING.Data.Controls.GmapControl
{
    public class Map : GMapControl
    {
        private static GMapMarker currentMarker;

        private static ImageSource defaultImg = null;

        private static GMapMarker SetPositionMarker;

        public delegate void PointLatLngImgChanged(PointLatLngImg point);

        public event PointLatLngImgChanged OnCurrentPointLatLngImgChanged;

        public Map()
        {
            InitMapControl();
        }

        private void InitMapControl()
        {
            GMap.NET.CacheProviders.MySQLPureImageCache ch = new GMap.NET.CacheProviders.MySQLPureImageCache();
            //ch.ConnectionString = @"server=sql2008;User Id=trolis;Persist Security Info=True;database=gmapnetcache;password=trolis;";
            ch.ConnectionString = ConfigurationManager.AppSettings["mapName"]?.ToString();
            this.Manager.PrimaryCache = ch;

            // set your proxy here if need
            //GMapProvider.IsSocksProxy = true;
            //GMapProvider.WebProxy = new WebProxy("127.0.0.1", 1080);
            //GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
            // or
            //GMapProvider.WebProxy = WebRequest.DefaultWebProxy;
            //
            double lat = double.Parse(ConfigurationManager.AppSettings["defaultLat"] == null ? "0" : ConfigurationManager.AppSettings["defaultLat"]);
            double lng = double.Parse(ConfigurationManager.AppSettings["defaultLng"] == null ? "0" : ConfigurationManager.AppSettings["defaultLng"]);

            this.MapProvider = GMapProviders.AmapProvider;
            this.Position = new PointLatLng(lat, lng); //地图中心点
            this.Manager.Mode = AccessMode.ServerOnly;
            this.DragButton = MouseButton.Right;

            this.SetPositionByKeywords("beijing, China");//设定初始中心位置为Chengdu，成都坐标为西纬30.67度，东经104.06
            this.ShowCenter = false;//不显示中心的红色十字

            this.MouseMove += new System.Windows.Input.MouseEventHandler(MainMap_MouseMove);
            this.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(MainMap_MouseLeftButtonDown);
            this.MouseEnter += new MouseEventHandler(MainMap_MouseEnter);

            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            string resourceStr = @"/SING.Data;component/Controls/GmapControl/Images/red-dot.png";
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(new Uri(resourceStr, UriKind.Relative));
            defaultImg = (ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream);
        }

        #region Properties

        public PointLatLng CurrentPosition
        {
            get
            {
                return (PointLatLng)GetValue(CurrentPositionProperty);
            }
            set
            {
                SetValue(CurrentPositionProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentPositionProperty =
            DependencyProperty.Register("CurrentPosition", typeof(PointLatLng), typeof(Map), new UIPropertyMetadata(new PropertyChangedCallback(CurrentPositionClick)));

        private static void CurrentPositionClick(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Map target = d as Map;
            if (e.NewValue != null)
            {
                target.Position = (PointLatLng)e.NewValue;

                if (target.IsSetPositionMarker)
                {
                    if (SetPositionMarker != null)
                    {
                        SetPositionMarker.Position = target.Position;
                    }
                }
            }
        }

        public string CurrentPlacemark
        {
            get { return (string)GetValue(CurrentPlacemarkProperty); }
            set { SetValue(CurrentPlacemarkProperty, value); }
        }

        public static readonly DependencyProperty CurrentPlacemarkProperty =
            DependencyProperty.Register("CurrentPlacemark", typeof(string), typeof(Map), new UIPropertyMetadata(new PropertyChangedCallback(CurrentPlacemarkPropertyClick)));

        private static void CurrentPlacemarkPropertyClick(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Map target = d as Map;
            if (e.NewValue != null)
            {
            }
        }

        public PointLatLngImg CurrentPointLatLngImg
        {
            get { return (PointLatLngImg)GetValue(PointLatLngImgProperty); }
            set { SetValue(PointLatLngImgProperty, value); }
        }

        public static readonly DependencyProperty PointLatLngImgProperty =
            DependencyProperty.Register("CurrentPointLatLngImg", typeof(PointLatLngImg), typeof(Map), new UIPropertyMetadata(new PropertyChangedCallback(CPointLatLngImgPropertyClick)));

        private static void CPointLatLngImgPropertyClick(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Map target = d as Map;
            if (e.NewValue != null)
            {
                target.CurrentPosition = target.CurrentPointLatLngImg.Point;
                GetCurrentMarkers(target);

                if (target.OnCurrentPointLatLngImgChanged != null)
                {
                    target.OnCurrentPointLatLngImgChanged.Invoke(target.CurrentPointLatLngImg);
                }
            }
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)(GetValue(ImageSourceProperty)); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(Map), new UIPropertyMetadata(defaultImg, new PropertyChangedCallback(ImageSourceChanged)));

        private static void ImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Map target = d as Map;
            if (e.NewValue != null)
            {
                target.ImageSource = (ImageSource)e.NewValue;
            }
        }

        public bool IsSetPositionMarker
        {
            get { return (bool)(GetValue(IsSetPositionMarkerProperty)); }
            set { SetValue(IsSetPositionMarkerProperty, value); }
        }

        public static readonly DependencyProperty IsSetPositionMarkerProperty =
            DependencyProperty.Register("IsSetPositionMarker", typeof(bool), typeof(Map), new UIPropertyMetadata(false, new PropertyChangedCallback(IsSetPositionMarkerPropertyChanged)));

        private static void IsSetPositionMarkerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Map target = d as Map;

            bool result = Convert.ToBoolean(e.NewValue);

            if (result)
            {
                SetPositionMarker = new GMapMarker(target.CurrentPosition);
                {
                    if (target.ImageSource == null) target.ImageSource = defaultImg;
                    SetPositionMarker.Shape = new CustomMarker(target, SetPositionMarker, target.ImageSource);
                    SetPositionMarker.Offset = new System.Windows.Point(-15, -15);
                    SetPositionMarker.ZIndex = int.MaxValue;
                    target.Markers.Add(SetPositionMarker);
                }
            }
        }

        //public ObservableCollection<PointLatLngImg> Points
        //{
        //    get { return (ObservableCollection<PointLatLngImg>)(GetValue(PointsProperty)); }
        //    set { SetValue(PointsProperty, value); }
        //}

        //public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points", typeof(ObservableCollection<PointLatLngImg>), typeof(Map), new PropertyMetadata(PointsPropertyChanged));
        public List<PointLatLngImg> Points
        {
            get { return (List<PointLatLngImg>)(GetValue(PointsProperty)); }
            set { SetValue(PointsProperty, value); }
        }

        public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points", typeof(List<PointLatLngImg>), typeof(Map), new PropertyMetadata(PointsPropertyChanged));
        private static void PointsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Map target = d as Map;

                if (e.NewValue != null)
                {
                    if (target.IsDisplayMarker)
                    {
                        AddMarker(target);
                    }
                    else if (target.IsDisplayPolyline)
                    {
                        SetPolyline(target);
                    }
                    else if (target.IsDisplayRoute)
                    {
                        SetRoute(target);
                    }
                    else if (target.IsDisplayPolygon)
                    {
                        SetPolygon(target);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("Map->PointsPropertyChanged：\r\n" + ex.Message);
            }
        }

        public bool IsDisplayMarker
        {
            get { return (bool)(GetValue(IsDisplayMarkerProperty)); }
            set { SetValue(IsDisplayMarkerProperty, value); }
        }

        public static readonly DependencyProperty IsDisplayMarkerProperty = DependencyProperty.Register("IsDisplayMarker", typeof(bool), typeof(Map), new UIPropertyMetadata(false, null));

        public bool IsDisplayRoute
        {
            get { return (bool)(GetValue(IsDisplayRouteProperty)); }
            set { SetValue(IsDisplayRouteProperty, value); }
        }

        public static readonly DependencyProperty IsDisplayRouteProperty = DependencyProperty.Register("IsDisplayRoute", typeof(bool), typeof(Map), new UIPropertyMetadata(false, null));

        public bool IsDisplayPolygon
        {
            get { return (bool)(GetValue(IsDisplayPolygonProperty)); }
            set { SetValue(IsDisplayPolygonProperty, value); }
        }

        public static readonly DependencyProperty IsDisplayPolygonProperty = DependencyProperty.Register("IsDisplayPolygon", typeof(bool), typeof(Map), new UIPropertyMetadata(false, null));

        public bool IsDisplayPolyline
        {
            get { return (bool)(GetValue(IsDisplayPolylineProperty)); }
            set { SetValue(IsDisplayPolylineProperty, value); }
        }

        public static readonly DependencyProperty IsDisplayPolylineProperty = DependencyProperty.Register("IsDisplayPolyline", typeof(bool), typeof(Map), new UIPropertyMetadata(false, null));
        #endregion

        #region Event
        private void MainMap_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                System.Windows.Point p = e.GetPosition(this);
                CurrentPosition = this.FromLocalToLatLng((int)p.X, (int)p.Y);
                if (SetPositionMarker != null)
                {
                    SetPositionMarker.Position = CurrentPosition;
                }
            }
        }

        private void MainMap_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(this);
            CurrentPosition = this.FromLocalToLatLng((int)p.X, (int)p.Y);
            if (SetPositionMarker != null)
            {
                SetPositionMarker.Position = CurrentPosition;
            }
        }

        private void MainMap_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        private static void AddMarker(Map target)
        {
            ClearMarkers(target);

            if (target.Points != null)
            {
                foreach (PointLatLngImg p in target.Points)
                {
                    AddMarker(target, p, "Marker");
                }
            }
        }

        private static void AddMarker(Map map, PointLatLngImg iPoint, string tag)
        {
            GMapMarker m = new GMapMarker(iPoint.Point);
            {
                Placemark? p = null;
                //if (false)
                //{
                    GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
                    var plret = GMapProviders.GoogleMap.GetPlacemark(iPoint.Point, out status);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plret != null)
                    {
                        p = plret;
                    }
                //}
                //string ToolTipText;
                //if (p != null)
                //{
                //    ToolTipText = p.Value.Address;
                //}
                //else
                //{
                //    ToolTipText = currentMarker.Position.ToString();
                //}

                m.Shape = new CustomMarker(map, m, iPoint);
                m.ZIndex = 55;
                m.Tag = tag;
            }
            map.Markers.Add(m);
        }

        private static void SetRoute(Map target)
        {
            ClearMarkers(target);

            if (target.Points != null)
            {
                for (int i = 0; i < target.Points.Count - 1; i++)
                {
                    int j = i + 1;
                    if (j < target.Points.Count)
                    //for (int j = i+1; j < target.Points.Count; j++)
                    {
                        PointLatLngImg start = new PointLatLngImg()
                        {
                            Point = target.Points[i].Point,
                            Img = target.Points[i].Img
                        };
                        PointLatLngImg end = new PointLatLngImg()
                        {
                            Point = target.Points[j].Point,
                            Img = target.Points[j].Img
                        };

                        SetRoute(target, start, end);
                    }
                }
            }
        }
        private static void SetRoute(Map map, PointLatLngImg start, PointLatLngImg end)
        {
            RoutingProvider rp = map.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.OpenStreetMap;
            }

            MapRoute route = rp.GetRoute(start.Point, end.Point, false, false, (int)map.Zoom);
            if (route != null)
            {
                GMapMarker m1 = new GMapMarker(start.Point);
                m1.Shape = new CustomMarker(map, m1, start);
                m1.Tag = "Route";
                GMapMarker m2 = new GMapMarker(end.Point);
                m2.Shape = new CustomMarker(map, m2, end);
                m2.Tag = "Route";
                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                    mRoute.Tag = "Route";
                }
                map.Markers.Add(m1);
                map.Markers.Add(m2);
                map.Markers.Add(mRoute);

                map.ZoomAndCenterMarkers(null);
            }
        }
        private static void SetPolyline(Map target)
        {
            ClearMarkers(target);

            if (target.Points != null)
            {
                List<PointLatLng> list = new List<PointLatLng>();
                for (int i = 0; i < target.Points.Count; i++)
                {
                    AddMarker(target, target.Points[i], "Polyline");
                    list.Add(target.Points[i].Point);
                }

                GMapRoute mPolyline = new GMapRoute(list);
                {
                    mPolyline.ZIndex = -1;
                    mPolyline.Tag = "Polyline";
                }
                target.Markers.Add(mPolyline);
                target.ZoomAndCenterMarkers(null);
            }
        }

        private static void SetPolygon(Map target)
        {
            ClearMarkers(target);

            if (target.Points != null)
            {
                List<PointLatLng> list = new List<PointLatLng>();
                for (int i = 0; i < target.Points.Count; i++)
                {
                    AddMarker(target, target.Points[i], "Polygon");
                    list.Add(target.Points[i].Point);
                }

                GMapPolygon mPolygon = new GMapPolygon(list);
                {
                    mPolygon.ZIndex = -1;
                    mPolygon.Tag = "Polygon";
                }
                target.Markers.Add(mPolygon);
                target.ZoomAndCenterMarkers(null);
            }
        }

        private static void GetCurrentMarkers(Map map)
        {
            if (map.Markers != null && map.Markers.Count > 0)
            {
                foreach (var mark in map.Markers)
                {
                    if (mark.Position != map.CurrentPointLatLngImg.Point || mark.Shape == null) continue;
                    CustomMarker cust = (mark.Shape as CustomMarker);
                    if (cust == null) continue;
                    if (mark.Tag == null) continue;
                    if (mark.Tag.Equals("Marker"))
                    {
                        cust.icon.Source = map.CurrentPointLatLngImg.Img;
                    }
                    else if (mark.Tag.Equals("Route"))
                    {
                        cust.icon.Source = map.CurrentPointLatLngImg.Img;
                    }
                    else if (mark.Tag.Equals("Polygon"))
                    {
                        cust.icon.Source = map.CurrentPointLatLngImg.Img;
                    }
                    else if (mark.Tag.Equals("Polyline"))
                    {
                        cust.icon.Source = map.CurrentPointLatLngImg.Img;
                    }
                    currentMarker = mark;
                }
            }
        }

        private static void ClearMarkers(Map map)
        {
            var clear = map.Markers.Where(p => p != null && p != SetPositionMarker);
            if (clear != null)
            {
                for (int i = 0; i < clear.Count(); i++)
                {
                    map.Markers.Remove(clear.ElementAt(i));
                    i--;
                }
            }
        }
        #endregion


#if DEBUG
        /// <summary>
        /// any custom drawing here
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }
#endif
    }
}
