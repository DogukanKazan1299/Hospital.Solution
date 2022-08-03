using Hospital.Business.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly INurseService _nurseService;
        public NursesController(INurseService nurseService)
        {
            _nurseService= nurseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _nurseService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _nurseService.GetByNurse(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddNurse(Nurse nurse)
        {
            var result = _nurseService.Add(nurse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteNurse(Nurse nurse)
        {
            var result = _nurseService.Delete(nurse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult UpdateNurse(Nurse nurse)
        {
            var result = _nurseService.Update(nurse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
