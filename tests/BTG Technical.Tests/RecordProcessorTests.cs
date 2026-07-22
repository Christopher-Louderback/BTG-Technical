using Xunit;
using BTG_Technical;

namespace BTG_Technical_Tests
{
    public class RecordProcessorTests
    {
        private BTG_Technical.Record CreateRecord(int quantity, decimal unitPrice)
        {
            return new BTG_Technical.Record
            {
                TransactionDate = DateTime.Now,
                CustomerId = "CUST001",
                CustomerName = "Test Customer",
                Product = "Test Product",
                Quantity = quantity,
                UnitPrice = unitPrice,
                Total = quantity * unitPrice
            };
        }

        [Fact]
        public void Process_WithValidRecords_ReturnsAllRecords()
        {
            // Arrange
            var records = new List<BTG_Technical.Record>
            {
                CreateRecord(5, 10.00m),
                CreateRecord(3, 25.00m),
                CreateRecord(2, 15.50m)
            };

            // Act
            var result = RecordProcessor.Process(records);

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Process_WithInvalidQuantity_FiltersOutRecord()
        {
            // Arrange
            var records = new List<BTG_Technical.Record>
            {
                CreateRecord(5, 10.00m),
                CreateRecord(0, 25.00m),  // Invalid: quantity is 0
                CreateRecord(2, 15.50m)
            };

            // Act
            var result = RecordProcessor.Process(records);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.DoesNotContain(records[1], result);
        }

        [Fact]
        public void Process_WithInvalidPrice_FiltersOutRecord()
        {
            // Arrange
            var records = new List<BTG_Technical.Record>
            {
                CreateRecord(5, 10.00m),
                CreateRecord(3, 0m),  // Invalid: price is 0
                CreateRecord(2, 15.50m)
            };

            // Act
            var result = RecordProcessor.Process(records);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.DoesNotContain(records[1], result);
        }

        [Fact]
        public void Process_WithEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var records = new List<BTG_Technical.Record>();

            // Act
            var result = RecordProcessor.Process(records);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Process_WithAllInvalidRecords_ReturnsEmpty()
        {
            // Arrange
            var records = new List<BTG_Technical.Record>
            {
                CreateRecord(0, 10.00m),
                CreateRecord(5, 0m),
                CreateRecord(-1, 25.00m)
            };

            // Act
            var result = RecordProcessor.Process(records);

            // Assert
            Assert.Empty(result);
        }
    }
}
