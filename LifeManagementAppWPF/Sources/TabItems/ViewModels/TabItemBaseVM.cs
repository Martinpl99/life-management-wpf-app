using CommunityToolkit.Mvvm.ComponentModel;
using LifeManagementAppWPF.Sources.TabItems.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Sources.TabItems.ViewModel
{
    public abstract class TabItemBaseVM : ObservableObject, ITabItemVM
    {
        private string _header = "Set header!";
        public virtual string Header 
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }
    }
}
