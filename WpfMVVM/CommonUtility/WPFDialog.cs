using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;
using System.Data;
using System.IO;

namespace WpfMVVM.CommonUtility
{
    public class WPFDialog
    {

        #region 變數區

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string selectedFileName { get; set; }

        /// <summary>
        /// 檔案路徑
        /// </summary>
        public string selectedFilePath { get; set; }

        /// <summary>
        /// OpenFile過濾的副檔名
        /// </summary>
        public string _openFileType { get; set; }

        /// <summary>
        /// SaveFile過濾的副檔名
        /// </summary>
        public string _saveFileType { get; set; }

        #endregion

        #region 建構子

        /// <summary>
        /// 空參數的建構子
        /// 預設歸零檔案名稱、檔案路徑
        /// </summary>
        public WPFDialog()
        {
            this.selectedFilePath = null;
            this.selectedFileName = null;
        }

        #endregion

        #region 過濾副檔名的方法

        /// <summary>
        /// 設定OpenFile的FileType
        /// </summary>
        /// <param name="_Filter"></param>
        /// <returns></returns>
        private string OpenSelectFilter(FilterType _Filter)
        {

            switch (_Filter)
            {
                case FilterType.Image:
                    {
                        _openFileType = "*.bmp; *.jpg; *.gif; | *.bmp; *.jpg; *.gif; | *.jpg | *.jpg; | *.gif | *.gif; | *.bmp | *.bmp; | All files(*.*) | *.*";
                        break;
                    }
                case FilterType.Pdf:
                    {
                        _openFileType = "*.pdf|*.pdf|All files(*.*)|*.*";
                        break;
                    }
                case FilterType.Word:
                    {
                        _openFileType = "*.docx|*.docx;|*.docm|*.docm;|*.dotx|*.dotx;|*.dotm|*.dotm;|All files(*.*)|*.*";
                        break;
                    }
                case FilterType.Excel:
                    {
                        _openFileType = "*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|All files(*.*)|*.*";
                        break;
                    }
                case FilterType.PowerPoint:
                    {
                        _openFileType = "*.pptx|*.pptx;|*.pptm|*.pptm;|*.potx|*.potx;|*.potm|*.potm;|*.ppam|*.ppam;|*.ppsx|*.ppsx;|*.ppsm|*.ppsm;|All files(*.*)|*.*";
                        break;
                    }
                case FilterType.All:
                    {
                        _openFileType = "All files(*.*)|*.*|*.pdf|*.pdf;|*.docx|*.docx;|*.docm|*.docm;|*.dotx|*.dotx;|*.dotm|*.dotm;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.pptx|*.pptx;|*.pptm|*.pptm;|*.potx|*.potx;|*.potm|*.potm;|*.ppam|*.ppam;|*.ppsx|*.ppsx;|*.ppsm|*.ppsm;";
                        break;
                    }
                case FilterType.Def:
                    {
                        _openFileType = _openFileType;
                        break;
                    }
                default:
                    {
                        _openFileType = "All files(*.*)|*.*|*.pdf|*.pdf;|*.docx|*.docx;|*.docm|*.docm;|*.dotx|*.dotx;|*.dotm|*.dotm;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.pptx|*.pptx;|*.pptm|*.pptm;|*.potx|*.potx;|*.potm|*.potm;|*.ppam|*.ppam;|*.ppsx|*.ppsx;|*.ppsm|*.ppsm;";
                        break;
                    }
            }
            return _openFileType;
        }

        /// <summary>
        /// 設定SaveFile的FileType
        /// </summary>
        /// <param name="_Filter"></param>
        /// <returns></returns>
        private string SaveSelectFilter(FilterType _Filter)
        {
            switch (_Filter)
            {
                case FilterType.Image:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.bmp; *.jpg; *.gif | *.bmp; *.jpg; *.gif; | *.jpg | *.jpg; | *.gif | *.gif; | *.bmp | *.bmp;";
                        break;
                    }
                case FilterType.Pdf:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.pdf|*.pdf";
                        break;
                    }
                case FilterType.Word:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.docx;*.docm;*.dotx;*.dotm;|*.docx;*.docm;*.dotx;*.dotm;|*.docx|*.docx;|*.docm|*.docm;|*.dotx|*.dotx;|*.dotm|*.dotm;";
                        break;
                    }
                case FilterType.Excel:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.xlsx;*.xlsm;*.xltx;*.xltm;*.xlam;|*.xlsx;*.xlsm;*.xltx;*.xltm;*.xlam;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;";
                        break;
                    }
                case FilterType.PowerPoint:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.pptx;*.pptm;*.potx;*.potm;*.ppam;*.ppsx;*.ppsm;|*.pptx;*.pptm;*.potx;*.potm;*.ppam;*.ppsx;*.ppsm;|*.pptx|*.pptx;|*.pptm|*.pptm;|*.potx|*.potx;|*.potm|*.potm;|*.ppam|*.ppam;|*.ppsx|*.ppsx;|*.ppsm|*.ppsm;";
                        break;
                    }
                case FilterType.All:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.pdf|*.pdf;|*.docx|*.docx;|*.docm|*.docm;|*.dotx|*.dotx;|*.dotm|*.dotm;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.pptx|*.pptx;|*.pptm|*.pptm;|*.potx|*.potx;|*.potm|*.potm;|*.ppam|*.ppam;|*.ppsx|*.ppsx;|*.ppsm|*.ppsm;";
                        break;
                    }
                case FilterType.Def:
                    {
                        _saveFileType = _saveFileType;
                        break;
                    }
                default:
                    {
                        _saveFileType = "All files(*.*)|*.*|*.pdf|*.pdf;|*.docx|*.docx;|*.docm|*.docm;|*.dotx|*.dotx;|*.dotm|*.dotm;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.xlsx|*.xlsx;|*.xlsm|*.xlsm;|*.xltx|*.xltx;|*.xltm|*.xltm;|*.xlam|*.xlam;|*.pptx|*.pptx;|*.pptm|*.pptm;|*.potx|*.potx;|*.potm|*.potm;|*.ppam|*.ppam;|*.ppsx|*.ppsx;|*.ppsm|*.ppsm;";
                        break;
                    }
            }
            return _saveFileType;
        }

        #endregion

        /// <summary>
        /// 透過檔案路徑fileName取得BitmapImage物件
        /// </summary>
        /// <param name="fileName">檔案路徑</param>
        /// <returns>BitmapImage物件</returns>
        internal BitmapImage FileNameToBitmapImage(string fileName)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fileName, UriKind.Relative);
            bitmap.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }

        /// <summary>
        /// OpenFile 把資料轉成二進為存入集合
        /// </summary>
        /// <param name="Filter">過濾的型別(自定義選Def,直接set _openFileType)</param>
        /// <param name="multiselect">是否可以複數選檔案</param>
        /// <returns>FileData集合</returns>
        public List<FileData> OpFileByDocToByte(FilterType Filter, bool multiselect)
        {
            List<FileData> result = new List<FileData>();

            List<byte[]> ByteList = new List<byte[]>();

            OpenFileDialog dlg = new OpenFileDialog();

            //設置是否可以複數選檔案
            if (!multiselect)
            {
                dlg.Multiselect = false;
            }
            else
            {
                dlg.Multiselect = true;
            }

            //設置過濾的副檔名
            dlg.Filter = this.OpenSelectFilter(Filter);

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                FileData _fd = new FileData();

                _fd.Bitmap = this.FileNameToBitmapImage("Images/NoImage.jpg");

                result.Add(_fd);
            }
            else
            {
                this.selectedFilePath = dlg.FileName;

                dlg.InitialDirectory = this.selectedFilePath;

                for (int i = 0; i < dlg.FileNames.Count<string>(); i++)
                {


                    FileData _fd = new FileData();

                    string[] _ex = dlg.SafeFileNames[i].Split('.');

                    _fd.FileName = dlg.SafeFileNames[i];

                    //非圖檔時，顯示pdf提示圖片
                    if (_ex[1] != "jpg")
                    {
                        _fd.Bitmap = this.FileNameToBitmapImage("Images/pdf.png");
                    }
                    else
                    {
                        _fd.Bitmap = this.FileNameToBitmapImage(dlg.FileNames[i]);

                    }
                    _fd.Binary = BinaryUtil.BinaryReadToEnd(new FileStream(dlg.FileNames[i], FileMode.Open, FileAccess.Read));

                    //另一種讀法，效能如何以後在測試
                    //_fd.Binary = File.ReadAllBytes(dlg.FileNames[i]);

                    result.Add(_fd);
                }
            }
            return result;
        }

        /// <summary>
        /// 開啟圖檔的OpenFile
        /// 使用此方法不使用預設圖片(取消選圖的時候)
        /// </summary>
        /// <param name="multiselect">是否可以複選檔案</param>
        /// <returns></returns>
        public List<FileData> OpFileByImage(bool multiselect)
        {
            return this.OpFileByImage(null, false, multiselect);
        }

        /// <summary>
        /// 開啟圖檔的OpenFile
        /// </summary>
        /// <param name="CancleImagePath">取消時所使用的圖片(Null的話跑預設圖檔)</param>
        /// <param name="multiselect">是否可以複選檔案</param>
        /// <returns></returns>
        public List<FileData> OpFileByImage(string CancleImagePath, bool multiselect)
        {
            return this.OpFileByImage(CancleImagePath, true, multiselect);
        }

        /// <summary>
        /// 開啟圖檔的OpenFile
        /// </summary>
        /// <param name="CancleImagePath">取消時所使用的圖片(Null的話跑預設圖檔)</param>
        /// <param name="IsHasNullImage">是否啟用無選圖時，給一張NoImage圖片</param>
        /// <param name="multiselect">是否可以複選檔案</param>
        /// <returns>回傳圖片資料集合</returns>
        private List<FileData> OpFileByImage(string CancleImagePath, bool IsHasNullImage, bool multiselect)
        {
            List<FileData> result = new List<FileData>();

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                //判斷是否要多選檔案
                if (!multiselect)
                {
                    dlg.Multiselect = false;
                }
                else
                {
                    dlg.Multiselect = true;
                }

                BitmapImage bitmap = new BitmapImage();

                dlg.Filter = OpenSelectFilter(FilterType.Image);
                dlg.Title = "選取圖片";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.selectedFilePath = dlg.FileName;

                    this.selectedFileName = dlg.SafeFileName;

                    for (int i = 0; i < dlg.FileNames.Count<string>(); i++)
                    {
                        bitmap = this.FileNameToBitmapImage(dlg.FileNames[i]);

                        FileData _fd = new FileData();

                        _fd.FileName = dlg.SafeFileNames[i];

                        _fd.Bitmap = this.FileNameToBitmapImage(dlg.FileNames[i]);

                        _fd.Binary = BinaryUtil.BinaryReadToEnd(new FileStream(dlg.FileNames[i], FileMode.Open, FileAccess.Read));

                        result.Add(_fd);
                    }
                    dlg.InitialDirectory = this.selectedFilePath;
                }
                else if (!IsHasNullImage)
                {
                    FileData _fd = new FileData();

                    _fd.Bitmap = null;

                    result.Add(_fd);

                    this.selectedFilePath = null;
                    this.selectedFileName = null;
                }
                else
                {
                    if (string.IsNullOrEmpty(CancleImagePath))
                    {
                        FileData _fd = new FileData();

                        _fd.Bitmap = this.FileNameToBitmapImage("../../../KevanFramework/WPF/Images/NoImage.jpg");

                        result.Add(_fd);

                        this.selectedFilePath = null;
                        this.selectedFileName = "NoImage";
                    }
                    else
                    {
                        FileData _fd = new FileData();

                        _fd.Bitmap = this.FileNameToBitmapImage(CancleImagePath);

                        result.Add(_fd);

                        this.selectedFilePath = null;
                        this.selectedFileName = null;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        /// <summary>
        /// 傳入二進位資料、檔案名稱(包含附檔名)、選擇檔案Type，把資料寫入PC中
        /// </summary>
        /// <param name="DocData">二進位資料</param>
        /// <param name="FileName">檔案名稱</param>
        /// <param name="Filter">過濾的資料(存儲時所看到PC的資料)</param>
        public void SaveFileByDocToPC(byte[] DocData, string FileName, FilterType Filter)
        {
            try
            {
                SaveFileDialog Savedlg = new SaveFileDialog();

                byte[] DataByte = DocData;
                Savedlg.Filter = this.SaveSelectFilter(Filter);

                Savedlg.FileName = FileName;

                if (Savedlg.ShowDialog() == DialogResult.OK)
                {
                    this.selectedFilePath = Savedlg.FileName;
                    Savedlg.InitialDirectory = this.selectedFilePath;
                    File.WriteAllBytes(Savedlg.FileName, DataByte);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
