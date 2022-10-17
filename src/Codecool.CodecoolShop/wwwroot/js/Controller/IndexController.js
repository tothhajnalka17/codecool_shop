// Add buttons for filtering
function AddFilters() {
    // dynamically generate categories
    let categories = [];
    let suppliers = [];

    let productCards = document.querySelectorAll('.cardData');

    productCards.forEach((card) => {
        categories.push(card.dataset.category);
        suppliers.push(card.dataset.supplier);
    });
}

//Read in the activated filters and hide cards that don't match
function FilterCards() {

}

AddFilters();