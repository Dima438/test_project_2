using System.Collections.Generic;
using DBStuff.Models;

namespace DBStuff.Data
{
    public class MockRepo : IRepo
    {
        public IEnumerable<Record> GetAllRecords()
        {
            List<Record> records;

            records = new List<Record>
            {
                new Record(1, "", ""),
                new Record(666, "x", "y"),
            };
            
            return records;
        }

        public Record GetRecordById(int Id)
        {
            return new Record(-1, "ass", "why");
        }
    }
}