using Microsoft.EntityFrameworkCore;
using Swol.Data.Models;

namespace Swol.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<WorkoutDay> WorkoutDays => Set<WorkoutDay>();
    public DbSet<WorkoutDayExercise> WorkoutDayExercises => Set<WorkoutDayExercise>();
    public DbSet<WorkoutLog> WorkoutLogs => Set<WorkoutLog>();
    public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();
    public DbSet<MuscleGroup> MuscleGroups => Set<MuscleGroup>();
    public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups => Set<ExerciseMuscleGroup>();
    public DbSet<Mesocycle> Mesocycles => Set<Mesocycle>();
    public DbSet<MesocycleDay> MesocycleDays => Set<MesocycleDay>();
    public DbSet<MesocycleDayExercise> MesocycleDayExercises => Set<MesocycleDayExercise>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Many-to-many Exercise <-> MuscleGroup
        modelBuilder.Entity<ExerciseMuscleGroup>()
            .HasKey(emg => new { emg.ExerciseId, emg.MuscleGroupId });
        modelBuilder.Entity<ExerciseMuscleGroup>()
            .HasOne(emg => emg.Exercise)
            .WithMany(e => e.ExerciseMuscleGroups)
            .HasForeignKey(emg => emg.ExerciseId);
        modelBuilder.Entity<ExerciseMuscleGroup>()
            .HasOne(emg => emg.MuscleGroup)
            .WithMany()
            .HasForeignKey(emg => emg.MuscleGroupId);

        // Mesocycle -> Days
        modelBuilder.Entity<MesocycleDay>()
            .HasOne(md => md.Mesocycle)
            .WithMany(m => m.Days)
            .HasForeignKey(md => md.MesocycleId);

        // MesocycleDay -> Exercises
        modelBuilder.Entity<MesocycleDayExercise>()
            .HasOne(mde => mde.MesocycleDay)
            .WithMany(md => md.Exercises)
            .HasForeignKey(mde => mde.MesocycleDayId);
        modelBuilder.Entity<MesocycleDayExercise>()
            .HasOne(mde => mde.Exercise)
            .WithMany()
            .HasForeignKey(mde => mde.ExerciseId);

        // Workout -> Days
        modelBuilder.Entity<WorkoutDay>()
            .HasOne(wd => wd.Workout)
            .WithMany(w => w.Days)
            .HasForeignKey(wd => wd.WorkoutId);

        // WorkoutDay -> Exercises
        modelBuilder.Entity<WorkoutDayExercise>()
            .HasOne(wde => wde.WorkoutDay)
            .WithMany(wd => wd.Exercises)
            .HasForeignKey(wde => wde.WorkoutDayId);
        modelBuilder.Entity<WorkoutDayExercise>()
            .HasOne(wde => wde.Exercise)
            .WithMany()
            .HasForeignKey(wde => wde.ExerciseId);

        // WorkoutLog -> MesocycleDay (new relationship)
        modelBuilder.Entity<WorkoutLog>()
            .HasOne(wl => wl.MesocycleDay)
            .WithMany()
            .HasForeignKey(wl => wl.MesocycleDayId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Seed();
    }
}