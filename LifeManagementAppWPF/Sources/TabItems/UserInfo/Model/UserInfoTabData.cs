using CommunityToolkit.Mvvm.ComponentModel;

namespace LifeManagementAppWPF.Sources.TabItems.UserInfo.Model
{
    //Only for Data, do not include any methods
    public class UserInfoTabData : ObservableObject
    {
        private string _name = string.Empty;
        public string Name 
        { 
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _lastName = string.Empty;
        public string LastName 
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
    }
}
