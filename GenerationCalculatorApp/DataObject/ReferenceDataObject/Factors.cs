using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenerationCalculatorApp.DataObject.ReferenceDataObject
{
    public class Factors
    {
        [XmlElement]
        public ValueFactor ValueFactor { get; set; }

        [XmlElement]
        public EmissionsFactor EmissionsFactor { get; set; }
    }
}
