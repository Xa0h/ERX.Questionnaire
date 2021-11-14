using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class WorkInfo
    {
        public int BusinessId { get; set; }
        public long? UserId { get; set; }
        public int? OccupationId { get; set; }
        public string JobType { get; set; }
        public string BusinessType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual Occupation Occupation { get; set; }
        public virtual PersonalInfo User { get; set; }
    }
}
