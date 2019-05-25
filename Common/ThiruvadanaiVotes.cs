using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{


    public class ThiruvadanaiVotes
    {
        public int PartNo;
        public string pollingStation;
        public string BoothAdress;
        public int TotalVotes;
        public int PolledVotes;
        public int NTKVotes2019;
        public decimal NTKpercentage;
        public string Panchayat;
        public string UnionBlocks;
        public string Hamlets;

        public ThiruvadanaiVotes(string csvLine)
        {
            string[] values = csvLine.Split(',');
            //ThiruvadanaiVotes dailyValues = new ThiruvadanaiVotes();
            PartNo = Convert.ToInt32(values[0].Split('-')[0]);
            pollingStation = values[1];
            BoothAdress = values[6];
            TotalVotes = Convert.ToInt32(values[3]);
            PolledVotes = Convert.ToInt32(values[4]);
            NTKVotes2019 = Convert.ToInt32(values[2]);
            NTKpercentage = Convert.ToInt32(values[5]);
            Panchayat = values[7];
            UnionBlocks = values[8];
            Hamlets = values[9];

            //return dailyValues;
        }
    }
}
