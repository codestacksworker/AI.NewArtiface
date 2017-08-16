using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace SING.Data.Help
{
    public class ImageConvert
    {
        public static byte[] PathToBinaryStream(string path)
        {
            byte[] buffer = null;

            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                fs.Close();
            }
            catch (Exception ex)
            {
                buffer = null;
            }

            return buffer;
        }

        //public static ImageSource PathToImageSource(string path)
        //{
        //    ImageSource imageSource = null;

        //    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
        //    try
        //    {
        //        StreamResourceInfo streamResourceInfo = Application.GetResourceStream(new Uri(path, UriKind.Relative));

        //        imageSource = (ImageSource)imageSourceConverter.ConvertFrom(streamResourceInfo.Stream);
        //    }
        //    catch
        //    {
        //        imageSource = (ImageSource)imageSourceConverter.ConvertFrom(new Bitmap(20, 20));
        //    }

        //    return imageSource;
        //}

        public static Image BinaryStreamToImage(byte[] buffer)
        {
            Image img = null;
            try
            {
                MemoryStream ms = new MemoryStream(buffer);

                img = Image.FromStream(ms);
            }
            catch
            {
                img = null;
            }

            return img;
        }

        public static BitmapSource GetThumbImg(byte[] buffer)
        {
            using (Image drawingImage = Image.FromStream(new MemoryStream(buffer)))
            {
                using (Image thumbImage =
                drawingImage.GetThumbnailImage(100, 100, () => { return true; }, IntPtr.Zero))
                {
                    MemoryStream ms = new MemoryStream();
                    thumbImage.Save(ms, ImageFormat.Png);

                    BitmapFrame bf = BitmapFrame.Create(ms);
                    bf.Freeze();
                    return bf;
                }
            }
        }

        public static byte[] ImageToBinaryStream(Image img)
        {
            byte[] buffer = null;

            try
            {
                MemoryStream ms = new MemoryStream();

                ImageFormat format = img.RawFormat;

                if (format.Equals(ImageFormat.Jpeg))
                {
                    img.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    img.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    img.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    img.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    img.Save(ms, ImageFormat.Icon);
                }

                //ms.Position = 0;

                ms.Seek(0, SeekOrigin.Begin);

                ms.Read(buffer, 0, buffer.Length);

                ms.Close();
            }
            catch
            {
                buffer = null;
            }

            return buffer;
        }

        public static BitmapImage ByteArrayToBitmapImage(byte[] buffer)
        {
            BitmapImage bmp = null;

            try
            {
                bmp = new BitmapImage();

                bmp.CacheOption = BitmapCacheOption.OnLoad;

                bmp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;

                bmp.BeginInit();

                bmp.StreamSource = new MemoryStream(buffer);

                bmp.DecodePixelWidth = 100;

                bmp.EndInit();

                bmp.Freeze();
            }
            catch
            {
                bmp = null;
            }

            return bmp;
        }

        /// <summary>
        /// 生成指定图片的缩略图
        /// </summary>
        /// <param name="imgToResize">指定图片</param>
        /// <param name="size">缩略图大小</param>
        /// <returns></returns>
        public static Image ResizeImage(Image imgToResize, System.Drawing.Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public static byte[] BitmapImageToByteArray(BitmapImage bmp)
        {
            byte[] buffer = null;

            try
            {
                Stream sMarket = bmp.StreamSource;

                if (sMarket != null && sMarket.Length > 0)
                {
                    //很重要，因为Position经常位于Stream的末尾，导致下面读取到的长度为0。
                    sMarket.Position = 0;

                    using (BinaryReader br = new BinaryReader(sMarket))
                    {
                        buffer = br.ReadBytes((int)sMarket.Length);
                    }
                    bmp.Freeze();
                }
            }
            catch
            {
                buffer = null;
            }

            return buffer;
        }

        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;

            Image image = BinaryStreamToImage(buffer);

            ImageFormat format = image.RawFormat;

            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }

            System.IO.FileInfo info = new System.IO.FileInfo(file);

            System.IO.Directory.CreateDirectory(info.Directory.FullName);

            File.WriteAllBytes(file, buffer);

            return file;
        }

        #region  测试
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);
        public static BitmapSource BinaryToBitmapSource(byte[] data)
        {
            var ms = new System.IO.MemoryStream(data);
            var bmp = new Bitmap(ms);
            var source = ToBitmapSource(bmp);
            ms.Close();
            bmp.Dispose();
            return source;
        }

        private static BitmapSource ToBitmapSource(System.Drawing.Bitmap bmp)
        {
            try
            {
                var ptr = bmp.GetHbitmap();
                var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ptr);
                return source;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 从bitmap转换成ImageSource
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static ImageSource ChangeBitmapToImageSource(Bitmap bitmap)
        {
            //Bitmap bitmap = icon.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            if (!DeleteObject(hBitmap))
            {
                throw new System.ComponentModel.Win32Exception();
            }

            return wpfBitmap;
        }


        public static ImageSource PathToImageSource(string path)
        {
            Image img = Image.FromFile(path);
            Bitmap bmp = new Bitmap(img);
            return ChangeBitmapToImageSource(bmp);
        }
        #endregion
    }
}
