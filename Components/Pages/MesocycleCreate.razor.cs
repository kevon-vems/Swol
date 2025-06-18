using Microsoft.AspNetCore.Components;
using Swol.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Swol.Components.Pages;

public partial class MesocycleCreate : ComponentBase
{
    [Inject] public Data.ApplicationDbContext Db { get; set; } = default!;
    [Inject] public NavigationManager Nav { get; set; } = default!;

    private Mesocycle mesocycle = new Mesocycle();
    private MesocycleDay newDay = new MesocycleDay();
    private MesocycleDay? selectedDay;
    private MesocycleDayExercise newExercise = new MesocycleDayExercise();
    private List<Exercise> allExercises = new();

    protected override async Task OnInitializedAsync()
    {
        newDay = new MesocycleDay();
        allExercises = await Db.Exercises.OrderBy(e => e.Name).ToListAsync();
    }

    private void AddDay()
    {
        if (newDay.WeekNumber < 1 || newDay.WeekNumber > mesocycle.NumberOfWeeks)
            return;
        var day = new MesocycleDay
        {
            WeekNumber = newDay.WeekNumber,
            DayOfWeek = newDay.DayOfWeek,
            Name = newDay.Name
        };
        mesocycle.Days.Add(day);
        newDay = new MesocycleDay();
        StateHasChanged();
    }

    private void RemoveDay(MesocycleDay day)
    {
        mesocycle.Days.Remove(day);
        if (selectedDay == day) selectedDay = null;
        StateHasChanged();
    }

    private void SelectDay(MesocycleDay day)
    {
        selectedDay = day;
        newExercise = new MesocycleDayExercise();
    }

    private void AddExerciseToDay()
    {
        if (selectedDay == null || newExercise.ExerciseId == 0) return;
        var exercise = allExercises.FirstOrDefault(e => e.Id == newExercise.ExerciseId);
        if (exercise == null) return;
        var ex = new MesocycleDayExercise
        {
            ExerciseId = newExercise.ExerciseId,
            Exercise = exercise,
            Sets = newExercise.Sets,
            RepsPerSet = newExercise.RepsPerSet,
            WeightInKg = newExercise.WeightInKg,
            OrderInDay = (selectedDay.Exercises.Count + 1)
        };
        selectedDay.Exercises.Add(ex);
        newExercise = new MesocycleDayExercise();
        StateHasChanged();
    }

    private void RemoveExerciseFromDay(MesocycleDay day, MesocycleDayExercise ex)
    {
        day.Exercises.Remove(ex);
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
