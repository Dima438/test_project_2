using AutoMapper;
using DBStuff.Data;
using DBStuff.Dto;
using DBStuff.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}