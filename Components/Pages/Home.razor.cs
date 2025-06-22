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

        var startDate = workout.StartDate ?? DateTime.Today;

        for (int i = 0; i < 7; i++)
        {
            var dow = startDate.AddDays(i).DayOfWeek;
            var wDay = new WorkoutDay
            {
                WorkoutId = workout.Id,
                DayOfWeek = dow,
                Name = dow.ToString()
            };
            Db.WorkoutDays.Add(wDay);
            await Db.SaveChangesAsync();

            var tDay = template.Days.FirstOrDefault(d => d.DayOfWeek == dow);
            if (tDay != null)
            {
                foreach (var tEx in tDay.Exercises.OrderBy(e => e.OrderInDay))
                {
                    var wEx = new WorkoutDayExercise
                    {
                        WorkoutDayId = wDay.Id,
                        ExerciseId = tEx.ExerciseId,
                        OrderInDay = tEx.OrderInDay
                    };
                    Db.WorkoutDayExercises.Add(wEx);
                }

                await Db.SaveChangesAsync();
            }
        }

        await Db.SaveChangesAsync();
        Nav.NavigateTo($"/workouts/{workout.Id}");
    }
}
