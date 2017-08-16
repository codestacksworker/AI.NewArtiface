using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using SING.Data.Logger;
using Telerik.Windows.Controls;

namespace SING.Infrastructure
{
    public static class UIHelper
    {
        public static T TryFindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = GetParentObject(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                //use recursion to proceed with next level
                return TryFindParent<T>(parentObject);
            }
        }

        public static DependencyObject GetParentObject(this DependencyObject child)
        {
            if (child == null) return null;

            //handle content elements separately
            ContentElement contentElement = child as ContentElement;
            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null) return parent;

                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            //also try searching for parent in framework elements (such as DockPanel, etc)
            FrameworkElement frameworkElement = child as FrameworkElement;
            if (frameworkElement != null)
            {
                DependencyObject parent = frameworkElement.Parent;
                if (parent != null) return parent;
            }

            //if it's not a ContentElement/FrameworkElement, rely on VisualTreeHelper
            return VisualTreeHelper.GetParent(child);
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static T FindParent<T>(DependencyObject item, Type StopAt) where T : class
        {
            if (item is T)
            {
                return item as T;
            }
            else
            {
                DependencyObject _parent = VisualTreeHelper.GetParent(item);
                if (_parent == null)
                {
                    return default(T);
                }
                else
                {
                    Type _type = _parent.GetType();
                    if (StopAt != null)
                    {
                        if ((_type.IsSubclassOf(StopAt) == true) || (_type == StopAt))
                        {
                            return null;
                        }
                    }

                    if ((_type.IsSubclassOf(typeof(T)) == true) || (_type == typeof(T)))
                    {
                        return _parent as T;
                    }
                    else
                    {
                        return FindParent<T>(_parent, StopAt);
                    }
                }
            }
        }

        public static T FindChildOfType<T>(DependencyObject root) where T : class

        {

            var queue = new Queue<DependencyObject>();

            queue.Enqueue(root);




            while (queue.Count > 0)

            {

                DependencyObject current = queue.Dequeue();

                for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)

                {

                    var child = VisualTreeHelper.GetChild(current, i);

                    var typedChild = child as T;

                    if (typedChild != null)

                    {

                        return typedChild;

                    }

                    queue.Enqueue(child);

                }

            }

            return null;

        }

        public static List<T> FindAllChildOfType<T>(DependencyObject root) where T : class
        {
            var queue = new Queue<DependencyObject>();

            queue.Enqueue(root);

            List<T> allChild = new List<T>();

            while (queue.Count > 0)
            {
                DependencyObject current = queue.Dequeue();
                for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)
                {
                    var child = VisualTreeHelper.GetChild(current, i);

                    var typedChild = child as T;

                    if (typedChild != null)
                    {
                        allChild.Add(typedChild);
                    }

                    queue.Enqueue(child);
                }
            }
            return allChild;
        }

        public static List<T> GetVisualChildCollection<T>(object parent) where T : UIElement
        {
            List<T> visualCollection = new List<T>();

            GetVisualChildCollection(parent as DependencyObject, visualCollection);

            return visualCollection;
        }

        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : UIElement
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }

        public static void RefreshPopWindows()
        {
            var shellViewModel = Application.Current.MainWindow.DataContext;

            if (shellViewModel != null)
            {
                var property = shellViewModel.GetType().GetProperty("OpendRadWindows");
                if (property == null)
                {
                    throw new ArgumentNullException("property");
                }

                property.SetValue(shellViewModel, RadWindowManager.Current.GetWindows(), null);
            }
        }



        public static Window GetTopMostWindow()
        {
            Window Rewindow = null;
            try
            {
                Application.Current.Dispatcher.Invoke((Action) delegate
                {
                    foreach (Window window in Application.Current.Windows)
                    {

                        if (window.Topmost == true)
                        {
                            Rewindow = window;
                            try
                            {
                                IntPtr windowHandle = new WindowInteropHelper(Rewindow).Handle;
                                Logger.Info("获得窗口" + windowHandle.ToString());
                            }
                            catch (Exception ex)
                            {

                                Logger.Info("获得窗口出错 " + ex.InnerException.ToString());
                                Logger.Info("获得窗口" + Rewindow.ToString());
                            }


                            break;
                        }
                    }
                });
                Thread.Sleep(1000);
                if (Rewindow == null)
                {
                    Rewindow = Application.Current.MainWindow;

                    try
                    {
                        IntPtr windowHandle = new WindowInteropHelper(Rewindow).Handle;
                        Logger.Info("获得窗口" + windowHandle.ToString());
                    }
                    catch (Exception ex)
                    {

                        Logger.Info("获得窗口出错 " + ex.InnerException.ToString());
                        Logger.Info("获得窗口" + Rewindow.ToString());
                    }

                }
            }
            catch
            {
            }

            return Rewindow;
        }
    }
}
