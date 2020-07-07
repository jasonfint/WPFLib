using System.Collections.Generic;

namespace TreeViewDemo
{
    public class TreeViewViewModel
    {
        public string Icon { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<TreeViewViewModel> Children { get; set; }
        public TreeViewViewModel()
        {
            Children = new List<TreeViewViewModel>();
        }
    }
}
