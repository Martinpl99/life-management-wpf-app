using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Common.Windows.Interfaces;
using LifeManagementAppWPF.Dialogs.LoggingDialog.Interfaces;
using System.Windows.Input;

namespace LifeManagementAppWPF.Dialogs.LoggingDialog.ViewModel
{
    internal class LoggingDialogVM : ObservableObject,
        ILoggingDialogVM,
        IOkWindow,
        ICancelWindow
    {
        public LoggingDialogVM()
        {
            OnOkCommand = new RelayCommand(() => OnOkCommandExecute());
            OnCancelCommand = new RelayCommand(() => OnCancelCommandExecute());
        }

        #region Properties

        private string _userId = string.Empty;
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref  _userId, value);
        }

        #endregion

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
