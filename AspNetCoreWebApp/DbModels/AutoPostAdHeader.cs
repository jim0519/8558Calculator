using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class AutoPostAdHeader
    {
        public AutoPostAdHeader()
        {
            AutoPostAdLine = new HashSet<AutoPostAdLine>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime PostDate { get; set; }

        public ICollection<AutoPostAdLine> AutoPostAdLine { get; set; }
    }
}
