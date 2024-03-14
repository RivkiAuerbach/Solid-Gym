using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;
using Solid.Data;
using AutoMapper;
using Solid.Core.DTOs;
using System;
using Solid.API.models;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet]       
        public async Task<ActionResult<IEnumerable<Student>>> Get()
          {

                //return _studentService.GetAllStudent();

                var list =  _studentService.GetAllStudent();
                var listDto = _mapper.Map<IEnumerable<StudentDTO>>(list);

                await Task.WhenAll(list);

               return Ok(listDto);
          }
        

        // GET: api/<EventController>
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            //if (_studentService.GetIdStudent(id) == null)
            //    return NotFound();
            ////return Ok(stud);
            //return _studentService.GetIdStudent(id);


            var stud = _studentService.GetIdStudent(id);
            var studDto = _mapper.Map<GuideDTO>(stud);
            return Ok(studDto);
        }

        // POST api/<EventController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentPostModel stud)
        {
            //_studentService.PostStudent(s);

            var studentToAdd = _mapper.Map<Student>(stud);
            await  _studentService.PostStudent(studentToAdd);
            var studentDto = _mapper.Map<GuideDTO>(studentToAdd);
            return Ok(studentDto);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentPostModel student)
        {

            //_studentService.PutStudent(s, id);


            var existStudent = _studentService.GetIdStudent(id);//שליפת היוזר הקיים
            if (existStudent is null)//אם לא קיים - להחזיר 404
            {
                return NotFound();
            }

            _mapper.Map(student, existStudent);//מיפוי הערכים מהפוסט-מודל ליוזר מהטבלה

            _studentService.PutStudent(existStudent, id);//שליחה לעדכון בטבלה

            return Ok(_mapper.Map<StudentDTO>(existStudent));//מיפוי והחזרה לקליינט
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
