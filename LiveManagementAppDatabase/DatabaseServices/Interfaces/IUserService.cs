using MyFirstWebAPIProject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveManagementAppDatabase.DatabaseServices.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDto?> GetUserById(Guid id);
    }
}
