using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PrimaryTypes
{
    public class BoothReport
    {

        public string PanchayatName { get; set; }

        public int BoothCount { get; set; }

        public int Votes { get; set; }

        public int HamletsCount { get; set; }

        public string HamletsList { get; set; }

        public string UnionBlocks { get; set; }

        public string Scope { get; set; }

    }
}
