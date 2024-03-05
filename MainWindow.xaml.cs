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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 文件批量重命名
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 初始值
        public int InitNum { get; set; }
        // 递增量
        public int Increment { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            string d_path = folderBrowserDialog.SelectedPath;
            this.directoryPathLabel.Content = d_path;
            Console.WriteLine(d_path);
        }

    }
}
