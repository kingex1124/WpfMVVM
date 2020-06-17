using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfMVVM.CommonUtility
{
    public class WPFImageByte
    {
        public WPFImageByte()
        {
        }

        public byte[] WPFGetbyte(BitmapImage img)
        {
            byte[] array;
            try
            {
                if (img == null)
                {
                    array = null;
                }
                else
                {
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    MemoryStream ms = null;
                    try
                    {
                        try
                        {
                            ms = new MemoryStream();
                            encoder.Save(ms);
                            array = ms.ToArray();
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                    }
                    finally
                    {
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return array;
        }

        public BitmapImage WPFGetImage(byte[] byteData)
        {
            return this.WPFGetImage(byteData, null);
        }

        public BitmapImage WPFGetImage(byte[] byteData, string UriPath)
        {
            BitmapImage bitmapImage;
            try
            {
                BitmapImage bitImg = new BitmapImage();
                Convert.ToByte(null);
                if (!(byteData == null ? true : byteData[0] == 0))
                {
                    MemoryStream ms = null;
                    try
                    {
                        try
                        {
                            ms = new MemoryStream(byteData)
                            {
                                Position = (long)0
                            };
                            bitImg.BeginInit();
                            bitImg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            bitImg.CacheOption = BitmapCacheOption.OnLoad;
                            bitImg.UriSource = null;
                            bitImg.StreamSource = ms;
                            bitImg.EndInit();
                            bitmapImage = bitImg;
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                    }
                    finally
                    {
                        ms.Close();
                        ms.Dispose();
                    }
                }
                else if (string.IsNullOrEmpty(UriPath))
                {
                    bitImg.BeginInit();
                    bitImg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitImg.CacheOption = BitmapCacheOption.OnLoad;
                    bitImg.UriSource = new Uri("../../../NekomekoFramework/Tools/WPF/Images/NoImage.jpg", UriKind.Relative);
                    bitImg.EndInit();
                    bitmapImage = bitImg;
                }
                else
                {
                    bitImg.BeginInit();
                    bitImg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitImg.CacheOption = BitmapCacheOption.OnLoad;
                    bitImg.UriSource = new Uri(UriPath, UriKind.Relative);
                    bitImg.EndInit();
                    bitmapImage = bitImg;
                }
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return bitmapImage;
        }
    }
}
