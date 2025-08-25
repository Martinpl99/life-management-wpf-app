using AutoMapper;
using CommunityToolkit.Mvvm.Input;
using LifeManagementAppWPF.Global;
using LifeManagementAppWPF.Sources.TabItems.Interface;
using LifeManagementAppWPF.Sources.TabItems.UserInfo.Model;
using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using MyFirstWebAPIProject.Dto;
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
            TabItemLoaded = new RelayCommand(async () => await TabItemLoadedExec());
            UpdateUserDataCommand = new RelayCommand(async() => await UpdateUserDataCommandExec());
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

        private ICommand _updateUserDataCommand;
        public ICommand UpdateUserDataCommand 
        { 
            get => _updateUserDataCommand;
            set => SetProperty(ref _updateUserDataCommand, value);
        }

        #endregion

        #region Methods

        public async Task TabItemLoadedExec()
        {
            await GetUserData();
        }

        private async Task GetUserData()
        {
            var user = await _userService.GetUserByIdAsync(_applicationContext.UserId);

            if (user == null) return;

            var infoTabData = _autoMapper.Map<UserInfoTabData>(user);
            UserInfoTabData = infoTabData;
        }

        private async Task UpdateUserDataCommandExec()
        {
            var userUpdateDto = _autoMapper.Map<UserUpdateDto>(UserInfoTabData);

            var userGetDto = await _userService.UpdateUserByIdAsync(_applicationContext.UserId, userUpdateDto);

            var infoTabData = _autoMapper.Map<UserInfoTabData>(userGetDto);

            if(infoTabData != null)
                UserInfoTabData = infoTabData;
            else
                await GetUserData();
        }

        #endregion
    }
}
