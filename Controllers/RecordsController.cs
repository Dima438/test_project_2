using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DBStuff.Models;
using DBStuff.Data;
using System.Linq;
using AutoMapper;
using DBStuff.Dto;
using Microsoft.AspNetCore.JsonPatch;
using DBStuff.Support;

namespace DBStuff.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        private readonly IFileRepo _fileRepo;

        public RecordsController(IRepo repo, IFileRepo fileRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _fileRepo = fileRepo;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<RecordReadDTO>> GetAllRecords()
        {
            System.Collections.Generic.IEnumerable<Record> records;
            System.Collections.Generic.IEnumerable<RecordReadDTO> dtos;

            records = _repo.GetAllRecords();
            dtos = _mapper.Map<IEnumerable<RecordReadDTO>>(records);

            return Ok(dtos);
        }
        [HttpGet("{id}", Name="GetRecordById")]
        public ActionResult<RecordReadDTO> GetRecordById(int id)
        {
            Record record;
            RecordReadDTO dto;

            record = _repo.GetRecordById(id);
            dto = _mapper.Map<RecordReadDTO>(record);

            if (record != null)
                return Ok(dto);
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<RecordReadDTO> CreateRecord(RecordCreateDTO createDto)
        {
            Record record;
            RecordReadDTO recordReadDTO;

            record = _mapper.Map<Record>(createDto);
            _repo.CreateRecord(record);
            _repo.SaveChanges();

            recordReadDTO = _mapper.Map<RecordReadDTO>(record);

            // return Ok(recordReadDTO);
            return CreatedAtRoute(nameof(GetRecordById), new {recordReadDTO.Id}, recordReadDTO); //wtf is this?
        }

        // [HttpPost("{Id}/upload")]
        // public ActionResult UploadFile(int id, string file)
        // {

        // }

        // [HttpPut("{Id}")]
        // public ActionResult UpdateRecord(int id, RecordUpdateDTO updateDTO)
        // {
        //     Record recordFromRepo;

        //     recordFromRepo = _repo.GetRecordById(id);

        //     if (recordFromRepo == null)
        //         return NotFound();
            
        //     _mapper.Map(updateDTO, recordFromRepo);
        //     _repo.UpdateRecord(recordFromRepo);
        //     _repo.SaveChanges();

        //     return NoContent();
        // }

        
        [HttpPut("{Id}/{fileId}")]
        public ActionResult UpdateRecord(int id, int fileId)
        {
            Record recordFromRepo;
            List<int> indicies;

            recordFromRepo = _repo.GetRecordById(id);

            if (recordFromRepo == null)
                return NotFound();
            
            if (fileId < _fileRepo.GetIndex())
            {
                if (recordFromRepo.IdString == null)
                    recordFromRepo.IdString = "";

                indicies = StringToList.GetIntList(recordFromRepo.IdString);

                if (indicies.Contains(fileId))
                    return BadRequest();

                recordFromRepo.IdString += " ";
                recordFromRepo.IdString += fileId.ToString();
            }

            _repo.UpdateRecord(recordFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{Id}")]
        public ActionResult PatchRecord(int id, JsonPatchDocument<RecordUpdateDTO> patch)
        {
            Record record;
            RecordUpdateDTO updateDTO;

            record = _repo.GetRecordById(id);
            if (record == null)
                return NotFound();
            
            updateDTO = _mapper.Map<RecordUpdateDTO>(record);
            patch.ApplyTo(updateDTO, ModelState);
            if (!TryValidateModel(updateDTO))
                return ValidationProblem(ModelState);

            _mapper.Map(updateDTO, record);
            _repo.UpdateRecord(record);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteRecord(int id)
        {
            Record record;

            record = _repo.GetRecordById(id);
            if (record == null)
                return NotFound();
            
            _repo.DeleteRecord(record);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}