using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Record> GetAllRecords()
        {
            return _context.Records.ToList();
        }

        public Record GetRecordById(int Id)
        {
            return _context.Records.FirstOrDefault(p => p.Id == Id);
        }
    }
}