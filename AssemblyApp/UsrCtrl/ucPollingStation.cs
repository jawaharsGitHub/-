using System;
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

namespace CenturyFinCorpApp.UsrCtrl
{
    public partial class ucPollingStation : UserControl
    {
        List<PollingStation> pollingStations;

        List<BoothReport> boothReport;

        public ucPollingStation()
        {
            InitializeComponent();

            pollingStations = PollingStation.GetAll();

            dataGridView1.DataSource = pollingStations;

            cmbAssembly.DataSource = Assembly.GetAll();

            cmbReports.DataSource = GetOptions();

            cmbAssembly.SelectedValue = 210;

            cmbUnionBlocks.DataSource = pollingStations.Select(s => s.UnionBlocks).Distinct().ToList();

        }

        public static List<KeyValuePair<int, string>> GetOptions()
        {
            var myKeyValuePair = new List<KeyValuePair<int, string>>()
               {
                new KeyValuePair<int, string>(0, "ALL"),
                   new KeyValuePair<int, string>(1, "Reports"),
                   new KeyValuePair<int, string>(2, "By Votes"),
                   new KeyValuePair<int, string>(3, "By Booths"),
                   new KeyValuePair<int, string>(4, "By Hamlets"),
                   new KeyValuePair<int, string>(10, "Return By Yesterday"),
                   new KeyValuePair<int, string>(5, "Return By Today"),
                   new KeyValuePair<int, string>(6, "Return By Tomorrow"),
                   new KeyValuePair<int, string>(7, "By Return Day"),
                   new KeyValuePair<int, string>(8, "By Return Type"),
                   new KeyValuePair<int, string>(9, "By CollectionSpot")

               };

            return myKeyValuePair;

        }

        private void cmbAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ps = pollingStations.Where(w => w.PartNo.Substring(0, 3).ToInt32() == cmbAssembly.SelectedValue.ToInt32()).ToList();

            dataGridView1.DataSource = ps;


            label1.Text = $"{ps.Count} Polling Stations";
        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (customers == null) return;
            var value = ((KeyValuePair<int, string>)cmbReports.SelectedItem).Key;
            List<PollingStation> searchedPollingStations;



            if (value == 1)
            {
                var data = (from p in pollingStations
                            group p by p.Panchayat.Trim() into newGroup
                            select new BoothReport
                            {
                                PanchayatName = newGroup.Key,
                                BoothCount = newGroup.Count(),
                                Votes = newGroup.Sum(s => s.TotalVotes),
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




                            }).DistinctBy(d => d.PanchayatName).ToList();

                var mergedStations = (from p in pollingStations
                                      group p by p.PartNo into newGroup
                                      where newGroup.Count() > 1
                                      select newGroup).ToList();

                boothReport = data.ToList();
                dataGridView1.DataSource = boothReport;
            }

            else if (value == 2)
            {

                dataGridView1.DataSource = boothReport.OrderByDescending(o => o.Votes).ToList();
            }
            else if (value == 3)
            {

                dataGridView1.DataSource = boothReport.OrderByDescending(o => o.BoothCount).ToList();
            }
            else if (value == 4)
            {

                dataGridView1.DataSource = boothReport.OrderByDescending(o => o.HamletsCount).ToList();
            }

        }

        private void cmbScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = boothReport.Where(w => w.Scope == cmbScope.Text).ToList();

        }

        private void cmbUnionBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = boothReport.Where(w => w.UnionBlocks.Trim() == cmbUnionBlocks.Text.Trim()).OrderByDescending(o => o.Votes).ToList();

        }
    }
}
