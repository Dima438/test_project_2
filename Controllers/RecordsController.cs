using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DBStuff.Models;
using DBStuff.Data;
using System.Linq;

namespace DBStuff.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly MockRepo _mock_repo = new MockRepo();
        [HttpGet]
        public ActionResult<IEnumerable<Record>> GetAllRecords()
        {
            List<Record> records;

            records = _mock_repo.GetAllRecords().ToList<Record>();

            return Ok(records);
        }
        [HttpGet("{id}")]
        public ActionResult<Record> GetRecordById(int id)
        {
            Record record;

            record = _mock_repo.GetRecordById(id);

            return Ok(record);
        }
    }
}