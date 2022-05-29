using GenerationCalculatorApp.DataObject.ParserDataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenerationCalculatorApp.DataObject.ReferenceDataObject
{
    public class ReferenceData
    {
        [XmlArray]
        [XmlArrayItem("Factor", Type = typeof(Factor)),
          XmlArrayItem(Type = typeof(ValueFactor)),
          XmlArrayItem(Type = typeof(EmissionsFactor))]
        public List<Factor> Factors { get; set; }
    }
}
