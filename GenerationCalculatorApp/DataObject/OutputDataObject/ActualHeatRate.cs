using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationCalculatorApp.DataObject.OutputDataObject
{
    public class ActualHeatRate
    {
        public string Name { get; set; }
        public double HeatRate { get; set; }

        public ActualHeatRate(string name, double heatRate)
        {
            Name = name;
            HeatRate = heatRate;
        }

        public ActualHeatRate()
        {
        }

        public override bool Equals(object? obj)
        {
            ActualHeatRate actualHeatRate = obj as ActualHeatRate;
            if (actualHeatRate == null)
                return false;

            return actualHeatRate.Name.Equals(Name) && actualHeatRate.HeatRate == HeatRate;
        }
    }
}
