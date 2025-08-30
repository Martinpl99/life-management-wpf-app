using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Sources.TabItems.Interface;
using LifeManagementAppWPF.Sources.TabItems.ToDo.Model;
using LifeManagementAppWPF.Sources.TabItems.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LifeManagementAppWPF.Sources.TabItems.ViewModel
{
    internal class TODOItemVM : TabItemBaseVM, ITODOItemVM
    {
        public TODOItemVM()
        {
            Header = "ToDo";
            RemoveSelectedTodoItemCommand = new RelayCommand(() => RemoveSelectedTodoItemCommandExec());
            AddNewTodoItemCommand = new RelayCommand(() => AddNewTodoItemCommandExec());
            RemoveSelectedTodoItemsCommand = new RelayCommand(RemoveSelectedTodoItemsCommandExec);

            TodoItems.Add(new TodoItem { Done = true, WhatToDo="DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
            TodoItems.Add(new TodoItem { Done = true, WhatToDo = "DUPA" });
        }

        #region Properties

        ObservableCollection<TodoItem> _todoItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set => SetProperty(ref _todoItems, value);
        }

        private TodoItem _selecteTodoItem = new TodoItem();
        public TodoItem SelectedTodoItem
        {
            get => _selecteTodoItem;
            set => SetProperty(ref _selecteTodoItem, value);
        }

        private ObservableCollection<TodoItem> _selectedTodoItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> SelectedTodoItems 
        { 
            get => _selectedTodoItems;
            set => SetProperty(ref _selectedTodoItems, value);
        }

        #endregion

        #region Commands

        private ICommand _removeSelectedTodoItemCommand;
        public ICommand RemoveSelectedTodoItemCommand
        {
            get => _removeSelectedTodoItemCommand;
            set => SetProperty(ref _removeSelectedTodoItemCommand, value);
        }

        private ICommand _addNewTodoItem;
        public ICommand AddNewTodoItemCommand 
        { 
            get => _addNewTodoItem;
            set => SetProperty(ref _addNewTodoItem, value);
        }

        private ICommand _removeSelectedTodoItemsCommand;
        public ICommand RemoveSelectedTodoItemsCommand 
        { 
            get => _removeSelectedTodoItemsCommand; 
            set => SetProperty(ref _removeSelectedTodoItemsCommand, value);
        }

        #endregion

        #region Methods

        private void RemoveSelectedTodoItemCommandExec()
        {
            if (SelectedTodoItem is null) return;

            var existingItem = TodoItems?.Where(x => x == SelectedTodoItem)?.FirstOrDefault();
            if (existingItem != null)
            {
                _todoItems.Remove(existingItem);
            }
        }

        private void RemoveSelectedTodoItemsCommandExec()
        {
            if (SelectedTodoItems is null) return;

            var selectedItems = SelectedTodoItems.ToList();

            foreach (var todoItem in selectedItems)
                TodoItems?.Remove(todoItem);
        }

        private void AddNewTodoItemCommandExec()
        {
            TodoItems?.Add(new TodoItem());
        }

        #endregion
    }
}
