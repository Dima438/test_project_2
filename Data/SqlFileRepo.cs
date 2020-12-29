using System.Collections.Generic;
using System.Linq;
using DBStuff.Dto;
using DBStuff.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBStuff.Data
{
    public class SqlFileRepo : IFileRepo
    {
        private readonly RecordContext _context;
        // public int current_id {get; set;}

        public SqlFileRepo(RecordContext context)
        {
            _context = context;
            // current_id = 0;
        }

        public int GetIndex()
        {
            // return _context.Files.OrderByDescending(p => p.Id).FirstOrDefault().Id; //this does not work
            return _context.Files.Count();

        }

        public DbTest GetFileById (int Id)
        {
            return _context.Files.FirstOrDefault(p => p.Id == Id);
        }
        public void UploadFile(DbTest file)
        {
            if (file == null)
                throw new System.Exception(nameof(file));
            
            // current_id ++;
            _context.Add(file);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}