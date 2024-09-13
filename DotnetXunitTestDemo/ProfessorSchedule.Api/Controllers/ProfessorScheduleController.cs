using Microsoft.AspNetCore.Mvc;
using ProfessorScheduleLib.Senders;
using ProfessorScheduleLib.Services;

namespace ProfessorSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorScheduleController : ControllerBase
    {
        private ProfessorScheduleSender _professorScheduleSender;
        public ProfessorScheduleController(ProfessorScheduleSender professorScheduleSender)
        {
            _professorScheduleSender = professorScheduleSender;
        }

        [HttpGet("schedule")]
        public IActionResult GetProfessorSchedule()
        {
            // Call the service to get the schedule
            var schedule = _professorScheduleSender.SendGetProfessorSchedule();

            // Return the result as a 200 OK response with the data in JSON format
            return Ok(schedule);
        }

    }
}
