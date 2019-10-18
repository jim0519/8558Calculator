using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class ScheduleRuleLine
    {
        public int Id { get; set; }
        public int ScheduleRuleId { get; set; }
        public DateTime TimeRangeFrom { get; set; }
        public DateTime TimeRangeTo { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime EditTime { get; set; }
        public string EditBy { get; set; }

        public ScheduleRule ScheduleRule { get; set; }
    }
}
