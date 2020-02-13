using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels.CalculatorDbModels
{
    public partial class User:BaseEntity
    {
        public User()
        {

        }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }

    }
}
