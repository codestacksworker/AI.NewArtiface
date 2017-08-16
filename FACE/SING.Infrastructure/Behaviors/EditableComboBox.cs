using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SING.Infrastructure.Behaviors
{
    public class EditableComboBox
    {
        public static int GetCharacterCasing(DependencyObject obj)
        {
            return (int)obj.GetValue(CharacterCasingProperty);
        }

        public static void SetCharacterCasing(DependencyObject obj, int value)
        {
            obj.SetValue(CharacterCasingProperty, value);
        }

        public static readonly DependencyProperty CharacterCasingProperty =
            DependencyProperty.RegisterAttached("CharacterCasing", typeof(int), typeof(EditableComboBox), new UIPropertyMetadata(OnCharacterCasingChanged));

        private static void OnCharacterCasingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = obj as Telerik.Windows.Controls.RadComboBox;

            if (comboBox == null)
            {
                return;
            }

            comboBox.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (DispatcherOperationCallback)delegate
            {
                var childrenCount = VisualTreeHelper.GetChildrenCount(comboBox);

                if (childrenCount > 0)
                {
                    var rootElement = VisualTreeHelper.GetChild(comboBox, 0) as FrameworkElement;
                    if (rootElement != null)
                        rootElement.SetValue(TextBox.CharacterCasingProperty, (CharacterCasing)e.NewValue);
                }

                return null;
            },null);
        }
    }
}
