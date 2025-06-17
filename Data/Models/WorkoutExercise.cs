namespace Swol.Data.Models;

public class WorkoutExercise
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
    
    public int Sets { get; set; }
    public int? RepsPerSet { get; set; }
    public double? WeightInKg { get; set; }
    public int OrderInWorkout { get; set; }
}