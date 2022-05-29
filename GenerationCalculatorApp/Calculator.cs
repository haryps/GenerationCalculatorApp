using GenerationCalculatorApp.DataObject.InputDataObject;
using GenerationCalculatorApp.DataObject.OutputDataObject;
using GenerationCalculatorApp.DataObject.ParserDataObject;
using GenerationCalculatorApp.DataObject.ReferenceDataObject;

namespace GenerationCalculatorApp
{
    public class Calculator
    {
        public GenerationReport GenerationReport { get; }
        public ReferenceData ReferenceData { get; }

        public Calculator(GenerationReport generationReport, ReferenceData referenceData)
        {
            GenerationReport = generationReport;
            ReferenceData = referenceData;
        }

        public List<TotalGeneration> CalculateTotalGenerationValue()
        {
            List<TotalGeneration> totalGenerations = new List<TotalGeneration>();

            foreach (WindGenerator windGenerator in GenerationReport.WindGenerators)
            {
                double totalGenerationValue = 0;
                double factor = windGenerator.Location == Location.Offshore
                    ? ReferenceData.Factors.ValueFactor.Low
                    : ReferenceData.Factors.ValueFactor.High;
                foreach (Day day in windGenerator.Days)
                {
                    totalGenerationValue += day.Energy * day.Price * factor;
                }

                totalGenerations.Add(new TotalGeneration(windGenerator.Name, totalGenerationValue));
            }

            foreach (GasGenerator gasGenerator in GenerationReport.GasGenerators)
            {
                double totalGenerationValue = 0;
                double factor = ReferenceData.Factors.ValueFactor.Medium;
                foreach (Day day in gasGenerator.Days)
                {
                    totalGenerationValue += day.Energy * day.Price * factor;
                }

                totalGenerations.Add(new TotalGeneration(gasGenerator.Name, totalGenerationValue));
            }

            foreach (CoalGenerator coalGenerator in GenerationReport.CoalGenerators)
            {
                double totalGenerationValue = 0;
                double factor = ReferenceData.Factors.ValueFactor.Medium;
                foreach (Day day in coalGenerator.Days)
                {
                    totalGenerationValue += day.Energy * day.Price * factor;
                }

                totalGenerations.Add(new TotalGeneration(coalGenerator.Name, totalGenerationValue));
            }

            return totalGenerations;
        }

        public List<MaxDailyEmission> CalculateHighestDailyEmissions()
        {
            List<MaxDailyEmission> dailyEmissions = new List<MaxDailyEmission>();

            foreach (GasGenerator gasGenerator in GenerationReport.GasGenerators)
            {
                foreach (Day day in gasGenerator.Days)
                {
                    double emission = day.Energy * gasGenerator.EmissionsRating * ReferenceData.Factors.EmissionsFactor.Medium;
                    dailyEmissions.Add(new MaxDailyEmission(gasGenerator.Name, day.Date, emission));
                }
            }

            foreach (CoalGenerator coalGenerator in GenerationReport.CoalGenerators)
            {
                foreach (Day day in coalGenerator.Days)
                {
                    double emission = day.Energy * coalGenerator.EmissionsRating * ReferenceData.Factors.EmissionsFactor.High;
                    dailyEmissions.Add(new MaxDailyEmission(coalGenerator.Name, day.Date, emission));
                }
            }

            List<MaxDailyEmission> dailyMaxEmissions = new List<MaxDailyEmission>();

            var emissionGroupByDay = dailyEmissions.GroupBy(x => x.Date);
            foreach (var dailyEmission in emissionGroupByDay)
            {
                dailyMaxEmissions.Add(dailyEmission.OrderByDescending(x => x.Emission).First());
            }

            return dailyMaxEmissions;
        }

        public List<ActualHeatRate> CalculateActualHeatRate()
        {
            List<ActualHeatRate> actualHeatRates = new List<ActualHeatRate>();

            foreach (CoalGenerator coalGenerator in GenerationReport.CoalGenerators)
            {
                double actualHeatRate = coalGenerator.TotalHeatInput / coalGenerator.ActualNetGeneration;
                actualHeatRates.Add(new ActualHeatRate(coalGenerator.Name, actualHeatRate));
            }

            return actualHeatRates;
        }
    }
}