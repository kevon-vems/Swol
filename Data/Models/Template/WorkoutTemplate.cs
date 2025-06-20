namespace Swol.Data.Models.Template;

public class WorkoutTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int NumberOfWeeks { get; set; } = 4;
    public bool IsActive { get; set; } = false;
    public DateTime? StartDate { get; set; }
    public ICollection<WorkoutTemplateDay> Days { get; set; } = new List<WorkoutTemplateDay>();
}