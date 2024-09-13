using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessorScheduleLib.Services;

namespace ProfessorSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorScheduleController : ControllerBase
    {
        private readonly IProfessorScheduleService _professorScheduleService;

        public ProfessorScheduleController(IProfessorScheduleService professorScheduleService)
        {
            _professorScheduleService = professorScheduleService;
        }

        [HttpGet("schedule")]
        public IActionResult GetProfessorSchedule()
        {
            // Call the service to get the schedule
            var schedule = _professorScheduleService.GetProfessorSchedule();

            // Return the result as a 200 OK response with the data in JSON format
            return Ok(schedule);
        }

    }
}
