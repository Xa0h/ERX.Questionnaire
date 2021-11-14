using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class PersonalInfo
    {
        public PersonalInfo()
        {
            HomeAddresses = new HashSet<HomeAddress>();
            WorkAddresses = new HashSet<WorkAddress>();
            WorkInfos = new HashSet<WorkInfo>();
        }

        public long UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CountryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<HomeAddress> HomeAddresses { get; set; }
        public virtual ICollection<WorkAddress> WorkAddresses { get; set; }
        public virtual ICollection<WorkInfo> WorkInfos { get; set; }
    }
}
