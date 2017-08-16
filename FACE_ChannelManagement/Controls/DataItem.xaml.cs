using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// DataItem.xaml 的交互逻辑
    /// </summary>
    public partial class DataItem : UserControl
    {
        public DataItem()
        {
            InitializeComponent();
            //this.DataContext = ItemContent;
        }

        //static DataItem()
        //{

        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(DataItem), new FrameworkPropertyMetadata(typeof(DataItem)));
        //}

        #region
        
        //public DataItemContent ItemContent
        //{
        //    get
        //    {
        //        return (DataItemContent)GetValue(ItemContentProperty);
        //    }
        //    set
        //    {
        //        SetValue(ItemContentProperty, value);
        //    }
        //}

        //// Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ItemContentProperty =
        //            DependencyProperty.Register("ItemSource", typeof(DataItemContent), typeof(DataItem));
        //DependencyProperty.Register("ItemContent", typeof(DataItemContent), typeof(DataItem), new UIPropertyMetadata(null, OnItemContentChanged));

        //private static void OnItemContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    DataItem item = d as DataItem;
        //    DataItemContent content = e.NewValue as DataItemContent;
        //    if (item != null && content != null)
        //    {
        //        item.LbDirect.Content = content.Direct;
        //        item.LbDomainName.Content = content.DomainName;
        //        item.LbChannelName.Content = content.ChannelName;
        //        item.ImgChannelShow.Source = content.ChannelShow;
        //        item.IcIsConnected.IsConnected = content.IsConnected;
        //    }
        //}


        public string ChannelName
        {
            get { return (string)GetValue(ChannelNameProperty); }
            set { SetValue(ChannelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChannelNameProperty =
            DependencyProperty.Register("ChannelName", typeof(string), typeof(DataItem), new PropertyMetadata(string.Empty));


        public bool IsConnected
        {
            get { return (bool)GetValue(IsConnectedProperty); }
            set { SetValue(IsConnectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register("IsConnected", typeof(bool), typeof(DataItem), new PropertyMetadata(false));


        public string RegionName
        {
            get { return (string)GetValue(RegionNameProperty); }
            set { SetValue(RegionNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DomainName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegionNameProperty =
            DependencyProperty.Register("RegionName", typeof(string), typeof(DataItem), new PropertyMetadata(string.Empty));



        public string ChannelDirect
        {
            get { return (string)GetValue(ChannelDirectProperty); }
            set { SetValue(ChannelDirectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChannelDirectProperty =
            DependencyProperty.Register("ChannelDirect", typeof(string), typeof(DataItem), new PropertyMetadata(string.Empty));


        public string Uuid
        {
            get { return (string)GetValue(UuidProperty); }
            set { SetValue(UuidProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Uuid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UuidProperty =
            DependencyProperty.Register("Uuid", typeof(string), typeof(DataItem), new PropertyMetadata(string.Empty));


        public ICommand UpdateConnected
        {
            get { return (ICommand)GetValue(UpdateConnectedProperty); }
            set { SetValue(UpdateConnectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateConnectedProperty =
            DependencyProperty.Register("UpdateConnected", typeof(ICommand), typeof(DataItem), new PropertyMetadata(null));


        public ICommand VideoViewExit
        {
            get { return (ICommand)GetValue(VideoViewExitProperty); }
            set { SetValue(VideoViewExitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VideoViewExit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VideoViewExitProperty =
            DependencyProperty.Register("VideoViewExit", typeof(ICommand), typeof(DataItem), new PropertyMetadata(null));


        #endregion

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
