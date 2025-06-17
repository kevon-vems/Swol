namespace Swol.Data.Models;

public class ExerciseSet
{
    public int Id { get; set; }
    public int WorkoutLogId { get; set; }
    public WorkoutLog WorkoutLog { get; set; } = null!;
    
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
    
    public int SetNumber { get; set; }
    public int? Reps { get; set; }
    public double? WeightInKg { get; set; }
    public TimeSpan? Duration { get; set; }
    public string? Notes { get; set; }
}