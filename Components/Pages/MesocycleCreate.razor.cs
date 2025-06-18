using Microsoft.AspNetCore.Components;
using Swol.Data.Models;
using Microsoft.EntityFrameworkCore;
using Swol.Enums;

namespace Swol.Components.Pages;

public partial class MesocycleCreate : ComponentBase
{
    [Inject] public Data.ApplicationDbContext Db { get; set; } = default!;
    [Inject] public NavigationManager Nav { get; set; } = default!;

    private Mesocycle mesocycle = new Mesocycle();
    private List<Exercise> allExercises = new();
    private Dictionary<DayOfWeek, int> newExerciseDayId = new();
    private Dictionary<DayOfWeek, MuscleGroups?> selectedMuscleGroup = new();
    private Dictionary<DayOfWeek, int> selectedExerciseId = new();

    protected override async Task OnInitializedAsync()
    {
        allExercises = await Db.Exercises
            .Include(e => e.ExerciseMuscleGroups)
                .ThenInclude(emg => emg.MuscleGroup)
            .OrderBy(e => e.Name)
            .ToListAsync();
        // Start with two days (Monday, Tuesday)
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Monday });
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Tuesday });
        foreach (var d in mesocycle.Days)
            newExerciseDayId[d.DayOfWeek] = 0;
    }

    private void AddDay()
    {
        // Add the first available DayOfWeek not already used
        var available = Enum.GetValues<DayOfWeek>().Except(mesocycle.Days.Select(d => d.DayOfWeek)).ToList();
        if (!available.Any()) return;
        var day = new MesocycleDay { DayOfWeek = available.First() };
        mesocycle.Days.Add(day);
        newExerciseDayId[day.DayOfWeek] = 0;
        StateHasChanged();
    }

    private void RemoveDay(MesocycleDay day)
    {
        mesocycle.Days.Remove(day);
        newExerciseDayId.Remove(day.DayOfWeek);
        StateHasChanged();
    }

    private void AddExerciseToDay(MesocycleDay day)
    {
        if (!selectedExerciseId.TryGetValue(day.DayOfWeek, out var exId) || exId == 0) return;
        if (day.Exercises.Any(e => e.ExerciseId == exId)) return;
        var exercise = allExercises.FirstOrDefault(e => e.Id == exId);
        if (exercise == null) return;
        var ex = new MesocycleDayExercise
        {
            ExerciseId = exId,
            Exercise = exercise,
            OrderInDay = day.Exercises.Count + 1
        };
        day.Exercises.Add(ex);
        // Reset to muscle group selection for this day
        selectedMuscleGroup[day.DayOfWeek] = null;
        selectedExerciseId[day.DayOfWeek] = 0;
        StateHasChanged();
    }

    private void OnMuscleGroupChanged(DayOfWeek day, object value)
    {
        if (Enum.TryParse<MuscleGroups>(value?.ToString(), out var mg))
            selectedMuscleGroup[day] = mg;
        else
            selectedMuscleGroup[day] = null;
        selectedExerciseId[day] = 0; // Reset exercise selection
    }

    private void OnExerciseSelectChanged(DayOfWeek day, object value)
    {
        if (int.TryParse(value?.ToString(), out var id))
            selectedExerciseId[day] = id;
        else
            selectedExerciseId[day] = 0;
    }

    private IEnumerable<Exercise> GetExercisesForDay(DayOfWeek day)
    {
        if (selectedMuscleGroup.TryGetValue(day, out var mg) && mg != null)
        {
            // Only match on muscle groups that exist in both enum and DB
            return allExercises.Where(e =>
                e.ExerciseMuscleGroups.Any(emg => string.Equals(emg.MuscleGroup.Name, mg.ToString(), StringComparison.OrdinalIgnoreCase))
            );
        }
        return Enumerable.Empty<Exercise>();
    }

    private void RemoveExerciseFromDay(MesocycleDay day, MesocycleDayExercise ex)
    {
        day.Exercises.Remove(ex);
        StateHasChanged();
    }

    private void OnDayOfWeekChanged(MesocycleDay day, object? value)
    {
        if (value is null) return;
        if (!Enum.TryParse<DayOfWeek>(value.ToString(), out var newDayOfWeek)) return;
        if (mesocycle.Days.Any(d => d != day && d.DayOfWeek == newDayOfWeek)) return; // Prevent duplicates
        // Remove old mapping
        newExerciseDayId.Remove(day.DayOfWeek);
        day.DayOfWeek = newDayOfWeek;
        // Add new mapping
        if (!newExerciseDayId.ContainsKey(newDayOfWeek))
            newExerciseDayId[newDayOfWeek] = 0;
        StateHasChanged();
    }

    private async Task HandleSubmit()
    {
        mesocycle.IsActive = true;
        Db.Mesocycles.Add(mesocycle);
        await Db.SaveChangesAsync();
        Nav.NavigateTo("/mesocycles");
    }
}
