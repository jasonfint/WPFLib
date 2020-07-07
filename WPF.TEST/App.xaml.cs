using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using LanguageLocalizationHelper;

namespace WPF.TEST
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("qps-ploc");

            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            InitLanguage();
        }

        /// <summary>
        /// 国际化执行器
        /// </summary>

        public static LanguageHelper Lang { get; private set; }
        
        /// <summary>
        /// 初始化语言
        /// </summary>
        private void InitLanguage()
        {
            Lang = App.Current.Resources["language"] as LanguageHelper;
            //Lang.ChangeLanguage += Lang_ChangeLanguage;
            if (Lang == null)
            {
                Lang = new LanguageHelper();
                App.Current.Resources.Add("language", Lang);
            }
            string curLang = "zh-CN";
            Lang.SetLanguage(curLang);

        }

        private void Lang_ChangeLanguage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void ChangeLanguage(string name)
        {
            Lang.SetLanguage(name);
        }
    }
}
