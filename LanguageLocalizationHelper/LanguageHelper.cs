using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageLocalizationHelper
{
    /// <summary>
    /// 多语言管理器
    /// </summary>
    public class LanguageHelper : INotifyPropertyChanged
    {


        #region Singleton

        private static LanguageHelper _instance;

        public static LanguageHelper Instance => _instance ?? (_instance = new LanguageHelper());

        #endregion

        private  ObservableResources languageResource = new ObservableResources();
        /// <summary>
        /// 刷新器
        /// </summary>
        public  ObservableResources LanguageResource
        {
            get { return languageResource; }
            set { languageResource = value; }
        }

        /// <summary>
        /// 当前语言
        /// </summary>
        public string CurrentLanguage
        {
            get
            {
                return Language.CultureName;
            }
        }

        private Language language;

        public Language Language
        {
            get { return language; }
            set
            {
                language = value;
                OnPropertyChanged("Language");
            }
        }

        /// <summary>
        /// 设置语言类型
        /// </summary>
        /// <param name="type"></param>
        public  void SetLanguage(string name)
        {
            try
            {
                if (Languages.ContainsKey(name))
                {
                    Language lang = Languages[name];
                    CultureInfo culture = new CultureInfo(lang.Name);//可能会出错，这里做异常捕获
                    if (culture != null)
                    {
                        Thread.CurrentThread.CurrentCulture = culture;
                        Thread.CurrentThread.CurrentUICulture = culture;
                        LanguageResource.Update();
                        if (ChangeLanguage != null)
                        {
                            ChangeLanguage(lang.CultureName, null);
                        }
                        Language = lang;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取对应语言的值
        /// </summary>
        /// <param name="name">显示名字</param>
        /// <returns></returns>
        public   string GetValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            return LanguageResource[name];
        }

        public LanguageHelper()
        {
            Languages.Add("zh-CN", new Language("zh-CN", "简体中文"));
            Languages.Add("en-US", new Language("en-US", "English"));
        }

        private Dictionary<string, Language> languages = new Dictionary<string, Language>();
        /// <summary>
        /// 多国语言集合
        /// </summary>
        public Dictionary<string, Language> Languages
        {
            get { return languages; }
            set { languages = value; }
        }

        public event EventHandler ChangeLanguage;//更改语言事件通知

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
