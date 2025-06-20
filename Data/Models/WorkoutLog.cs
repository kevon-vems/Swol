namespace Swol.Data.Models;

public class WorkoutLog
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    
    // Optional reference to a Workout Template (if this workout is part of one)
    public int? WorkoutTemplateId { get; set; }
    public WorkoutTemplate? WorkoutTemplate { get; set; }
    
    // Week number within the Workout Template (if applicable)
    public int? WorkoutTemplateWeek { get; set; }
    
    // Reference to the specific MesocycleDay (if applicable)
    public int? MesocycleDayId { get; set; }
    public MesocycleDay? MesocycleDay { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Notes { get; set; }
    
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}