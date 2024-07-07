using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using InventoryModels;

namespace InventoryModels
{
    public class FileReader
    {
        string url;
        SimulationSystem system = new SimulationSystem();

        public FileReader(string url)
        {
            this.url = url;
        }
        public List<Distribution> fillDemandDist(StreamReader read)
        {
            List<Distribution> DisTable = new List<Distribution>();
            string line = read.ReadLine();
            string[] sep;
            decimal cumprob = 0;
            int minr = 0;
            int maxr = 0;

            while (line != null && line !="")
            {
                sep = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int Value = int.Parse(sep[0]);
                decimal prob = decimal.Parse(sep[1]);
                minr = Convert.ToInt32(cumprob * 100) + 1;
                cumprob += prob;
                maxr += Convert.ToInt32(prob * 100);

                DisTable.Add(new Distribution(Value, prob, cumprob, minr, maxr));
                line = read.ReadLine();
            }
            return DisTable;
        }
        public List<Distribution> fillLeadDaysDist(StreamReader read)
        {
            List<Distribution> DisTable = new List<Distribution>();
            string line = read.ReadLine();
            string[] sep;
            decimal cumprob = 0;
            int minr = 0;
            int maxr = 0;

            while (line != null && line != "")
            {
                sep = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int Value = int.Parse(sep[0]);
                decimal prob = decimal.Parse(sep[1]);
                minr = Convert.ToInt32(cumprob * 100) + 1;
                cumprob += prob;
                maxr += Convert.ToInt32(prob * 100);

                DisTable.Add(new Distribution(Value, prob, cumprob, minr, maxr));
                line = read.ReadLine();
            }
            return DisTable;
        }
        public SimulationSystem LoadData()
        {
            SimulationSystem system = new SimulationSystem();
            using (StreamReader read = new StreamReader(url))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    if (line == "OrderUpTo") system.OrderUpTo = int.Parse(read.ReadLine());
                    else if (line == "ReviewPeriod") system.ReviewPeriod = int.Parse(read.ReadLine());
                    else if (line == "StartInventoryQuantity") system.StartInventoryQuantity = int.Parse(read.ReadLine());
                    else if (line == "StartLeadDays") system.StartLeadDays = int.Parse(read.ReadLine());
                    else if (line == "StartOrderQuantity") system.StartOrderQuantity = int.Parse(read.ReadLine());
                    else if (line == "NumberOfDays") system.NumberOfDays = int.Parse(read.ReadLine());
                    else if (line == "DemandDistribution")
                    {
                        system.DemandDistribution = fillDemandDist(read);
                    }
                    else if (line == "LeadDaysDistribution") system.LeadDaysDistribution = fillLeadDaysDist(read);
                    else if (line == "" || line == " ") continue;
                }

            }
            return system;
        }
    }
}
//Done
