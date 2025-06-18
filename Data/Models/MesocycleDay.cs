namespace Swol.Data.Models;

public class MesocycleDay
{
    public int Id { get; set; }
    public int MesocycleId { get; set; }
    public Mesocycle Mesocycle { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public ICollection<MesocycleDayExercise> Exercises { get; set; } = new List<MesocycleDayExercise>();
}
