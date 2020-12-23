using DBStuff.Models;

namespace DBStuff.Dto
{
    public class RecordReadDTO
    {
        public int Id { get; set; }
        public string Line {get; set;}
        public MyFile File { get; set; }
    }
}