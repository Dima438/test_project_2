using System.Collections.Generic;
using System.Linq;
using DBStuff.Dto;
using DBStuff.Models;

namespace DBStuff.Data
{
    public class SqlRepo : IRepo
    {
        private readonly RecordContext _context;

        public SqlRepo(RecordContext context)
        {
            _context = context;
        }

        public void CreateRecord(Record record)
        {
            if (record == null)
                throw new System.Exception(nameof(record));
                
            _context.Add(record);
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return _context.Records.ToList();
        }

        public Record GetRecordById(int Id)
        {
            return _context.Records.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRecord(Record record)
        {
            //
        }

        // RecordReadDTO IRepo.GetRecordById(int Id)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}