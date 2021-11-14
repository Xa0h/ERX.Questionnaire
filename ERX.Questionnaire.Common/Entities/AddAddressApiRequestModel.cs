using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class AddAddressApiRequestModel
    {
        public long UserId { get; set; }
        public AddressApiRequestModel HomeAddress { get; set; }
        public AddressApiRequestModel WorkAddress { get; set; }
    }
}
