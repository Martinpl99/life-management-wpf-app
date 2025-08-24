using LifeManagementAppWPF.Sources.TabItems.UserInfo.Model;
using System.Windows.Input;

namespace LifeManagementAppWPF.Sources.TabItems.Interface
{
    public interface IUserInfoTabViewModel
    {
        ICommand TabItemLoaded { get; set; }
        UserInfoTabData UserInfoTabData { get; set; }
    }
}
