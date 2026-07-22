## This program prompts the user for a CSV file, then extracts the data from the CSV, validates it, and provides it in JSON form.

To run program: dotnet run --project "src/BTG Technical" -- "(target csv here)"
To run with provided CSV in data folder: dotnet run --project "src/BTG Technical" -- "src/BTG Technical/data/transactions.csv"  
To run tests: dotnet test  

Expected input - CSV file with TransactionDate, CustomerId, CustomerName, Product, Quantity, and UnitPrice columns
Expected output - JSON file named after input file with transformed data from input file  

# Program Flow  
Input Validation  
User provides file, validity checked  

Reading/Extracting  
The file is parsed and transaction record extracted  

Processing  
Records are validated, invalid records are filtered and logged  

Output  
Processed records are written as formatted JSON to an output file  

# Commit History
![Screenshot](https://i.imgur.com/rB7pJ6j.png)

# Pull Requests
![Screenshot](https://i.imgur.com/COXXnNa.png)

# A Pull Request
![Screenshot](https://i.imgur.com/nY2mNl1.png)

# Repo Structure
![Screenshot](https://i.imgur.com/jMcq48d.png)
