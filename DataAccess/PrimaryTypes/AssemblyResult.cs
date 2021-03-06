﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PrimaryTypes
{
    public class AssemblyResult : BaseClass
    {
        private static string JsonFilePath = AppConfiguration.AssemblyResultFile;


        public int PartNo { get; set; }
        public int? TotalVotes { get; set; }
        public int? PolledVotes { get; set; }
        public int? NTKVotes2019 { get; set; }
        public decimal? NTKpercentage { get; set; }
        public string pollingStation { get; set; }
        public string BoothAdress { get; set; }
        public int? BoothGroupNo { get; set; }
        public string UnionBlocks { get; set; }
        public string Panchayat { get; set; }
        public string Hamlets { get; set; }
        public int? Scope { get; set; }
        


        public static List<AssemblyResult> GetAll()
        {
            var fileName = AppConfiguration.GetDynamicPath(JsonFilePath);
            return ReadFileAsObjects<AssemblyResult>(fileName);
        }
    }

}
