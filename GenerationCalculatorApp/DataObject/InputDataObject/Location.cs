using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenerationCalculatorApp.DataObject.InputDataObject
{
    public enum Location
    {
        [XmlEnum(Name = "Offshore")]
        Offshore,
        [XmlEnum(Name = "Onshore")]
        Onshore
    }
}
