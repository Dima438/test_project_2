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
        [HttpGet("{id}")]
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

            record = _mapper.Map<Record>(createDto);
            _repo.CreateRecord(record);
            _repo.SaveChanges();

            return Ok(record);
        }
    }
}