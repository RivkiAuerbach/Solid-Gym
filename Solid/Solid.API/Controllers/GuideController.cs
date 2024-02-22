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
    public class GuideController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService, IMapper mapper)
        {
            _guideService = guideService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guide>>> Get()
        {

            //return _guideService.GetAllGuide();

            var list = _guideService.GetAllGuide();
            var listDto = _mapper.Map<IEnumerable<GuideDTO>>(list);

            await Task.WhenAll(list);

            return Ok(listDto);
        }

        // GET: api/<EventController>
        [HttpGet("{id}")]
        public ActionResult<Guide> Get(int id)
        {

            //if (_guideService.GetIdGuide(id) == null)
            //    return NotFound();
            ////return Ok(guid);
            //return _guideService.GetIdGuide(id);


            var guide = _guideService.GetIdGuide(id);
            var guideDto = _mapper.Map<GuideDTO>(guide);
            return Ok(guideDto);
        }

        // POST api/<EventController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GuidePostModel guide)
        {
            //_guideService.PostGuide(g);

           var guideToAdd = _mapper.Map<Guide>(guide); 
           await  _guideService.PostGuide(guideToAdd);
           var guideDto = _mapper.Map<GuideDTO>(guideToAdd);
           return Ok(guideDto);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GuidePostModel guide)
        {

            //_guideService.PutGuide(g, id);


            var existGuide = _guideService.GetIdGuide(id);//שליפת היוזר הקיים
            if (existGuide is null)//אם לא קיים - להחזיר 404
            {
                return NotFound();
            }

            _mapper.Map(guide, existGuide);//מיפוי הערכים מהפוסט-מודל ליוזר מהטבלה

            _guideService.PutGuide(existGuide, id);//שליחה לעדכון בטבלה

            return Ok(_mapper.Map<GuideDTO>(existGuide));//מיפוי והחזרה לקליינט

        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var guid = _guideService.GetAllGuide().Find(e => e.Id == id);
            //_guideService.GetAllGuide().Remove(guid);
            _guideService.RemoveGuide(id);
        }
    }
}
