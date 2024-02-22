
using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;
using Solid.Data;
using AutoMapper;
using Solid.Core.DTOs;
using Solid.API.models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService, IMapper mapper)
        {
            _trainingService = trainingService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> Get()
        {
            //return _trainingService.GetAllTraining();

            var list =  _trainingService.GetAllTraining();
            var listDto = _mapper.Map<IEnumerable<StudentDTO>>(list);

            await Task.WhenAll(list);

            return Ok(listDto);
        }

        // GET: api/<EventController>
        [HttpGet("{id}")]
        public ActionResult<Training> Get(int id)
        {
            //if (_trainingService.GetIdTraining(id) == null)
            //    return NotFound();
            ////return Ok(train);
            //return _trainingService.GetIdTraining(id);


            var train = _trainingService.GetIdTraining(id);
            var trainDto = _mapper.Map<TrainingDTO>(train);
            return Ok(trainDto);
        }


        // POST api/<EventController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrainingPostModel train)
        {

            //_trainingService.PostTraining(t);


            var trainingToAdd = _mapper.Map<Training>(train);
            await _trainingService.PostTraining(trainingToAdd);
            var trainingDto = _mapper.Map<TrainingDTO>(trainingToAdd);
            return Ok(trainingDto);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TrainingPostModel training)
        {
            //_trainingService.PutTraining(t, id);


            var existTraining = _trainingService.GetIdTraining(id);//שליפת היוזר הקיים
            if (existTraining is null)//אם לא קיים - להחזיר 404
            {
                return NotFound();
            }

            _mapper.Map(training, existTraining);//מיפוי הערכים מהפוסט-מודל ליוזר מהטבלה

            _trainingService.PutTraining(existTraining, id);//שליחה לעדכון בטבלה

            return Ok(_mapper.Map<TrainingDTO>(existTraining));//מיפוי והחזרה לקליינט
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var train = _trainingService.GetAllTraining().Find(e => e.Id == id);
            //_trainingService.GetAllTraining().Remove(train);
            _trainingService.RemoveTraining(id);
        }
    }
}
