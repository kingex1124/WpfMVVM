using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.CommonUtility
{
    /// <summary>
    /// 檔案類型
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// 圖片檔
        /// </summary>
        Image,
        /// <summary>
        /// Pdf格式
        /// </summary>
        Pdf,
        /// <summary>
        /// Word格式
        /// </summary>
        Word,
        /// <summary>
        /// Excel格式
        /// </summary>
        Excel,
        /// <summary>
        /// PowerPoint格式
        /// </summary>
        PowerPoint,
        /// <summary>
        /// 所有格式
        /// </summary>
        All,
        /// <summary>
        /// 自定義格式
        /// </summary>
        Def
    }
}
