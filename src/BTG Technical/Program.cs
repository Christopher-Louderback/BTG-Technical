using BTG_Technical;

Console.WriteLine("Enter input file."); //Prompt user for target files and assign to variables. hardcoding here just for testing
string? inputFile = Console.ReadLine(); //read parameter from user input, use args not readline, have transactions.csv as default
string? outputFile = Path.ChangeExtension(inputFile, ".json");//convention is apparently to keep file name, can do this and just have it overwrite what's in there now if it already exists

if (!string.IsNullOrWhiteSpace(inputFile))
{
    Console.WriteLine("Reading file and extracting data.");//read and extract data
    List<Record> data = Reader.ReadFile(inputFile);

    Console.WriteLine("Processing data.");//process/validate data
    List<Record> processedData = Processor.Process(data);

    Console.WriteLine("Creating JSON.");//write json to file
    Writer.Write(outputFile, processedData);
}