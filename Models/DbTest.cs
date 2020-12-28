using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DBStuff.Models
{
    public class DbTest
    {
        [Key]
        public int aNumber {get; set;}
        public string aString {get; set;}
    }
}