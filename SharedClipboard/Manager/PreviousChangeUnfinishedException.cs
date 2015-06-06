using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Manager
{
    class PreviousChangeUnfinishedException : Exception
    {
        public PreviousChangeUnfinishedException(string message) : base(message) { }
    }
}
