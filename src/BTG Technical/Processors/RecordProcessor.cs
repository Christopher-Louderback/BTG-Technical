namespace BTG_Technical
{
    public class RecordProcessor
    {
        public static List<Record> Process (List<Record> data)
        {
            List<Record> processedData = new List<Record>();
            int goodCount = 0;
            int badCount = 0;

            foreach (Record record in data)
            {
                if (record.Quantity > 0 && record.UnitPrice > 0)
                {
                    processedData.Add(record);
                    goodCount++;
                }
                else
                {
                    Console.WriteLine($"Invalid record: {record.TransactionDate}, {record.CustomerId}, {record.CustomerName}, {record.Product}, {record.Quantity}, {record.UnitPrice}, {record.Total}. Not added to result.");
                    badCount++;
                }
            }

            Console.WriteLine($"Processing complete. {goodCount} records processed, {badCount} records rejected.");
            return processedData;
        }
    }
}