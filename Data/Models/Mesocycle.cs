namespace Swol.Data.Models;

public class Mesocycle
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Today;
    public int NumberOfWeeks { get; set; } = 4;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<MesocycleDay> Days { get; set; } = new List<MesocycleDay>();
    public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
}