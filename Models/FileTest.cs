using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DBStuff.Models
{
    public class FileTest
    {
        public IFormFile file {get; set;}
    }
}