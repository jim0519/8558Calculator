using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class Account
    {
        public Account()
        {
            AutoPostAdPostData = new HashSet<AutoPostAdPostData>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cookie { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public string Ipaddress { get; set; }
        public string UserAgent { get; set; }

        public ICollection<AutoPostAdPostData> AutoPostAdPostData { get; set; }
    }
}
