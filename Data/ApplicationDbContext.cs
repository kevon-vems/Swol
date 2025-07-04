using Microsoft.EntityFrameworkCore;
using Swol.Data.Models.Config;
using Swol.Data.Models.Template;
using Swol.Data.Models.Work;

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
    public DbSet<WorkoutDayExerciseSet> WorkoutDayExerciseSets => Set<WorkoutDayExerciseSet>();
    public DbSet<MuscleGroup> MuscleGroups => Set<MuscleGroup>();
    public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups => Set<ExerciseMuscleGroup>();
    public DbSet<WorkoutTemplate> WorkoutTemplates => Set<WorkoutTemplate>();
    public DbSet<WorkoutTemplateDay> WorkoutTemplateDays => Set<WorkoutTemplateDay>();
    public DbSet<WorkoutTemplateDayExercise> WorkoutTemplateDayExercises => Set<WorkoutTemplateDayExercise>();
    
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

        // WorkoutTemplate -> Days
        modelBuilder.Entity<WorkoutTemplateDay>()
            .HasOne(md => md.WorkoutTemplate)
            .WithMany(m => m.Days)
            .HasForeignKey(md => md.WorkoutTemplateId);
        modelBuilder.Entity<WorkoutTemplateDay>()
            .Property(md => md.DayOfWeek)
            .IsRequired();
        modelBuilder.Entity<WorkoutTemplateDay>()
            .Property(md => md.Label)
            .IsRequired();
        modelBuilder.Entity<WorkoutTemplateDay>()
            .Property(md => md.OrderNumber)
            .IsRequired();

        // WorkoutTemplateDay -> Exercises
        modelBuilder.Entity<WorkoutTemplateDayExercise>()
            .HasOne(mde => mde.WorkoutTemplateDay)
            .WithMany(md => md.Exercises)
            .HasForeignKey(mde => mde.WorkoutTemplateDayId);
        modelBuilder.Entity<WorkoutTemplateDayExercise>()
            .HasOne(mde => mde.Exercise)
            .WithMany()
            .HasForeignKey(mde => mde.ExerciseId);

        // Workout -> Template
        modelBuilder.Entity<Workout>()
            .HasOne(w => w.WorkoutTemplate)
            .WithMany(wt => wt.Workouts)
            .HasForeignKey(w => w.WorkoutTemplateId);

        // Workout -> Days
        modelBuilder.Entity<WorkoutDay>()
            .HasOne(wd => wd.Workout)
            .WithMany(w => w.Days)
            .HasForeignKey(wd => wd.WorkoutId);
        modelBuilder.Entity<WorkoutDay>()
            .Property(wd => wd.DayOfWeek)
            .IsRequired();
        modelBuilder.Entity<WorkoutDay>()
            .Property(wd => wd.Label)
            .IsRequired();
        modelBuilder.Entity<WorkoutDay>()
            .Property(wd => wd.OrderNumber)
            .IsRequired();

        // WorkoutDay -> Exercises
        modelBuilder.Entity<WorkoutDayExercise>()
            .HasOne(wde => wde.WorkoutDay)
            .WithMany(wd => wd.Exercises)
            .HasForeignKey(wde => wde.WorkoutDayId);
        modelBuilder.Entity<WorkoutDayExercise>()
            .HasOne(wde => wde.Exercise)
            .WithMany()
            .HasForeignKey(wde => wde.ExerciseId);

        // WorkoutDayExercise -> Sets
        modelBuilder.Entity<WorkoutDayExerciseSet>()
            .HasOne(set => set.WorkoutDayExercise)
            .WithMany(wde => wde.Sets)
            .HasForeignKey(set => set.WorkoutDayExerciseId);

        // Set precision for WeightInLb
        modelBuilder.Entity<WorkoutDayExerciseSet>()
            .Property(s => s.WeightInLb)
            .HasPrecision(6, 2); 

        modelBuilder.Seed();
    }
}