using System.Collections.Generic;
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

        public virtual ICollection<MyFile> Files { get; set; }

    }
}