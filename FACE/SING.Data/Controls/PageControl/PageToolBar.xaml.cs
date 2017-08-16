using SING.Data.Help;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SING.Data.Controls.PageControl
{
    /// <summary>
    /// PageToolBar.xaml 的交互逻辑
    /// </summary>
    public partial class PageToolBar : UserControl
    {

        public PageToolBar()
        {
            InitializeComponent();
            
        }
        

        public IPageCondition DataSource
        {
            get { return (IPageCondition)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(IPageCondition), typeof(PageToolBar), new PropertyMetadata(null, DataSourceChanged));


        private static void DataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IPageCondition newValue= e.NewValue as IPageCondition;
            if (d is PageToolBar&& newValue!=null)
            {
                (d as PageToolBar).DataContext = newValue;
            }
        }


        public ICommand ChangePageCommand
        {
            get { return (ICommand)GetValue(ChangePageCommandProperty); }
            set { SetValue(ChangePageCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChangePageCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangePageCommandProperty =
            DependencyProperty.Register("ChangePageCommand", typeof(ICommand), typeof(PageToolBar), new PropertyMetadata(null, ChangePageCommandChanged));


        private static void ChangePageCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand newValue = e.NewValue as ICommand;
            if (d is PageToolBar && newValue != null)
            {
                (d as PageToolBar).btnPrevPage.Command = newValue;
                (d as PageToolBar).btnPrevPage.CommandParameter = "Up";
                (d as PageToolBar).btnNextPage.Command = newValue;
                (d as PageToolBar).btnNextPage.CommandParameter = "Down";
            }
        }

    }
}
