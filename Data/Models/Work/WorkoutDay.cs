namespace Swol.Data.Models.Work;

public class WorkoutDay
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public string? Name { get; set; }
    public ICollection<WorkoutDayExercise> Exercises { get; set; } = new List<WorkoutDayExercise>();
}
