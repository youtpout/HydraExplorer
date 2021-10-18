using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HydraExplorer.Models
{
    public class Transaction
    {
        public string id { get; set; }
        public List<Input> inputs { get; set; }
        public List<Output> outputs { get; set; }
        public bool isCoinbase { get; set; }
        public bool isCoinstake { get; set; }
        public int blockHeight { get; set; }
        public int confirmations { get; set; }
        public int timestamp { get; set; }
        public string inputValue { get; set; }
        public string outputValue { get; set; }
        public string refundValue { get; set; }
        public string fees { get; set; }

        public string cutId { get { return string.Join("", id.Take(20)) + "..."; } }

        public decimal txHydra
        {
            get
            {
                if (decimal.TryParse(outputValue, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }
    }

    public class ScriptSig
    {
        public string type { get; set; }
    }

    public class Input
    {
        public string prevTxId { get; set; }
        public int outputIndex { get; set; }
        public string value { get; set; }
        public string address { get; set; }
        public string addressHex { get; set; }
        public ScriptSig scriptSig { get; set; }
    }

    public class ScriptPubKey
    {
        public string type { get; set; }
    }

    public class Output
    {
        public string value { get; set; }
        public string address { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
        public string addressHex { get; set; }
    }

}
