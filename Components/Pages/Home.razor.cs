using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Swol.Data.Models.Template;
using Swol.Data.Models.Work;

namespace Swol.Components.Pages;

public partial class Home : ComponentBase
{
    [Inject] public Data.ApplicationDbContext Db { get; set; } = default!;
    [Inject] public NavigationManager Nav { get; set; } = default!;

    private bool isLoading = true;
    private WorkoutTemplate? activeTemplate;

    protected override async Task OnInitializedAsync()
    {
        activeTemplate = await Db.WorkoutTemplates
            .Include(t => t.Days)
                .ThenInclude(d => d.Exercises)
            .FirstOrDefaultAsync();
        isLoading = false;
    }

    private async Task StartWorkoutAsync()
    {
        if (activeTemplate == null)
            return;

        var existingWorkout = await Db.Workouts
            .FirstOrDefaultAsync(w =>
                w.WorkoutTemplateId == activeTemplate.Id &&
                w.StartDate == DateTime.Today);

        if (existingWorkout != null)
        {
            Nav.NavigateTo($"/workouts/{existingWorkout.Id}");
            return;
        }

        var workout = new Workout
        {
            Name = $"{activeTemplate.Name} - {DateTime.Today:yyyy-MM-dd}",
            WorkoutTemplateId = activeTemplate.Id,
            StartDate = DateTime.Today,
            IsActive = true
        };

        Db.Workouts.Add(workout);
        await Db.SaveChangesAsync();

        var template = await Db.WorkoutTemplates
            .Include(t => t.Days)
                .ThenInclude(d => d.Exercises)
            .FirstAsync(t => t.Id == activeTemplate.Id);

        int weekNumber = 1;
        int orderNumber = 1;
        foreach (var templateDay in template.Days.OrderBy(d => d.DayNumber))
        {
            var workoutDay = new WorkoutDay
            {
                WorkoutId = workout.Id,
                DayOfWeek = templateDay.DayOfWeek,
                Label = templateDay.DayOfWeek.ToString(),
                WeekNumber = weekNumber,
                OrderNumber = orderNumber++,
                Name = templateDay.DayOfWeek.ToString()
            };
            Db.WorkoutDays.Add(workoutDay);
            await Db.SaveChangesAsync();

            if (templateDay != null)
            {
                foreach (var templateExercise in templateDay.Exercises.OrderBy(e => e.OrderInDay))
                {
                    var workoutExercise = new WorkoutDayExercise
                    {
                        WorkoutDayId = workoutDay.Id,
                        ExerciseId = templateExercise.ExerciseId,
                        OrderInDay = templateExercise.OrderInDay
                    };
                    Db.WorkoutDayExercises.Add(workoutExercise);
                }
            }

            await Db.SaveChangesAsync();
        }

        await Db.SaveChangesAsync();
        Nav.NavigateTo($"/workouts/{workout.Id}");
    }
}
