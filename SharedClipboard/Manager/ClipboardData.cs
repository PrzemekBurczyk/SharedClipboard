using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClipboard.Manager
{
    public enum ClipboardDataType
    {
        TEXT, IMAGE, FILES
    }

    public class ClipboardData
    {
        public string Sender { get; set; }
        public string Data { get; set; }
        public ClipboardDataType Type { get; set; }
        public string Id { get; set; }
    }

    public class ClipboardFile
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
