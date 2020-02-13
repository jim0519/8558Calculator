using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels.CalculatorDbModels
{
    public partial class BaseEntity
    {
        public BaseEntity()
        {

        }

        public int Id { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime EditTime { get; set; }
        public string EditBy { get; set; }
    }
}
