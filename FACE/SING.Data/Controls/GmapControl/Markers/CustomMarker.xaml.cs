using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET.WindowsPresentation;
using SING.Data.Controls.GmapControl.Models;

namespace SING.Data.Controls.GmapControl.Markers
{
    public partial class CustomMarker : UserControl, INotifyPropertyChanged
    {
        private Map _map;
        private GMapMarker _marker;
        private PointLatLngImg _ipoint;

        public virtual PointLatLngImg IPoint
        {
            get
            {
                return _ipoint;
            }
            set
            {
                this._ipoint = value;
                OnPropertyChanged("IPoint");
            }
        }

        public CustomMarker(Map map, GMapMarker marker, ImageSource img)
        {
            InitializeComponent();
            this._map = map;
            this._marker = marker;
            icon.Source = img;
            icon.Visibility = Visibility;
            IPoint = new PointLatLngImg();
            DataContext = this;
            this.Unloaded += new RoutedEventHandler(CustomMarker_Unloaded);
            this.Loaded += new RoutedEventHandler(CustomMarker_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(CustomMarker_SizeChanged);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseMove += new MouseEventHandler(CustomMarker_MouseMove);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarker_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarker_MouseLeftButtonDown);
        }

        public CustomMarker(Map map, GMapMarker marker, PointLatLngImg ipoint)
        {
            InitializeComponent();
            this._map = map;
            this._marker = marker;
            this.IPoint = ipoint;
            DataContext = this;
            this.Unloaded += new RoutedEventHandler(CustomMarker_Unloaded);
            this.Loaded += new RoutedEventHandler(CustomMarker_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(CustomMarker_SizeChanged);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseMove += new MouseEventHandler(CustomMarker_MouseMove);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarker_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarker_MouseLeftButtonDown);
        }

        private void CustomMarker_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= new RoutedEventHandler(CustomMarker_Unloaded);
            this.Loaded -= new RoutedEventHandler(CustomMarker_Loaded);
            this.SizeChanged -= new SizeChangedEventHandler(CustomMarker_SizeChanged);
            this.MouseEnter -= new MouseEventHandler(MarkerControl_MouseEnter);
            this.MouseLeave -= new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseMove -= new MouseEventHandler(CustomMarker_MouseMove);
            this.MouseLeftButtonUp -= new MouseButtonEventHandler(CustomMarker_MouseLeftButtonUp);
            this.MouseLeftButtonDown -= new MouseButtonEventHandler(CustomMarker_MouseLeftButtonDown);

            _marker.Shape = null;
            icon.Source = null;
            icon = null;
        }

        private void CustomMarker_Loaded(object sender, RoutedEventArgs e)
        {
            if (icon.Source != null && icon.Source.CanFreeze)
            {
                icon.Source.Freeze();
            }
        }
        private void CustomMarker_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _marker.Offset = new Point(-e.NewSize.Width / 2, -e.NewSize.Height);
        }

        private void CustomMarker_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                Point p = e.GetPosition(_map);
                _marker.Position = _map.FromLocalToLatLng((int)p.X, (int)p.Y);
            }
        }
        private void CustomMarker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                Mouse.Capture(null);

                _map.CurrentPointLatLngImg = IPoint;
            }
        }

        private void CustomMarker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Mouse.Capture(null);
                _map.CurrentPointLatLngImg = IPoint;
            }
        }

        private void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
        {
            _marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        private void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            _marker.ZIndex += 10000;
            Popup.IsOpen = true;
        }

        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
