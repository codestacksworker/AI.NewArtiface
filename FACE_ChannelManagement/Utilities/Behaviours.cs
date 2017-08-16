using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace FACE_ChannelManagement.Utilities
{
    public static class Behaviours
    {
        #region ExpandingBehaviour (Attached DependencyProperty)
        public static readonly DependencyProperty ExpandingBehaviourProperty =
            DependencyProperty.RegisterAttached("ExpandingBehaviour", typeof(ICommand), typeof(Behaviours),
                new PropertyMetadata(OnExpandingBehaviourChanged));
        public static void SetExpandingBehaviour(DependencyObject o, ICommand value)
        {
            o.SetValue(ExpandingBehaviourProperty, value);
        }
        public static ICommand GetExpandingBehaviour(DependencyObject o)
        {
            return (ICommand)o.GetValue(ExpandingBehaviourProperty);
        }
        private static void OnExpandingBehaviourChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //TreeViewItem tvi = d as TreeViewItem;
            RadTreeViewItem tvi = d as RadTreeViewItem;
            if (tvi != null)
            {
                ICommand ic = e.NewValue as ICommand;
                if (ic != null)
                {
                    tvi.Expanded += (s, a) =>
                    {
                        if (ic.CanExecute(a))
                        {
                            ic.Execute(a);

                        }
                        a.Handled = true;
                    };
                }
            }
        }
        #endregion
    }
}
