using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace TreeViewCheckBox
{
    public class TreeViewModel : ReactiveObject

    {
        /// <summary>
        /// 父
        /// </summary>       
        public TreeViewModel Parent
        {
            get;
            set;
        }

        /// <summary>
        /// 子
        /// </summary>
        public List<TreeViewModel> Children
        {
            get;
            set;
        }

        /// <summary>
        /// 节点的名字
        /// </summary>
        public string NodeName
        {
            get;
            set;
        }

        public bool? _isChecked;
        /// <summary>
        /// CheckBox是否选中
        /// </summary>
        public bool? IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                SetIsChecked(value, true, true);
            }
        }

        public TreeViewModel(string name)
        {
            this.NodeName = name;
            this.Children = new List<TreeViewModel>();
        }
        public TreeViewModel() { }


        private void SetIsChecked(bool? value, bool checkedChildren, bool checkedParent)
        {
            if (_isChecked == value) return;
            _isChecked = value;
            //选中和取消子类
            if (checkedChildren && value.HasValue && Children != null)
                Children.ForEach(ch => ch.SetIsChecked(value, true, false));

            //选中和取消父类
            if (checkedParent && this.Parent != null)
                this.Parent.CheckParentCheckState();

            //通知更改
            this.RaisePropertyChanged("IsChecked");
        }

        /// <summary>
        /// 检查父类是否选 中
        /// 如果父类的子类中有一个和第一个子类的状态不一样父类ischecked为null
        /// </summary>
        private void CheckParentCheckState()
        {
            List<TreeViewModel> checkedItems = new List<TreeViewModel>();
            string checkedNames = string.Empty;
            bool? _currentState = this.IsChecked;
            bool? _firstState = null;
            for (int i = 0; i < this.Children.Count(); i++)
            {
                bool? childrenState = this.Children[i].IsChecked;
                if (i == 0)
                {
                    _firstState = childrenState;
                }
                else if (_firstState != childrenState)
                {
                    _firstState = null;
                }
            }
            if (_firstState != null) _currentState = _firstState;
            SetIsChecked(_firstState, false, true);
        }

        /// <summary>
        /// 创建树
        /// </summary>
        /// <param name="children"></param>
        /// <param name="isChecked"></param>

        public void CreateTreeWithChildre(TreeViewModel children, bool? isChecked)
        {
            this.Children.Add(children);
            //必须先把孩子加入再为Parent赋值，
            //否则当只有一个子节点时Parent的IsChecked状态会出错

            children.Parent = this;
            children.IsChecked = isChecked;
        }
    }
}
