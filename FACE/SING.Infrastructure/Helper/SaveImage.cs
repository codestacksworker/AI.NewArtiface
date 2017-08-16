using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SING.Data.Help;
using SING.Data.Logger;
using SING.Data.BaseTools;

namespace SING.Infrastructure.Helper
{
    public class SaveImage
    {
        public static void Action(string fileName, byte[] imgBuffer)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();

                sfd.Title = "请保存抓拍照片";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfd.Filter = "jpg|*.jpg|bmp|*.bmp|png|*.png|gif|*gif|icon|*icon";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.ValidateNames = true;
                sfd.AddExtension = true;
                sfd.FileName = !string.IsNullOrEmpty(fileName) ? fileName: string.Format(@"{0}", DateTime.Now.ToString("yyyyMMddhhmmss"));
                sfd.DefaultExt = "png";
                sfd.CheckPathExists = true;

                if (sfd.ShowDialog() == true)
                {
                    fileName = sfd.FileName;

                    bool isSave = true;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string fileNameExt = fileName.Substring(fileName.LastIndexOf(".") + 1);
                        //string FilePath = fileName.Substring(0, fileName.LastIndexOf("\\"));
                        //string newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                        ImageFormat imgformat = null;

                        if (!string.IsNullOrEmpty(fileNameExt))
                        {
                            switch (fileNameExt)
                            {
                                case "jpg":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                    break;
                                case "png":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                    break;
                                case "bmp":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                    break;
                                case "gif":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                                    break;
                                case "icon":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Icon;
                                    break;
                                default:
                                    MessageBoxHelper.Show("只能存取为: jpg,bmp,gif,png,icon 格式");
                                    isSave = false;
                                    break;
                            }

                        }
                        if (imgformat == null)
                        {
                            imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        }

                        if (isSave)
                        {
                            try
                            {
                                //System.IO.FileInfo info = new System.IO.FileInfo(fileName);
                                //if (info.Directory != null) System.IO.Directory.CreateDirectory(info.Directory.FullName);
                                //File.WriteAllBytes(fileName, FaceCaptureData.FcapObjImg);

                                Image img = ImageConvert.BinaryStreamToImage(imgBuffer);

                                if (img != null)
                                {
                                    img.Save(sfd.FileName);
                                    MessageBoxHelper.Show("保存成功！", "提示", MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Information);
                                }
                                
                            }
                            catch
                            {
                                MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("保存失败！", "提示", MessageBoxImage.Warning);
                Logger.Error("【Error】：保存图片异常！【SaveImage】-->【函数名】：Action", ex);
            }
        }
    }
}
