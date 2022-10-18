import { ButtonFactory, CardFactory } from "../View/View.js"

// Add buttons for filtering
function AddFilters() {
    // TODO fetch the data dynamically from the backend
    let categories = ["software", "hardware"];
    let suppliers = ["lenovo", "amazon"];

    let mainContainer = document.querySelector('main');

    let filterContainer = document.createElement('div');

    mainContainer.appendChild(filterContainer);
    filterContainer.id = "filterContainer";

    // Draw buttons
    let categoryHeader = document.createElement('h3');
    categoryHeader.innerText = "Categories";
    filterContainer.appendChild(categoryHeader);
    for (let category of categories) {
        filterContainer.appendChild(ButtonFactory("category", category));
    }

    let supplierHeader = document.createElement('h3');
    supplierHeader.innerText = "Suppliers";
    filterContainer.appendChild(supplierHeader);
    for (let supplier of suppliers) {
        filterContainer.appendChild(ButtonFactory("supplier", supplier));
    }

    AddButtonListeners();
    // Event listeners for the buttons
    // parameterized query string to get the data from model file
    // fetch query for the categories and the suppliers

}

function AddButtonListeners() {
    let buttons = document.querySelectorAll(".filterButton");
    
    buttons.forEach((button) => button.addEventListener("click", (e) => {
        if (button.getAttribute('toggled') == 'false') {
            button.setAttribute('toggled', true);
        }
        else {
            button.setAttribute('toggled', false);
        }
        GatherToggledButtons();
    }));
}
    
function GatherToggledButtons() {
    let dict = {};
    let clickedButtons = document.querySelectorAll(".filterButton");
    
    clickedButtons.forEach((button) => {
        if (button.getAttribute('toggled') == 'true') {
            let category = button.getAttribute('data-filter-type');
            let value = button.getAttribute('data-filter-value');

            if (category in dict) {
                console.log(`${category} in dictionary`);
                dict[category].push(value);
            }
            else {
                dict[category] = [value];
            }
            }
        })
}

//Read in the activated filters and hide cards that don't match
function UpdateCards() {
    // fetch
    // cardfactory
    // attach
}

AddFilters();