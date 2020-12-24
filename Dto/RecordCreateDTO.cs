using System.ComponentModel.DataAnnotations;
using DBStuff.Models;

namespace DBStuff.Dto
{
    public class RecordCreateDTO
    {
        [Required]
        public string Line {get; set;}
        [Required]
        public string AnotherLine {get; set;}
        public MyFile File { get; set; }
    }
}