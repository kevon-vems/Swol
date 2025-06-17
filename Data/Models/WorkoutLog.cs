namespace Swol.Data.Models;

public class WorkoutLog
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    
    // Optional reference to a Mesocycle (if this workout is part of one)
    public int? MesocycleId { get; set; }
    public Mesocycle? Mesocycle { get; set; }
    
    // Week number within the Mesocycle (if applicable)
    public int? MesocycleWeek { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Notes { get; set; }
    
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}