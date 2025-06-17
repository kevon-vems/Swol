// JS functions for handling muscle group multi-select
function initMuscleGroupSelect() {
    // This function will be called after component renders
    console.log("Initializing muscle group select...");
}

function getSelectedMuscleGroups() {
    // Get the select element
    const select = document.getElementById('muscleGroupsSelect');
    
    // Get all selected options
    const selectedOptions = Array.from(select.selectedOptions);
    
    // Return array of selected values
    return selectedOptions.map(option => option.value);
}