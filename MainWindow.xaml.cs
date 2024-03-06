using System;
using System.Collections.Generic;
using System.IO;
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

using Microsoft.Win32;
using Path = System.IO.Path;


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

        // 要替换的字符串
        public string TargetString { get; set; }
        // 填充的字符串
        public string DestinationString { get; set; }

        public string DirectoryPath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        // 选择文件夹路径
        private void ChooseDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            string d_path = folderBrowserDialog.SelectedPath;
            this.directoryPathLabel.Content = d_path;
            this.DirectoryPath = d_path;
        }
        // 执行增量重命名操作
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //1. 读取文件列表
            if(string.IsNullOrEmpty(this.DirectoryPath))
            {
                MessageBox.Show("文件夹路径不能为空", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } else
            {
                // 开始读取目录下的文件

                // 检测 第一种规则是否存在

                if(string.IsNullOrEmpty(this.initNumTextBox.Text) == true || string.IsNullOrEmpty(this.incrementTextBox.Text) == true)
                {
                    MessageBox.Show("初始值和增量都必填", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                } else
                {
                    this.InitNum = int.Parse(this.initNumTextBox.Text);// 初始值
                    this.Increment = int.Parse(this.incrementTextBox.Text);// 增量

                    DirectoryInfo folder = new DirectoryInfo(this.DirectoryPath);
                    foreach(FileInfo item in folder.GetFiles())
                    {
                        string newName = item.DirectoryName + "\\" + $"{InitNum}" + $"{item.Extension}";
                        InitNum += Increment;
                        //Console.WriteLine($"旧文件名:{item.FullName}");
                        //Console.WriteLine($"新文件名:{newName}");
                        File.Move(item.FullName, newName);
                    }

                }
            }


        }
        // 字符串替换
        private void submitButton1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
