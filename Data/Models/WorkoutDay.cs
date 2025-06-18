namespace Swol.Data.Models;

public class WorkoutDay
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public string? Name { get; set; }
    public ICollection<WorkoutDayExercise> Exercises { get; set; } = new List<WorkoutDayExercise>();
}

public class WorkoutDayExercise
{
    public int Id { get; set; }
    public int WorkoutDayId { get; set; }
    public WorkoutDay WorkoutDay { get; set; } = null!;
    public int OrderInDay { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
    public int Sets { get; set; }
    public int? RepsPerSet { get; set; }
    public double? WeightInKg { get; set; }
}
