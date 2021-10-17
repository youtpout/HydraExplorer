using System;
using System.Collections.Generic;
using System.Text;

namespace HydraExplorer.Models
{
    public class Info
    {
        public int height { get; set; }
        public double supply { get; set; }
        public long netStakeWeight { get; set; }
        public double feeRate { get; set; }
        public string gasPrice { get; set; }
        public string circulatingSupply { get; set; }
        public string APR { get; set; }
    }
}
