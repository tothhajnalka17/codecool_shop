// Add buttons for filtering
function AddFilters() {
    // TODO fetch the data dynamically from the backend
    let categories = ["software", "hardware"];
    let suppliers = ["lenovo", "amazon"];

    // Draw buttons
    // Event listeners for the buttons
    // parameterized query string to get the data from model file
    // fetch query for the categories and the suppliers

}

function GatherFilters() {
    let buttons = document.querySelectorAll(".filterButton");
    
    buttons.forEach((button) => button.addEventListener("click", (e) => {
        console.log(button)
    }))
    
    
    

}

//Read in the activated filters and hide cards that don't match
function UpdateCards() {
    // fetch
    // cardfactory
    // attach
}

AddFilters();