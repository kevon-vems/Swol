namespace Swol.Data.Models;

public class MesocycleDay
{
    public int Id { get; set; }
    public int WorkoutTemplateId { get; set; }
    public WorkoutTemplate WorkoutTemplate { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public int WeekNumber { get; set; } // Added for workout progression
    public int DayNumber { get; set; } // Added for workout progression
    public ICollection<MesocycleDayExercise> Exercises { get; set; } = new List<MesocycleDayExercise>();
}
