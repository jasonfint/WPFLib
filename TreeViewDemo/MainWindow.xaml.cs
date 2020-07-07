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

namespace TreeViewDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //加载tree数据
            ShowTreeView();
        }
        /// <summary>
        /// 加载tree数据
        /// </summary>
        private void ShowTreeView()
        {
            List<TreeViewViewModel> listItem = new List<TreeViewViewModel>();
            TreeViewViewModel mainNode = new TreeViewViewModel()
            {
                DisplayName = "功能菜单",
                Name = "主目录--功能菜单"
            };

            TreeViewViewModel systemNode = new TreeViewViewModel()
            {
                DisplayName = "系统设置",
                Name = "当前菜单--系统设置"
            };
            TreeViewViewModel userTag = new TreeViewViewModel()
            {
                DisplayName = "用户名",
                Name = "当前选项--用户名"
            };
            TreeViewViewModel pwdTag = new TreeViewViewModel()
            {
                DisplayName = "密码修改",
                Name = "当前选项--密码修改"
            };
            systemNode.Children.Add(pwdTag);
            systemNode.Children.Add(userTag);
            mainNode.Children.Add(systemNode);
            listItem.Add(mainNode);
            this.tvProperty.ItemsSource = listItem;

        }
        /*
          public void MainWay()
         {
             var query = from L in listItem
                         group L by L.Fecha into fetchaGroup
                         select new
                         {
                             Fecha = fetchaGroup.Key,
                             Count = fetchaGroup.Count(),
                             FetchaGroup = (from fg in fetchaGroup
                                            group fg by fg.Nbanco into NbancoGroup
                                            select new
                                            {
                                                Nbanco = NbancoGroup.Key,
                                                NbancoGroup = (from ng in NbancoGroup
                                                               group ng by ng.Ngrupo into NgrupoGroup
                                                               select new { Ngrupo = NgrupoGroup.Key, NgrupoGroup }
                                                             )
                                            }
                                             )
                         }
             ;


             foreach (var g in query)
             {
                 Console.WriteLine("{0} ({1})", g.Fecha, g.Count);

                 foreach (var fg in g.FetchaGroup)
                 {
                     Console.WriteLine("\t{0}", fg.Nbanco);

                     foreach (var ng in fg.NbancoGroup)
                     {
                         Console.WriteLine("\t\t{0} {1}", ng.Ngrupo, ng.NgrupoGroup.Sum(ngg => ngg.Monto));

                         if (ng.NgrupoGroup.Count() > 1)
                         {
                             foreach (var ngg in ng.NgrupoGroup)
                             {
                                 Console.WriteLine("\t\t\t{0} {1}", ngg.Npersona, ngg.Monto);
                             }
                         }
                     }
                 }
             }
         }
          */


    }
}
