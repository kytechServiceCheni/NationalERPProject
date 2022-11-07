
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using National.Domain.Logic.IRepository;
using National.Domain.Logic.Repository;
using National.Services;
using National.Services.IServices;

namespace National.Web.Api
{
    public class RegisterServices
    {
        public static void Services(WebApplicationBuilder builder)
        {
            //services.AddDbContext<MSMARTERPDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IUserServices, UserServices>();
           builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ITokenRepository, TokenRepository>();
        }
    }
}
