using System.Collections.Generic;
using DBStuff.Dto;
using DBStuff.Models;

namespace DBStuff.Data
{
    public interface IFileRepo
    {
        bool SaveChanges();
        DbTest GetFileById (int Id);
        void UploadFile(DbTest file);
        int GetIndex();
    }
}