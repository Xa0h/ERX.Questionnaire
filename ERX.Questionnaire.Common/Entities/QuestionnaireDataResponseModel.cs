using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class QuestionnaireDataResponseModel
    {
        public long  QuestionId { get; set; }
        public string Question { get; set; }
        public int OrderId { get; set; }
    }
}
