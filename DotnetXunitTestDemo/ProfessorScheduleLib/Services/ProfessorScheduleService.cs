using ProfessorScheduleLib.Models;

namespace ProfessorScheduleLib.Services;

public class ProfessorScheduleService : IProfessorScheduleService
{
    public ProfessorScheduleModel GetProfessorSchedule()
    {
        return new ProfessorScheduleModel
        {
            NomeDoProfessor = "Dr. Chris Lima",
            HorarioDeAtendimento = "Segunda a Sexta, 10:00 AM - 11:00 AM",
            Periodo = "Integral",
            Sala = "3",
            Predio = new List<int> { 4 }
        };
    }
}
