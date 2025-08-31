using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Common.Interfaces;
using LifeManagementAppWPF.Common.Windows.Interfaces;
using LifeManagementAppWPF.Dialogs.LoggingDialog.View;
using LifeManagementAppWPF.Global;
using LifeManagementAppWPF.MainWnd.Interfaces;
using LifeManagementAppWPF.Sources.TabItems.Interface;
using LifeManagementAppWPF.Sources.TabItems.ViewModel;
using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using LiveManagementAppDatabase.DatabaseServices.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LifeManagementAppWPF.MainWnd.ViewModel
{
    public class MainWindowVM :
        ObservableObject,
        IMainWindowVM,
        ICancelWindow
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private IDatabaseStatus _databaseStatus;
        private readonly LoggingDialog _loggingWindow;

        public MainWindowVM(IApplicationContext appContext,
            IUserService userService,
            IMapper mapper,
            IDatabaseStatus databaseStatus,
            LoggingDialog loggingWindow)
        {
            _applicationContext = appContext;
            _userService = userService;
            _loggingWindow = loggingWindow;
            _mapper = mapper;
            _databaseStatus = databaseStatus;

            _userService = new UserService();
            WindowLoadedCommand = new RelayCommand(() => OnWindowLoaded());
            GenerateTabItems();
        }

        #region OkCancelWindowBehaviourEvents

        public event Action OnCancelEvent;

        #endregion

        #region Properties
        private ObservableCollection<ITabItemVM> _tabItems = new ObservableCollection<ITabItemVM>();
        public ObservableCollection<ITabItemVM> TabItems 
        {
            get => _tabItems;
            set => SetProperty(ref _tabItems, value);
        }
        #endregion

        #region Commands

        private ICommand _windowLoadedCommand;
        public ICommand WindowLoadedCommand
        {
            get => _windowLoadedCommand;
            set => SetProperty(ref _windowLoadedCommand, value);
        }

        #endregion

        private void GenerateTabItems()
        {
            TabItems.Add(new UserInfoTabVM(_userService, _applicationContext, _mapper, _databaseStatus));
            TabItems.Add(new TODOItemVM());
        }
        private void OnWindowLoaded()
        {
            OpenLoggingWindow();
        }

        private void OpenLoggingWindow()
        {
            //var result = _loggingWindow.ShowDialog();

            //if (result == true)
            //{
            //    if (_loggingWindow.DataContext is not ILoggingDialogVM) 
            //        CloseWindow();

            //    var viewModel = _loggingWindow.DataContext as ILoggingDialogVM;

            //    if (!Guid.TryParse(viewModel.UserId, out var userId))
            //        CloseWindow();

            //    _applicationContext.UserId = userId;
            //}
            //else
            //{
            //    Application.Current.Shutdown();
            //}
        }

        private void CloseWindow()
        {
            OnCancelEvent?.Invoke();
        }
    }
}
