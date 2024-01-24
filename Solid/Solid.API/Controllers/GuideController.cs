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
    public class GuideController : ControllerBase
    {
        
        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            //return _dataContext.GuideList;
            return _guideService.GetAllGuide();
        }

        // GET: api/<EventController>
        [HttpGet("{id}")]
        public ActionResult<Guide> Get(int id)
        {
            
            if (_guideService.GetIdGuide(id) == null)
                return NotFound();
            //return Ok(guid);
            return _guideService.GetIdGuide(id);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Guide g)
        {
            //var maxGuide = _guideService.GetAllGuide().Max(e => e.Id);
            //g.Id = ++maxGuide;
            //_guideService.GetAllGuide().Add(g);
            _guideService.PostGuide(g);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide g)
        {
            //var guid = _guideService.GetAllGuide().Find(e => e.Id == id);
            //guid.Name = g.Name;
            //guid.Seniority = g.Seniority;
            //guid.Address = g.Address;
            _guideService.PutGuide(g, id);
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
