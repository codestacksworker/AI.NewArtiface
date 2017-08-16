using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SING.Data.BaseTools
{
    public static class MessageBoxHelper
    {
        public static void Show(string message, string title="提示", MessageBoxImage icon = MessageBoxImage.Error)
        {
            MessageBox.Show(Application.Current.MainWindow,message, title, MessageBoxButton.OK, icon);
        }

        public static MessageBoxResult confirm(string message, string title = "提示", MessageBoxImage icon = MessageBoxImage.Question)
        {
            return MessageBox.Show(Application.Current.MainWindow,message, title, MessageBoxButton.YesNo, icon);
        }

        public static bool ConfirmMessage(string message)
        {
            return confirm(message) == MessageBoxResult.Yes;
        }

    }
}
