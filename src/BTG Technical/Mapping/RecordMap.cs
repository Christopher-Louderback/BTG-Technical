using CsvHelper.Configuration;

namespace BTG_Technical
{
    public class RecordMap : ClassMap<Record>
    {
        /// <summary>
        /// Maps the CSV columns to the Record properties, calculates Total field.
        /// </summary>
        public RecordMap()
        {
            Map(m => m.TransactionDate).Name("TransactionDate");
            Map(m => m.CustomerId).Name("CustomerId");
            Map(m => m.CustomerName).Name("CustomerName");
            Map(m => m.Product).Name("Product");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.UnitPrice).Name("UnitPrice");
            Map(m => m.Total).Convert(args =>
            {
                var quantity = args.Row.GetField<int>("Quantity");
                var price = args.Row.GetField<decimal>("UnitPrice");
                return quantity * price;
            });
        }
    }
}