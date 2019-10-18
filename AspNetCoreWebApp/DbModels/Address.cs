using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.DbModels
{
    public partial class Address
    {
        public Address()
        {
            AutoPostAdPostData = new HashSet<AutoPostAdPostData>();
        }

        public int Id { get; set; }
        public string AddressName { get; set; }
        public string PostCode { get; set; }
        public string GeoLatitude { get; set; }
        public string GeoLongitude { get; set; }

        public ICollection<AutoPostAdPostData> AutoPostAdPostData { get; set; }
    }
}
