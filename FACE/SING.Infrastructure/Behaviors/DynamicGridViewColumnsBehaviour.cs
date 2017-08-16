using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace SING.Infrastructure.Behaviors
{
    #region   DataGridColumns
    public class DataGridColumnsBindingBehaviour : Behavior<DataGrid>
    {
        public ObservableCollection<DataGridColumn> Columns
        {
            get { return (ObservableCollection<DataGridColumn>)base.GetValue(ColumnsProperty); }
            set { base.SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns", typeof(ObservableCollection<DataGridColumn>), typeof(DataGridColumnsBindingBehaviour), new PropertyMetadata(OnDataGridColumnsPropertyChanged));

        private static void OnDataGridColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var context = source as DataGridColumnsBindingBehaviour;

            var oldItems = e.OldValue as ObservableCollection<DataGridColumn>;

            if (oldItems != null)
            {
                foreach (var one in oldItems)
                {
                    context._datagridColumns.Remove(one);
                }
                    
                oldItems.CollectionChanged -= context.collectionChanged;
            }

            var newItems = e.NewValue as ObservableCollection<DataGridColumn>;

            if (newItems != null)
            {
                foreach (var one in newItems)
                {
                    context._datagridColumns.Add(one);
                }

                newItems.CollectionChanged += context.collectionChanged;
            }
        }

        private ObservableCollection<DataGridColumn> _datagridColumns;

        protected override void OnAttached()
        {
            base.OnAttached();

            this._datagridColumns = AssociatedObject.Columns;
        }


        private void collectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (DataGridColumn one in e.NewItems)
                        {
                            _datagridColumns.Add(one);
                        }
                    } 
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (DataGridColumn one in e.OldItems)
                        {
                            _datagridColumns.Remove(one);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    _datagridColumns.Move(e.OldStartingIndex, e.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    _datagridColumns.Clear();
                    if (e.NewItems != null)
                    {
                        foreach (DataGridColumn one in e.NewItems)
                        {
                            _datagridColumns.Add(one);
                            
                        }
                    }
                    break;
            }
        }
    }
    //View:
    // <DataGrid x:Name="_dataGrid">
    //    <DataGrid.Columns>
    //        <DataGridTextColumn Header = "Test" />
    //    </ DataGrid.Columns >
    //    < i:Interaction.Behaviors>
    //        <loc:ColumnsBindingBehaviour Columns = "{Binding DataGridColumns}" />
    //    </ i:Interaction.Behaviors>
    //</DataGrid>

    //viewmodel:
    //    private ObservableCollection<DataGridColumn> _dataGridColumns;
    //public ObservableCollection<DataGridColumn> DataGridColumns
    //{
    //    get
    //    {
    //        if (_dataGridColumns == null)
    //            _dataGridColumns = new ObservableCollection<DataGridColumn>()
    //             {
    //                 new DataGridTextColumn()
    //                 {
    //                     Header = "Column1"
    //                 }
    //             };

    //        return _dataGridColumns;
    //    }
    //    set
    //    {
    //        _dataGridColumns = value;
    //        OnPropertyChanged("DataGridColumns");
    //    }
    //}
    #endregion

    #region   GridViewColumns
    public class GridViewColumnsBindingBehaviour : Behavior<RadGridView>
    {
        public ObservableCollection<Telerik.Windows.Controls.GridViewColumn> Columns
        {
            get { return (ObservableCollection<Telerik.Windows.Controls.GridViewColumn>)base.GetValue(ColumnsProperty); }
            set { base.SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns",
            typeof(ObservableCollection<Telerik.Windows.Controls.GridViewColumn>), typeof(GridViewColumnsBindingBehaviour),
                new PropertyMetadata(OnDataGridColumnsPropertyChanged));

        private static void OnDataGridColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var context = source as GridViewColumnsBindingBehaviour;

            var oldItems = e.OldValue as ObservableCollection<Telerik.Windows.Controls.GridViewColumn>;

            if (oldItems != null)
            {
                foreach (var one in oldItems)
                    context._datagridColumns.Remove(one);

                oldItems.CollectionChanged -= context.collectionChanged;
            }

            var newItems = e.NewValue as ObservableCollection<Telerik.Windows.Controls.GridViewColumn>;

            if (newItems != null)
            {
                int index = context.StartColumnIndex;
                foreach (var one in newItems)
                {
                    one.CellTemplateSelector = new GridViewColumnCellTemplateSelector();
                    if (index < context._datagridColumns.Count - 1)
                        context._datagridColumns.Insert(index, one);
                    else
                        context._datagridColumns.Add(one);

                    index++;
                }

                newItems.CollectionChanged += context.collectionChanged;
            }
        }

        public int StartColumnIndex
        {
            get { return (int)GetValue(StartColumnIndexProperty); }
            set { SetValue(StartColumnIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartColumnIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartColumnIndexProperty =
            DependencyProperty.Register("StartColumnIndex", typeof(int), typeof(GridViewColumnsBindingBehaviour), new PropertyMetadata(0));



        private ObservableCollection<Telerik.Windows.Controls.GridViewColumn> _datagridColumns;

        protected override void OnAttached()
        {
            base.OnAttached();

            this._datagridColumns = AssociatedObject.Columns;
        }

        private void collectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            int index = StartColumnIndex;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                        foreach (Telerik.Windows.Controls.GridViewColumn one in e.NewItems)
                        {
                            one.CellTemplateSelector = new GridViewColumnCellTemplateSelector();

                            if (index <= _datagridColumns.Count - 1)
                                _datagridColumns.Insert(index++, one);
                            else
                                _datagridColumns.Add(one);
                        }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                        foreach (Telerik.Windows.Controls.GridViewColumn one in e.OldItems)
                            _datagridColumns.Remove(one);
                    break;

                case NotifyCollectionChangedAction.Move:
                    _datagridColumns.Move(e.OldStartingIndex, e.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    _datagridColumns.Clear();
                    if (e.NewItems != null)
                        foreach (Telerik.Windows.Controls.GridViewColumn one in e.NewItems)
                            _datagridColumns.Add(one);
                    break;
            }
        }
    }
    #endregion
}
