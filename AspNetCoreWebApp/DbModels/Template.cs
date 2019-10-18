using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class Template
    {
        public Template()
        {
            ProductCategory = new HashSet<ProductCategory>();
            TemplateField = new HashSet<TemplateField>();
        }

        public int Id { get; set; }
        public string TemplateName { get; set; }

        public ICollection<ProductCategory> ProductCategory { get; set; }
        public ICollection<TemplateField> TemplateField { get; set; }
    }
}
