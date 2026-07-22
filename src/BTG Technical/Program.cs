using BTG_Technical;

Console.WriteLine("Enter input file.");
string? inputFile = Console.ReadLine();
Console.WriteLine("Enter output file.");
string? outputFile = Console.ReadLine();


if (inputFile != null && outputFile != null)
{
    Console.WriteLine("Reading file and extracting data.");
    Reader reader = new Reader();
    List<Record> data = reader.ReadFile(inputFile);
    Console.WriteLine("File read and data extracted. Processing data.");
    //Processor processor = new Processor(data);
}
//take args 0 and 1, 0 = csv, 1 = where writing to
//assign to variable and pass to reader (di)
//reader/extractor(?) assigns results to ds to pass to processor
//pass product to writer



/*
 * class to open + read
 * prompt user for file name, generate output file
 * class to extract
 * call all in main
 * class to validate and calculate
 * class to produce json output*/