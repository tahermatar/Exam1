using CsvHelper;
using Exam1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private exam1Context _exam1Context;
        public ExamController(exam1Context exaexam1Context)
        {
            _exam1Context = exaexam1Context;
        }
        // GET: api/<ExamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var category = _exam1Context.Categories.ToList();
            var subcategor = _exam1Context.Subcategories.ToList();
            var item = _exam1Context.Items.ToList();

            return new string[] { "value1", "value2" };
        }
        [HttpGet("[action]")]
        public IActionResult Export()
        {
            var csvpath = Path.Combine(Environment.CurrentDirectory, $"Items-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvpath))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    var data = _exam1Context.Categories.SelectMany(x => x.Subcategories).SelectMany(x => x.Items).ToList();
                    csvWriter.WriteRecords(data);
                }
            }
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
