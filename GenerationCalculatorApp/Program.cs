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
            string generatorFilePath = ConfigurationManager.AppSettings["GeneratorData"];
            string referenceFilePath = ConfigurationManager.AppSettings["ReferenceData"];
            if (generatorFilePath == null || referenceFilePath == null)
                throw new ArgumentNullException("Generator and reference data file path must be defined in App Config");

            IFileProcessor xmlProcessor = new XmlProcessor();
            GenerationReport generationReport = xmlProcessor.Parse<GenerationReport>(generatorFilePath);
            ReferenceData referenceData = xmlProcessor.Parse<ReferenceData>(referenceFilePath);

            Calculator calculator = new Calculator(generationReport, referenceData);
            List<TotalGeneration> totalGenerations = calculator.CalculateTotalGenerationValue();
            List<MaxDailyEmission> maxEmissionGenerators = calculator.CalculateHighestDailyEmissions();
            List<ActualHeatRate> actualHeatRates = calculator.CalculateActualHeatRate();

            string outputFilePath = ConfigurationManager.AppSettings["OutputFile"];
            if (outputFilePath == null)
                throw new ArgumentNullException("Output file path must be defined in App Config");

            GenerationOutput generationOutput = new GenerationOutput(totalGenerations, maxEmissionGenerators, actualHeatRates);
            xmlProcessor.Write<GenerationOutput>(outputFilePath, generationOutput);
        }
    }
}