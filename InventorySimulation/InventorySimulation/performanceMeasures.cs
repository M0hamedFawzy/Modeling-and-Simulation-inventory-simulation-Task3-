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
    public partial class performanceMeasures : Form
    {
        SimulationSystem system;
        public performanceMeasures()
        {
            InitializeComponent();
        }

        private void performanceMeasures_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            system = SharedData.system;
            label8.Text  = $"{system.PerformanceMeasures.EndingInventoryAverage} ";
            label14.Text = $"{system.PerformanceMeasures.ShortageQuantityAverage} ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text  = "0";
            label14.Text = "0";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
