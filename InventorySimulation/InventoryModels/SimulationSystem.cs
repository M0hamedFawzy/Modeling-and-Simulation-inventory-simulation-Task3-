using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }

        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }
        public int ReviewPeriod { get; set; }
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }
        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }

        ///////////// OUTPUTS /////////////

        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public void Run()
        {
            int ind = 0;
            int OrderArrival = StartLeadDays;
            int shortage = 0;
            int OQ = StartOrderQuantity;
            int currentInv = 0;
            Random rnd = new Random();
            decimal avgEnding = 0;
            decimal avgshortage = 0;

            //Console.WriteLine("day cycle DayWC Beg Demand Ending Shortage RandLD leaddays OA OQ");

            for (int i = 1; i <= NumberOfDays; i++)
            {
                SimulationCase Sc = new SimulationCase();
                Sc.Day = i-1;
                Sc.Cycle = ((i-1) / ReviewPeriod) + 1;
                Sc.DayWithinCycle = ((i-1) % ReviewPeriod) + 1;

                //calculating Beginning Inventory
                if (i == 1)
                {
                    Sc.BeginningInventory = StartInventoryQuantity;
                    OrderArrival--;
                }
                else
                {
                    if (OrderArrival != 0)
                    {
                        Sc.BeginningInventory = currentInv;
                        OrderArrival--;
                    }
                    else
                    {
                        Sc.BeginningInventory = currentInv + OQ;
                        OQ = 0;
                    }
                }

                //calculating RandomDemand And Demand
                Sc.RandomDemand = rnd.Next(1,100);
                for (int j = 0; j < DemandDistribution.Count; j++)
                {
                    if (Sc.RandomDemand >= DemandDistribution[j].MinRange &&
                       Sc.RandomDemand <= DemandDistribution[j].MaxRange)
                    {
                        Sc.Demand = DemandDistribution[j].Value;
                        break;
                    }
                }

                //calculating Ending Inventory and Shortage quantity
                if (Sc.BeginningInventory - Sc.Demand - shortage>=0)
                {
                    Sc.EndingInventory = Sc.BeginningInventory - Sc.Demand - shortage;
                    currentInv = Sc.EndingInventory;
                    Sc.ShortageQuantity = 0;
                    shortage = 0;
                }
                else
                {
                    Sc.EndingInventory = 0;
                    currentInv = 0;
                    Sc.ShortageQuantity =shortage + Sc.Demand - Sc.BeginningInventory  ;
                    shortage = Sc.ShortageQuantity;
                }
                avgEnding += Sc.EndingInventory;
                avgshortage += Sc.ShortageQuantity;

                //calculating Order Quantity, Random Lead Days and Lead Days
                if (Sc.DayWithinCycle != ReviewPeriod)
                {
                    Sc.OrderQuantity = 0;
                    Sc.RandomLeadDays = 0;
                    Sc.LeadDays = 0;
                }
                else
                {
                    OQ = OrderUpTo - currentInv + shortage;
                    Sc.OrderQuantity = OQ;

                    Sc.RandomLeadDays = rnd.Next(1,100); 
                    ind++;
                    for (int j = 0; j < LeadDaysDistribution.Count; j++)
                    {
                        if (Sc.RandomLeadDays >= LeadDaysDistribution[j].MinRange &&
                           Sc.RandomLeadDays <= LeadDaysDistribution[j].MaxRange)
                        {
                            Sc.LeadDays = LeadDaysDistribution[j].Value;
                            OrderArrival = Sc.LeadDays;
                            break;
                        }
                    }
                }
               /* Console.WriteLine(Sc.Day+"\t"+Sc.Cycle+"\t\t"+Sc.DayWithinCycle+"\t"+Sc.BeginningInventory+"\t"+Sc.Demand+"\t\t"
                    +Sc.EndingInventory+"\t\t"+Sc.ShortageQuantity+"\t\t"+Sc.RandomLeadDays+"\t\t"+Sc.LeadDays+"\t\t"+OrderArrival+"\t"+OQ);
               */
                SimulationTable.Add(Sc);
                
            }

            PerformanceMeasures.EndingInventoryAverage = avgEnding / NumberOfDays;
            PerformanceMeasures.ShortageQuantityAverage = avgshortage / NumberOfDays;
        }
    }
}
