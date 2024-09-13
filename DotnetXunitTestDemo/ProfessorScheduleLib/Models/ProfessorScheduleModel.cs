namespace ProfessorScheduleLib.Models;

public class ProfessorScheduleModel
{
    public string ProfessorName { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public List<int> Building { get; set; } = new List<int>();
}
