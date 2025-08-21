using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Common.Windows.Interfaces;
using LifeManagementAppWPF.Windows.LoggingWindow.View;
using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using LiveManagementAppDatabase.DatabaseServices.Services;
using System.Windows.Input;

namespace LifeManagementAppWPF
{
    public class MainWindowVM : ObservableObject, ICancelWindow
    {
        private readonly IUserService _userService;
        public MainWindowVM()
        {
            _userService = new UserService();
            ButtonClickCommand = new RelayCommand(() => ButtonClickCommandExec());
            OpenOpeningWindowCommand = new RelayCommand(() => OpenOpeningWindowCommandExec());
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

        private ICommand _openOpeningWindowCommand;

        public ICommand OpenOpeningWindowCommand
        {
            get => _openOpeningWindowCommand;
            set => SetProperty(ref _openOpeningWindowCommand, value);
        }

        private async Task ButtonClickCommandExec()
        {
            await _userService.GetUserById(Guid.Parse("01988695-61c0-7259-9f76-f03d4b23ec29"));
        }

        private void OpenOpeningWindowCommandExec()
        {
            var openAppWindow = new LoggingWindow();
            var result = openAppWindow.ShowDialog();

            if (result == true)
            {
                Console.WriteLine("DUPA");
            }
            else
            {
                CancelWindow();
            }
        }

        private void CancelWindow()
        {
            OnCancelEvent?.Invoke();
        }
    }
}
