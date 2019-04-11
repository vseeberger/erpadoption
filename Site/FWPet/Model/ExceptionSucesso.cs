using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FWPet.Model
{
    public class ExceptionSucesso : System.Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ExceptionSucesso() : base() { }

        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        public ExceptionSucesso(String message) : base(message) { }

        /// <summary>
        /// Argument constructor with inner exception
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        /// <param name="innerException">Inner exception</param>
        public ExceptionSucesso(String message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Argument constructor with serialization support
        /// </summary>
        /// <param name="info">Instance of SerializationInfo</param>
        /// <param name="context">Instance of StreamingContext</param>
        protected ExceptionSucesso(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
