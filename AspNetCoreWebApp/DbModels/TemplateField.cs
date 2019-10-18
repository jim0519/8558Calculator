using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class TemplateField
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int DataFieldId { get; set; }
        public int Order { get; set; }
        public string DefaultValue { get; set; }
        public string TemplateFieldName { get; set; }
        public int TemplateFieldType { get; set; }
        public bool IsRequireInput { get; set; }

        public DataField DataField { get; set; }
        public Template Template { get; set; }
    }
}
