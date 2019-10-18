using AspNetCoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreWebApp.Business
{
    public class CalculatorService
    {
        public const int EighteenMonthDays = 548;
        public const int TwelveMonthDays = 365;

        public IList<ResultMonth> CalculateResult(ref IList<EntryDepart> entryDepartRecord, DateTime visaStartDate, DateTime visaEndDate)
        {
            try
            {
                var retResultMonths = new List<ResultMonth>();
                DateTime mustDepartDate = DateTime.MinValue;
                DateTime canReturnDate = DateTime.MinValue;
                entryDepartRecord = entryDepartRecord.OrderBy(edr=>edr.EntryDate).ToList();

                var lastEntryDepart = entryDepartRecord.LastOrDefault();
                var firstEntryDepart = entryDepartRecord.FirstOrDefault();
                //var isCalculatingDepartDate = (!lastEntryDepart.DepartDate.HasValue ? true : false);
                //var calculateFrom = (!isCalculatingDepartDate ? lastEntryDepart.DepartDate.Value:lastEntryDepart.EntryDate);
                var calculateFrom = lastEntryDepart.EntryDate;

                //if (isCalculatingDepartDate)
                //{
                //bool hasMustDepartResult = false;
                //bool hasNewTwelveMonthStayResult = false;
                int i = 0;
                //var finalCalculateEntryDepartRecord= new List<EntryDepart>();
                while (mustDepartDate==DateTime.MinValue || canReturnDate == DateTime.MinValue)
                {

                    var tmpToDate = calculateFrom.AddDays(i);
                    var tmpFromDate = tmpToDate.AddDays(-EighteenMonthDays);
                    var totalEntryDays = 0;

                    if (mustDepartDate == DateTime.MinValue)
                    {
                        //var calculateEntryDepartRecord = (!isCalculatingDepartDate ? entryDepartRecord : entryDepartRecord.Where(r => r != lastEntryDepart).ToList());
                        var calculateEntryDepartRecord = entryDepartRecord.Where(r => r != lastEntryDepart).ToList();
                        calculateEntryDepartRecord.Add(new EntryDepart() { EntryDate = lastEntryDepart.EntryDate, DepartDate = tmpToDate });

                        //var tmpNotRemovalRecord = new List<EntryDepart>();
                        foreach (var edr in calculateEntryDepartRecord)
                        {
                            totalEntryDays += InclusiveDays(tmpFromDate, tmpToDate, edr.EntryDate, edr.DepartDate.Value);

                            //tmpNotRemovalRecord.Add(edr);
                        }

                        if (totalEntryDays >=TwelveMonthDays)
                        {
                            //hasMustDepartResult = true;
                            if (i == 0)
                                mustDepartDate = entryDepartRecord.Where(r => r != lastEntryDepart).LastOrDefault().DepartDate.Value;
                            else
                                mustDepartDate = tmpToDate;
                            //calculateEntryDepartRecord = calculateEntryDepartRecord.Where(e => tmpNotRemovalRecord.Contains(e)).ToList();

                            //break;
                        }
                    }
                    if (canReturnDate == DateTime.MinValue&& mustDepartDate!=DateTime.MinValue)
                    {
                        IList<EntryDepart> calculateEntryDepartRecord;
                        if ((lastEntryDepart.DepartDate != null && IsDateInsideRange(mustDepartDate, lastEntryDepart.EntryDate, lastEntryDepart.DepartDate.Value)) || !lastEntryDepart.DepartDate.HasValue)
                        {
                            calculateEntryDepartRecord = entryDepartRecord.Where(r => r != lastEntryDepart).ToList();
                            if(mustDepartDate>=lastEntryDepart.EntryDate)
                                calculateEntryDepartRecord.Add(new EntryDepart() { EntryDate = lastEntryDepart.EntryDate, DepartDate = mustDepartDate });
                        }
                        else
                        {
                            calculateEntryDepartRecord = entryDepartRecord;
                        }

                            

                        //var tmpNotRemovalRecord = new List<EntryDepart>();
                        foreach (var edr in calculateEntryDepartRecord)
                        {
                            totalEntryDays += InclusiveDays(tmpFromDate, tmpToDate, edr.EntryDate, edr.DepartDate.Value);
                        }

                        if(totalEntryDays< TwelveMonthDays)
                        {
                            //hasNewTwelveMonthStayResult = true;
                            canReturnDate = tmpToDate.AddDays(1);
                        }
                    }
                    //finalCalculateEntryDepartRecord = calculateEntryDepartRecord;


                    //else
                    //{
                    //    //if(totalEntryDays <= TwelveMonthDays)
                    //    if ((tmpToDate - tmpFromDate).TotalDays - totalEntryDays >= EighteenMonthDays - TwelveMonthDays)
                    //    {
                    //        hasResult = true;
                    //        newTwelveMonthDate = tmpToDate;
                    //    }
                    //}
                    i++;
                }
                //}
                //else
                //{

                var isCalculatingDepartDate = false;
                if ((lastEntryDepart.DepartDate != null&& IsDateInsideRange(mustDepartDate, lastEntryDepart.EntryDate, lastEntryDepart.DepartDate.Value)) || !lastEntryDepart.DepartDate.HasValue)
                {
                    //remove last entrydepart, add entrydepart with mustDepartDate as depart date
                    entryDepartRecord= entryDepartRecord.Where(r => r != lastEntryDepart).ToList();
                    if (mustDepartDate >= lastEntryDepart.EntryDate)
                        entryDepartRecord.Add(new EntryDepart() { EntryDate = lastEntryDepart.EntryDate, DepartDate = mustDepartDate });
                    //canReturnDate = mustDepartDate.AddDays(EighteenMonthDays - TwelveMonthDays);
                    isCalculatingDepartDate = true;
                }
                else if(mustDepartDate<lastEntryDepart.EntryDate)
                {
                    //remove last entrydepart
                    entryDepartRecord = entryDepartRecord.Where(r => r != lastEntryDepart).ToList();
                }
                else
                {
                    //canReturnDate = lastEntryDepart.DepartDate.Value.AddDays(EighteenMonthDays - TwelveMonthDays);
                }

               
                //if (!isCalculatingDepartDate)
                //    newTwelveMonthDate = lastEntryDepart.DepartDate.Value.AddDays(EighteenMonthDays - TwelveMonthDays);
                //else
                //    newTwelveMonthDate = mustDepartDate.AddDays(EighteenMonthDays - TwelveMonthDays);
                //}

                    //var firstDayOfMonth = ;
                    //var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                var totalMonths = ((visaEndDate.Year - visaStartDate.Year) * 12) + visaEndDate.Month - visaStartDate.Month;
                for (int j = 0; j < totalMonths; j++)
                {
                    var firstDayOfMonth = new DateTime(visaStartDate.Year, visaStartDate.Month, 1).AddMonths(j);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    var newResultMonth = new ResultMonth(firstDayOfMonth, lastDayOfMonth);
                    //var calculateEntryDepartRecord = entryDepartRecord;
                    if (isCalculatingDepartDate)
                    {
                        //calculateEntryDepartRecord = entryDepartRecord.Where(r => r != lastEntryDepart).ToList();
                        //calculateEntryDepartRecord.Add(new EntryDepart() { EntryDate = lastEntryDepart.EntryDate, DepartDate = mustDepartDate });
                        if (IsDateInsideRange(mustDepartDate, newResultMonth.StartDate, newResultMonth.EndDate))
                        {
                            newResultMonth.CssClass = "MustDepart";
                            newResultMonth.ToolTip += (string.IsNullOrEmpty(newResultMonth.ToolTip) ? string.Empty : ", ") + "Must Depart Date: " + mustDepartDate.ToShortDateString();
                        }
                    }
                    //else
                    //{
                    if (IsDateInsideRange(canReturnDate, newResultMonth.StartDate, newResultMonth.EndDate))
                    {
                        if (entryDepartRecord.LastOrDefault().DepartDate.HasValue && entryDepartRecord.LastOrDefault().DepartDate.Value >= mustDepartDate)
                        {
                            newResultMonth.CssClass = "CanReturn";
                            newResultMonth.ToolTip += (string.IsNullOrEmpty(newResultMonth.ToolTip) ? string.Empty : ", ") + "Can Return From: " + canReturnDate.ToShortDateString();
                        }
                        //else
                        //{
                        //    newResultMonth.CssClass = "NewTwelveMonths";
                        //    newResultMonth.ToolTip += (string.IsNullOrEmpty(newResultMonth.ToolTip) ? string.Empty : ", ") + "New Twelve Months Stay From: " + canReturnDate.ToShortDateString();
                        //}
                    }
                    //}

                    foreach (var edr in entryDepartRecord)
                    {
                        if (InclusiveDays(newResultMonth.StartDate, newResultMonth.EndDate, edr.EntryDate, edr.DepartDate.Value) > 0&&!newResultMonth.IsOnshore)
                        {
                            newResultMonth.IsOnshore = true;
                            if(string.IsNullOrEmpty(newResultMonth.CssClass))
                                newResultMonth.CssClass = "OnShore";
                            newResultMonth.ToolTip += (string.IsNullOrEmpty(newResultMonth.ToolTip) ? string.Empty : ", ") + "Total Days: "+((edr.DepartDate.Value- edr.EntryDate).TotalDays+1);
                            //break;
                        }

                        if (IsDateInsideRange(edr.EntryDate, newResultMonth.StartDate, newResultMonth.EndDate))
                        {
                            newResultMonth.ToolTip += (string.IsNullOrEmpty(newResultMonth.ToolTip) ? string.Empty : ", ") + "Entry Date: " + edr.EntryDate;
                        }

                        if (edr.DepartDate != null && IsDateInsideRange(edr.DepartDate.Value, newResultMonth.StartDate, newResultMonth.EndDate))
                        {
                            newResultMonth.ToolTip += (string.IsNullOrEmpty(newResultMonth.ToolTip) ? string.Empty : ", ") + "Depart Date: " + edr.DepartDate;
                        }
                    }

                    

                    retResultMonths.Add(newResultMonth);
                }

                return retResultMonths;
            }
            catch
            {
                return default(IList<ResultMonth>);
            }
        }

        public int InclusiveDays(DateTime s1, DateTime e1, DateTime s2, DateTime e2)
        {
            // If they don't intersect return 0.
            if (!(s1 <= e2 && e1 >= s2))
            {
                return 0;
            }

            // Take the highest start date and the lowest end date.
            DateTime start = s1 > s2 ? s1 : s2;
            DateTime end = e1 > e2 ? e2 : e1;

            // Add one to the time range since its inclusive.
            return (int)(end - start).TotalDays + 1;
        }

        public bool IsDateInsideRange(DateTime dateToCheck,DateTime rangeStartDate,DateTime rangeEndDate)
        {
            return dateToCheck >= rangeStartDate && dateToCheck <= rangeEndDate;
        }
    }


}