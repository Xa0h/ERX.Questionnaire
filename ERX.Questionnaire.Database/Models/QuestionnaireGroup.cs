using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class QuestionnaireGroup
    {
        public QuestionnaireGroup()
        {
            Questionnaires = new HashSet<Questionnaire>();
        }

        public short GroupId { get; set; }
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
        public short Order { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
