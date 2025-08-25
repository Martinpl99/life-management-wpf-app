using LiveManagementAppDatabase.DatabaseServices.Interfaces;
using LiveManagementAppDatabase.DatabaseSettings;
using LiveManagementAppDatabase.Utils.Serializers;
using MyFirstWebAPIProject.Dto;
using System.Text;

namespace LiveManagementAppDatabase.DatabaseServices.Services
{
    public class UserService : IUserService
    {
        private readonly string apiUserAddress =
                DatabaseOpt.DatabaseAddress + DatabaseOpt.UserEndpointAddress;
        public async Task<UserGetDto?> GetUserByIdAsync(Guid id)
        {
            using var httpClient = new HttpClient();

            var response  = await httpClient.GetAsync(apiUserAddress + $"/{id}");

            if(response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var userDto = JsonHelper.DeserializeAsync<UserGetDto>(responseStream);
                return await userDto; 
            }

            return null;
        }

        public async Task<UserGetDto?> UpdateUserByIdAsync(Guid userId, UserUpdateDto userUpdateDto)
        {
            using var httpClient = new HttpClient();

            var json = JsonHelper.Serialize(userUpdateDto); 
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiUserAddress + "/" +userId, content);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var userDto = JsonHelper.DeserializeAsync<UserGetDto>(responseStream);
                return await userDto;
            }

            return null;
        }
    }
}
