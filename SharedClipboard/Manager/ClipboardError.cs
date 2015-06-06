using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Manager
{
    public class ErrorReason
    {
        public const string LOCKED = "locked";
        public const string TIMEOUT = "timeout";
        public const string NOT_REQUESTED = "not_requested";
    }

    public class ClipboardError
    {
        public string Id { get; set; }
        public string Reason { get; set; }
    }
}
