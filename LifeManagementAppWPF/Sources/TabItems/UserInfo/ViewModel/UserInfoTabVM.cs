using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Global;
using LifeManagementAppWPF.Sources.TabItems.Interface;
using LifeManagementAppWPF.Sources.TabItems.UserInfo.Model;
using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using System.Windows.Input;

namespace LifeManagementAppWPF.Sources.TabItems.ViewModel
{
    class UserInfoTabVM : TabItemBaseVM, IUserInfoTabViewModel
    {
        private readonly IUserService _userService;
        private readonly IApplicationContext _applicationContext;
        private readonly IMapper _autoMapper;
        public UserInfoTabVM(IUserService userService,
            IApplicationContext appContext,
            IMapper autoMapper)
        {
            _userService = userService;
            _applicationContext = appContext;
            _autoMapper = autoMapper;
            Header = "User Data";
            TabItemLoaded = new RelayCommand(() => TabItemLoadedExec());
        }

        #region Properties

        private UserInfoTabData _userInfoTabData = new UserInfoTabData();
        public UserInfoTabData UserInfoTabData  
        { 
            get => _userInfoTabData;
            set => SetProperty(ref _userInfoTabData, value);
        }

        #endregion

        #region Commands

        private ICommand _tabItemLoaded;
        public ICommand TabItemLoaded 
        {
            get => _tabItemLoaded;
            set => SetProperty(ref _tabItemLoaded, value);
        }

        #endregion

        #region Methods

        public async Task TabItemLoadedExec()
        {
            await GetUserData();
        }

        private async Task GetUserData()
        {
            var user = await _userService.GetUserById(_applicationContext.UserId);

            if (user == null) return;

            var infoTabData = _autoMapper.Map<UserInfoTabData>(user);
            UserInfoTabData = infoTabData;
        }

        #endregion
    }
}
