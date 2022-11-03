import { ButtonFactory, CardFactory } from "../View/View.js"
import { fetchProducts, fetchFilteredProducts } from "../Model/Model.js"
import { AddToCartButtonEventListener } from "../Controller/ShoppingCartController.js"



AddListeners();
AddFilters();
EventForFilterButton();
AddToCartButtonEventListener();

function AddListeners() {
    var selected = document.querySelectorAll(".box-up");
    selected.forEach(box => box.addEventListener("click", (e) => {
        window.location = `/product/viewer/${box.dataset.id}`;
    }));
}


// Add buttons for filtering
async function AddFilters() {

    // TODO fetch the data dynamically from the backend
    let categories = ["Shirt","Mug"];
    let suppliers = ["Gergo", "Marci", "Hajni", "Zoárd", "Robi", "Fülöp"];

    let filterContainer = document.querySelector('.filters');

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
}

// Fact: The click event trigger twice default in label, preventDefault disable all css command. 3hour wasted :(

function EventForFilterButton() {
    let filterSwitches = document.querySelectorAll('.toggle-switch')
    filterSwitches.forEach(filterSwitch => filterSwitch.addEventListener("click", function (e) {
        if (this.dataset.status == "toggled") {
            delete this.dataset.status;
            
        }
        else {
            this.dataset.status = "toggled";
        }
        UpdateCards();

    }))
}

function GatherFilters() {
    let filters = {};
    let buttons = document.querySelectorAll("[data-status]");

    buttons.forEach((button) => {
       
        let category = button.getAttribute('filter-type');
        let value = button.nextElementSibling.innerText;

        if (category in filters) {
            filters[category].push(value);
        }
        else {
            filters[category] = [value];
        }
        
    })
    return filters;
}

//Read in the activated filters and hide cards that don't match
async function UpdateCards() {
    console.log("start filtering");
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
        let card = CardFactory(product.name, product.description, product.defaultPrice, product.id);
        cardHolder.appendChild(card);
    }
    AddListeners();
    AddToCartButtonEventListener();
    
}