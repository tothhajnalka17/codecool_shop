export { ButtonFactory, CardFactory }

// Create the dom elements that hold the card data
function CardFactory(name, description, category, supplier, price) {
    let card = document.createElement('div');

}

function ButtonFactory(filterType, filterValue) {
    let button = document.createElement('button');
    button.classList.add('filterButton', 'btn', 'btn-primary');
    button.setAttribute('toggled', false);
    button.dataset.filterType = filterType;
    button.dataset.filterValue = filterValue;
    button.innerText = filterValue;
    return button;
}