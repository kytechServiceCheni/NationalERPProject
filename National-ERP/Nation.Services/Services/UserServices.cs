using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Nation.Services.ServiceResponse;
using National.Domain.Logic.DTO;
using National.Domain.Logic.IRepository;
using National.Repository.Entity;
using National.Services.Common;
using National.Services.IServices;
using National.Services.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National.Services
{
    public class UserServices: IUserServices
    {
        private readonly IUserRepository _Iuser;
        private readonly ITokenRepository _IToken;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository Iuser, ITokenRepository IToken,IMapper mapper)
        {
            _Iuser = Iuser;
          _mapper = mapper;
          _IToken = IToken;
        }
        public async Task<UserDto?> GetUserRecords(int userId)
        {
            try
            {
                var result = await _Iuser.GetUserId(userId);
                return new UserDto()
                {
                    FirstName = result?.FirstName,
                    Id = result.Id,
                    LastName = result.LastName,
                    UserName = result.UserName

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public async Task<UserResponse> Authenticate(UserRequest userRequest)
        {       
            var user  = (await _Iuser.Find(x=>x.Email== userRequest.Email)).FirstOrDefault();
            bool _isPasswordMatched = false;
             string token = null;
            var userDto = new UserDto()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                UserName = userRequest.Email,
                

            };
            if (user!=null)
            {
                var isPasswordMatched = VerifyPassword(userRequest.Password, user.StoredSalt, user.Password);
                _isPasswordMatched = isPasswordMatched;
            }
            if (user == null || !_isPasswordMatched)
            {
           
               var userResponse = new UserResponse()
                {
                    accessToken = token,
                    Message= Message.InvalidUserMessage,
                    UserInfo= userDto
                };
                return userResponse;
            }
            token = _IToken.GenerateJwtToken(userDto);
            userDto.Id = user.UserId;
            var userResponseNew = new UserResponse()
            {
                accessToken = token,
                Message = Message.InvalidUserMessage,
                UserInfo = userDto
            };
            return userResponseNew;
        }
        private bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword)
        {
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return encryptedPassw == storedPassword;
        }
        public async Task<string> RegisterUser(UserRequest user)
        {
            try
            {
                var entity = _mapper.Map<User>(user);
                var userRecord = _Iuser.Add(entity);

                if (userRecord != null)
                {                 
                    
                  return await Task.FromResult(Message.SaveMessage);
                   
                }
                return null;
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
    }
}
