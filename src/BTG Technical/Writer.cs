using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG_Technical
{
    internal class Writer
    { //need to clean json indents etc. (review)
        internal void Write(string file, List<Record> data)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(file, json);
            Console.WriteLine($"Data written to {file}.");
        }
    }
    //write output to file
    //Produce JSON output containing the transformed records.
}
