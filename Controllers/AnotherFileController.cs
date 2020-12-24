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
    [Route("api/upload")]
    public class AnotherFileController : ControllerBase
    {
        public static IWebHostEnvironment _environment;

        public AnotherFileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public ActionResult<string> Post([FromForm] FileTest fileTest)
        {
            try
            {
                // string path = _environment.WebRootPath;

                string path = "D:\\new_training\\C#\\db_stuff";

                path += "\\FileTest\\";

                Console.WriteLine("Current path: " + path);

                if (fileTest.file != null)
                    Console.WriteLine("Current file: " + fileTest.file.FileName);
                else
                    Console.WriteLine("File is null");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream stream = System.IO.File.Create(path + fileTest.file.FileName))
                {
                    Console.WriteLine("Copying...");

                    fileTest.file.CopyTo(stream);
                    stream.Flush();

                    return Ok("Success!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");

                return BadRequest(ex.Message);
            }
        }
    }
}