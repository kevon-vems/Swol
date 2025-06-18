namespace Swol.Data.Models;

// This file is now obsolete and can be deleted. The new structure uses MesocycleDay with WeekNumber for week grouping.
public class MesocycleWeek
{
    public int Id { get; set; }
    public int MesocycleId { get; set; }
    public Mesocycle Mesocycle { get; set; } = null!;
    public int WeekNumber { get; set; }
    public ICollection<MesocycleDay> Days { get; set; } = new List<MesocycleDay>();
}
