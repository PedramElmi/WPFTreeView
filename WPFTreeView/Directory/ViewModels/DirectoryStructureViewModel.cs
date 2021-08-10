using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTreeView
{
    /// <summary>
    /// ViewModel for the main view
    /// </summary>
    class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {

            var drivesItems = new ObservableCollection<DirectoryItem>(DirectoryStructure.GetLogicalDrives());
            var drives = from drive in drivesItems
                         select new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive);

            Items = new ObservableCollection<DirectoryItemViewModel>(drives);
        }

    }
}
