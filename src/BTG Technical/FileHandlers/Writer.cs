using System.Text.Json;

namespace BTG_Technical
{
    public class Writer
    {
        /// <summary>
        /// JSON options, adding indentation and switching to camelCase.
        /// </summary>
        public static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase //standard
        };
        /// <summary>
        /// Writes a list of records to a JSON file.
        /// </summary>
        /// <param name="file">The target file.</param>
        /// <param name="data">The data to write.</param>
        public static void Write(string file, List<Record> data)
        {
            var json = JsonSerializer.Serialize(data, Options);
            File.WriteAllText(file, json);
            Console.WriteLine($"Data written to {file}.");
        }
    }
}
