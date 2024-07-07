using InventoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySimulation
{
    public partial class simulationTable : Form
    {
        SimulationSystem system;
        int no_days = 0;
        bool showBtn = false;
        public simulationTable()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            system = SharedData.system;
            no_days = system.NumberOfDays;
            dataGridView1.ReadOnly = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (showBtn == false)
            {
                for (int i = 0; i < no_days; i++)
                {
                    dataGridView1.Rows.Add(
                                            system.SimulationTable[i].Day,
                                            system.SimulationTable[i].Cycle,
                                            system.SimulationTable[i].DayWithinCycle,
                                            system.SimulationTable[i].BeginningInventory,
                                            system.SimulationTable[i].RandomDemand,
                                            system.SimulationTable[i].Demand,
                                            system.SimulationTable[i].EndingInventory,
                                            system.SimulationTable[i].ShortageQuantity,
                                            system.SimulationTable[i].OrderQuantity,
                                            system.SimulationTable[i].RandomLeadDays,
                                            system.SimulationTable[i].LeadDays
                                          );
                }
            }
            showBtn = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            showBtn = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simulationTable_Load(object sender, EventArgs e)
        {

        }

        
    }
}
