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

//this controller works sometimes;
//gotta fill in the name field in rester for whatever reason;

//use controller's request to manually fetch the file
//[FromRoute] / [FromQuery]

namespace DBStuff.Controllers
{
    public class FileController : Controller
    {
        
        [HttpPost]
        [Route("api/file")]
        public ActionResult<string> Upload([FromForm] IFormFile file, [FromServices] IHostingEnvironment environment) //what's this? 
        {
            // string test_path = $"{environment.ContentRootPath}";

            // Console.WriteLine(test_path + "?");

            try
            {
                var item = Request.Form.Files[0];   
                // string fileName = $"{environment.ContentRootPath}\\FileTest\\{file.FileName}";
                string fileName = $"{environment.ContentRootPath}\\FileTest\\{item.FileName}";

                Console.WriteLine(fileName);

                using (FileStream stream = System.IO.File.Create(fileName))
                {
                    item.CopyTo(stream);
                    stream.Flush();
                }

                return Ok(fileName);
            }
            catch (Exception e)
            {
                //
                Console.WriteLine(e.Message);
                //
                return BadRequest(e.Message);
            }
            
        }
    }
}