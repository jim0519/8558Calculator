using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApp.Models
{
    public class CalculatorViewModel
    {
        [UIHint("DateNullable")]
        public DateTime? VisaStartDate { get; set; }
        [UIHint("DateNullable")]
        public DateTime? VisaEndDate { get; set; }
        [UIHint("DateNullable")]
        public DateTime? EntryDate { get; set; }
        [UIHint("DateNullable")]
        public DateTime? DepartDate { get; set; }

        public List<EntryDepart> EntryDepartRecord { get; set; }

        public List<ResultMonth> Result { get; set; }

        
    }

    public class EntryDepart
    {
        public DateTime EntryDate { get; set; }
        public DateTime? DepartDate { get; set; }
    }

    public class ResultMonth
    {
        public ResultMonth(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public override string ToString()
        {
            return StartDate.ToString("yyyy MMM");
        }
        public string Caption => this.ToString();
        public bool IsOnshore { get; set; }
        public string CssClass { get; set; }
        public string ToolTip { get; set; }
    }
}