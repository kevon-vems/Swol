using Swol.Data.Models.Config;

namespace Swol.Data.Models.Template;

public class WorkoutTemplateDayExercise
{
    public int Id { get; set; }
    public int WorkoutTemplateDayId { get; set; }
    public WorkoutTemplateDay WorkoutTemplateDay { get; set; } = null!;
    public int OrderInDay { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
}
