using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;
using Solid.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.GetAllStudent();
        }

        // GET: api/<EventController>
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            //var stud= _studentService.GetAllStudent().Find(e => e.Id == id);
            if (_studentService.GetIdStudent(id) == null)
                return NotFound();
            //return Ok(stud);
            return _studentService.GetIdStudent(id);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Student s)
        {
            //var maxStudent = _studentService.GetAllStudent().Max(e => e.Id);
            //s.Id = ++maxStudent;
            //_studentService.GetAllStudent().Add(s);
            _studentService.PostStudent(s);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student s)
        {
            //var stud = _studentService.GetAllStudent().Find(e => e.Id == id);
            //stud.Name = s.Name;
            //stud.Age = s.Age;
            //stud.Address = s.Address;
            _studentService.PutStudent(s, id);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var stud = _studentService.GetAllStudent().Find(e => e.Id == id);
            //_studentService.GetAllStudent().Remove(stud);
            _studentService.RemoveStudent(id);
        }
    }
}
