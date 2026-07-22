using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG_Technical
{
    /// <summary>
    /// A record of a transaction.
    /// </summary>
    internal class Record
    {
        /// <summary>
        /// The date of the transaction.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// The ID of the customer.
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string? CustomerName { get; set; }
        /// <summary>
        /// The product name.
        /// </summary>
        public string? Product { get; set; }
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
