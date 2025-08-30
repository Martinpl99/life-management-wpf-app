using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Sources.TabItems.ToDo.Model
{
    public class TodoItem : ObservableObject
    {
        private bool _done = false;
        public bool Done 
        {
            get => _done; 
            set => SetProperty(ref _done, value);
        }

        private string _whatToDo = string.Empty;
        public string WhatToDo
        {
            get => _whatToDo;
            set => SetProperty(ref _whatToDo, value);
        }
    }
}
