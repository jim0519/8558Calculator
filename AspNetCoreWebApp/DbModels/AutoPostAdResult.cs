using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class AutoPostAdResult
    {
        public int Id { get; set; }
        public int AutoPostAdDataId { get; set; }
        public DateTime PostDate { get; set; }
        public string AdId { get; set; }

        public AutoPostAdPostData AutoPostAdData { get; set; }
    }
}
