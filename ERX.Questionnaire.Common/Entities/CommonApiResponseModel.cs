using System;
using System.Collections.Generic;
using System.Text;

namespace ERX.Questionnaire.Common.Entities
{
    public class CommonApiResponseModel<T, V>
    {
        /// <summary>
        /// Did the request successfully validate and perform business actions.
        /// </summary>
        public bool IsRequestSuccess { get; set; }

        /// <summary>
        /// A model to describe the error that occoured.
        /// </summary>
        public V Validations { get; set; }

        /// <summary>
        /// A model to describe the exception that occoured.
        /// </summary>
        public object Exceptions { get; set; }

        /// <summary>
        /// The response model specific to the request.
        /// </summary>
        public T Response { get; set; }
    }
}
