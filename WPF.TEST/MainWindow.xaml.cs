using LanguageLocalizationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF.TEST
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        LanguageHelper languageResource = new LanguageHelper();
        public MainWindow()
        {
            InitializeComponent();
            //tbxEnglish.SetResourceReference(TextBox.TextProperty, "x:Static properties:Resources.FIVE");
            //Binding bindEnglish = new Binding("{ x:Static properties:Resources.FIVE}");




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("这是测试按钮");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");
            TextBox tbxEnglish = new TextBox();
            SP.Children.Add(tbxEnglish);
            //tbxEnglish.Background = new RadialGradientBrush(Colors.Red, Colors.Transparent);
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding();
            binding.Source = System.Windows.Application.Current.FindResource("language"); ;
            binding.Path = new PropertyPath("LanguageResource[BorbidAppType]");
            binding.Mode = BindingMode.OneWay;
            tbxEnglish.SetBinding(TextBox.TextProperty, binding);


        }

        private string lang = "zh-CN";
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (lang == "zh-CN")
            {
                lang = "en-US";
            }
            else
            {
                lang = "zh-CN";
            }
            App.ChangeLanguage(lang);
        }

        private void Code_Click(object sender, RoutedEventArgs e)
        {
         MessageBox.Show(   LanguageHelper.Instance.GetValue("BorbidAppType"));
        }
    }
}
