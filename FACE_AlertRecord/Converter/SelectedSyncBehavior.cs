using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace FACE_AlertRecord.Converter
{


    // Behavior for synchronizing a RadDataGrid's SelectedItems collection with a SelectedItems collection of the ViewModel (the Network)
    // The problem is, that RadDataGrid.SelectedItems is a read-only collection and therefore cannot be used for two-way binding.

   public class SelectedSyncBehavior : Behavior<RadGridView>
    {
        bool _collectionChangedSuspended = false;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedItems.CollectionChanged += GridSelectedItems_CollectionChanged;
        }

        /// <summary>
        /// Getter/Setter for DependencyProperty, bound to the DataContext's SelectedItems ObservableCollection
        /// </summary>
        public INotifyCollectionChanged SelectedItems
        {
            get { return (INotifyCollectionChanged)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        /// <summary>
        /// Dependency Property "SelectedItems" is target of binding to DataContext's SelectedItems
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(INotifyCollectionChanged), typeof(SelectedSyncBehavior), new PropertyMetadata(OnSelectedItemsPropertyChanged));

        /// <summary>
        /// PropertyChanged handler for DependencyProperty "SelectedItems"
        /// </summary>
        private static void OnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            INotifyCollectionChanged collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                // Hook to the Network's SelectedItems
                collection.CollectionChanged += (target as SelectedSyncBehavior).ContextSelectedItems_CollectionChanged;
            }
        }

        /// <summary>
        /// Will be called, when the Network's SelectedItems collection changes
        /// </summary>
        void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_collectionChangedSuspended) return;    // Don't react recursively to CollectionChanged events

            _collectionChangedSuspended = true;

            // Select and unselect items in the grid
            if (e.NewItems != null)
                foreach (object item in e.NewItems)
                    AssociatedObject.SelectedItems.Add(item);

            if (e.OldItems != null)
                foreach (object item in e.OldItems)
                    AssociatedObject.SelectedItems.Remove(item);

            _collectionChangedSuspended = false;
        }

        /// <summary>
        /// Will be called when the GridView's SelectedItems collection changes
        /// </summary>
        void GridSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_collectionChangedSuspended) return;    // Don't react recursively to CollectionChanged events

            _collectionChangedSuspended = true;

            // Select and unselect items in the DataContext
            if (e.NewItems != null)
                foreach (object item in e.NewItems)
                    (SelectedItems as IList).Add(item);

            if (e.OldItems != null)
                foreach (object item in e.OldItems)
                    (SelectedItems as IList).Remove(item);

            _collectionChangedSuspended = false;
        }

    }
}


