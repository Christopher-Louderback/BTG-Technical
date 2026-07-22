using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG_Technical
{
    internal class Processor
    {
        internal List<Record> Process (List<Record> data)
        {
            List<Record> processedData = new List<Record>();

            foreach (Record record in data)
            {
                if (true && record.Quantity > 0 && record.UnitPrice > 0) //validate string
                {

                }
                else
                {
                    //log and dont copy
                }
            }

            return processedData;
        }
        //for each rows
        //if transaction date is valid and quantity > 0 and unit price > 0
        //continue
        //else
        //skip and log
    }
}
