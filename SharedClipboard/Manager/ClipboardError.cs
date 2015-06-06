using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Manager
{
    public class ErrorReason
    {
        public static const string LOCKED = "locked";
        public static const string TIMEOUT = "timeout";
        public static const string NOT_REQUESTED = "not_requested";
    }

    public class ClipboardError
    {
        public string Id { get; set; }
        public string Reason { get; set; }
    }
}
