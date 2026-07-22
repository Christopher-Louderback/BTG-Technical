namespace BTG_Technical
{
    /// <summary>
    /// A record of a transaction.
    /// </summary>
    public class Record
    {
        /// <summary>
        /// The date of the transaction.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// The ID of the customer.
        /// </summary>
        public required string CustomerId { get; set; }
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public required string CustomerName { get; set; }
        /// <summary>
        /// The product name.
        /// </summary>
        public required string Product { get; set; }
        /// <summary>
        /// The number of items in the transaction.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// The price per unit.
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// The total price (Quantity * UnitPrice.
        /// </summary>
        public decimal Total { get; set; }
    }
}
