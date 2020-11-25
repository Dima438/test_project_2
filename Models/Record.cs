using System.ComponentModel.DataAnnotations;

namespace DBStuff.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Line {get; set;}
        [Required]
        public string AnotherLine {get; set;}

        // public Record(int Id, string Line, string AnotherLine)
        // {
        //     this.Id = Id;
        //     this.Line = Line;
        //     this.AnotherLine = AnotherLine;
        // }
    }
}