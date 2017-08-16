using System;
using System.Collections;
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
using SING.Data.DAL.Data;

namespace SING.Data.Controls
{
    /// <summary>
    /// PictureControls.xaml 的交互逻辑
    /// </summary>
    public partial class PictureControls : UserControl
    {
        public PictureControls()
        {
            InitializeComponent();
        }

        #region  Dependcy Property


        public IEnumerable<AlertData> ItemsCollection
        {
            get { return (IEnumerable<AlertData>)GetValue(ItemsCollectionProperty); }
            set { SetValue(ItemsCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsCollectionProperty =
            DependencyProperty.Register("ItemsCollection", typeof(IEnumerable<AlertData>), typeof(PictureControls), new PropertyMetadata(null, ItemsCollectionChanged));

        private static void ItemsCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PictureControls)
            {
                var pic = d as PictureControls;
                if (e.NewValue != null)
                {
                    pic.listBoxPic.ItemsSource = e.NewValue as IEnumerable<AlertData>;
                }
            }
        }



        public object CurrentPage
        {
            get { return (object)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(object), typeof(PictureControls), new PropertyMetadata(null, CurrentPageChanged));

        private static void CurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controls = d as PictureControls;
            if (controls != null)
            {
                if (e.NewValue != null)
                {
                    controls.listBoxPic.SelectedItem = e.NewValue;
                }
            }
        }

        #endregion

        private void listBoxPic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                var item = e.AddedItems as IList;
                if (item != null)
                    CurrentPage = item.Cast<AlertData>().FirstOrDefault();
            }
        }
    }
}
