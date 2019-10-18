using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class ScheduleRule
    {
        public ScheduleRule()
        {
            AutoPostAdPostData = new HashSet<AutoPostAdPostData>();
            ScheduleRuleLine = new HashSet<ScheduleRuleLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IntervalDay { get; set; }
        public DateTime LastSuccessTime { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime EditTime { get; set; }
        public string EditBy { get; set; }

        public ICollection<AutoPostAdPostData> AutoPostAdPostData { get; set; }
        public ICollection<ScheduleRuleLine> ScheduleRuleLine { get; set; }
    }
}
