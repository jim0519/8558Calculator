using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class CustomFieldLine
    {
        public int Id { get; set; }
        public int CustomFieldGroupId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public CustomFieldGroup CustomFieldGroup { get; set; }
    }
}
