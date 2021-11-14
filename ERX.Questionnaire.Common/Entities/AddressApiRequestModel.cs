using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class AddressApiRequestModel
    {
        public string AddressLine1 { get; set; }
        public string Postcode { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
