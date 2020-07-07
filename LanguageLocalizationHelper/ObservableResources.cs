using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLocalizationHelper
{
    /// <summary>
    /// 语言资源文件刷新器
    /// </summary>
    public class ObservableResources : INotifyPropertyChanged
    {
        public string this[string name]
        {
            get
            {
                return LanguageRes.ResourceManager.GetString(name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Update()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
    }
}
