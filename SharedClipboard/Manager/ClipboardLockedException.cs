using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Manager
{
    class ClipboardLockedException : Exception
    {
        public ClipboardLockedException(string message) : base(message) { }
    }
}
