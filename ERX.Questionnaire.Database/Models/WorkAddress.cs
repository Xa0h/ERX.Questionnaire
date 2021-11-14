using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class WorkAddress
    {
        public long WorkAddressId { get; set; }
        public long? UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual PersonalInfo User { get; set; }
    }
}
