using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveManagementAppDatabase.DatabaseSettings;
using System.Text.Json;
using MyFirstWebAPIProject.Dto;
using LiveManagementAppDatabase.Utils.Serializers;

namespace LiveManagementAppDatabase.DatabaseServices.Services
{
    public class UserService : IUserService
    {
        private readonly string apiUserAddress =
                DatabaseOpt.DatabaseAddress + DatabaseOpt.UserEndpointAddress;
        public async Task<UserGetDto?> GetUserById(Guid id)
        {
            using var httpClient = new HttpClient();

            var response  = await httpClient.GetAsync(apiUserAddress + $"/{id}");

            if(response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var userDto = JsonHelper.DeserializeAsync<UserGetDto>(responseStream);
                return await userDto; 
            }
            else
            {
                return null;
            }
        }
    }
}
