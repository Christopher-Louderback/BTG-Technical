using BTG_Technical;

if (args.Length == 0)
{
    Console.Error.WriteLine("Error: No input file specified.");
    return;
}

string? inputFile = args[0];

if (!File.Exists(inputFile))
{
    Console.Error.WriteLine($"Error: File {inputFile} not found.");
    return;
}

string outputFile = Path.ChangeExtension(inputFile, ".json");

Console.WriteLine("Reading file and extracting data.");
List<Record> data = Reader.ReadFile(inputFile);

Console.WriteLine("Processing data.");
List<Record> processedData = RecordProcessor.Process(data);

Console.WriteLine("Creating JSON.");
Writer.Write(outputFile, processedData);