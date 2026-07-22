namespace BTG_Technical
{
    internal class Reader
    {
        public List<Record> ReadFile(string file)
        {
            List<Record> records = new List<Record>();

            var lines = File.ReadLines(file).ToList();//tolist needed?

            foreach (var line in lines.Skip(1)) //skip column names
            { //try except?
                var fields = line.Split(','); //could break, can improve this later
                var record = new Record
                {
                    TransactionDate = DateTime.Parse(fields[0]),
                    CustomerId = int.Parse(fields[1]),
                    CustomerName = fields[2],
                    Product = fields[3],
                    Quantity = int.Parse(fields[4]),
                    UnitPrice = decimal.Parse(fields[5]),
                    Total = int.Parse(fields[4]) * decimal.Parse(fields[5])
                };
                records.Add(record);
            }
            return records;
        }
    }
}