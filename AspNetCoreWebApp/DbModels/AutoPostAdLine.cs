using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class AutoPostAdLine
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string ExternalId { get; set; }
        public string Status { get; set; }
        public DateTime PostDate { get; set; }

        public AutoPostAdHeader Header { get; set; }
    }
}
