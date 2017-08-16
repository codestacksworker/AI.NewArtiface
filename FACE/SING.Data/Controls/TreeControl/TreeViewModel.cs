using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.ViewModel;
using SING.Data.Controls.TreeControl.Models;

namespace SING.Data.Controls.TreeControl
{

    public class TreeViewModel: NotificationObject
    {
        private DataItemCollection items;

        public TreeViewModel()
        {
            this.items = new DataItemCollection(null);

            this.BeginLoadingItems();
        }

        public DataItemCollection Items
        {
            get
            {
                return this.items;
            }
        }


        private Visibility _menuVisibility = Visibility.Visible;

        public Visibility MenuVisibility
        {
            get
            {
                return this._menuVisibility;
            }
            set
            {
                if (this._menuVisibility != value)
                {
                    this._menuVisibility = value;
                    RaisePropertyChanged("MenuVisibility");
                }
            }
        }

        private void BeginLoadingItems()
        {
            // You can load the items from a web service
            this.ItemsLoaded();
        }

        private void ItemsLoaded()
        {
            DataItem root = new DataItem();
            root.Text = "北京";
            root.IsExpanded = true;

            DataItem deletedItems = new DataItem();
            root.Items.Add(deletedItems);
            deletedItems.Text = "朝阳";

            DataItem inbox = new DataItem();
            deletedItems.Items.Add(inbox);
            inbox.Text = "88-74";
            inbox.MenuDropVisibility = Visibility.Collapsed;

            DataItem folders = new DataItem();
            deletedItems.Items.Add(folders);
            folders.Text = "8874";
            folders.MenuDropVisibility = Visibility.Collapsed;

            DataItem junkEmails = new DataItem();
            root.Items.Add(junkEmails);
            junkEmails.Text = "天津";

            DataItem outbox = new DataItem();
            junkEmails.Items.Add(outbox);
            outbox.Text = "88-74";
            outbox.MenuDropVisibility = Visibility.Collapsed;

            DataItem sentItems = new DataItem();
            root.Items.Add(sentItems);
            sentItems.Text = "济南";

            DataItem search = new DataItem();
            root.Items.Add(search);
            search.Text = "上海";

            DataItem followup = new DataItem();
            search.Items.Add(followup);
            followup.Text = "88-73";
            followup.MenuDropVisibility = Visibility.Collapsed;

            DataItem largeMail = new DataItem();
            search.Items.Add(largeMail);
            largeMail.Text = "88-72";
            largeMail.MenuDropVisibility = Visibility.Collapsed;

            DataItem unreadMail = new DataItem();
            search.Items.Add(unreadMail);
            unreadMail.Text = "88-76";
            unreadMail.MenuDropVisibility = Visibility.Collapsed;

            this.Items.Add(root);
        }
    }
}
