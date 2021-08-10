using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTreeView
{
    public class DirectoryItemViewModel : BaseViewModel
    {

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullPath;
            this.Type = type;

            // setup the children as needed
            ClearChildren();
        }




        public ICommand ExpandCommand { get; set; }

        public string FullPath { get; set; }

        public DirectoryItemType Type { get; set; }

        public string Name { get => this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        
        /// <summary>
        /// indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get => Type != DirectoryItemType.File; }

        public bool IsExpanded
        {
            get => this.Children?.Count(f => f != null) > 0;

            set
            {
                if (value == true)
                {
                    Expand();
                }
                else
                {
                    this.ClearChildren();
                }
            }
        }


        private void ClearChildren()
        {
            // clear items
            Children = new ObservableCollection<DirectoryItemViewModel>();

            // show the expand icon
            if (Type != DirectoryItemType.File)
            {
                Children.Add(null);
            }

        }

        /// <summary>
        /// Expand Dir and finds the children
        /// </summary>
        private void Expand()
        {
            if (Type == DirectoryItemType.File)
            {
                return;
            }

            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            var childrenTransformed01 = from child in children
                         select new DirectoryItemViewModel(child.FullPath, child.Type);
            Children = new ObservableCollection<DirectoryItemViewModel>(childrenTransformed01);
        }
    }
}
