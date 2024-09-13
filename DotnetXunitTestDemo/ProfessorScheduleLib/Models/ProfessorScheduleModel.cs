namespace ProfessorScheduleLib.Models;

public class ProfessorScheduleModel
{
    public string NomeDoProfessor { get; set; } = string.Empty;
    public string HorarioDeAtendimento { get; set; } = string.Empty;
    public string Periodo { get; set; } = string.Empty;
    public string Sala { get; set; } = string.Empty;
    public List<int> Predio { get; set; } = new List<int>();
}
