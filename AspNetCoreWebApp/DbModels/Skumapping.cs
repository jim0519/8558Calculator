using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class Skumapping
    {
        public int Id { get; set; }
        public string OldSku { get; set; }
        public string NewSku { get; set; }
    }
}
