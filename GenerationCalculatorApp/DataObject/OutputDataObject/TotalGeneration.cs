using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationCalculatorApp.DataObject.OutputDataObject
{
    public class TotalGeneration
    {
        public string Name { get; set; }
        public double Total { get; set; }

        public TotalGeneration(string name, double total)
        {
            Name = name;
            Total = total;
        }

        public TotalGeneration()
        {
        }
    }
}
