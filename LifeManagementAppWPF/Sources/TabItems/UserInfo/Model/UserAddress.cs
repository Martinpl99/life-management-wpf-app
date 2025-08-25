using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementAppWPF.Sources.TabItems.UserInfo.Model
{
    public class UserAddress : ObservableObject
    {
        private string _city = string.Empty;
        public string City 
        {
            get => _city;
            set =>SetProperty(ref _city, value);
        }

        private string _street = string.Empty;
        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value);
        }

        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }
    }
}
