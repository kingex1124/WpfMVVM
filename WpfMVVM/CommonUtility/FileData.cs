using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfMVVM.CommonUtility
{
    /// <summary>
    /// OpenFile所開起來的檔案資料
    /// </summary>
    public class FileData
    {
        /// <summary>
        /// Bitmap資料
        /// </summary>
        public BitmapImage Bitmap { get; set; }

        /// <summary>
        /// 二進位資料
        /// </summary>
        public byte[] Binary { get; set; }

        /// <summary>
        /// 檔案名稱(不包含路徑)
        /// </summary>
        public string FileName { get; set; }
    }
}
