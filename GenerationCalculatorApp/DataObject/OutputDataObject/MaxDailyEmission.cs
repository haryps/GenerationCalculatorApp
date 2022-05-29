using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationCalculatorApp.DataObject.OutputDataObject
{
    public class MaxDailyEmission
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Emission { get; set; }

        public MaxDailyEmission(string name, DateTime date, double emission)
        {
            Name = name;
            Date = date;
            Emission = emission;
        }

        public MaxDailyEmission()
        {
        }

        public override bool Equals(object? obj)
        {
            MaxDailyEmission maxDailyEmission = obj as MaxDailyEmission;
            if (maxDailyEmission == null)
                return false;

            return maxDailyEmission.Name.Equals(Name) && maxDailyEmission.Date == Date && maxDailyEmission.Emission == Emission;

        }
    }
}
