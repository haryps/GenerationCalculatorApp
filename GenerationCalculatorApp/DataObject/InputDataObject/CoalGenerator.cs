using GenerationCalculatorApp.DataObject.InputDataObject;

namespace GenerationCalculatorApp.DataObject.ParserDataObject
{
    public class CoalGenerator : Generator
    {
        public double TotalHeatInput { get; set; }
        public double ActualNetGeneration { get; set; }
        public double EmissionsRating { get; set; }
    }
}