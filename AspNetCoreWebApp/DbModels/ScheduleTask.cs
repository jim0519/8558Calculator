using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class ScheduleTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seconds { get; set; }
        public string Type { get; set; }
        public bool Enabled { get; set; }
        public bool StopOnError { get; set; }
        public DateTime? LastStartTime { get; set; }
        public DateTime? LastEndTime { get; set; }
        public DateTime? LastSuccessTime { get; set; }
    }
}
