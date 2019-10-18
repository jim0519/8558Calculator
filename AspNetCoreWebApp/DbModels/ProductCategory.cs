using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryId { get; set; }
        public int TemplateId { get; set; }
        public int CategoryTypeId { get; set; }
        public string Status { get; set; }

        public Template Template { get; set; }
    }
}
