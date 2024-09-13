using ProfessorScheduleLib.Models;
using ProfessorScheduleLib.Services;

namespace ProfessorScheduleLib.Senders;

public class ProfessorScheduleSender
{
    private readonly IProfessorScheduleService _professorScheduleService;

    public ProfessorScheduleSender(IProfessorScheduleService professorScheduleService)
    {
        _professorScheduleService = professorScheduleService;
    }

    public ProfessorScheduleModel SendGetProfessorSchedule(){
        return _professorScheduleService.GetProfessorSchedule();
    }
}
