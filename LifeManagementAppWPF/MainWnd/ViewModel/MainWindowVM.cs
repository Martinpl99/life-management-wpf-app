using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Common.Windows.Interfaces;
using LifeManagementAppWPF.Dialogs.LoggingDialog.Interfaces;
using LifeManagementAppWPF.Dialogs.LoggingDialog.View;
using LifeManagementAppWPF.Dialogs.LoggingDialog.ViewModel;
using LifeManagementAppWPF.Global;
using LifeManagementAppWPF.MainWnd.Interfaces;
using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using LiveManagementAppDatabase.DatabaseServices.Services;
using System.Windows.Input;

namespace LifeManagementAppWPF.MainWnd.ViewModel
{
    public class MainWindowVM :
        ObservableObject,
        IMainWindowVM,
        ICancelWindow
    {

        private readonly IUserService _userService;
        private readonly IApplicationContext _applicationContext;
        private readonly LoggingDialog _loggingWindow;

        public MainWindowVM(IApplicationContext appContext,
            LoggingDialog loggingWindow)
        {
            _applicationContext = appContext;
            _loggingWindow = loggingWindow;
            _userService = new UserService();
            ButtonClickCommand = new RelayCommand(() => ButtonClickCommandExec());
            WindowLoadedCommand = new RelayCommand(() => OnWindowLoaded());
        }

        #region OkCancelWindowBehaviourEvents

        public event Action OnCancelEvent;

        #endregion

        private ICommand _buttonClickCommand;
        public ICommand ButtonClickCommand
        {
            get => _buttonClickCommand;
            set => SetProperty(ref _buttonClickCommand, value);
        }

        private ICommand _windowLoadedCommand;

        public ICommand WindowLoadedCommand
        {
            get => _windowLoadedCommand;
            set => SetProperty(ref _windowLoadedCommand, value);
        }

        private async Task ButtonClickCommandExec()
        {
            await _userService.GetUserById(_applicationContext.UserId);
        }

        private void OnWindowLoaded()
        {
            OpenLoggingWindow();
        }

        private void OpenLoggingWindow()
        {
            var result = _loggingWindow.ShowDialog();

            if (result == true)
            {
                if (_loggingWindow.DataContext is not ILoggingDialogVM)
                    CloseWindow();

                var viewModel = _loggingWindow.DataContext as ILoggingDialogVM;

                if (!Guid.TryParse(viewModel.UserId, out var userId))
                    CloseWindow();

                _applicationContext.UserId = userId;
            }
            else
            {
                CloseWindow();
            }
        }

        private void CloseWindow()
        {
            OnCancelEvent?.Invoke();
        }
    }
}
