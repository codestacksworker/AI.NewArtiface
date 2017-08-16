using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FACE_ChannelManagement.Utilities
{
    public static class AttachedProperty
    {
        public static bool GetIsConnected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsConnectedProperty);
        }

        public static void SetIsConnected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsConnectedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.RegisterAttached("IsConnected", typeof(bool), typeof(AttachedProperty), new PropertyMetadata(false));

        public static Color GetIsMyColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(MyColorProperty);
        }

        public static void SetMyColor(DependencyObject obj, Color value)
        {
            obj.SetValue(MyColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsConnected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyColorProperty =
            DependencyProperty.RegisterAttached("MyColor", typeof(Color), typeof(AttachedProperty), new PropertyMetadata(Colors.White));



        public static bool GetIsInEdit(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsInEditProperty);
        }

        public static void SetIsInEdit(DependencyObject obj, bool value)
        {
            obj.SetValue(IsInEditProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsInEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInEditProperty =
            DependencyProperty.RegisterAttached("IsInEdit", typeof(bool), typeof(AttachedProperty), new PropertyMetadata(false));


    }
}
