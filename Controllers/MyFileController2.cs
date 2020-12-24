using AutoMapper;
using DBStuff.Data;
using DBStuff.Dto;
using DBStuff.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web;

namespace DBStuff.Controllers
{
    
    public class MyFileController2 : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        public MyFileController2(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        // [ValidateAntiForgeryToken]
        [Route("api/myfile/{Id}")]
        public ActionResult<string> Create ([FromRoute] int id, [FromForm] IFormFile upload)
        {           

            try
            {
                Record recordFromRepo;
                // RecordReadDTO recordReadDTO;

                recordFromRepo = _repo.GetRecordById(id);

                if (recordFromRepo == null)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    if (upload != null && upload.Length > 0)
                    {
                        var file = new MyFile
                        {
                            Id = recordFromRepo.Id,
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            ContentType = upload.ContentType
                        };

                        // using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        // {
                        //     file.Content = reader.ReadBytes((int)upload.Length);
                        // }

                        using var fileStream = upload.OpenReadStream();
                        byte[] bytes = new byte[upload.Length];
                        fileStream.Read(bytes, 0, (int)upload.Length);    

                        recordFromRepo.File = file;

                        _repo.UpdateRecord(recordFromRepo);
                        _repo.SaveChanges();

                        return Ok("fine");
                    }
                    else
                        return BadRequest("here");
                }
                else
                    return BadRequest("there");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}