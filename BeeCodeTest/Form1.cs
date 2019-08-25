using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeCodeTest
{
    public partial class Form1 : Form
    {
        List<WorkerBee> workerBeeList = new List<WorkerBee>();
        List<QueenBee> queenBeeList = new List<QueenBee>();
        List<DroneBee> droneBeeList = new List<DroneBee>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workerBees = GetWorkerBeeList();
            var queenBees = GetQueenBeeList();
            var droneBees = GetDroneBeeList();
            PopulateListItems(listView1, workerBees.Cast<Bee>().ToList());
            PopulateListItems(listView2, queenBees.Cast<Bee>().ToList());
            PopulateListItems(listView3, droneBees.Cast<Bee>().ToList());
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var workerBees = GetWorkerBeeList();
            var queenBees = GetQueenBeeList();
            var droneBees = GetDroneBeeList();
            PopulateListItems(listView1, workerBees.Cast<Bee>().ToList());
            PopulateListItems(listView2, queenBees.Cast<Bee>().ToList());
            PopulateListItems(listView3, droneBees.Cast<Bee>().ToList());
        }

        public void PopulateListItems(ListView listView, List<Bee> beeList)
        {
            listView.Items.Clear();
            foreach (var bee in beeList)
            {
                var row = new string[] { bee.BeeID.ToString(), bee.CurrentHealth().ToString(), bee.BeeStatus };
                var lv = new ListViewItem(row);
                lv.Tag = bee;
                listView.Items.Add(lv);
            }
        }

        private List<WorkerBee> GetWorkerBeeList()
        {
            var workerList = new List<WorkerBee>();
            for (int i = 0; i < 10; i++)
            {
                workerList.Add(new WorkerBee());
            }
            workerBeeList = workerList;
            return workerList;
        }

        private List<QueenBee> GetQueenBeeList()
        {
            var queenList = new List<QueenBee>();
            for (int i = 0; i < 10; i++)
            {
                queenList.Add(new QueenBee());
            }
            queenBeeList = queenList;
            return queenList;
        }

        private List<DroneBee> GetDroneBeeList()
        {
            var droneList = new List<DroneBee>();
            for (int i = 0; i < 10; i++)
            {
                droneList.Add(new DroneBee());
            }
            droneBeeList = droneList;
            return droneList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeListItemValues();
        }

        private async void ChangeListItemValues()
        {
           
            foreach (var worker in workerBeeList)
            {
                await Task.Run(() => Thread.Sleep(TimeSpan.FromSeconds(0.01)));
                worker.TakeDamage(new Random().Next(0, 80), worker.BeeStatus);
                worker.CheckBeeStatus();
            }
            foreach (var queen in queenBeeList)
            {
                await Task.Run(() => Thread.Sleep(TimeSpan.FromSeconds(0.01)));
                queen.TakeDamage(new Random().Next(0, 80), queen.BeeStatus);
                queen.CheckBeeStatus();
            }
            foreach (var drone in droneBeeList)
            {
                await Task.Run(() => Thread.Sleep(TimeSpan.FromSeconds(0.01)));
                drone.TakeDamage(new Random().Next(0, 80), drone.BeeStatus);
                drone.CheckBeeStatus();
            }
            PopulateListItems(listView1, workerBeeList.Cast<Bee>().ToList());
            PopulateListItems(listView2, queenBeeList.Cast<Bee>().ToList());
            PopulateListItems(listView3, droneBeeList.Cast<Bee>().ToList());
         
        }
    }
}
