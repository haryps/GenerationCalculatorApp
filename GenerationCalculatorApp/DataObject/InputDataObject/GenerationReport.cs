using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenerationCalculatorApp.DataObject.ParserDataObject
{
    public class GenerationReport
    {
        [XmlArray("Wind")]
        [XmlArrayItem(ElementName = "WindGenerator")]
        public List<WindGenerator> WindGenerators { get; set; }

        [XmlArray("Gas")]
        [XmlArrayItem(ElementName = "GasGenerator")]
        public List<GasGenerator> GasGenerators { get; set; }

        [XmlArray("Coal")]
        [XmlArrayItem(ElementName = "CoalGenerator")]
        public List<CoalGenerator> CoalGenerators { get; set; }
    }
}
