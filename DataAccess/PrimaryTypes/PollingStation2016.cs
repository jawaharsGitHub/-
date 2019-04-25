using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PrimaryTypes
{
    public class PollingStation2016 : BaseClass
    {
        private static string JsonFilePath = AppConfiguration.PollingStationFile;

        public int SlNo { get; set; }

        public int PollingStationId { get; set; }

        public string Location { get; set; }

        public string PollingArea { get; set; }

        public string Gender { get; set; }

        public int AssemblyNo { get; set; }

        public int ParlimentaryNo { get; set; }

        public static List<PollingStation2016> GetAll()
        {
            return ReadFileAsObjects<PollingStation2016>(JsonFilePath);
        }
    }
}
