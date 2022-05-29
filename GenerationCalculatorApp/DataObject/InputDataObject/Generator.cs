using GenerationCalculatorApp.DataObject.ParserDataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenerationCalculatorApp.DataObject.InputDataObject
{
    public class Generator
    {
        public string Name { get; set; }

        [XmlArray("Generation")]
        [XmlArrayItem(ElementName = "Day")]
        public List<Day> Days { get; set; }
    }
}
