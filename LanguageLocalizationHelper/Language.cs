using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLocalizationHelper
{
    /// <summary>
    /// 语言类
    /// zc+ 20160905
    /// </summary>
    public class Language
    {
        /// <summary>
        /// 语言类型名称
        /// 中文对应zh-CN
        /// 英文对应en-US
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 基于文化的显示名称
        /// 中文对应简体中文
        /// 英文对应English
        /// </summary>
        public string CultureName { get; set; }

        public Language(string name, string culture)
        {
            Name = name;
            CultureName = culture;
        }
    }
}
