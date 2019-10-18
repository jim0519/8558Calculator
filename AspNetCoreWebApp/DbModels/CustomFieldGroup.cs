using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class CustomFieldGroup
    {
        public CustomFieldGroup()
        {
            AutoPostAdPostData = new HashSet<AutoPostAdPostData>();
            CustomFieldLine = new HashSet<CustomFieldLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AutoPostAdPostData> AutoPostAdPostData { get; set; }
        public ICollection<CustomFieldLine> CustomFieldLine { get; set; }
    }
}
