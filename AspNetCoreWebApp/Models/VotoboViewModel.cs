using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApp.Models
{
    public class VotoboViewModel
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


    public class Html
    {
        public string supplierInfo { get; set; }
        public string productUrl1688 { get; set; }
        public object aLink1688 { get; set; }
        public int platformId { get; set; }
        public string itemId { get; set; }
        public string img { get; set; }
        public string smallImg { get; set; }
        public string producturl { get; set; }
        public string haveMemberId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string totalSold { get; set; }
        public string days7totalSold { get; set; }
        public double days7totalSoldPrice { get; set; }
        public double days7amplitude { get; set; }
        public string categoryId { get; set; }
        public string categoryName { get; set; }
        public string timeStart { get; set; }
        public string sellerId { get; set; }
        public string sellerTableId { get; set; }
        public string storeName { get; set; }
        public string shopTimeStart { get; set; }
        public string shippingCost { get; set; }
        public string ImmediateDevelopment { get; set; }
        public string mbPublishUrl { get; set; }
        public int isFollow { get; set; }
        public string after7Day { get; set; }
        public string after14Day { get; set; }
        public object productTimeCreated { get; set; }
        public object differenceOfPrice { get; set; }
        public string differenceOfPriceDateCode { get; set; }
        public object differenceOfPricePercent { get; set; }
        public string commentCnt { get; set; }
        public string before7Comment { get; set; }
        public string score { get; set; }
        public string brand { get; set; }
        public string bsrRank { get; set; }
        public string bsrCategory { get; set; }
        public string sellerType { get; set; }
        public string offerCnt { get; set; }
    }

    public class VotoboResult
    {
        public bool success { get; set; }
        public List<Html> html { get; set; }
        public object signHtml { get; set; }
        public int count { get; set; }
        public string memberId { get; set; }
    }
}