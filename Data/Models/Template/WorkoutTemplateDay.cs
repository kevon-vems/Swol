namespace Swol.Data.Models.Template;

public class WorkoutTemplateDay
{
    public int Id { get; set; }
    public int WorkoutTemplateId { get; set; }
    public WorkoutTemplate WorkoutTemplate { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public string Label { get; set; } = string.Empty;
    public int OrderNumber { get; set; }
    public ICollection<WorkoutTemplateDayExercise> Exercises { get; set; } = new List<WorkoutTemplateDayExercise>();
}
