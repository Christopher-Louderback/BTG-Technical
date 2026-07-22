using System.Text.Json;

namespace BTG_Technical
{
    public class Writer
    {
        public static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase //standard
        };
        public static void Write(string file, List<Record> data)
        {
            var json = JsonSerializer.Serialize(data, Options);
            File.WriteAllText(file, json);
            Console.WriteLine($"Data written to {file}.");
        }
    }
}
