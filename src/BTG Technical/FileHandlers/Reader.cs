using CsvHelper;
using System.Globalization;

namespace BTG_Technical
{
    public class Reader
    {
        public static List<Record> ReadFile(string file)
        {
            try
            {
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<RecordMap>();
                    var records = csv.GetRecords<Record>().ToList();

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
}