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

namespace FACE_ChannelManagement.Controls
{
    /// <summary>
    /// IConStatus.xaml 的交互逻辑
    /// </summary>
    public partial class IConStatus : UserControl
    {
        public IConStatus()
        {
            InitializeComponent();
        }

        #region 连接状态调整
        public bool IsConnected
        {
            get
            {
                return (bool)GetValue(IsConnectedProperty);
            }
            set
            {
                SetValue(IsConnectedProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register("IsConnected", typeof(bool), typeof(IConStatus), new UIPropertyMetadata(false, OnIsConnectedChanged));

        private static void OnIsConnectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IConStatus item = d as IConStatus;
            bool value = (bool)e.NewValue;
            if (item != null)
            {
                item.PtIcon.Fill = value ? new SolidColorBrush(Colors.Green)
                    : new SolidColorBrush(Colors.Red);
            }
        }
        #endregion
    }
}
