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

        public override bool Equals(object? obj)
        {
            TotalGeneration totalGeneration = obj as TotalGeneration;
            if (totalGeneration == null)
                return false;

            return totalGeneration.Name == Name && totalGeneration.Total == Total;
        }
    }
}
