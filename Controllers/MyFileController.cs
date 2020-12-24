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
    
    public class MyFileController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        public MyFileController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        [Route("api/myfile")]
        public ActionResult<string> Create (RecordCreateDTO createDto, [FromForm] IFormFile upload)
        {
            try
            {
                Record record;
                RecordReadDTO recordReadDTO;

                record = _mapper.Map<Record>(createDto);
                _repo.CreateRecord(record);

                recordReadDTO = _mapper.Map<RecordReadDTO>(record);

                if (ModelState.IsValid)
                {
                    if (upload != null && upload.Length > 0)
                    {
                        var file = new MyFile
                        {
                            Id = record.Id,
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

                        record.File = file;
                    }

                    _repo.SaveChanges();

                    return Ok("uploaded");
                }
                else
                    return BadRequest("???");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}