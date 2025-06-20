namespace Swol.Data.Models.Work;

public class WorkoutDayExerciseSet
{
    public int Id { get; set; }
    public int WorkoutDayExerciseId { get; set; }
    public WorkoutDayExercise WorkoutDayExercise { get; set; } = null!;
    public int SetNumber { get; set; }
    public int Reps { get; set; }
    public decimal WeightInLb { get; set; }
}
