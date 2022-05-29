using GenerationCalculatorApp.DataObject.OutputDataObject;
using GenerationCalculatorApp.DataObject.ParserDataObject;
using GenerationCalculatorApp.DataObject.ReferenceDataObject;
using System.Configuration;

namespace GenerationCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFileProcessor xmlProcessor = new XmlProcessor();
            GenerationReport generationReport = xmlProcessor.Parse<GenerationReport>(ConfigurationManager.AppSettings["GeneratorData"]);
            ReferenceData referenceData = xmlProcessor.Parse<ReferenceData>(ConfigurationManager.AppSettings["ReferenceData"]);

            Calculator calculator = new Calculator(generationReport, referenceData);
            List<TotalGeneration> totalGenerations = calculator.CalculateTotalGenerationValue();
            List<MaxDailyEmission> maxEmissionGenerators = calculator.CalculateHighestDailyEmissions();
            List<ActualHeatRate> actualHeatRates = calculator.CalculateActualHeatRate();

            GenerationOutput generationOutput = new GenerationOutput(totalGenerations, maxEmissionGenerators, actualHeatRates);
            xmlProcessor.Write<GenerationOutput>(ConfigurationManager.AppSettings["OutputFile"], generationOutput);
        }
    }
}