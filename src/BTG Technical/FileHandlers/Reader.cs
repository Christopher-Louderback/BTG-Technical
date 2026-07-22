using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BTG_Technical
{
    public class Reader
    {
        public static List<Record> ReadFile(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException($"Input file {file} not found.");

            try
            {
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<RecordMap>();
                    var records = csv.GetRecords<Record>().ToList();
                    foreach (var r in records)
                    {
                        r.Total = r.Quantity * r.UnitPrice;
                    }

                    Console.WriteLine("Data read and extracted.");
                    return records;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Error reading CSV file: {file}", ex);
            }
        }
    }

    public class RecordMap : ClassMap<Record> //move into own file
    {
        public RecordMap()
        {
            Map(m => m.TransactionDate).Name("TransactionDate");
            Map(m => m.CustomerId).Name("CustomerId");
            Map(m => m.CustomerName).Name("CustomerName");
            Map(m => m.Product).Name("Product");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.UnitPrice).Name("UnitPrice");
            Map(m => m.Total).Convert(args => //set to 0 and put in own file
            {
                var quantity = args.Row.GetField<int>("Quantity");
                var price = args.Row.GetField<decimal>("UnitPrice");
                return quantity * price;
            });
        }
    }
}