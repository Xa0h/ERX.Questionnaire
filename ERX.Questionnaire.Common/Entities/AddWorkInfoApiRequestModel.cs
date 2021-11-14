using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class AddWorkInfoApiRequestModel
    {
        public int OccupationId { get; set; }
        public string JobType { get; set; }
        public string BusinessType { get; set; }
        public int UserId { get; set; }
    }
}
