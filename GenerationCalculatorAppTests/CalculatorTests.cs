using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenerationCalculatorApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerationCalculatorApp.DataObject.ParserDataObject;
using GenerationCalculatorApp.DataObject.ReferenceDataObject;
using GenerationCalculatorApp.DataObject.OutputDataObject;

namespace GenerationCalculatorApp.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        Calculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            IFileProcessor xmlProcessor = new XmlProcessor();
            ReferenceData referenceData = xmlProcessor.Parse<ReferenceData>("../../../TestDataFiles/ReferenceData.xml");
            GenerationReport generationReport = xmlProcessor.Parse<GenerationReport>("../../../TestDataFiles/test1.xml");
            calculator = new Calculator(generationReport, referenceData);
        }

        [TestMethod()]
        public void CalculateTotalGenerationValueTest()
        {
            List<TotalGeneration> actualTotalGenerations = calculator.CalculateTotalGenerationValue();
            List<TotalGeneration> expectedTotalGenerations = new List<TotalGeneration>()
            {
                new TotalGeneration("Wind1",272),
                new TotalGeneration("Wind2",210),
                new TotalGeneration("Wind3",300),
                new TotalGeneration("Gas1",150),
                new TotalGeneration("Gas2",205),
                new TotalGeneration("Coal1",585),
                new TotalGeneration("Coal2",680),
            };
            Assert.AreEqual(expectedTotalGenerations.Count, actualTotalGenerations.Count);
            for (int i = 0; i < actualTotalGenerations.Count; i++)
            {
                Assert.AreEqual(actualTotalGenerations[i].Name, expectedTotalGenerations[i].Name);
                Assert.AreEqual(actualTotalGenerations[i].Total, expectedTotalGenerations[i].Total);
            }
        }

        [TestMethod()]
        public void CalculateHighestDailyEmissionsTest()
        {
            List<MaxDailyEmission> actualMaxDailyEmissions = calculator.CalculateHighestDailyEmissions();
            List<MaxDailyEmission> expectedMaxDailyEmissions = new List<MaxDailyEmission>()
            {
                new MaxDailyEmission("Coal2", new DateTime(2017,1,1,7,0,0), 54),
                new MaxDailyEmission("Coal1", new DateTime(2017,1,2,7,0,0), 42),
                new MaxDailyEmission("Coal2", new DateTime(2017,1,3,7,0,0), 54),
            };
            Assert.AreEqual(expectedMaxDailyEmissions.Count, actualMaxDailyEmissions.Count);
            for (int i = 0; i < actualMaxDailyEmissions.Count; i++)
            {
                Assert.AreEqual(actualMaxDailyEmissions[i].Name, expectedMaxDailyEmissions[i].Name);
                Assert.AreEqual(actualMaxDailyEmissions[i].Date, expectedMaxDailyEmissions[i].Date);
                Assert.AreEqual(actualMaxDailyEmissions[i].Emission, expectedMaxDailyEmissions[i].Emission);
            }
        }

        [TestMethod()]
        public void CalculateActualHeatRateTest()
        {
            List<ActualHeatRate> actualActualHeatRates = calculator.CalculateActualHeatRate();
            List<ActualHeatRate> expectedActualHeatRates = new List<ActualHeatRate>()
            {
                new ActualHeatRate("Coal1", 0.5),
                new ActualHeatRate("Coal2", 0.75),
            };
            Assert.AreEqual(expectedActualHeatRates.Count, actualActualHeatRates.Count);
            for (int i = 0; i < actualActualHeatRates.Count; i++)
            {
                Assert.AreEqual(actualActualHeatRates[i].Name, expectedActualHeatRates[i].Name);
                Assert.AreEqual(actualActualHeatRates[i].HeatRate, expectedActualHeatRates[i].HeatRate);
            }
        }
    }
}