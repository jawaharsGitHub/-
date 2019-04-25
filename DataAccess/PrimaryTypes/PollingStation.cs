using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PrimaryTypes
{
    public class PollingStation : BaseClass
    {

        private static string JsonFilePath = AppConfiguration.PollingStationFile;

        public string PartNo { get; set; }
        public string pollingStation { get; set; }
        public string BoothAdress { get; set; }
        public string RevenueVillage { get; set; }
        public string Panchayat { get; set; }
        public string UnionBlocks { get; set; }
        public string Hamlets { get; set; }
        public int? Male { get; set; }
        public int? Female { get; set; }
        public int? ThirdGender { get; set; }
        public int TotalVotes { get; set; }
        public string MainTownOrVillage { get; set; }
        public string Mandalam { get; set; }
        public string Birga { get; set; }
        public string PoliceStation { get; set; }
        public string Taluk { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }
        public string Status { get; set; }
        public string OverlapPartNo { get; set; }
        public string Scope { get; set; }




        public static List<PollingStation> GetAll()
        {
            return ReadFileAsObjects<PollingStation>(JsonFilePath);
        }

    }
}
