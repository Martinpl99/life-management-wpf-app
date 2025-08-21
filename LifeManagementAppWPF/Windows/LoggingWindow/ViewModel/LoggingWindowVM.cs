using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Common.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeManagementAppWPF.Windows.LoggingWindow.ViewModel
{
    internal class LoggingWindowVM : ObservableObject, IOkWindow, ICancelWindow
    {
        public LoggingWindowVM()
        {
            OnOkCommand = new RelayCommand(() => OnOkCommandExecute());
            OnCancelCommand = new RelayCommand(() => OnCancelCommandExecute());
        }

        #region OnOkWindowBehaviourEvents

        public event Action OnOkEvent;
        public event Action OnCancelEvent;

        #endregion

        #region Commands

        private ICommand _onOkCommand;
        public ICommand OnOkCommand
        {
            get => _onOkCommand;
            set => SetProperty(ref _onOkCommand, value);
        }

        private ICommand _onCancelCommand;

        public ICommand OnCancelCommand
        {
            get => _onCancelCommand;
            set => SetProperty(ref _onCancelCommand, value);
        }

        #endregion

        #region CommandMethods
        private void OnOkCommandExecute() 
        {
            OnOkEvent?.Invoke();
        }

        void OnCancelCommandExecute() 
        {
            OnCancelEvent?.Invoke();
        }

        #endregion
    }
}
