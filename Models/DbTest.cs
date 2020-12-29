using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DBStuff.Models
{
    public class DbTest
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public byte[] Content { get; set; }
    }
}