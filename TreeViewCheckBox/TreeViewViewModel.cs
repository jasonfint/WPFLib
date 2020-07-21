using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace TreeViewCheckBox
{
  public  class TreeViewViewModel:ReactiveObject
    {

        private ObservableCollection<TreeViewModel> treeViewModels = new ObservableCollection<TreeViewModel>();
        public ObservableCollection<TreeViewModel> TreeViewModels
        {
            get { return treeViewModels; }
            set
            {
                this.RaiseAndSetIfChanged(ref treeViewModels, value);
            }
        }

        public List<string> _names;

        public TreeViewViewModel()
        {
            TreeViewModels = new ObservableCollection<TreeViewModel>();
            foreach (var item in MyCreateTree())
            {
                TreeViewModels.Add(item);
            }

        }
        /// <summary>
        /// 创建树
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> MyCreateTree()
        {
            List<TreeViewModel> views = new List<TreeViewModel>();
            //TreeViewModel _myT = new TreeViewModel("合约");
            TreeViewModel _myy = new TreeViewModel("CCP");
            views.Add(_myy);
            TreeViewModel _myy1 = new TreeViewModel("CCP_1");
            _myy.CreateTreeWithChildre(_myy1, true);
            TreeViewModel _myy2 = new TreeViewModel("CCP_2");
            _myy.CreateTreeWithChildre(_myy2, true);
            TreeViewModel _myy3 = new TreeViewModel("CCP_3");
            _myy.CreateTreeWithChildre(_myy3, true);
            return views;
        }

        /// <summary>
        /// 选中的节点名称保存在_names中
        /// </summary>
        //public void SaveC()
        //{
        //    _names = new List<string>();
        //    //SelectedTree=MyTrees.FindAll(r => r.IsChecked == true); 
        //    foreach (TreeViewModel tree in MyTrees)
        //    {
        //        GetCheckedItems(tree);
        //    }
        

        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <param name="tree"></param>
        private void GetCheckedItems(TreeViewModel tree)
        {
            if (tree.Parent != null && (tree.Children == null || tree.Children.Count == 0))
            {
                if (tree.IsChecked.HasValue && tree.IsChecked == true)
                    _names.Add(tree.NodeName);
            }
            else if (tree.Children != null && tree.Children.Count > 0)
            {
                foreach (TreeViewModel tv in tree.Children)
                    GetCheckedItems(tv);
            }
        }
    
    }
}
