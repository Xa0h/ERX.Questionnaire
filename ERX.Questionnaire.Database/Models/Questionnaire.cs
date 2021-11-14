using System;
using System.Collections.Generic;

#nullable disable

namespace ERX.Questionnaire.Database.Models
{
    public partial class Questionnaire
    {
        public long QuestionnaireId { get; set; }
        public string Question { get; set; }
        public short GroupId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual QuestionnaireGroup Group { get; set; }
    }
}
