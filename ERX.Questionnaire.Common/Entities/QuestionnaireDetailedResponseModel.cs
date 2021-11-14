using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class QuestionnaireDetailedResponseModel
    {
        public PersonalInfoResponseModel PersonalInfo { get; set; }
        public AddressInfoResponseModel HomeAddress { get; set; }
        public AddressInfoResponseModel WorkAddress { get; set; }
        public WorkInfoResponseModel WorkInfo { get; set; }
    }
}
