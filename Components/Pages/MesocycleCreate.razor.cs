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
    private HashSet<(DayOfWeek, int)> editingExercises = new();
    private Dictionary<(DayOfWeek, int), MuscleGroups?> editingMuscleGroup = new();
    public string? selectedDayToAdd { get; set; }

    protected override async Task OnInitializedAsync()
    {
        allExercises = await Db.Exercises
            .Include(e => e.ExerciseMuscleGroups)
                .ThenInclude(emg => emg.MuscleGroup)
            .OrderBy(e => e.Name)
            .ToListAsync();
        // Start with two days (Monday, Tuesday)
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Sunday });
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Monday });
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Tuesday });
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Wednesday });
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Thursday });
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Friday});
        mesocycle.Days.Add(new MesocycleDay { DayOfWeek = DayOfWeek.Saturday });
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

    private void OnExerciseSelected(MesocycleDay day, object value, MesocycleDayExercise? editingEx = null)
    {
        if (int.TryParse(value?.ToString(), out var exId) && exId > 0)
        {
            if (editingEx != null)
            {
                var exercise = allExercises.FirstOrDefault(e => e.Id == exId);
                if (exercise == null) return;
                editingEx.ExerciseId = exId;
                editingEx.Exercise = exercise;
            }
            else
            {
                selectedExerciseId[day.DayOfWeek] = exId;
                AddExerciseToDay(day);
                selectedExerciseId[day.DayOfWeek] = 0; // Reset selection
            }
            StateHasChanged();
        }
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
    private void RemoveSelectedMuscleGroup(DayOfWeek dayOfWeek)
    {
        if (selectedMuscleGroup.ContainsKey(dayOfWeek))
        {
            selectedMuscleGroup.Remove(dayOfWeek);
            StateHasChanged();
        }
    }
    private void StartEditingExercise(DayOfWeek dayOfWeek, int exerciseId)
    {
        editingExercises.Add((dayOfWeek, exerciseId));
        var day = mesocycle.Days.FirstOrDefault(d => d.DayOfWeek == dayOfWeek);
        var ex = day?.Exercises.FirstOrDefault(e => e.Exercise?.Id == exerciseId);

        if (ex?.Exercise != null)
        {
            var mg = ex.Exercise.ExerciseMuscleGroups.FirstOrDefault()?.MuscleGroup;
            if (mg != null)
                editingMuscleGroup[(dayOfWeek, exerciseId)] = Enum.Parse<MuscleGroups>(mg.Name);
        }
    }
    private void StopEditingExercise(DayOfWeek dayOfWeek, int exerciseId)
    {
        editingExercises.Remove((dayOfWeek, exerciseId));
        editingMuscleGroup.Remove((dayOfWeek, exerciseId));
    }
    private IEnumerable<Exercise> GetExercisesForDay(DayOfWeek dayOfWeek)
    {
        if (selectedMuscleGroup.TryGetValue(dayOfWeek, out var mg) && mg != null)
        {
            return allExercises.Where(ex => ex.ExerciseMuscleGroups.Any(emg => emg.MuscleGroup.Name == mg.ToString()));
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
