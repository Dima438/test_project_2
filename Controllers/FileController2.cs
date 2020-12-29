using AutoMapper;
using DBStuff.Data;
using DBStuff.Dto;
using DBStuff.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace DBStuff.Controllers
{
    
    public class FileController2 : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IFileRepo _fileRepo;
        private readonly IMapper _mapper;

        public FileController2(IRepo repo, IFileRepo fileRepo, IMapper mapper)
        {
            _repo = repo;
            _fileRepo = fileRepo;
            _mapper = mapper;

            // Console.WriteLine("constructor called\n");
        }


       [HttpPost]
       [Route("api/file")]
        public ActionResult<int> CreateFile()
        {
            DbTest file;
            int id;

            id = _fileRepo.GetIndex();
            file = new DbTest{Id = 0, Name = "file" + id.ToString()}; //why does this work? 

            _fileRepo.UploadFile(file);
            _fileRepo.SaveChanges();

            return Ok(id);
        }

        [HttpPut]
        [Route("api/file/{Id}")]
        public ActionResult<string> Create ([FromRoute] int id, [FromForm] IFormFile upload, [FromServices] IHostingEnvironment environment)
        {           
            try
            {
                var file = _fileRepo.GetFileById(id);

                if (file == null)
                    return NotFound();

                var item = Request.Form.Files[0];   
                // string fileName = $"{environment.ContentRootPath}\\FileTest\\{file.FileName}";


                if (ModelState.IsValid && item != null)
                {
                    using var fileStream = item.OpenReadStream();
                    byte[] bytes = new byte[item.Length];
                    fileStream.Read(bytes, 0, (int)item.Length);    
                    file.Content = bytes;

                    // recordFromRepo.Content = bytes;
                    // // recordFromRepo.File = file;

                    _fileRepo.SaveChanges();

                    return Ok("fine");
                }
                else
                    return BadRequest("here");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/file/{Id}")]
        public ActionResult<string> Upload(int id, [FromServices] IHostingEnvironment environment)
        {
            // string test_path = $"{environment.ContentRootPath}";

            // Console.WriteLine(test_path + "?");

            var file = _fileRepo.GetFileById(id);
            var item = file.Content;

            try
            {
                // string fileName = $"{environment.ContentRootPath}\\FileTest\\{file.FileName}";
                string fileName = $"{environment.ContentRootPath}\\FileTest\\file";
                fileName += id.ToString();

                Console.WriteLine(fileName);

                using (FileStream stream = System.IO.File.Create(fileName))
                {
                    Stream bytes = new MemoryStream(item);
                    bytes.CopyTo(stream);
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