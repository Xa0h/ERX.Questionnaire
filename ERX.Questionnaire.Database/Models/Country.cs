using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class Country
    {
        public Country()
        {
            PersonalInfos = new HashSet<PersonalInfo>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelectionPermitted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual ICollection<PersonalInfo> PersonalInfos { get; set; }
    }
}
