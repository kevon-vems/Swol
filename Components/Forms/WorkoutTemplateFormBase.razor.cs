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

            // Initialize newExerciseDayId for loaded days
            foreach (var d in template.Days)
                newExerciseDayId[d.DayOfWeek] = 0;
        }
        else
        {
            // Create mode: initialize with all days
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Sunday });
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Monday });
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Tuesday });
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Wednesday });
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Thursday });
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Friday });
            template.Days.Add(new WorkoutTemplateDay { DayOfWeek = DayOfWeek.Saturday });
            foreach (var d in template.Days)
                newExerciseDayId[d.DayOfWeek] = 0;
        }
    }

    private void AddDay()
    {
        var available = Enum.GetValues<DayOfWeek>().Except(template.Days.Select(d => d.DayOfWeek)).ToList();
        if (!available.Any()) return;
        var day = new WorkoutTemplateDay { DayOfWeek = available.First() };
        template.Days.Add(day);
        newExerciseDayId[day.DayOfWeek] = 0;
        StateHasChanged();
    }

    private void RemoveDay(WorkoutTemplateDay day)
    {
        template.Days.Remove(day);
        newExerciseDayId.Remove(day.DayOfWeek);
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
                selectedExerciseId[day.DayOfWeek] = exId;
                AddExerciseToDay(day);
                selectedExerciseId[day.DayOfWeek] = 0;
            }
            StateHasChanged();
        }
    }
    private void AddExerciseToDay(WorkoutTemplateDay day)
    {
        if (!selectedExerciseId.TryGetValue(day.DayOfWeek, out var exId) || exId == 0) return;
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

        selectedMuscleGroup[day.DayOfWeek] = null;
        selectedExerciseId[day.DayOfWeek] = 0;
        StateHasChanged();
    }

    private void OnMuscleGroupChanged(DayOfWeek day, object value)
    {
        if (Enum.TryParse<MuscleGroups>(value?.ToString(), out var muscleGroup))
            selectedMuscleGroup[day] = muscleGroup;
        else
            selectedMuscleGroup[day] = null;
        selectedExerciseId[day] = 0;
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
        var day = template.Days.FirstOrDefault(d => d.DayOfWeek == dayOfWeek);
        var ex = day?.Exercises.FirstOrDefault(e => e.Exercise?.Id == exerciseId);

        if (ex?.Exercise != null)
        {
            var muscleGroup = ex.Exercise.ExerciseMuscleGroups.FirstOrDefault()?.MuscleGroup;
            if (muscleGroup != null)
                editingMuscleGroup[(dayOfWeek, exerciseId)] = Enum.Parse<MuscleGroups>(muscleGroup.Name);
        }
    }
    private void StopEditingExercise(DayOfWeek dayOfWeek, int exerciseId)
    {
        editingExercises.Remove((dayOfWeek, exerciseId));
        editingMuscleGroup.Remove((dayOfWeek, exerciseId));
    }
    private IEnumerable<Exercise> GetExercisesForDay(DayOfWeek dayOfWeek)
    {
        if (selectedMuscleGroup.TryGetValue(dayOfWeek, out var muscleGroup) && muscleGroup != null)
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
        if (template.Days.Any(d => d != day && d.DayOfWeek == newDayOfWeek)) return;
        newExerciseDayId.Remove(day.DayOfWeek);
        day.DayOfWeek = newDayOfWeek;
        if (!newExerciseDayId.ContainsKey(newDayOfWeek))
            newExerciseDayId[newDayOfWeek] = 0;
        StateHasChanged();
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