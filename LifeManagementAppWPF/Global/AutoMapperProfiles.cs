using AutoMapper;
using LifeManagementAppWPF.Sources.TabItems.UserInfo.Model;
using MyFirstWebAPIProject.Dto;

namespace LifeManagementAppWPF.Global
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddressGetDto, UserAddress>().ReverseMap();
            CreateMap<UserAddressUpdateDto, UserAddress>().ReverseMap();

            CreateMap<UserGetDto, UserInfoTabData>().ReverseMap();
            CreateMap<UserUpdateDto, UserInfoTabData>().ReverseMap();
        }
    }
}
