using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class Distribution
    {
        public Distribution()
        {

        }
        public Distribution(int value, decimal prob, decimal cumprob, int minr, int maxr)
        {
            this.Value = value;
            this.Probability = prob;
            this.CummProbability = cumprob;
            this.MinRange = minr;
            this.MaxRange = maxr;
        }
        public int Value { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
    }
}
