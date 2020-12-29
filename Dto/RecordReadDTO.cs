using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBStuff.Dto
{
    public class RecordReadDTO
    {
        public int Id { get; set; }
        public string Line {get; set;}
        public string IdString {get; set;}
    }
}