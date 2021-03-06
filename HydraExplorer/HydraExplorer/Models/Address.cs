using System;
using System.Collections.Generic;
using System.Text;

namespace HydraExplorer.Models
{
    public class Address
    {
        public string balance { get; set; }
        public string totalReceived { get; set; }
        public string totalSent { get; set; }
        public string unconfirmed { get; set; }
        public string staking { get; set; }
        public string mature { get; set; }
        public List<Qrc20Balances> qrc20Balances { get; set; }
        public List<Qrc721Balances> qrc721Balances { get; set; }
        public int ranking { get; set; }
        public int transactionCount { get; set; }
        public int blocksMined { get; set; }

        public decimal balanceHydra
        {
            get
            {
                if (decimal.TryParse(balance, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }

        public decimal receivedHydra
        {
            get
            {
                if (decimal.TryParse(totalReceived, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }

        public decimal sentHydra
        {
            get
            {
                if (decimal.TryParse(totalSent, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }

        public decimal stakingHydra
        {
            get
            {
                if (decimal.TryParse(staking, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }
    }

    public class Qrc20Balances
    {
        public string address { get; set; }
        public string addressHex { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int decimals { get; set; }
        public string balance { get; set; }
        public decimal balanceToken
        {
            get
            {
                if (decimal.TryParse(balance, out decimal result))
                {
                    return result / (decimal)Math.Pow(10, decimals);
                }
                return 0;
            }
        }
    }

    public class Qrc721Balances
    {
        public string address { get; set; }
        public string addressHex { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int count { get; set; }
    }
}
