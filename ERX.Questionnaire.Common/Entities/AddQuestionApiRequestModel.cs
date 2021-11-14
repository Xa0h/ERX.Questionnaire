using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class AddQuestionApiRequestModel
    {
        public string Question { get; set; }
        public short GroupId { get; set; }
        public int OrderId { get; set; }
    }
}
