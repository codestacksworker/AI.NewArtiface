using SING.Data.Help;
using System;
using System.Collections.Generic;
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

namespace SING.Data.Controls
{
    /// <summary>
    /// PictureIndicateControl.xaml 的交互逻辑
    /// </summary>
    public partial class PictureIndicateControl : UserControl
    {
        
        public object ImageData
        {
            get { return (object)GetValue(ImageDataProperty); }
            set { SetValue(ImageDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageDataProperty =
            DependencyProperty.Register("ImageData", typeof(object), typeof(PictureIndicateControl), new PropertyMetadata(null, ImageDataChanged));



        public Brush BrushIndicate
        {
            get { return (Brush)GetValue(BrushIndicateProperty); }
            set { SetValue(BrushIndicateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BrushIndicate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushIndicateProperty =
            DependencyProperty.Register("BrushIndicate", typeof(Brush), typeof(PictureIndicateControl), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255,247,216,216)),ValueChanged));



        public Brush BrushLine
        {
            get { return (Brush)GetValue(BrushLineProperty); }
            set { SetValue(BrushLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BrushLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushLineProperty =
            DependencyProperty.Register("BrushLine", typeof(Brush), typeof(PictureIndicateControl), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 247, 216, 216)),ValueChanged));




        public int IndicateWidth
        {
            get { return (int)GetValue(IndicateWidthProperty); }
            set { SetValue(IndicateWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicateWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndicateWidthProperty =
            DependencyProperty.Register("IndicateWidth", typeof(int), typeof(PictureIndicateControl), new PropertyMetadata(0, ValueChanged));



        public int IndicateHeight
        {
            get { return (int)GetValue(IndicateHeightProperty); }
            set { SetValue(IndicateHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicateHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndicateHeightProperty =
            DependencyProperty.Register("IndicateHeight", typeof(int), typeof(PictureIndicateControl), new PropertyMetadata(0, ValueChanged));




        public int IndicateLeft
        {
            get { return (int)GetValue(IndicateLeftProperty); }
            set { SetValue(IndicateLeftProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicateLeft.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndicateLeftProperty =
            DependencyProperty.Register("IndicateLeft", typeof(int), typeof(PictureIndicateControl), new PropertyMetadata(0, ValueChanged));



        public int IndicateTop
        {
            get { return (int)GetValue(IndicateTopProperty); }
            set { SetValue(IndicateTopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicateTop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndicateTopProperty =
            DependencyProperty.Register("IndicateTop", typeof(int), typeof(PictureIndicateControl), new PropertyMetadata(0, ValueChanged));




        public int LineThickness
        {
            get { return (int)GetValue(LineThicknessProperty); }
            set { SetValue(LineThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineThicknessProperty =
            DependencyProperty.Register("LineThickness", typeof(int), typeof(PictureIndicateControl), new PropertyMetadata(1, ValueChanged));




        public int IndicateThickness
        {
            get { return (int)GetValue(IndicateThicknessProperty); }
            set { SetValue(IndicateThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicateThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndicateThicknessProperty =
            DependencyProperty.Register("IndicateThickness", typeof(int), typeof(PictureIndicateControl), new PropertyMetadata(1, ValueChanged));


        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PictureIndicateControl)
            {
                (d as PictureIndicateControl).Redraw();
            }
        }
        private static void ImageDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PictureIndicateControl)
            {
                (d as PictureIndicateControl).SetImageData();
            }
        }


        private double controlWidth;
        private double controlHeight;
        public PictureIndicateControl()
        {
            InitializeComponent();
            this.SizeChanged += PictureIndicateControl_SizeChanged;
        }
        

        private void PictureIndicateControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            controlWidth = this.ActualWidth;
            controlHeight = this.ActualHeight;
            Redraw();
        }

        private void ImgBackground_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (controlWidth == double.NaN || controlHeight == double.NaN) return;

            this.imgBackground.SizeChanged -= ImgBackground_SizeChanged;
            imgScare = controlHeight / e.NewSize.Height;
            this.imgBackground.Height = controlHeight;
            this.imgBackground.Width = e.NewSize.Width*imgScare;
            this.imgBackground.Stretch = Stretch.UniformToFill;
            Redraw();
        }

        private void SetImageData()
        {
            if (ImageData != null && ImageData is byte[])
            {
                var data = ImageData as byte[];
                if (data.Length > 0)
                {
                    this.imgBackground.Source = ImageConvert.BinaryToBitmapSource(data);
                    this.imgBackground.SizeChanged += ImgBackground_SizeChanged;
                }
            }
        }

        double imgScare = 1.0;
        private void Redraw()
        {
            if (controlWidth == double.NaN || controlHeight == double.NaN) return;
            
            double sWidth, sHeight, sLeft, sTop;
            sWidth = this.IndicateWidth*imgScare;
            sHeight = this.IndicateHeight * imgScare;
            sLeft = this.IndicateLeft * imgScare;
            sTop = this.IndicateTop * imgScare;

            //设置颜色
            this.recIndicate.Stroke = this.BrushIndicate;
            this.recLineLeft.Fill = this.recLineRight.Fill = this.recLineTop.Fill = this.recLineBottom.Fill = this.BrushLine;

            //设置粗细
            if (IndicateWidth == 0 || IndicateHeight == 0)
            {
                this.recIndicate.StrokeThickness =0;
                this.recLineLeft.Height = this.recLineRight.Height = this.recLineTop.Width = this.recLineBottom.Width = 0;
            }
            else
            {
                this.recIndicate.StrokeThickness = this.IndicateThickness;
                this.recLineLeft.Height = this.recLineRight.Height = this.recLineTop.Width = this.recLineBottom.Width = this.LineThickness;
            }
            

            this.recIndicate.Width = sWidth;
            this.recIndicate.Height = sHeight;
            this.recLineLeft.Width = sLeft;
            var d1 = this.controlWidth - sLeft - sWidth;
            if (d1 < 0)
            {
                d1 = 0;
            }
            this.recLineRight.Width = d1;
            this.recLineTop.Height = sTop;
            var d2 = this.controlHeight - sTop - sHeight;
            if (d2 < 0)
            {
                d2 = 0;
            }
            this.recLineBottom.Height = d2;

            //设置位置
            Canvas.SetLeft(this.recIndicate, sLeft);
            Canvas.SetTop(this.recIndicate, sTop);

            Canvas.SetLeft(this.recLineLeft, 0);
            Canvas.SetTop(this.recLineLeft, sTop + sHeight / 2);

            Canvas.SetLeft(this.recLineRight, sLeft + sWidth);
            Canvas.SetTop(this.recLineRight, sTop + sHeight / 2);

            Canvas.SetLeft(this.recLineTop, sLeft + sWidth / 2);
            Canvas.SetTop(this.recLineTop,0);

            Canvas.SetLeft(this.recLineBottom, sLeft + sWidth / 2);
            Canvas.SetTop(this.recLineBottom, sTop + sHeight);

        }


     
    }
}
