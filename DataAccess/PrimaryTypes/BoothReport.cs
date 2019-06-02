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

        public int? TotalVotes { get; set; }

        public int? PolledVotes { get; set; }
        public int? NTKVotes2019 { get; set; }
        public double? NTKpercentage { get; set; }

        public int HamletsCount { get; set; }

        public string HamletsList { get; set; }

        public string UnionBlocks { get; set; }

        public int? Scope { get; set; }

    }
}
