using System;
using System.Collections.Generic;
using System.Text;

namespace HydraExplorer.Models
{
    public class Search
    {
        public const string typeAddress = "address";
        public const string typeBlock = "block";
        public const string typeTransaction = "transaction";
        public const string typeContract = "contract";
        public string type { get; set; }
        public string address { get; set; }
        public string addressHex { get; set; }
    }
}
