using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            WorkInfos = new HashSet<WorkInfo>();
        }

        public int OccupationId { get; set; }
        public string OccupationType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual ICollection<WorkInfo> WorkInfos { get; set; }
    }
}
