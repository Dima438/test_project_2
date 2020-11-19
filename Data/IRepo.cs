using System.Collections.Generic;
using DBStuff.Models;

namespace DBStuff.Data
{
    public interface IRepo
    {
        IEnumerable<Record> GetAllRecords();
        Record GetRecordById (int Id);
    }
}