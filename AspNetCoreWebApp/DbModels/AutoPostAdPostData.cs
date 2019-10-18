using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class AutoPostAdPostData
    {
        public AutoPostAdPostData()
        {
            AutoPostAdResult = new HashSet<AutoPostAdResult>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int InventoryQty { get; set; }
        public int AddressId { get; set; }
        public int AccountId { get; set; }
        public int CustomFieldGroupId { get; set; }
        public string BusinessLogoPath { get; set; }
        public string Description { get; set; }
        public string ImagesPath { get; set; }
        public string CustomId { get; set; }
        public string Status { get; set; }
        public decimal Postage { get; set; }
        public string Notes { get; set; }
        public int AdTypeId { get; set; }
        public int ScheduleRuleId { get; set; }

        public Account Account { get; set; }
        public Address Address { get; set; }
        public CustomFieldGroup CustomFieldGroup { get; set; }
        public ScheduleRule ScheduleRule { get; set; }
        public ICollection<AutoPostAdResult> AutoPostAdResult { get; set; }
    }
}
