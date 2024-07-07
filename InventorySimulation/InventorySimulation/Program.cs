using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryModels;
using InventoryTesting;

namespace InventorySimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileReader fileReader = new FileReader(@"D:\7th Semester\Modeling and Simulation\Task 3\InventorySimulation\InventorySimulation\TestCases\TestCase1.txt");
            SimulationSystem system = fileReader.LoadData();
            system.Run();
            //string result = TestingManager.Test(system, Constants.FileNames.TestCase2);
            //MessageBox.Show(result);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
