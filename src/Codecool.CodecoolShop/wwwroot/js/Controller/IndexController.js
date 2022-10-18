import { ButtonFactory, CardFactory } from "../View/View.js"
import { fetchProducts, fetchFilteredProducts } from "../Model/Model.js"

// Add buttons for filtering
async function AddFilters() {

    // TODO fetch the data dynamically from the backend
    let categories = ["Software", "Hardware"];
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
            button.classList.remove('btn-primary');
            button.classList.add('btn-danger');
        }
        else {
            button.setAttribute('toggled', false);
            button.classList.remove('btn-danger');
            button.classList.add('btn-primary');
        }
        UpdateCards();
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
    let cardHolder = document.querySelector('#card-container');
    cardHolder.innerHTML = "";

    if (Object.keys(filters).length == 0) {
        products = await fetchProducts();
    }
    else {
        products = await fetchFilteredProducts(filters);
    }
    for (var product of products) {
        console.log(product);
        let card = CardFactory(product.name, product.description, product.productCategory.department, product.supplier.name, product.defaultPrice, product.currency);
        
        cardHolder.appendChild(card);
    }

}

AddFilters();