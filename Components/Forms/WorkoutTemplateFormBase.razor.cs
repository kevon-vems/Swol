using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Swol.Enums;
using Swol.Data.Models.Template;
using Swol.Data.Models.Config;

namespace Swol.Components.Forms;

public partial class WorkoutTemplateFormBase : ComponentBase
{
    [Inject] public Data.ApplicationDbContext Db { get; set; } = default!;
    [Inject] public NavigationManager Nav { get; set; } = default!;
    [Parameter] public int? Id { get; set; }

    private string PageTitle => Id.HasValue ? "Edit Template" : "Add Template";

    private WorkoutTemplate template = new WorkoutTemplate();
    private List<Exercise> allExercises = new();
    private Dictionary<string, MuscleGroups?> selectedMuscleGroup = new();
    private Dictionary<string, int> selectedExerciseId = new();
    private HashSet<(string, int)> editingExercises = new();
    private Dictionary<(string, int), MuscleGroups?> editingMuscleGroup = new();

    protected override async Task OnInitializedAsync()
    {
        allExercises = await Db.Exercises
            .Include(e => e.ExerciseMuscleGroups)
                .ThenInclude(emg => emg.MuscleGroup)
            .OrderBy(e => e.Name)
            .ToListAsync();

        if (Id.HasValue)
        {
            // Edit mode: load existing template with related data
            template = await Db.WorkoutTemplates
                .Include(m => m.Days)
                    .ThenInclude(d => d.Exercises)
                        .ThenInclude(e => e.Exercise)
                            .ThenInclude(ex => ex.ExerciseMuscleGroups)
                                .ThenInclude(emg => emg.MuscleGroup)
                .FirstOrDefaultAsync(m => m.Id == Id.Value)
                ?? new WorkoutTemplate();
        }
        else
        {
            // Create mode: initialize with a few default days
            template = new WorkoutTemplate();
            template.Days.Add(new WorkoutTemplateDay { Label = "Day 1", DayOfWeek = DayOfWeek.Monday, OrderNumber = 1 });
            template.Days.Add(new WorkoutTemplateDay { Label = "Day 2", DayOfWeek = DayOfWeek.Tuesday, OrderNumber = 2 });
            template.Days.Add(new WorkoutTemplateDay { Label = "Day 3", DayOfWeek = DayOfWeek.Wednesday, OrderNumber = 3 });
        }
    }

    private void AddDay()
    {
        var nextOrder = template.Days.Any() ? template.Days.Max(d => d.OrderNumber) + 1 : 1;
        var day = new WorkoutTemplateDay
        {
            Label = $"Day {nextOrder}",
            DayOfWeek = DayOfWeek.Monday,
            OrderNumber = nextOrder
        };
        template.Days.Add(day);
        StateHasChanged();
    }

    private void RemoveDay(WorkoutTemplateDay day)
    {
        template.Days.Remove(day);
        ReorderDays();
        StateHasChanged();
    }

    private void OnExerciseSelected(WorkoutTemplateDay day, object value, WorkoutTemplateDayExercise? editingEx = null)
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
                selectedExerciseId[day.Label] = exId;
                AddExerciseToDay(day);
                selectedExerciseId[day.Label] = 0;
            }
            StateHasChanged();
        }
    }
    private void AddExerciseToDay(WorkoutTemplateDay day)
    {
        if (!selectedExerciseId.TryGetValue(day.Label, out var exId) || exId == 0) return;
        if (day.Exercises.Any(e => e.ExerciseId == exId)) return;
        var exercise = allExercises.FirstOrDefault(e => e.Id == exId);
        if (exercise == null) return;
        var ex = new WorkoutTemplateDayExercise
        {
            ExerciseId = exId,
            Exercise = exercise,
            OrderInDay = day.Exercises.Count + 1
        };
        day.Exercises.Add(ex);

        selectedMuscleGroup[day.Label] = null;
        selectedExerciseId[day.Label] = 0;
        StateHasChanged();
    }

    private void OnMuscleGroupChanged(string label, object value)
    {
        if (Enum.TryParse<MuscleGroups>(value?.ToString(), out var muscleGroup))
            selectedMuscleGroup[label] = muscleGroup;
        else
            selectedMuscleGroup[label] = null;
        selectedExerciseId[label] = 0;
    }
    private void RemoveSelectedMuscleGroup(string label)
    {
        if (selectedMuscleGroup.ContainsKey(label))
        {
            selectedMuscleGroup.Remove(label);
            StateHasChanged();
        }
    }
    private void StartEditingExercise(string label, int exerciseId)
    {
        editingExercises.Add((label, exerciseId));
        var day = template.Days.FirstOrDefault(d => d.Label == label);
        var ex = day?.Exercises.FirstOrDefault(e => e.Exercise?.Id == exerciseId);

        if (ex?.Exercise != null)
        {
            var muscleGroup = ex.Exercise.ExerciseMuscleGroups.FirstOrDefault()?.MuscleGroup;
            if (muscleGroup != null)
                editingMuscleGroup[(label, exerciseId)] = Enum.Parse<MuscleGroups>(muscleGroup.Name);
        }
    }
    private void StopEditingExercise(string label, int exerciseId)
    {
        editingExercises.Remove((label, exerciseId));
        editingMuscleGroup.Remove((label, exerciseId));
    }
    private IEnumerable<Exercise> GetExercisesForDay(string label)
    {
        if (selectedMuscleGroup.TryGetValue(label, out var muscleGroup) && muscleGroup != null)
        {
            return allExercises.Where(ex => ex.ExerciseMuscleGroups.Any(emg => emg.MuscleGroup.Name == muscleGroup.ToString()));
        }
        return Enumerable.Empty<Exercise>();
    }
    private void RemoveExerciseFromDay(WorkoutTemplateDay day, WorkoutTemplateDayExercise ex)
    {
        day.Exercises.Remove(ex);
        StateHasChanged();
    }

    private void OnDayOfWeekChanged(WorkoutTemplateDay day, object? value)
    {
        if (value is null) return;
        if (!Enum.TryParse<DayOfWeek>(value.ToString(), out var newDayOfWeek)) return;
        day.DayOfWeek = newDayOfWeek;
        StateHasChanged();
    }

    private void OnLabelChanged(WorkoutTemplateDay day, object? value)
    {
        if (value is null) return;
        day.Label = value.ToString() ?? string.Empty;
        StateHasChanged();
    }

    private void ReorderDays()
    {
        int order = 1;
        foreach (var d in template.Days.OrderBy(d => d.OrderNumber))
        {
            d.OrderNumber = order++;
        }
    }

    private async Task HandleSubmit()
    {

        if (Id.HasValue)
        {
            Db.WorkoutTemplates.Update(template);
        }
        else
        {
            Db.WorkoutTemplates.Add(template);
        }

        await Db.SaveChangesAsync();
        Nav.NavigateTo("/templates");
    }

    private async Task DeleteTemplate()
    {
        if (!Id.HasValue) return;

        var toDelete = await Db.WorkoutTemplates
            .Include(t => t.Days)
                .ThenInclude(d => d.Exercises)
            .FirstOrDefaultAsync(t => t.Id == Id.Value);

        if (toDelete != null)
        {
            Db.WorkoutTemplates.Remove(toDelete);
            await Db.SaveChangesAsync();
        }

        Nav.NavigateTo("/templates");
    }
}