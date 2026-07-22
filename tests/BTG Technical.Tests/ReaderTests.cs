using Xunit;
using BTG_Technical;

namespace BTG_Technical_Tests
{
    public class ReaderTests
    {
        private string CreateTestCsvFile(string content)
        {
            var testDir = Path.Combine(Path.GetTempPath(), "BTGTests");
            Directory.CreateDirectory(testDir);

            var filePath = Path.Combine(testDir, $"test_{Guid.NewGuid()}.csv");
            File.WriteAllText(filePath, content);
            return filePath;
        }

        private void CleanupTestFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        [Fact]
        public void ReadFile_WithValidCsv_ReturnsRecords()
        {
            // Arrange
            var csvContent = @"TransactionDate,CustomerId,CustomerName,Product,Quantity,UnitPrice
2024-01-15,CUST001,John Doe,Widget,5,10.50
2024-01-16,CUST002,Jane Smith,Gadget,3,25.00";

            var filePath = CreateTestCsvFile(csvContent);

            try
            {
                // Act
                var records = Reader.ReadFile(filePath);

                // Assert
                Assert.NotNull(records);
                Assert.Equal(2, records.Count);
                Assert.Equal(52.50m, records[0].Total);
                Assert.Equal(75.00m, records[1].Total);
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }

        [Fact]
        public void ReadFile_WithNonexistentFile_ThrowsInvalidOperationException()
        {
            // Arrange
            var nonexistentFile = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.csv");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => Reader.ReadFile(nonexistentFile));
        }

        [Fact]
        public void ReadFile_ParsesDataCorrectly()
        {
            // Arrange
            var csvContent = @"TransactionDate,CustomerId,CustomerName,Product,Quantity,UnitPrice
2024-01-15,CUST001,John Doe,Laptop,1,1299.99";

            var filePath = CreateTestCsvFile(csvContent);

            try
            {
                // Act
                var records = Reader.ReadFile(filePath);

                // Assert
                Assert.Single(records);
                var record = records[0];
                Assert.Equal(new DateTime(2024, 1, 15), record.TransactionDate);
                Assert.Equal("CUST001", record.CustomerId);
                Assert.Equal("John Doe", record.CustomerName);
                Assert.Equal("Laptop", record.Product);
                Assert.Equal(1, record.Quantity);
                Assert.Equal(1299.99m, record.UnitPrice);
                Assert.Equal(1299.99m, record.Total);
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }
    }
}
