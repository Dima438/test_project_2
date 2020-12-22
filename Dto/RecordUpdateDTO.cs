using System.ComponentModel.DataAnnotations;

namespace DBStuff.Dto
{
    public class RecordUpdateDTO
    {
        [Required]
        public string Line {get; set;}
        [Required]
        public string AnotherLine {get; set;}
    }
}