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

namespace SING.Data.Controls.WaterMarkPrint
{
    /// <summary>
    /// WaterMarkPrintCTL.xaml 的交互逻辑
    /// </summary>
    public partial class WaterMarkPrintCTL : UserControl
    {
        public WaterMarkPrintCTL()
        {
            InitializeComponent();
        }

        #region  Dependcy Propertys


        public double Score
        {
            get { return (double)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Score.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(double), typeof(WaterMarkPrintCTL), new PropertyMetadata(0.0,OnScoreChangedCallback));

        private static void OnScoreChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null)
            {
                var self = d as WaterMarkPrintCTL;
                double value = 0.0;
                if (e.NewValue != null&&!string.IsNullOrEmpty(e.NewValue.ToString())&&double.TryParse(e.NewValue.ToString(),out value))
                {
                    self.lb_Text.Content = value;
                }
            }
        }

        public bool IsStandard
        {
            get { return (bool)GetValue(IsStandardProperty); }
            set { SetValue(IsStandardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsStandard.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStandardProperty =
            DependencyProperty.Register("IsStandard", typeof(bool), typeof(WaterMarkPrintCTL), new PropertyMetadata(false));

        #endregion
    }
}
