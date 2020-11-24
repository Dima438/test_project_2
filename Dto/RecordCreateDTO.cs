using System.ComponentModel.DataAnnotations;

namespace DBStuff.Dto
{
    public class RecordCreateDTO
    {
        [Required]
        public string Line {get; set;}
        [Required]
        public string AnotherLine {get; set;}
    }
}