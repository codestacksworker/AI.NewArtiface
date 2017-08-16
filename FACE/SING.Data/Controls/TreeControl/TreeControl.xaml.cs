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
using SING.Data.Controls.TreeControl.Models;
using Telerik.Windows.Controls;

namespace SING.Data.Controls.TreeControl
{
    public partial class TreeControl : UserControl
    {
        public TreeControl()
        {
            InitializeComponent();
        }
 
        public TreeViewModel viewModel
        {
            get { return this.DataContext as TreeViewModel; }
            set { this.DataContext = value; }
        }

        private RadTreeViewItem ClickedTreeViewItem
        {
            get
            {
                return this.ContextMenu.GetClickedElement<RadTreeViewItem>();
            }
        }

        private DataItem CurrentDataItem;
        private void DropDownMenuOpened(object sender, RoutedEventArgs e)
        {
            RadDropDownButton item = sender as RadDropDownButton;

            if (item != null)
            {
                CurrentDataItem = item.DataContext as DataItem;
            }
        }
        private void ContextMenuOpened(object sender, RoutedEventArgs e)
        {
            if (this.ClickedTreeViewItem != null)
            {
                CurrentDataItem = this.ClickedTreeViewItem.DataContext as DataItem;

                // We will disable the "New Sibling" and "Delete" context menu 
                // items if the clicked treeview item is a root item
                bool isRootItem = CurrentDataItem.Parent == null;

                (this.ContextMenu.Items[1] as RadMenuItem).IsEnabled = !isRootItem; // New Sibling
                (this.ContextMenu.Items[4] as RadMenuItem).IsEnabled = !isRootItem; // Delete
            }
        }

        private void ContextMenuClick(object sender, RoutedEventArgs e)
        {
            if (CurrentDataItem == null) return;

            //DataItem item = this.ClickedTreeViewItem.DataContext as DataItem;
            DataItem item = CurrentDataItem;
            if (item == null) return;

            string header = (e.OriginalSource as RadMenuItem).Tag as string;
            switch (header)
            {
                case "New Child":
                    DataItem newChild = new DataItem();
                    newChild.Text = "New Child";
                    item.Items.Add(newChild);
                    item.IsExpanded = true; // Ensure that the new child is visible
                    break;
                case"New Chananel":
                    DataItem newChananel = new DataItem();
                    newChananel.Text = "New Chananel";
                    newChananel.MenuDropVisibility = Visibility.Collapsed;
                    item.Items.Add(newChananel);
                    item.IsExpanded = true;
                    break;
                case "New Sibling":
                    DataItem newSibling = new DataItem();
                    newSibling.Text = "New Sibling";
                    item.Parent.Items.Add(newSibling);
                    break;
                case "Delete":
                    item.Parent.Items.Remove(item);
                    break;
                case "Edit":
                    this.ClickedTreeViewItem.IsInEditMode = true;
                    break;
                case "Select":
                    this.ClickedTreeViewItem.IsSelected = true;
                    break;
            }
        }
    }
}
