using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class CountryResponseModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsSelectionPermitted { get; set; }
    }
}
