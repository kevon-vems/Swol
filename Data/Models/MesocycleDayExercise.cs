namespace Swol.Data.Models;

public class MesocycleDayExercise
{
    public int Id { get; set; }
    public int MesocycleDayId { get; set; }
    public MesocycleDay MesocycleDay { get; set; } = null!;
    public int OrderInDay { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;
    public int Sets { get; set; }
    public int? RepsPerSet { get; set; }
    public double? WeightInKg { get; set; }
}
