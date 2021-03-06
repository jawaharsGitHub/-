﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.PrimaryTypes;
using Common.ExtensionMethod;
using System.IO;
using System.Diagnostics;

namespace CenturyFinCorpApp.UsrCtrl
{
    public partial class ucPollingStation : UserControl
    {
        List<AssemblyResult> pollingStations;

        List<BoothReport> boothReport;

        public ucPollingStation()
        {
            InitializeComponent();


            cmbAssembly.DataSource = Assembly.GetAll();

            cmbReports.DataSource = GetOptions();

            this.cmbAssembly.SelectedIndexChanged += new System.EventHandler(this.cmbAssembly_SelectedIndexChanged);
            //cmbAssembly.SelectedValue = 210;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        public static List<KeyValuePair<int, string>> GetOptions()
        {
            var myKeyValuePair = new List<KeyValuePair<int, string>>()
               {
                new KeyValuePair<int, string>(0, "ALL"),
                   new KeyValuePair<int, string>(1, "By Panchayats"),
                   new KeyValuePair<int, string>(2, "By Ondrium"),
                   new KeyValuePair<int, string>(3, "> 100 votes"),
                   new KeyValuePair<int, string>(4, "> 50 votes"),
                   //new KeyValuePair<int, string>(5, "TEST"),
                   //new KeyValuePair<int, string>(6, "Return By Tomorrow"),
                   //new KeyValuePair<int, string>(7, "By Return Day"),
                   //new KeyValuePair<int, string>(8, "By Return Type"),
                   //new KeyValuePair<int, string>(9, "By CollectionSpot")

               };

            return myKeyValuePair;

        }

        private void cmbAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {

            pollingStations = PollingStation.GetAll(cmbAssembly.SelectedValue); // ?? 210);

            dataGridView1.DataSource = pollingStations;



            var data = (from p in pollingStations
                        group p by p.Panchayat.Trim() into newGroup
                        select new BoothReport
                        {
                            PanchayatName = newGroup.Key,
                            BoothCount = newGroup.Count(),
                            TotalVotes = newGroup.Sum(s => s.TotalVotes),
                            PolledVotes = newGroup.Sum(s => s.PolledVotes),
                            NTKVotes2019 = newGroup.Sum(s => s.NTKVotes2019),
                            NTKpercentage = Math.Round(Convert.ToDouble(newGroup.Sum(s => s.NTKVotes2019)) / Convert.ToDouble(newGroup.Sum(s => s.PolledVotes)) * 100, 1),

                            HamletsCount = (from x in newGroup.ToList()
                                            let h = x.Hamlets.Split('\n')
                                            select h.Where(w => string.IsNullOrEmpty(w.Trim()) == false).Count()).Sum(),
                            HamletsList =
                                         string.Join(Environment.NewLine, (from x in newGroup.ToList()
                                                                           let h = x.Hamlets.Split('\n')
                                                                           let m = string.Join(Environment.NewLine, h.Where(w => string.IsNullOrEmpty(w.Trim()) == false).ToArray())
                                                                           select m).ToArray()),
                            UnionBlocks = newGroup.ToList().First().UnionBlocks,
                            Scope = newGroup.ToList().First().Scope




                        }).OrderByDescending(o => o.NTKpercentage).ToList();
            //DistinctBy(d => d.PanchayatName).ToList();


            boothReport = data.ToList();
            cmbUnionBlocks.DataSource = pollingStations.Select(s => s.UnionBlocks).Distinct().ToList();

            var ps = pollingStations.Where(w => w.NTKVotes2019 != null).ToList(); // pollingStations.Where(w => w.PartNo == cmbAssembly.SelectedValue.ToInt32()).ToList();

            var scope1 = ps.Where(w => w.Scope == 1).ToList().Count;


            dataGridView1.DataSource = ps;

            var mergedPS = (from p in ps
                            group p by p.PartNo into newGroup
                            where newGroup.Count() > 1
                            select newGroup.Count() - 1).Sum();



            label1.Text = $"{ps.Count - mergedPS} Polling Booth";
        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = ((KeyValuePair<int, string>)cmbReports.SelectedItem).Key;

            if(value == 0)
            {
                pollingStations = PollingStation.GetAll(cmbAssembly.SelectedValue); // ?? 210);
                dataGridView1.DataSource = pollingStations;

                label1.Text = $"{pollingStations.Count} Record(s)";


            }
            if (value == 1)
            {
                dataGridView1.DataSource = boothReport;
                label1.Text = $"{boothReport.Count} Record(s)";

                //var totalVotes = boothReport.Sum(s => s.Votes);

                //var scope1Votes = boothReport.Where(w => w.Scope == "1").Sum(s => s.Votes);

                //var REMAININGvOTES = totalVotes - scope1Votes;


                //var totalHamlets = boothReport.Sum(s => s.HamletsCount);

                //var scope1Hamlets = boothReport.Where(w => w.Scope == "1").Sum(s => s.HamletsCount);


            }

            else if (value == 2)
            {

                var data = (from p in pollingStations
                            group p by p.UnionBlocks.Trim() into newGroup
                            select new // BoothReport
                            {
                                UnionBlocks = newGroup.Key,
                                //BoothCount = newGroup.Count(),
                                TotalVotes = newGroup.Sum(s => s.TotalVotes),
                                PolledVotes = newGroup.Sum(s => s.PolledVotes),
                                NTKVotes2019 = newGroup.Sum(s => s.NTKVotes2019),
                                NTKpercentage = Math.Round(Convert.ToDouble(newGroup.Sum(s => s.NTKVotes2019)) / Convert.ToDouble(newGroup.Sum(s => s.PolledVotes)) * 100, 1),

                                HamletsCount = (from x in newGroup.ToList()
                                                let h = x.Hamlets.Split('\n')
                                                select h.Where(w => string.IsNullOrEmpty(w.Trim()) == false).Count()).Sum(),
                                HamletsList =
                                             string.Join(Environment.NewLine, (from x in newGroup.ToList()
                                                                               let h = x.Hamlets.Split('\n')
                                                                               let m = string.Join(Environment.NewLine, h.Where(w => string.IsNullOrEmpty(w.Trim()) == false).ToArray())
                                                                               select m).ToArray()),
                                //UnionBlocks = newGroup.ToList().First().UnionBlocks,
                                //Scope = newGroup.ToList().First().Scope




                            }).OrderByDescending(o => o.NTKpercentage).ToList();

                dataGridView1.DataSource = data;
                label1.Text = $"{data.Count} Record(s)";
            }
            else if (value == 3)
            {

                var data = pollingStations.Where(w => w.NTKVotes2019 > 100).OrderByDescending(o => o.NTKpercentage).ToList();
                dataGridView1.DataSource = data;
                label1.Text = $"{data.Count} Record(s)";
            }
            else if (value == 4)
            {
                var data = pollingStations.Where(w => w.NTKVotes2019 > 50).OrderByDescending(o => o.NTKpercentage).ToList();
                dataGridView1.DataSource = data;
                label1.Text = $"{data.Count} Record(s)";
            }

            //label1.Text = $"{boothReport.Count} Panchayats";

        }

        private void cmbScope_SelectedIndexChanged(object sender, EventArgs e)
        {

            var scopedData = boothReport.Where(w => w.Scope == cmbScope.Text.ToInt32()).OrderByDescending(o => o.TotalVotes).ToList();
            dataGridView1.DataSource = scopedData;
            label1.Text = $"{scopedData.Count} Panchayats";
        }

        private void cmbUnionBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filteresData = boothReport.Where(w => w.UnionBlocks.Trim() == cmbUnionBlocks.Text.Trim()).OrderByDescending(o => o.TotalVotes).ToList();
            dataGridView1.DataSource = filteresData;
            label1.Text = $"{filteresData.Count()} Panchayats";


        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SaveToTxt();
        }

        public void SaveToTxt()
        {

            string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            int serialNo = 0;

            var data = boothReport.Where(w => w.UnionBlocks == cmbUnionBlocks.SelectedValue.ToString()).ToList();

            var fileName = cmbUnionBlocks.SelectedValue.ToString();

            using (TextWriter tw = new StreamWriter(Path.Combine(docPath, $"{fileName}.txt")))
            {
                foreach (var item in data)
                {
                    serialNo += 1;
                    tw.WriteLine(string.Format($"{serialNo}.{item.PanchayatName}(வார்டு - {item.HamletsCount} ஓட்டு - {item.TotalVotes}) {Environment.NewLine}------------------------------------------------------------{Environment.NewLine}"));

                    int hamletNo = 0;
                    foreach (var ham in item.HamletsList.Split('\n'))
                    {
                        hamletNo += 1;
                        tw.WriteLine($"{hamletNo}.{ham}");
                    }

                    tw.WriteLine(Environment.NewLine);
                }
            }


            Process.Start(Path.Combine(docPath, $"{fileName}.txt"));


        }

        private void btnBoothReport_Click(object sender, EventArgs e)
        {

            pollingStations = PollingStation.GetAll(cmbAssembly.SelectedValue ?? 210);

            var data = (from ps in pollingStations
                        group ps by ps.BoothGroupNo into newGroup
                        select newGroup).ToList();

            //StringBuilder sb = new StringBuilder();

            string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(docPath, $"{data.ToList().First().ToList().First().Panchayat}-Boothwise.txt");


            using (TextWriter tw = new StreamWriter(fileName))
            {
                data.ForEach(d =>
                    {
                        var tt = d.Count() > 1 ? "கள்" : "";
                        tw.WriteLine($"{d.First().pollingStation} ({d.Count()} வாக்கு சாவடி{tt} {d.Sum(s => s.TotalVotes)} ஓட்டுகள்)");
                        tw.WriteLine($"---------------------------------------------------------");

                        d.ToList().ForEach(fe =>
                        {
                            tw.WriteLine($"பாகம்:{fe.PartNo} - {fe.BoothAdress} ({fe.TotalVotes} ஓட்டுகள்)");

                        });

                        tw.WriteLine(Environment.NewLine);

                    }
            );

            }

            Process.Start(fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
