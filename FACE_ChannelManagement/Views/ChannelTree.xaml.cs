using FACE_ChannelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SING.Data.DAL.Data;

namespace FACE_ChannelManagement.UserControls
{
    /// <summary>
    /// Interaction logic for ChannelTreeControl.xaml
    /// </summary>
    public partial class ChannelTree : UserControl
    {
        public ChannelTree()
        {
            InitializeComponent();
        }

        #region  依赖属性
        public ObservableCollection<ChannelData> TreeSource
        {
            get { return (ObservableCollection<ChannelData>)GetValue(TreeSourceProperty); }
            set { SetValue(TreeSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TreeSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TreeSourceProperty =
            DependencyProperty.Register("TreeSource", typeof(ObservableCollection<ChannelData>), typeof(ChannelTree));

        public ChannelData CurrentItem
        {
            get { return (ChannelData)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof(ChannelData), typeof(ChannelTree));

        #endregion
    }
}
