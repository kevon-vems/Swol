using Swol.Data.Models.Config;

namespace Swol.Data.Models.Work;

public class WorkoutDayExercise
{
    public int Id { get; set; }
    public int WorkoutDayId { get; set; }
    public WorkoutDay WorkoutDay { get; set; } = null!;
    public int OrderInDay { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public ICollection<WorkoutDayExerciseSet> Sets { get; set; } = new List<WorkoutDayExerciseSet>();
}
