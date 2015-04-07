using System;
using System.Collections.Generic;

namespace SW.Core.Exceptions
{
    public class CwException : Exception
    {
        public IEnumerable<string> Erros { get; set; }

        public CwException(string message) : base(message)
        {
            Erros = new List<string>(){ message };
        }

        public CwException(IEnumerable<string> messages) : base(string.Join(", ", messages))
        {
            Erros = messages;
        }
    }
}
