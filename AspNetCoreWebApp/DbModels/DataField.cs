using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class DataField
    {
        public DataField()
        {
            TemplateField = new HashSet<TemplateField>();
        }

        public int Id { get; set; }
        public string DataFieldName { get; set; }

        public ICollection<TemplateField> TemplateField { get; set; }
    }
}
