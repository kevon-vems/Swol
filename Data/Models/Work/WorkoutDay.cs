namespace Swol.Data.Models.Work;

public class WorkoutDay
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    public string Label { get; set; } = string.Empty;
    public int WeekNumber { get; set; } = 1;
    public int OrderNumber { get; set; }
    public bool IsCompleted { get; set; }
    public string? Name { get; set; }
    public ICollection<WorkoutDayExercise> Exercises { get; set; } = new List<WorkoutDayExercise>();
}
