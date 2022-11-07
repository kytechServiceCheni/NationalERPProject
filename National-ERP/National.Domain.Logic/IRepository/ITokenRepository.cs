using National.Domain.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National.Domain.Logic.IRepository
{
    public interface ITokenRepository
    {
        string GenerateJwtToken(UserDto user);
    }
}
