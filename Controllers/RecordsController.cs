using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DBStuff.Models;
using DBStuff.Data;
using System.Linq;
using AutoMapper;
using DBStuff.Dto;

namespace DBStuff.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        public RecordsController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // private readonly MockRepo _mock_repo = new MockRepo();
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

        [HttpPut("{Id}")]
        public ActionResult UpdateRecord(int id, RecordUpdateDTO updateDTO)
        {
            Record recordFromRepo;

            recordFromRepo = _repo.GetRecordById(id);

            if (recordFromRepo == null)
                return NotFound();
            
            _mapper.Map(updateDTO, recordFromRepo);
            _repo.UpdateRecord(recordFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}