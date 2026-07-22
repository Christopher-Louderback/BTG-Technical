namespace BTG_Technical
{
    public class Reader
    {
        public static List<Record> ReadFile(string file)
        {
            List<Record> records = new();

            var lines = File.ReadLines(file);

            foreach (var line in lines.Skip(1)) //skip column names
            {
                try {
                    var fields = line.Split(','); //Can upgrade to something that doesn't explode with commas, csvhelper?
                    var record = new Record
                    {
                        TransactionDate = DateTime.Parse(fields[0]),
                        CustomerId = fields[1],
                        CustomerName = fields[2],
                        Product = fields[3],
                        Quantity = int.Parse(fields[4]),
                        UnitPrice = decimal.Parse(fields[5]),
                        Total = decimal.Parse(fields[4]) * decimal.Parse(fields[5])
                    };
                    records.Add(record);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing line: {line}. Error: {ex.Message}");
                }
            }

            Console.WriteLine("Data read and extracted.");
            return records;
        }
    }
}