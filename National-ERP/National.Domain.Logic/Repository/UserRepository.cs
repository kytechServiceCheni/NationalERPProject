using National.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using National.Domain.Logic.IRepository;
using Microsoft.EntityFrameworkCore;
using National.Domain.Logic.DTO;

namespace National.Domain.Logic.Repository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(NationalContext context) : base(context)
        {
          
        }
        public async Task<UserDto?> GetUserId(int userId)
        {
            try
            {
                return await _context.Users.Where(x => x.UserId == userId)
                .Select(x => new UserDto()
                {
                    Id = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.Email
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
