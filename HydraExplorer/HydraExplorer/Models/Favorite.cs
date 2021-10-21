using System;
using System.Collections.Generic;
using System.Text;

namespace HydraExplorer.Models
{
    public class Favorite
    {
        public const string keyFavorites = "keyFavorites";
        public string SearchType { get; set; }
        public string Value { get; set; }
        public string ValueHex { get; set; }
    }
}
