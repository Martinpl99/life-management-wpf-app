using AutoMapper;
using LifeManagementAppWPF.Sources.TabItems.UserInfo.Model;
using MyFirstWebAPIProject.Dto;

namespace LifeManagementAppWPF.Global
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserGetDto, UserInfoTabData>();
        }
    }
}
