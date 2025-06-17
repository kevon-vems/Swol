namespace Swol.Data.Models;

public class Mesocycle
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Today;
    public int NumberOfWeeks { get; set; } = 4;
    public bool IncludeDeloadWeek { get; set; } = true;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // A Mesocycle has one primary workout that is repeated each week with progressive overload
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
    
    // Navigation property for WorkoutLogs performed as part of this Mesocycle
    public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
    
    // Calculated property (not mapped to database)
    public int CurrentWeek => Math.Min(
        Math.Max(1, (int)Math.Ceiling((DateTime.Today - StartDate).TotalDays / 7.0)), 
        NumberOfWeeks);
    
    public bool IsDeloadWeek => IncludeDeloadWeek && CurrentWeek == NumberOfWeeks;
    
    public DateTime EndDate => StartDate.AddDays(NumberOfWeeks * 7 - 1);
    
    public bool IsCompleted => DateTime.Today > EndDate;
}