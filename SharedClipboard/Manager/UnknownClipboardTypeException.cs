using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Manager
{
    public class UnknownClipboardTypeException : Exception
    {
        public UnknownClipboardTypeException(string message) : base(message) { }
    }
}
