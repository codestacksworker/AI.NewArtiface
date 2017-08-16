using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Input;
using FACE_ChannelManagement.ViewModels;

namespace FACE_ChannelManagement.UserControls
{
    /// <summary>
    /// Interaction logic for ChannelGridControl.xaml
    /// </summary>
    public partial class VideoList : UserControl
    {
        public VideoList()
        {
            InitializeComponent();            
        }

        //private void cameraList_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        int count = cameraList.SelectedItems.Count - 1;
        //        if (cameraList.SelectedItems.Count > 1)
        //        {
        //            for (int i = 0; i < count; i++)
        //            {
        //                cameraList.SelectedItems.RemoveAt(0);
        //            }
        //            ListView.SetIsSelected(cameraList, false);
        //        }
        //        else
        //        {
        //            ListView.SetIsSelected(cameraList, true);
        //            object obj = cameraList.SelectedItem;
        //            if (obj == null)
        //            {
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message;
        //    }
        //}
    }
}
