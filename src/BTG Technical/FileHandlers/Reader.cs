using CsvHelper;
using System.Globalization;

namespace BTG_Technical
{
    public class Reader
    {
        /// <summary>
        /// Reads a CSV file and extracts the data into a list of records.
        /// </summary>
        /// <param name="file">The file to read and extract from.</param>
        /// <returns>The list of records.</returns>
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