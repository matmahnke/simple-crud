using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    [Serializable]
    public class PutsException : Exception
    {
        private List<ErrorField> errors;

        public PutsException(List<ErrorField> errors)
        {
            this.errors = errors;
        }

        public List<ErrorField> GetErrors()
        {
            return this.errors;
        }

        public string GetMessages()
        {
            StringBuilder builder = new StringBuilder();
            foreach (ErrorField item in errors)
            {
                builder.AppendLine(item.Message);
            }
            return builder.ToString();
        }

        public PutsException() { }
        public PutsException(string message) : base(message) { }
        public PutsException(string message, Exception inner) : base(message, inner) { }
        protected PutsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
