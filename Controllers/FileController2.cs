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
        private readonly IMapper _mapper;

        public FileController2(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("api/file/{Id}")]
        public ActionResult<string> Create ([FromRoute] int id, [FromForm] IFormFile upload, [FromServices] IHostingEnvironment environment)
        {           
            try
            {
                Record recordFromRepo;
                // RecordReadDTO recordReadDTO;

                recordFromRepo = _repo.GetRecordById(id);

                if (recordFromRepo == null)
                    return NotFound();

                var item = Request.Form.Files[0];   
                // string fileName = $"{environment.ContentRootPath}\\FileTest\\{file.FileName}";


                if (ModelState.IsValid && item != null)
                {
                    // var file = new MyFile
                    // {
                    //     Id = recordFromRepo.Id,
                    //     FileName = System.IO.Path.GetFileName(item.FileName),
                    //     ContentType = item.ContentType
                    // };

                    // using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    // {
                    //     file.Content = reader.ReadBytes((int)upload.Length);
                    // }

                    using var fileStream = item.OpenReadStream();
                    byte[] bytes = new byte[item.Length];
                    fileStream.Read(bytes, 0, (int)item.Length);    
                    recordFromRepo.Content = bytes;
                    // recordFromRepo.File = file;

                    _repo.UpdateRecord(recordFromRepo);
                    _repo.SaveChanges();

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
        public ActionResult<string> Upload(int id, [FromServices] IHostingEnvironment environment) //what's this? 
        {
            // string test_path = $"{environment.ContentRootPath}";

            // Console.WriteLine(test_path + "?");

            var record = _repo.GetRecordById(id);
            var item = record.Content;

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

        // public HttpResponseMessage Generate()
        // {
        //     var stream = new MemoryStream();

        //     var result = new HttpResponseMessage(HttpStatusCode.OK)
        //     {
        //         Content = new ByteArrayContent(stream.ToArray())
        //     };
        //     result.Content.Headers.ContentDisposition =
        //         new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //     {
        //         FileName = "file"
        //     };
        //     result.Content.Headers.ContentType =
        //         new MediaTypeHeaderValue("application/octet-stream");

        //     return result;
        // }
    }
}