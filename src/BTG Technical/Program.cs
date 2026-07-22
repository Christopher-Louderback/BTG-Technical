using BTG_Technical;

if (args.Length == 0)
{
    Console.Error.WriteLine("Error: No input file specified.");
    return;
}

string? inputFile = args[0]; //read parameter from user input and assign to variable

if (!File.Exists(inputFile))
{
    Console.Error.WriteLine($"Error: File not found: {inputFile}");
    return;
}

string outputFile = Path.ChangeExtension(inputFile, ".json");//convention is apparently to keep file name

Console.WriteLine("Reading file and extracting data.");//read and extract data
List<Record> data = Reader.ReadFile(inputFile);

Console.WriteLine("Processing data.");//process/validate data
List<Record> processedData = RecordProcessor.Process(data);

Console.WriteLine("Creating JSON.");//write json to file
Writer.Write(outputFile, processedData);