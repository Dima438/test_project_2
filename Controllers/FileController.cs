using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DBStuff.Models;
using DBStuff.Data;
using System.Linq;
using AutoMapper;
using DBStuff.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace DBStuff.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        [Route("api/file")]
        public ActionResult<string> Upload(IFormFile file, [FromServices] IHostingEnvironment environment) //what's this? 
        {
            // string test_path = $"{environment.ContentRootPath}";

            // Console.WriteLine(test_path + "?");

            try
            {
                string fileName = $"{environment.ContentRootPath}\\FileTest\\{file.FileName}";

                Console.WriteLine(fileName);

                using (FileStream stream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                return Ok(fileName);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}