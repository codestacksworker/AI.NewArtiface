﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using FACE_AlertRecord.ViewModels;
using SING.Infrastructure;
using Telerik.Windows.Controls;

namespace FACE_AlertRecord.Views
{
    /// <summary>
    /// CustomDateForm.xaml 的交互逻辑
    /// </summary>
    public partial class CustomDateForm : RadWindow
    {

        public CustomDateForm()
        {
            InitializeComponent();
        }

        public CustomDateForm(ViewModel viewModel):this()
        {
            this.Owner = Application.Current.MainWindow;
            this.viewModel = viewModel;
        }

        [Import(AllowRecomposition = false)]
        public ViewModel viewModel
        {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }

        public static bool FormIsOpen;

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FormIsOpen = true;
            UIHelper.RefreshPopWindows();
        }

        private void RadWindow_Closed(object sender, WindowClosedEventArgs e)
        {
            FormIsOpen = false;
            UIHelper.RefreshPopWindows();
        }

        private void RadWindow_Activated(object sender, EventArgs e)
        {
            UIHelper.RefreshPopWindows();
        }

        private void RadWindow_Deactivated(object sender, EventArgs e)
        {
            UIHelper.RefreshPopWindows();
        }
    }
}
