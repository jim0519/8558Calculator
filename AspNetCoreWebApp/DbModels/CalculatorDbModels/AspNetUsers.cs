using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetCoreWebApp.DbModels.CalculatorDbModels
{
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers()
        {

        }
        //public int Status { get; set; }

    }
}
