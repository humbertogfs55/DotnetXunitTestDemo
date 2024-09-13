using ProfessorScheduleLib.Models;

namespace ProfessorScheduleLib.Services;

public class ProfessorScheduleService : IProfessorScheduleService
{
    private ProfessorScheduleModel  professorScheduleModel = new ProfessorScheduleModel{
            NomeDoProfessor = "Dr. Chris Lima",
            HorarioDeAtendimento = "Segunda a Sexta, 10:00 AM - 11:00 AM",
            Periodo = "Integral",
            Sala = "3",
            Predio = new List<int> { 4 }
        };
    public ProfessorScheduleModel GetProfessorSchedule()
    {
        return professorScheduleModel;
    }

    public ProfessorScheduleModel GetProfessorByName(string nomeDoProfessor)
    {
        // Simulate searching for a professor by name
        var schedule = nomeDoProfessor == "Dr. Chris Lima" ? professorScheduleModel : new ProfessorScheduleModel{ NomeDoProfessor = "notFound"};
        return schedule;
    }
}
