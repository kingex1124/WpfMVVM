using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM.CommonUtility;

namespace WpfMVVM.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region 建構子

        /// <summary>
        /// 建構子
        /// </summary>
        public MainWindowViewModel()
        {

        }

        #endregion

        private string _labText = "LabTest";

        public string LabText
        {
            get { return _labText; }
            set
            {
                _labText = value;

                //當值改變時會觸發事件
                this.NotifyPropertyChanged("LabText");
            }
        }


        private string _tbText = string.Empty;

        public string TbText
        {
            get { return _tbText; }
            set
            {
                _tbText = value;

                //當值改變時會觸發事件
                this.NotifyPropertyChanged("TbText");
            }
        }
        public ICommand BtnTestCommand
        {
            get { return new RelayCommand(BtnTestCommandExecute, CanBtnTestCommand); }
        }

        /// <summary>
        /// 寫入圖檔用的物件
        /// </summary>
        List<FileData> _fd = new List<FileData>();

        /// <summary>
        /// 觸發OpenFile事件的方法
        /// </summary>
        private void BtnTestCommandExecute()
        {
            try
            {
                LabText = TbText;
            }
            catch (Exception ex)
            {
               
            }
        }

        [DebuggerStepThrough]
        private bool CanBtnTestCommand()
        {
            return true;
        }
    }
}
