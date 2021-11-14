using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class AddPersonalInfoApiResponseModel
    {
        public long? UserId { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
