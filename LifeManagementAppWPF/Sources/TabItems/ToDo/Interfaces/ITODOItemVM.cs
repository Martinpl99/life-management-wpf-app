using LifeManagementAppWPF.Sources.TabItems.ToDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeManagementAppWPF.Sources.TabItems.Interface
{
    internal interface ITODOItemVM
    {
        TodoItem SelectedTodoItem { get; set; }
        ObservableCollection<TodoItem> SelectedTodoItems { get; set; }
        ICommand RemoveSelectedTodoItemCommand { get; set; }
        ICommand RemoveSelectedTodoItemsCommand { get; set; }
        ICommand AddNewTodoItemCommand { get; set; }
    }
}
