using ProfessorScheduleLib.Models;

namespace ProfessorScheduleLib.Services;

public class ProfessorScheduleService : IProfessorScheduleService
{
    private ProfessorScheduleModel  professorScheduleModel = new ProfessorScheduleModel{
            ProfessorName = "Dr. Chris Lima",
            Schedule = "Segunda a Sexta, 10:00 AM - 11:00 AM",
            Period = "Noturno",
            Room = "3",
            Building = new List<int> { 4 }
        };
    public ProfessorScheduleModel GetProfessorSchedule()
    {
        return professorScheduleModel;
    }
}
