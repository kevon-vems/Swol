using Swol.Data.Models.Work;

namespace Swol.Data.Models.Template;

public class WorkoutTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public ICollection<WorkoutTemplateDay> Days { get; set; } = new List<WorkoutTemplateDay>();
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}