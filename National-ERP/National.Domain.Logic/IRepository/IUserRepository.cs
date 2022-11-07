using National.Domain.Logic.DTO;
using National.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National.Domain.Logic.IRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<UserDto?> GetUserId(int userId);
       
    }
}
