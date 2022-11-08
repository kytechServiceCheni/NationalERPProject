
using Nation.Services.ServiceResponse;
using National.Domain.Logic.DTO;
using National.Services.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National.Services.IServices
{
    public interface IUserServices
    {
        Task<UserDto?> GetUserRecords(int userId);
         Task<UserResponse> Authenticate(UserRequest user);
        Task<string> RegisterUser(UserRequest user); 
    }
}
