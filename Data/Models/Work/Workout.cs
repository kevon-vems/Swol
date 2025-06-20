using Swol.Data.Models.Template;

namespace Swol.Data.Models.Work;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int NumberOfWeeks { get; set; } = 4;
    public bool IsActive { get; set; } = false;
    public DateTime? StartDate { get; set; }
    public int? WorkoutTemplateId { get; set; }
    public WorkoutTemplate? WorkoutTemplate { get; set; }
    public ICollection<WorkoutDay> Days { get; set; } = new List<WorkoutDay>();
}