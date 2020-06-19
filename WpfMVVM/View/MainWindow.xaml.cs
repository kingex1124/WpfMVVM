using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfMVVM.View
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Vm.ActionTest += ActionTest;
            Vm.ActionParameter += ActionParameter;
            Vm.FuncTest += FuncTest;
        }

        private bool FuncTest(string arg)
        {
            return false;
        }

        private void ActionParameter(string obj)
        {
            MessageBox.Show(obj);
        }

        private void ActionTest()
        {
            MessageBox.Show("ActionTest");
        }
    }
}
