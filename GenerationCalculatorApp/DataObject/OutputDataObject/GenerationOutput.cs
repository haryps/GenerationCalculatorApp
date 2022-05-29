using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenerationCalculatorApp.DataObject.OutputDataObject
{
    public class GenerationOutput
    {
        public GenerationOutput() { }

        public GenerationOutput(List<TotalGeneration> totalGenerations, List<MaxDailyEmission> maxEmissionGenerators, List<ActualHeatRate> actualHeatRates)
        {
            TotalGenerations = totalGenerations;
            MaxEmissionGenerators = maxEmissionGenerators;
            ActualHeatRates = actualHeatRates;
        }

        [XmlArray("Totals")]
        [XmlArrayItem(ElementName = "Generator")]
        public List<TotalGeneration> TotalGenerations { get; set; }

        [XmlArray("MaxEmissionGenerators")]
        [XmlArrayItem(ElementName = "Day")]
        public List<MaxDailyEmission> MaxEmissionGenerators { get; set; }

        [XmlArray("ActualHeatRates")]
        [XmlArrayItem(ElementName = "ActualHeatRate")]
        public List<ActualHeatRate> ActualHeatRates { get; set; }
    }
}
