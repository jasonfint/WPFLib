using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace StreamWriterWPFDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count ++;
            //StreamWriter 写入
            StreamWriter writer = new StreamWriter($@"F:\test{count}.txt");//初始化写入           
            Stopwatch stopwatch = Stopwatch.StartNew();
            StringBuilder stringBuilder = new StringBuilder(500);
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("count:" + i +"时间：" +DateTime.Now.ToString("hh-mm-ss-ffffff"));
                writer.Write("1,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,10");
              
                writer.Write("1,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,10");
             
                writer.Write((2).ToString()+",");
                //writer.Write("COUNT,".Replace(",", ""));
                //writer.Write(3.ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("2,".ToString() + ",");
                //writer.Write("3,".ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("1,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,10");
                //writer.Write((2).ToString() + ",");
                //writer.Write(3.ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("2,".ToString() + ",");
                //writer.Write("3,".ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("1,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,10");
                //writer.Write((2).ToString() + ",");
                //writer.Write(3.ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("2,".ToString() + ",");
                //writer.Write("3,".ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("1,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,101,2,3,4,5,6,7,8,9,10");
                //writer.Write((2).ToString() + ",");
                //writer.Write(3.ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write("2,".ToString() + ",");
                //writer.Write("3,".ToString() + ",");
                //writer.Write("4,".ToString() + ",");
                //writer.Write("5,".ToString() + ",");
                //writer.Write("6,".ToString() + ",");
                //writer.Write("7,".ToString() + ",");
                //writer.Write("8,".ToString() + ",");
                //writer.Write("9,".ToString() + ",");
                //writer.Write("10,".ToString() + ",");
                //writer.Write("11,".ToString() + ",");
                //writer.Write("12,".ToString() + ",");
                //writer.Write("13,".ToString() + ",");
                //writer.Write("14,".ToString() + ",");
                //writer.Write("15,".ToString() + ",");
                //writer.Write("16,".ToString() + ",");
                //writer.Write("17,".ToString() + ",");
                //writer.Write("18,".ToString() + ",");
                //writer.Write("19,".ToString() + ",");
                //writer.Write("20,".ToString() + ",");
                //writer.Write($"{.ToString());count.ToString()}{ (1.000).ToString()}，");//写入一行   
                //stringBuilder.Append($"你好{count.ToString()}{ (1.000).ToString()}，");

                //writer.WriteLine();
                //stringBuilder.AppendLine();
                writer.WriteLine();//写入一行
            }
     
            writer.Flush();
            writer.Close();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}
