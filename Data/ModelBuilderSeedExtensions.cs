using Microsoft.EntityFrameworkCore;
using Swol.Data.Models;

namespace Swol.Data;

public static class ModelBuilderSeedExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise { Id = 1, Name = "Bench Press", Description = "Chest exercise" },
            new Exercise { Id = 2, Name = "Squat", Description = "Leg exercise" },
            new Exercise { Id = 3, Name = "Deadlift", Description = "Back and legs" },
            new Exercise { Id = 4, Name = "Pec Fly", Description = "Seated, bring arms together in front (pec-dec arms)" },
            new Exercise { Id = 5, Name = "Incline Press", Description = "Press at an incline angle" },
            new Exercise { Id = 6, Name = "Pull Over", Description = "Pull bar from overhead to hips" },
            new Exercise { Id = 7, Name = "Upright Row", Description = "Pull handles vertically to chin" },
            new Exercise { Id = 8, Name = "Deltoid (Lateral) Raise", Description = "Side arm raise (machine/cable)" },
            new Exercise { Id = 9, Name = "Shoulder Press", Description = "Overhead pressing of handles" },
            new Exercise { Id = 10, Name = "Bent Over Row", Description = "Pull handles toward torso while bent over" },
            new Exercise { Id = 11, Name = "Seated Row", Description = "Seated, pull handles to waist" },
            new Exercise { Id = 12, Name = "Shoulder Shrug", Description = "Elevate shoulders with resistance" },
            new Exercise { Id = 13, Name = "Ab Crunch", Description = "Curl torso with cable or strap" },
            new Exercise { Id = 14, Name = "Oblique Bend", Description = "Side bends with cable or strap" },
            new Exercise { Id = 15, Name = "Standing Biceps Curl", Description = "Curl using low pulley" },
            new Exercise { Id = 16, Name = "Preacher Curl", Description = "Curl over preacher pad (if attachment available)" },
            new Exercise { Id = 17, Name = "Reverse Curl", Description = "Curl with overhand grip (low pulley or bar)" },
            new Exercise { Id = 18, Name = "Tricep Press Down", Description = "Push cable down from overhead pulley" },
            new Exercise { Id = 19, Name = "Tricep Extension", Description = "Seated or standing cable extension" },
            new Exercise { Id = 20, Name = "Overhead Tricep Extension", Description = "Face away from pulley, extend arms overhead" },
            new Exercise { Id = 21, Name = "Cable Chest Fly", Description = "Standing, bring cables together in front" },
            new Exercise { Id = 22, Name = "Cable Crossover", Description = "Single-arm, pull cable across body" },
            new Exercise { Id = 23, Name = "Cable Lateral Raise", Description = "Side arm raise using low cable" },
            new Exercise { Id = 24, Name = "Cable Front Raise", Description = "Front arm raise with cable" },
            new Exercise { Id = 25, Name = "Cable Reverse Fly (Rear Delt)", Description = "Arms out to sides using cables" },
            new Exercise { Id = 26, Name = "Lat Pulldown (with bar)", Description = "Pull bar down from overhead" },
            new Exercise { Id = 27, Name = "Cable Row (Standing/Kneeling)", Description = "Pull cable to abs or lower chest" },
            new Exercise { Id = 28, Name = "Woodchop (Cable)", Description = "Diagonal cable pull for core rotation" },
            new Exercise { Id = 29, Name = "Cable Side Bend", Description = "Lateral trunk bend with cable" },
            new Exercise { Id = 30, Name = "Leg Extension", Description = "Straighten knee with padded lever" },
            new Exercise { Id = 31, Name = "Leg Curl", Description = "Curl heel to glute with padded lever or cable" },
            new Exercise { Id = 32, Name = "Glute Kickback", Description = "Rear leg extension using low cable/strap" },
            new Exercise { Id = 33, Name = "Hip Abduction (Cable)", Description = "Leg away from midline with ankle strap" },
            new Exercise { Id = 34, Name = "Hip Adduction (Cable)", Description = "Leg toward midline with ankle strap" },
            new Exercise { Id = 35, Name = "Standing Leg Curl (Cable)", Description = "Heel to glute using ankle strap" },
            new Exercise { Id = 36, Name = "Standing Calf Raise (Cable)", Description = "Push up on toes using resistance" },
            new Exercise { Id = 37, Name = "Leg Press (Optional Attachment)", Description = "Seated, push platform with feet" }
        );

        // Seed Muscle Groups (only those matching the enum)
        modelBuilder.Entity<MuscleGroup>().HasData(
            new MuscleGroup { Id = 1, Name = "Chest" },
            new MuscleGroup { Id = 2, Name = "Back" },
            new MuscleGroup { Id = 3, Name = "Shoulders" },
            new MuscleGroup { Id = 4, Name = "Triceps" },
            new MuscleGroup { Id = 5, Name = "Biceps" },
            new MuscleGroup { Id = 6, Name = "Quads" },
            new MuscleGroup { Id = 7, Name = "Glutes" },
            new MuscleGroup { Id = 8, Name = "Hamstrings" },
            new MuscleGroup { Id = 9, Name = "Calves" },
            new MuscleGroup { Id = 10, Name = "Traps" },
            new MuscleGroup { Id = 11, Name = "Lats" },
            new MuscleGroup { Id = 12, Name = "Forearms" },
            new MuscleGroup { Id = 13, Name = "Abs" }
        );

        // Seed ExerciseMuscleGroup (link only to enum-matching groups)
        modelBuilder.Entity<ExerciseMuscleGroup>().HasData(
            // Chest
            new ExerciseMuscleGroup { ExerciseId = 1, MuscleGroupId = 1 }, // Bench Press
            new ExerciseMuscleGroup { ExerciseId = 4, MuscleGroupId = 1 }, // Pec Fly
            new ExerciseMuscleGroup { ExerciseId = 5, MuscleGroupId = 1 }, // Incline Press
            new ExerciseMuscleGroup { ExerciseId = 21, MuscleGroupId = 1 }, // Cable Chest Fly
            new ExerciseMuscleGroup { ExerciseId = 22, MuscleGroupId = 1 }, // Cable Crossover
            // Back
            new ExerciseMuscleGroup { ExerciseId = 3, MuscleGroupId = 2 }, // Deadlift
            new ExerciseMuscleGroup { ExerciseId = 6, MuscleGroupId = 2 }, // Pull Over
            new ExerciseMuscleGroup { ExerciseId = 10, MuscleGroupId = 2 }, // Bent Over Row
            new ExerciseMuscleGroup { ExerciseId = 11, MuscleGroupId = 2 }, // Seated Row
            new ExerciseMuscleGroup { ExerciseId = 26, MuscleGroupId = 2 }, // Lat Pulldown
            new ExerciseMuscleGroup { ExerciseId = 27, MuscleGroupId = 2 }, // Cable Row
            // Shoulders
            new ExerciseMuscleGroup { ExerciseId = 7, MuscleGroupId = 3 }, // Upright Row
            new ExerciseMuscleGroup { ExerciseId = 8, MuscleGroupId = 3 }, // Deltoid (Lateral) Raise
            new ExerciseMuscleGroup { ExerciseId = 9, MuscleGroupId = 3 }, // Shoulder Press
            new ExerciseMuscleGroup { ExerciseId = 12, MuscleGroupId = 3 }, // Shoulder Shrug
            new ExerciseMuscleGroup { ExerciseId = 23, MuscleGroupId = 3 }, // Cable Lateral Raise
            new ExerciseMuscleGroup { ExerciseId = 24, MuscleGroupId = 3 }, // Cable Front Raise
            new ExerciseMuscleGroup { ExerciseId = 25, MuscleGroupId = 3 }, // Cable Reverse Fly
            // Triceps
            new ExerciseMuscleGroup { ExerciseId = 1, MuscleGroupId = 4 }, // Bench Press
            new ExerciseMuscleGroup { ExerciseId = 5, MuscleGroupId = 4 }, // Incline Press
            new ExerciseMuscleGroup { ExerciseId = 18, MuscleGroupId = 4 }, // Tricep Press Down
            new ExerciseMuscleGroup { ExerciseId = 19, MuscleGroupId = 4 }, // Tricep Extension
            new ExerciseMuscleGroup { ExerciseId = 20, MuscleGroupId = 4 }, // Overhead Tricep Extension
            // Biceps
            new ExerciseMuscleGroup { ExerciseId = 15, MuscleGroupId = 5 }, // Standing Biceps Curl
            new ExerciseMuscleGroup { ExerciseId = 16, MuscleGroupId = 5 }, // Preacher Curl
            // Quads
            new ExerciseMuscleGroup { ExerciseId = 2, MuscleGroupId = 6 }, // Squat
            new ExerciseMuscleGroup { ExerciseId = 30, MuscleGroupId = 6 }, // Leg Extension
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 6 }, // Leg Press
            // Glutes
            new ExerciseMuscleGroup { ExerciseId = 32, MuscleGroupId = 7 }, // Glute Kickback
            new ExerciseMuscleGroup { ExerciseId = 33, MuscleGroupId = 7 }, // Hip Abduction
            new ExerciseMuscleGroup { ExerciseId = 34, MuscleGroupId = 7 }, // Hip Adduction
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 7 }, // Leg Press
            // Hamstrings
            new ExerciseMuscleGroup { ExerciseId = 31, MuscleGroupId = 8 }, // Leg Curl
            new ExerciseMuscleGroup { ExerciseId = 35, MuscleGroupId = 8 }, // Standing Leg Curl
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 8 }, // Leg Press
            // Calves
            new ExerciseMuscleGroup { ExerciseId = 36, MuscleGroupId = 9 }, // Standing Calf Raise
            new ExerciseMuscleGroup { ExerciseId = 37, MuscleGroupId = 9 }, // Leg Press
            // Traps
            new ExerciseMuscleGroup { ExerciseId = 12, MuscleGroupId = 10 }, // Shoulder Shrug
            // Lats
            new ExerciseMuscleGroup { ExerciseId = 6, MuscleGroupId = 11 }, // Pull Over
            new ExerciseMuscleGroup { ExerciseId = 26, MuscleGroupId = 11 }, // Lat Pulldown
            // Forearms
            new ExerciseMuscleGroup { ExerciseId = 17, MuscleGroupId = 12 }, // Reverse Curl
            // Abs
            new ExerciseMuscleGroup { ExerciseId = 13, MuscleGroupId = 13 }, // Ab Crunch
            new ExerciseMuscleGroup { ExerciseId = 14, MuscleGroupId = 13 }, // Oblique Bend
            new ExerciseMuscleGroup { ExerciseId = 28, MuscleGroupId = 13 }, // Woodchop
            new ExerciseMuscleGroup { ExerciseId = 29, MuscleGroupId = 13 }  // Cable Side Bend
        );
    }
}
