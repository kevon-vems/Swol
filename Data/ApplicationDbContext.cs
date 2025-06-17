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
    public DbSet<WorkoutExercise> WorkoutExercises => Set<WorkoutExercise>();
    public DbSet<WorkoutLog> WorkoutLogs => Set<WorkoutLog>();
    public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();
    public DbSet<MuscleGroup> MuscleGroups => Set<MuscleGroup>();
    public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups => Set<ExerciseMuscleGroup>();
    public DbSet<Mesocycle> Mesocycles => Set<Mesocycle>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure relationships
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Workout)
            .WithMany(w => w.Exercises)
            .HasForeignKey(we => we.WorkoutId);
            
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);

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

        // Mesocycle -> Workout relationship
        modelBuilder.Entity<Mesocycle>()
            .HasOne(m => m.Workout)
            .WithMany()
            .HasForeignKey(m => m.WorkoutId);
            
        // WorkoutLog -> Mesocycle relationship (optional)
        modelBuilder.Entity<WorkoutLog>()
            .HasOne(wl => wl.Mesocycle)
            .WithMany(m => m.WorkoutLogs)
            .HasForeignKey(wl => wl.MesocycleId)
            .IsRequired(false);
            
        // Ensure only one active Mesocycle at a time
        modelBuilder.Entity<Mesocycle>()
            .HasIndex(m => m.IsActive)
            .HasFilter("[IsActive] = 1")
            .IsUnique();

        // Legacy single muscle group reference (can be removed after migration)
        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.MuscleGroup)
            .WithMany()
            .HasForeignKey(e => e.MuscleGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed data
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise { Id = 1, Name = "Bench Press", Description = "Chest exercise", Category = "Chest", MuscleGroupId = 1 },
            new Exercise { Id = 2, Name = "Squat", Description = "Leg exercise", Category = "Legs", MuscleGroupId = 22 },
            new Exercise { Id = 3, Name = "Deadlift", Description = "Back and legs", Category = "Back", MuscleGroupId = 23 },
            new Exercise { Id = 4, Name = "Pec Fly", Description = "Seated, bring arms together in front (pec-dec arms)", Category = "Chest", MuscleGroupId = 1 },
            new Exercise { Id = 5, Name = "Incline Press", Description = "Press at an incline angle", Category = "Chest", MuscleGroupId = 2 },
            new Exercise { Id = 6, Name = "Pull Over", Description = "Pull bar from overhead to hips", Category = "Back", MuscleGroupId = 6 },
            new Exercise { Id = 7, Name = "Upright Row", Description = "Pull handles vertically to chin", Category = "Shoulders", MuscleGroupId = 13 },
            new Exercise { Id = 8, Name = "Deltoid (Lateral) Raise", Description = "Side arm raise (machine/cable)", Category = "Shoulders", MuscleGroupId = 11 },
            new Exercise { Id = 9, Name = "Shoulder Press", Description = "Overhead pressing of handles", Category = "Shoulders", MuscleGroupId = 9 },
            new Exercise { Id = 10, Name = "Bent Over Row", Description = "Pull handles toward torso while bent over", Category = "Back", MuscleGroupId = 6 },
            new Exercise { Id = 11, Name = "Seated Row", Description = "Seated, pull handles to waist", Category = "Back", MuscleGroupId = 5 },
            new Exercise { Id = 12, Name = "Shoulder Shrug", Description = "Elevate shoulders with resistance", Category = "Shoulders", MuscleGroupId = 13 },
            new Exercise { Id = 13, Name = "Ab Crunch", Description = "Curl torso with cable or strap", Category = "Core", MuscleGroupId = 19 },
            new Exercise { Id = 14, Name = "Oblique Bend", Description = "Side bends with cable or strap", Category = "Core", MuscleGroupId = 20 },
            new Exercise { Id = 15, Name = "Standing Biceps Curl", Description = "Curl using low pulley", Category = "Arms", MuscleGroupId = 15 },
            new Exercise { Id = 16, Name = "Preacher Curl", Description = "Curl over preacher pad (if attachment available)", Category = "Arms", MuscleGroupId = 15 },
            new Exercise { Id = 17, Name = "Reverse Curl", Description = "Curl with overhand grip (low pulley or bar)", Category = "Arms", MuscleGroupId = 17 },
            new Exercise { Id = 18, Name = "Tricep Press Down", Description = "Push cable down from overhead pulley", Category = "Arms", MuscleGroupId = 16 },
            new Exercise { Id = 19, Name = "Tricep Extension", Description = "Seated or standing cable extension", Category = "Arms", MuscleGroupId = 16 },
            new Exercise { Id = 20, Name = "Overhead Tricep Extension", Description = "Face away from pulley, extend arms overhead", Category = "Arms", MuscleGroupId = 16 },
            new Exercise { Id = 21, Name = "Cable Chest Fly", Description = "Standing, bring cables together in front", Category = "Chest", MuscleGroupId = 1 },
            new Exercise { Id = 22, Name = "Cable Crossover", Description = "Single-arm, pull cable across body", Category = "Chest", MuscleGroupId = 1 },
            new Exercise { Id = 23, Name = "Cable Lateral Raise", Description = "Side arm raise using low cable", Category = "Shoulders", MuscleGroupId = 11 },
            new Exercise { Id = 24, Name = "Cable Front Raise", Description = "Front arm raise with cable", Category = "Shoulders", MuscleGroupId = 10 },
            new Exercise { Id = 25, Name = "Cable Reverse Fly (Rear Delt)", Description = "Arms out to sides using cables", Category = "Shoulders", MuscleGroupId = 12 },
            new Exercise { Id = 26, Name = "Lat Pulldown (with bar)", Description = "Pull bar down from overhead", Category = "Back", MuscleGroupId = 6 },
            new Exercise { Id = 27, Name = "Cable Row (Standing/Kneeling)", Description = "Pull cable to abs or lower chest", Category = "Back", MuscleGroupId = 5 },
            new Exercise { Id = 28, Name = "Woodchop (Cable)", Description = "Diagonal cable pull for core rotation", Category = "Core", MuscleGroupId = 20 },
            new Exercise { Id = 29, Name = "Cable Side Bend", Description = "Lateral trunk bend with cable", Category = "Core", MuscleGroupId = 20 },
            new Exercise { Id = 30, Name = "Leg Extension", Description = "Straighten knee with padded lever", Category = "Legs", MuscleGroupId = 22 },
            new Exercise { Id = 31, Name = "Leg Curl", Description = "Curl heel to glute with padded lever or cable", Category = "Legs", MuscleGroupId = 23 },
            new Exercise { Id = 32, Name = "Glute Kickback", Description = "Rear leg extension using low cable/strap", Category = "Legs", MuscleGroupId = 21 },
            new Exercise { Id = 33, Name = "Hip Abduction (Cable)", Description = "Leg away from midline with ankle strap", Category = "Legs", MuscleGroupId = 21 },
            new Exercise { Id = 34, Name = "Hip Adduction (Cable)", Description = "Leg toward midline with ankle strap", Category = "Legs", MuscleGroupId = 21 },
            new Exercise { Id = 35, Name = "Standing Leg Curl (Cable)", Description = "Heel to glute using ankle strap", Category = "Legs", MuscleGroupId = 23 },
            new Exercise { Id = 36, Name = "Standing Calf Raise (Cable)", Description = "Push up on toes using resistance", Category = "Legs", MuscleGroupId = 24 },
            new Exercise { Id = 37, Name = "Leg Press (Optional Attachment)", Description = "Seated, push platform with feet", Category = "Legs", MuscleGroupId = 22 }
        );

        // Seed Muscle Groups
        modelBuilder.Entity<MuscleGroup>().HasData(
            new MuscleGroup { Id = 1, Name = "Chest" },
            new MuscleGroup { Id = 2, Name = "Upper Chest" },
            new MuscleGroup { Id = 3, Name = "Middle Chest" },
            new MuscleGroup { Id = 4, Name = "Lower Chest" },
            new MuscleGroup { Id = 5, Name = "Back" },
            new MuscleGroup { Id = 6, Name = "Lats" },
            new MuscleGroup { Id = 7, Name = "Upper Back (Traps, Rhomboids)" },
            new MuscleGroup { Id = 8, Name = "Lower Back" },
            new MuscleGroup { Id = 9, Name = "Shoulders" },
            new MuscleGroup { Id = 10, Name = "Front Delts" },
            new MuscleGroup { Id = 11, Name = "Side Delts" },
            new MuscleGroup { Id = 12, Name = "Rear Delts" },
            new MuscleGroup { Id = 13, Name = "Traps" },
            new MuscleGroup { Id = 14, Name = "Arms" },
            new MuscleGroup { Id = 15, Name = "Biceps" },
            new MuscleGroup { Id = 16, Name = "Triceps" },
            new MuscleGroup { Id = 17, Name = "Forearms" },
            new MuscleGroup { Id = 18, Name = "Core" },
            new MuscleGroup { Id = 19, Name = "Abs" },
            new MuscleGroup { Id = 20, Name = "Obliques" },
            new MuscleGroup { Id = 21, Name = "Glutes" },
            new MuscleGroup { Id = 22, Name = "Quads" },
            new MuscleGroup { Id = 23, Name = "Hamstrings" },
            new MuscleGroup { Id = 24, Name = "Calves" }
        );

        // Seed ExerciseMuscleGroup (many-to-many)
        modelBuilder.Entity<ExerciseMuscleGroup>().HasData(
            // Bench Press
            new ExerciseMuscleGroup { ExerciseId = 1, MuscleGroupId = 1 },
            new ExerciseMuscleGroup { ExerciseId = 1, MuscleGroupId = 10 },
            new ExerciseMuscleGroup { ExerciseId = 1, MuscleGroupId = 16 },
            // Pec Fly
            new ExerciseMuscleGroup { ExerciseId = 4, MuscleGroupId = 1 },
            // Incline Press
            new ExerciseMuscleGroup { ExerciseId = 5, MuscleGroupId = 2 },
            new ExerciseMuscleGroup { ExerciseId = 5, MuscleGroupId = 10 },
            new ExerciseMuscleGroup { ExerciseId = 5, MuscleGroupId = 16 },
            // Pull Over
            new ExerciseMuscleGroup { ExerciseId = 6, MuscleGroupId = 6 },
            new ExerciseMuscleGroup { ExerciseId = 6, MuscleGroupId = 1 },
            new ExerciseMuscleGroup { ExerciseId = 6, MuscleGroupId = 16 },
            // Upright Row
            new ExerciseMuscleGroup { ExerciseId = 7, MuscleGroupId = 13 },
            new ExerciseMuscleGroup { ExerciseId = 7, MuscleGroupId = 9 },
            // Deltoid (Lateral) Raise
            new ExerciseMuscleGroup { ExerciseId = 8, MuscleGroupId = 11 },
            // Shoulder Press
            new ExerciseMuscleGroup { ExerciseId = 9, MuscleGroupId = 9 },
            new ExerciseMuscleGroup { ExerciseId = 9, MuscleGroupId = 16 },
            // Bent Over Row
            new ExerciseMuscleGroup { ExerciseId = 10, MuscleGroupId = 6 },
            new ExerciseMuscleGroup { ExerciseId = 10, MuscleGroupId = 12 },
            new ExerciseMuscleGroup { ExerciseId = 10, MuscleGroupId = 7 },
            // Seated Row
            new ExerciseMuscleGroup { ExerciseId = 11, MuscleGroupId = 5 },
            new ExerciseMuscleGroup { ExerciseId = 11, MuscleGroupId = 6 },
            // Shoulder Shrug
            new ExerciseMuscleGroup { ExerciseId = 12, MuscleGroupId = 13 },
            // Ab Crunch
            new ExerciseMuscleGroup { ExerciseId = 13, MuscleGroupId = 19 },
            // Oblique Bend
            new ExerciseMuscleGroup { ExerciseId = 14, MuscleGroupId = 20 },
            // Standing Biceps Curl
            new ExerciseMuscleGroup { ExerciseId = 15, MuscleGroupId = 15 },
            // Preacher Curl
            new ExerciseMuscleGroup { ExerciseId = 16, MuscleGroupId = 15 },
            // Reverse Curl
            new ExerciseMuscleGroup { ExerciseId = 17, MuscleGroupId = 17 },
            // Tricep Press Down
            new ExerciseMuscleGroup { ExerciseId = 18, MuscleGroupId = 16 },
            // Tricep Extension
            new ExerciseMuscleGroup { ExerciseId = 19, MuscleGroupId = 16 },
            // Overhead Tricep Extension
            new ExerciseMuscleGroup { ExerciseId = 20, MuscleGroupId = 16 },
            // Cable Chest Fly
            new ExerciseMuscleGroup { ExerciseId = 21, MuscleGroupId = 1 },
            // Cable Crossover
            new ExerciseMuscleGroup { ExerciseId = 22, MuscleGroupId = 1 },
            new ExerciseMuscleGroup { ExerciseId = 22, MuscleGroupId = 18 },
            // Cable Lateral Raise
            new ExerciseMuscleGroup { ExerciseId = 23, MuscleGroupId = 11 },
            // Cable Front Raise
            new ExerciseMuscleGroup { ExerciseId = 24, MuscleGroupId = 10 },
            // Cable Reverse Fly (Rear Delt)
            new ExerciseMuscleGroup { ExerciseId = 25, MuscleGroupId = 12 },
            new ExerciseMuscleGroup { ExerciseId = 25, MuscleGroupId = 7 },
            // Lat Pulldown (with bar)
            new ExerciseMuscleGroup { ExerciseId = 26, MuscleGroupId = 6 },
            new ExerciseMuscleGroup { ExerciseId = 26, MuscleGroupId = 7 },
            new ExerciseMuscleGroup { ExerciseId = 26, MuscleGroupId = 15 },
            // Cable Row (Standing/Kneeling)
            new ExerciseMuscleGroup { ExerciseId = 27, MuscleGroupId = 5 },
            new ExerciseMuscleGroup { ExerciseId = 27, MuscleGroupId = 6 },
            // Woodchop (Cable)
            new ExerciseMuscleGroup { ExerciseId = 28, MuscleGroupId = 20 },
            new ExerciseMuscleGroup { ExerciseId = 28, MuscleGroupId = 19 },
            // Cable Side Bend
            new ExerciseMuscleGroup { ExerciseId = 29, MuscleGroupId = 20 },
            // Leg Extension
            new ExerciseMuscleGroup { ExerciseId = 30, MuscleGroupId = 22 },
            // Leg Curl
            new ExerciseMuscleGroup { ExerciseId = 31, MuscleGroupId = 23 },
            // Glute Kickback
            new ExerciseMuscleGroup { ExerciseId = 32, MuscleGroupId = 21 },
            new ExerciseMuscleGroup { ExerciseId = 32, MuscleGroupId = 23 },
            // Hip Abduction (Cable)
            new ExerciseMuscleGroup { ExerciseId = 33, MuscleGroupId = 21 },
            // Hip Adduction (Cable)
            new ExerciseMuscleGroup { ExerciseId = 34, MuscleGroupId = 21 },
            // Standing Leg Curl (Cable)
            new ExerciseMuscleGroup { ExerciseId = 35, MuscleGroupId = 23 },
            // Standing Calf Raise (Cable)
            new ExerciseMuscleGroup { ExerciseId = 36, MuscleGroupId = 24 },
            // Leg Press (Optional Attachment)
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 22 },
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 21 },
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 23 },
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 24 }
        );
    }
}