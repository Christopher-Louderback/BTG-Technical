using Xunit;
using BTG_Technical;
using System.Globalization;
using System.Text;

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

                Assert.Equal(5, records[0].Quantity);
                Assert.Equal(10.50m, records[0].UnitPrice);
                Assert.Equal(52.50m, records[0].Total);

                Assert.Equal(3, records[1].Quantity);
                Assert.Equal(25.00m, records[1].UnitPrice);
                Assert.Equal(75.00m, records[1].Total);
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }

        [Fact]
        public void ReadFile_WithNonexistentFile_ThrowsFileNotFoundException()
        {
            // Arrange
            var nonexistentFile = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.csv");

            // Act & Assert
            var exception = Assert.Throws<FileNotFoundException>(() => Reader.ReadFile(nonexistentFile));
            Assert.Contains("Input file not found", exception.Message);
        }

        [Fact]
        public void ReadFile_CalculatesCorrectTotals()
        {
            // Arrange
            var csvContent = @"TransactionDate,CustomerId,CustomerName,Product,Quantity,UnitPrice
2024-01-15,CUST001,John Doe,Laptop,1,1299.99
2024-01-16,CUST002,Jane Smith,Mouse,10,15.50
2024-01-17,CUST003,Bob Johnson,Keyboard,2,89.99";

            var filePath = CreateTestCsvFile(csvContent);

            try
            {
                // Act
                var records = Reader.ReadFile(filePath);

                // Assert
                Assert.Equal(1299.99m, records[0].Total);
                Assert.Equal(155.00m, records[1].Total);
                Assert.Equal(179.98m, records[2].Total);
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }

        [Fact]
        public void ReadFile_PreservesCustomerData()
        {
            // Arrange
            var csvContent = @"TransactionDate,CustomerId,CustomerName,Product,Quantity,UnitPrice
2024-01-15,CUST123,Alice Johnson,Product A,2,50.00";

            var filePath = CreateTestCsvFile(csvContent);

            try
            {
                // Act
                var records = Reader.ReadFile(filePath);

                // Assert
                Assert.Single(records);
                var record = records[0];

                Assert.Equal("CUST123", record.CustomerId);
                Assert.Equal("Alice Johnson", record.CustomerName);
                Assert.Equal("Product A", record.Product);
                Assert.Equal(new DateTime(2024, 1, 15), record.TransactionDate);
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }

        [Fact]
        public void ReadFile_WithEmptyQuantity_DefaultsToZero()
        {
            // Arrange
            var csvContent = @"TransactionDate,CustomerId,CustomerName,Product,Quantity,UnitPrice
2024-01-15,CUST001,John Doe,Widget,0,10.50";

            var filePath = CreateTestCsvFile(csvContent);

            try
            {
                // Act
                var records = Reader.ReadFile(filePath);

                // Assert
                Assert.Single(records);
                Assert.Equal(0, records[0].Quantity);
                Assert.Equal(0m, records[0].Total);
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }

        [Fact]
        public void ReadFile_WithMultipleRecords_AllParsedCorrectly()
        {
            // Arrange
            var csvContent = @"TransactionDate,CustomerId,CustomerName,Product,Quantity,UnitPrice
2024-01-01,CUST001,Alice,Product1,5,10.00
2024-01-02,CUST002,Bob,Product2,3,20.00
2024-01-03,CUST003,Charlie,Product3,2,15.50
2024-01-04,CUST004,Diana,Product4,10,5.99";

            var filePath = CreateTestCsvFile(csvContent);

            try
            {
                // Act
                var records = Reader.ReadFile(filePath);

                // Assert
                Assert.Equal(4, records.Count);

                for (int i = 0; i < records.Count; i++)
                {
                    Assert.NotNull(records[i].CustomerId);
                    Assert.NotNull(records[i].CustomerName);
                    Assert.NotNull(records[i].Product);
                    Assert.True(records[i].Total > 0);
                }
            }
            finally
            {
                CleanupTestFile(filePath);
            }
        }
    }
}
