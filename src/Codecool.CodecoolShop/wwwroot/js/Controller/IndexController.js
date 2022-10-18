import { ButtonFactory, CardFactory } from "../View/View.js"
import { fetchProducts, fetchFilteredProducts } from "../Model/Model.js"

// Add buttons for filtering
async function AddFilters() {
    let products = await fetchProducts();
    console.log(products);
    // TODO display products

    // TODO fetch the data dynamically from the backend
    let categories = ["software", "hardware"];
    let suppliers = ["lenovo", "amazon"];

    let filterContainer = document.querySelector('#filterContainer');

    // Draw buttons
    let categoryHeader = document.createElement('h3');
    categoryHeader.innerText = "Categories";
    filterContainer.appendChild(categoryHeader);
    for (let category of categories) {
        filterContainer.appendChild(ButtonFactory("category", category));
    }

    // Draw supplier categories
    let supplierHeader = document.createElement('h3');
    supplierHeader.innerText = "Suppliers";
    filterContainer.appendChild(supplierHeader);
    for (let supplier of suppliers) {
        filterContainer.appendChild(ButtonFactory("supplier", supplier));
    }

    AddButtonListeners();
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

function GatherFilters() {
    let filters = {};
    let buttons = document.querySelectorAll(".filterButton");

    buttons.forEach((button) => {
        if (button.getAttribute('toggled') == 'true') {
            let category = button.getAttribute('data-filter-type');
            let value = button.getAttribute('data-filter-value');
            
            if (category in filters) {
                filters[category].push(value);
            }
            else {
                filters[category] = [value];
            }
        }
        })
    return filters;
}

//Read in the activated filters and hide cards that don't match
async function UpdateCards() {
    let filters = GatherFilters();
    let products = [];
    if (Object.keys(filters).length == 0) {
        products = await fetchProducts();
    }
    else {
        products = await fetchFilteredProducts(filters);
    }
    console.log(products);

    // cardfactory
    // attach
}

AddFilters();