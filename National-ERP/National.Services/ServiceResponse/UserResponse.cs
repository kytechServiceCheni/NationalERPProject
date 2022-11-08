using National.Domain.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nation.Services.ServiceResponse
{
    public class UserResponse
    {
      public  UserResponse()
        {
            UserInfo = new UserDto();
        }
        public UserDto? UserInfo{get;set;}
        public string? accessToken { get; set; }
        public string? Message { get; set; }
    }
}
