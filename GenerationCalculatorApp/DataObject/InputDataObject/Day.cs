namespace GenerationCalculatorApp.DataObject.ParserDataObject
{
    public class Day
    {
        public DateTime Date { get; set; }
        public double Energy { get; set; }
        public double Price { get; set; }

        public Day() { }

        public Day(DateTime date, double energy, double price)
        {
            Date = date;
            Energy = energy;
            Price = price;
        }
    }
}