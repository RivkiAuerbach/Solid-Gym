
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
    public class TrainingController : ControllerBase
    {  private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        [HttpGet]
        public IEnumerable<Training> Get()
        {
            return _trainingService.GetAllTraining();
        }

        // GET: api/<EventController>
        [HttpGet("{id}")]
        public ActionResult<Training> Get(int id)
        {
            //var train = _trainingService.GetAllTraining().Find(e => e.Id == id);
            if (_trainingService.GetIdTraining(id) == null)
                return NotFound();
            //return Ok(train);
            return _trainingService.GetIdTraining(id);
        }


        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Training t)
        {
            //var maxTrain = _trainingService.GetAllTraining().Max(e => e.Id);
            //t.Id = ++maxTrain;
            //_trainingService.GetAllTraining().Add(t);
            _trainingService.PostTraining(t);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Training t)
        {
            //var train = _trainingService.GetAllTraining().Find(e => e.Id == id);
            //train.Title = t.Title;
            //train.Day = t.Day;
            //train.Hour = t.Hour;
            //train.Student = t.Student;
            //train.Guide = t.Guide;
            _trainingService.PutTraining(t, id);
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
