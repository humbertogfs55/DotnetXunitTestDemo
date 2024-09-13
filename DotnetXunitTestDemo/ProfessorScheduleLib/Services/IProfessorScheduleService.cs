using ProfessorScheduleLib.Models;

namespace ProfessorScheduleLib.Services;

public interface IProfessorScheduleService
{
    ProfessorScheduleModel GetProfessorSchedule();
    ProfessorScheduleModel GetProfessorByName(string nomeDoProfessor);

}
