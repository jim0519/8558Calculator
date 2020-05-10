using System;
using System.Threading.Tasks;
using AspNetCoreWebApp.DbModels.CalculatorDbModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

[assembly: HostingStartup(typeof(AspNetCoreWebApp.Areas.Identity.IdentityHostingStartup))]
namespace AspNetCoreWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.Configure<IdentityOptions>(options =>
                {
                    // Default Password settings.
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                });
            });
        }
    }

    public class CustomSigninManager<AspNetUsers> : SignInManager<AspNetUsers> where AspNetUsers: AspNetCoreWebApp.DbModels.CalculatorDbModels.AspNetUsers
    {
        public CustomSigninManager(UserManager<AspNetUsers> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<AspNetUsers> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<AspNetUsers>> logger, IAuthenticationSchemeProvider schemes):base(userManager, contextAccessor,claimsFactory,optionsAccessor,logger,schemes)
        {

        }

        protected override Task<bool> IsLockedOut(AspNetUsers user)
        {
            //return base.IsLockedOut(user);
            var isLockedOut = false;
            if(user.LockoutEnabled&& user.LockoutEnd.HasValue)
            {
                //change the logic LockOutEnd to LockOutFrom
                var lockOutFromDate = user.LockoutEnd.Value;
                var remainingValidDays = (DateTime.Now - lockOutFromDate).TotalDays;
                if (remainingValidDays>0)
                {
                    isLockedOut = true;
                }
            }

            return Task.FromResult<bool>(isLockedOut);
        }
    }
}