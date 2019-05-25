using CenturyFinCorpApp.UsrCtrl;
using Common;
using DataAccess;
using DataAccess.ExtendedTypes;
using DataAccess.PrimaryTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CenturyFinCorpApp
{
    public partial class frmIndexForm : Form
    {

        bool usingMenu = false;
        bool isAdded = false; // for child forms
        public static MenuStrip menuStrip;

        public frmIndexForm()
        {

            InitializeComponent();

            // Read CSV.

            var resultData = AssemblyResult.GetAll()
                //.Where(w => w.NTKVotes2019 != null) // this is for thiruvaadanai
                .ToList();

            // 1. all booth level

            var PartNo = new StringBuilder();
            var pollingStation = new StringBuilder();
            var TotalVotes = new StringBuilder();
            var PolledVotes = new StringBuilder();
            var NTKVotes2019 = new StringBuilder();
            var NTKpercentage = new StringBuilder();
            var Panchayat = new StringBuilder();
            var UnionBlocks = new StringBuilder();
            var Hamlets = new StringBuilder();

            resultData.ForEach(fe =>
            {

                //PartNo.AppendLine($"{fe.PartNo.Split('-')[1]}");
                PartNo.AppendLine($"{fe.PartNo}");
                pollingStation.AppendLine($"{fe.pollingStation}");
                TotalVotes.AppendLine($"{fe.TotalVotes}");
                PolledVotes.AppendLine($"{fe.PolledVotes}");
                NTKVotes2019.AppendLine($"{fe.NTKVotes2019}");
                NTKpercentage.AppendLine($"{fe.NTKpercentage}");
                Panchayat.AppendLine($"{fe.Panchayat}");
                UnionBlocks.AppendLine($"{fe.UnionBlocks}");
                Hamlets.AppendLine($"{fe.Hamlets}");
            });

            //WriteToFile("partNoByBooth.txt", PartNo);
            //WriteToFile("pollingStationByBootht.txt", pollingStation);
            //WriteToFile("TotalVotesByBooth.txt", TotalVotes);
            //WriteToFile("PolledVotesByBooth.txt", PolledVotes);
            //WriteToFile("NTKVotes2019ByBooth.txt", NTKVotes2019);
            //WriteToFile("NTKpercentageByBooth.txt", NTKpercentage);
            //WriteToFile("PanchayatByBooth.txt", Panchayat);
            //WriteToFile("UnionBlocksByBooth.txt", UnionBlocks);
            ////WriteToFile("HamletsByPanchayat.txt", Hamlets);



            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            



            // 2. panchayat level

            //var testdata = resultData.Where(w => w.Panchayat == "களமzz")

            var panGrouped = (from pan in resultData
                              group pan by pan.Panchayat into newGroup
                              select new
                              {
                                  Panchayat = newGroup.Key,
                                  TotalVotes = newGroup.Sum(s => s.TotalVotes),
                                  PolledVotes = newGroup.Sum(s => s.PolledVotes),
                                  NTKVotes = newGroup.Sum(s => s.NTKVotes2019),
                                  percent = Math.Round(Convert.ToDouble(newGroup.Sum(s => s.NTKVotes2019)) / Convert.ToDouble(newGroup.Sum(s => s.PolledVotes)) * 100, 1)

                              }).OrderByDescending(o => o.percent).ToList();


            PartNo.Clear();
            pollingStation.Clear();
            TotalVotes.Clear();
            PolledVotes.Clear();
            NTKVotes2019.Clear();
            NTKpercentage.Clear();
            Panchayat.Clear();
            UnionBlocks.Clear();
            Hamlets.Clear();


            panGrouped.ForEach(fe =>
            {
                Panchayat.AppendLine($"{fe.Panchayat}");
                TotalVotes.AppendLine($"{fe.TotalVotes}");
                PolledVotes.AppendLine($"{fe.PolledVotes}");
                NTKVotes2019.AppendLine($"{fe.NTKVotes}");
                NTKpercentage.AppendLine($"{fe.percent}");
            });


            WriteToFile("partNoByPanchayat.txt", PartNo);
            WriteToFile("pollingStationByPanchayat.txt", pollingStation);
            WriteToFile("TotalVotesByPanchayat.txt", TotalVotes);
            WriteToFile("PolledVotesByPanchayat.txt", PolledVotes);
            WriteToFile("NTKVotes2019ByPanchayat.txt", NTKVotes2019);
            WriteToFile("NTKpercentageByPanchayat.txt", NTKpercentage);
            WriteToFile("PanchayatByPanchayat.txt", Panchayat);
            WriteToFile("UnionBlocksByPanchayat.txt", UnionBlocks);
            //WriteToFile("HamletsByPanchayat.txt", Hamlets);



            // 3. Ondrium level

            var OndriumGrouped = (from pan in resultData
                                  group pan by pan.UnionBlocks into newGroup
                                  select new
                                  {
                                      Union = newGroup.Key,
                                      TotalVotes = newGroup.Sum(s => s.TotalVotes),
                                      PolledVotes = newGroup.Sum(s => s.PolledVotes),
                                      NTKVotes = newGroup.Sum(s => s.NTKVotes2019),
                                      percent = Math.Round(Convert.ToDouble(newGroup.Sum(s => s.NTKVotes2019)) / Convert.ToDouble(newGroup.Sum(s => s.PolledVotes)) * 100, 1)

                                  }).OrderByDescending(o => o.percent).ToList();


            PartNo.Clear();
            pollingStation.Clear();
            TotalVotes.Clear();
            PolledVotes.Clear();
            NTKVotes2019.Clear();
            NTKpercentage.Clear();
            Panchayat.Clear();
            UnionBlocks.Clear();
            Hamlets.Clear();


            OndriumGrouped.ForEach(fe =>
            {
                Panchayat.AppendLine($"{fe.Union}");
                TotalVotes.AppendLine($"{fe.TotalVotes}");
                PolledVotes.AppendLine($"{fe.PolledVotes}");
                NTKVotes2019.AppendLine($"{fe.NTKVotes}");
                NTKpercentage.AppendLine($"{fe.percent}");
            });

            WriteToFile("PanchayatByOndrium.txt", Panchayat);
            WriteToFile("TotalVotesByOndrium.txt", TotalVotes);
            WriteToFile("PolledVotesByOndrium.txt", PolledVotes);
            WriteToFile("NTKVotes2019ByOndrium.txt", NTKVotes2019);
            WriteToFile("NTKpercentageByOndrium.txt", NTKpercentage);





            string[] filePaths = Directory.GetFiles(@"C:\Jawahar\RMD and TVD voters list", "*.PDF",
                                         SearchOption.AllDirectories);

            var data = new List<string>();

            foreach (var item in filePaths)
            {
                data.Add(new FileInfo(item).Name);

            }

            var newData = data.OrderBy(o => o);

            StringBuilder ss = new StringBuilder();

            foreach (var i in newData)
            {
                ss.AppendLine(i);

            }

            var result = ss.ToString();



            this.Text = "நாம் தமிழர் - 2019";
            this.AutoScrollOffset = new Point(0, 0);

            CreateMenu();

            panel1.Width = 1300;
            panel1.Height = this.Height;

            ShowForm<ucZonal>(); // initial form to be loaded
        }


        private void WriteToFile(string fileName, StringBuilder content)
        {
            using (TextWriter tw = new StreamWriter(fileName))
            {
                tw.WriteLine(content.ToString());
            }

            Process.Start(fileName);
        }

        private void CreateMenu()
        {
            // Menu
            menuStrip = new MenuStrip
            {
                Location = new Point(0, 0),
                Name = "MenuStrip"
            };




            var mnuZonal = new ToolStripMenuItem() { Name = "zonal", Text = "மண்டலம்" };
            mnuZonal.Click += (s, e) => ShowForm<ucZonal>(); ;
            menuStrip.Items.Add(mnuZonal);

            var mnuDistrict = new ToolStripMenuItem() { Name = "district", Text = "மாவட்டம்" };
            mnuDistrict.Click += (s, e) => ShowForm<ucDistrict>(); ;
            menuStrip.Items.Add(mnuDistrict);


            var mnuAssembly = new ToolStripMenuItem() { Name = "assembly", Text = "சட்டமன்ற-தொகுதி" };
            mnuAssembly.Click += (s, e) => ShowForm<ucAssembly>(); ;
            menuStrip.Items.Add(mnuAssembly);

            var mnuPanchayat = new ToolStripMenuItem() { Name = "kilai", Text = "பஞ்சாயத்து-கிளைகள்" };
            mnuPanchayat.Click += (s, e) => ShowForm<ucPanchayat>(); ;
            menuStrip.Items.Add(mnuPanchayat);

            var mnuPollingStation = new ToolStripMenuItem() { Name = "pollingstation", Text = "POLLING_STATION" };
            mnuPollingStation.Click += (s, e) => ShowForm<ucPollingStation>(); ;
            menuStrip.Items.Add(mnuPollingStation);



            var mnuBlock = new ToolStripMenuItem() { Name = "block", Text = "ஒன்றியம்" };
            mnuBlock.Click += (s, e) => ShowForm<ucBlock>(); ;
            menuStrip.Items.Add(mnuBlock);


            //Member
            var mnuMember = new ToolStripMenuItem() { Name = "addMember", Text = "பொறுப்பாளர்கள்" };
            mnuMember.Click += (s, e) => ShowForm<uclAddMember>(); ;
            menuStrip.Items.Add(mnuMember);

            //var mnuDataHelper = new ToolStripMenuItem() { Name = "dataHelper", Text = "DATA-HELPER" };
            //mnuDataHelper.Click += (s, e) => ShowForm<DataHelper>(); ;
            //menuStrip.Items.Add(mnuDataHelper);

            var mnuInternational = new ToolStripMenuItem() { Name = "international", Text = "வெளிநாட்டு-கிளைகள்" };
            mnuInternational.Click += (s, e) => ShowForm<ucInternational>(); ;
            menuStrip.Items.Add(mnuInternational);

            var mnuLocalbody = new ToolStripMenuItem() { Name = "localbody", Text = "உள்ளாட்சி-தேர்தல்" };
            mnuLocalbody.Click += (s, e) => ShowForm<ucLocalBody>(); ;
            menuStrip.Items.Add(mnuLocalbody);

            var mnuAnalysis = new ToolStripMenuItem() { Name = "localbody", Text = "2016-Election" };
            mnuAnalysis.Click += (s, e) => ShowForm<ucVotes>(); ;
            menuStrip.Items.Add(mnuAnalysis);


            this.Controls.Add(menuStrip);
        }


        public void ShowForm<T>(object cus = null) where T : UserControl
        {

            //UserControl ac = null;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
            }

            if (typeof(T) == typeof(ucZonal))
            {
                ucZonal ucZ = new ucZonal();
                panel1.Controls.Add(ucZ);
            }
            else if (typeof(T) == typeof(ucDistrict))
            {
                var zonal = (Zonal)cus;
                var ucd = new ucDistrict(zonal);
                panel1.Controls.Add(ucd);
            }
            else if (typeof(T) == typeof(ucAssembly))
            {
                var dist = (ZonalDistrict)cus;
                var ucd = new ucAssembly(dist); // (zonal);
                panel1.Controls.Add(ucd);
            }
            else if (typeof(T) == typeof(ucBlock))
            {
                //var zonal = (Assembly)cus;
                var ucd = new ucBlock(); // (zonal);
                panel1.Controls.Add(ucd);
            }
            else if (typeof(T) == typeof(ucBlock))
            {
                //var zonal = (Assembly)cus;
                var ucd = new ucBlock(); // (zonal);
                panel1.Controls.Add(ucd);
            }
            else if (typeof(T) == typeof(ucPanchayat))
            {
                var da = (DistrictAssembly)cus;
                var ucd = new ucPanchayat(da); // (zonal);
                panel1.Controls.Add(ucd);
            }
            else if (typeof(T) == typeof(uclAddMember))
            {
                //var da = (DistrictAssembly)cus;
                var ucd = new uclAddMember(); // (zonal);
                panel1.Controls.Add(ucd);
            }

            else if (typeof(T) == typeof(ucVotes))
            {
                //var da = (DistrictAssembly)cus;
                var ucd = new ucVotes(); // (zonal);
                panel1.Controls.Add(ucd);
            }
            else if (typeof(T) == typeof(ucPollingStation))
            {
                //var da = (DistrictAssembly)cus;
                var ucd = new ucPollingStation(); // (zonal);
                panel1.Controls.Add(ucd);
            }
            //else //(cus == null)
            //{
            //    ucZonal ucZ = new ucZonal();
            //    panel1.Controls.Add(ucZ);
            //}



        }

    }
}
