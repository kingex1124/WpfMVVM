using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM.CommonUtility;
using WpfMVVM.Model;

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

        #region 屬性

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

        private bool _testRbtn = true;

        /// <summary>
        /// RadioBtn的變數
        /// </summary>
        public bool TestRbtn
        {
            get { return _testRbtn; }
            set
            {
                _testRbtn = value;

                //當值改變時會觸發事件
                this.NotifyPropertyChanged("TestRbtn");
            }
        }

        private bool _testRbtn2 { get; set; }

        /// <summary>
        /// RadioBtn的變數
        /// </summary>
        public bool TestRbtn2
        {
            get { return _testRbtn2; }
            set
            {
                _testRbtn2 = value;

                //當值改變時會觸發事件
                this.NotifyPropertyChanged("TestRbtn2");
            }
        }

        /// <summary>
        /// 選擇時所回傳資料的私有變數
        /// </summary>
        private TestGridData _selectedValue = null;

        /// <summary>
        /// 選擇時所回傳資料的變數
        /// </summary>
        public TestGridData SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;

                //當值改變時會觸發事件
                this.NotifyPropertyChanged("SelectedValue");
            }
        }

        /// <summary>
        /// 存取所有查尋回來資料用的集合
        /// </summary>
        private List<TestGridData> _dataList = new List<TestGridData>();

        /// <summary>
        /// 存取DataGride顯示用的資料
        /// </summary>
        private ObservableCollection<TestGridData> _dataListView = new ObservableCollection<TestGridData>();

        /// <summary>
        /// Binding顯示用資料的變數
        /// </summary>
        public ObservableCollection<TestGridData> DataData
        {
            get
            {
                if (_dataListView.Count == 0)
                    _dataListView = GetDataList(); //may call web API ..WCF

                return _dataListView;
            }
            set { _dataListView = value; }
        }

        #endregion

        private ObservableCollection<TestGridData> GetDataList()
        {
            List<TestGridData> list = new List<TestGridData>()
            {
                new TestGridData(){ AColumn = "Q" , BColumn = "W" , CColumn = "E"},
                new TestGridData(){ AColumn = "A" , BColumn = "S" , CColumn = "D"},
                new TestGridData(){ AColumn = "Z" , BColumn = "X" , CColumn = "C"},
                new TestGridData(){ AColumn = "R" , BColumn = "T" , CColumn = "Y"},
                new TestGridData(){ AColumn = "F" , BColumn = "G" , CColumn = "H"},
            };
            foreach (var item in list)
            {
                var tmp = new TestGridData() { };
                tmp.AColumn = item.AColumn;
                tmp.BColumn = item.BColumn;
                tmp.CColumn = item.CColumn;

                _dataListView.Add(tmp);
            }
            return _dataListView;
        }

        #region 事件
        public ICommand BtnTestCommand
        {
            get { return new RelayCommand(BtnTestCommandExecute, CanBtnTestCommand); }
        }

        /// <summary>
        /// 觸發BtnTest事件的方法
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

        /// <summary>
        /// 
        /// </summary>
        public ICommand ShowDataCommand
        {
            get { return new RelayCommand(ShowDataCommandExecute, CanShowDataCommand); }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowDataCommandExecute()
        {
            MessageBox.Show(SelectedValue.AColumn);
        }

        private bool CanShowDataCommand()
        {
            return true;
        }
        #endregion
    }
}
