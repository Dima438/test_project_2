using System.Collections.Generic;
using DBStuff.Dto;
using DBStuff.Models;

namespace DBStuff.Data
{
    public interface IRepo
    {
        bool SaveChanges();
        IEnumerable<Record> GetAllRecords();
        Record GetRecordById (int Id);
        void CreateRecord(Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(Record record);
    }
}