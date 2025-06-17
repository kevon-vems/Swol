namespace Swol.Data.Models;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Category { get; set; } // E.g., "Chest", "Back", "Legs"
    public int MuscleGroupId { get; set; } // Legacy, can be removed after migration
    public MuscleGroup MuscleGroup { get; set; } = null!; // Legacy, can be removed after migration
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    public ICollection<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; } = new List<ExerciseMuscleGroup>();
}