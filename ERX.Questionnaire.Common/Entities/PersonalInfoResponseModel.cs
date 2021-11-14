using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class PersonalInfoResponseModel
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public bool IsSelectionPermitted { get; set; }
    }
}
