using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBStuff.Dto
{
    public class RecordUpdateDTO
    {
        [Required]
        public string Line {get; set;}
        [Required]
        public string AnotherLine {get; set;}
        public string IdString {get; set;}
    }
}