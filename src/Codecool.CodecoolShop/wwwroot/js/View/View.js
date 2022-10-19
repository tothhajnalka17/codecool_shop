export { ButtonFactory, CardFactory }

// Create the dom elements that hold the card data
function CardFactory(name, description, category, supplier, price, currency) {
    let card = document.createElement('div');
    card.classList.add('col-lg-3', 'card');
   
    let image = document.createElement('img');
    image.src = `img/${name}.jpg`;

    let cardBody = document.createElement('div');
    cardBody.classList.add('card-body');

    let cardTitle = document.createElement('h5');
    cardTitle.classList.add('card-title', 'text-center');
    cardTitle.innerText = name;

    let cardtext1 = document.createElement('p');
    cardtext1.classList.add('card-text');
    cardtext1.innerText = description;

    let cardtext2 = document.createElement('p');
    cardtext2.classList.add('card-text');
    cardtext2.innerText = `Category: ${category}`;

    let cardtext3 = document.createElement('p');
    cardtext3.classList.add('card-text');
    cardtext3.innerText = `Supplier: ${supplier}`;

    let cardtext4 = document.createElement('p');
    cardtext4.classList.add('card-text');
    cardtext4.innerText = `Price: ${price} ${currency}`;

    let button = document.createElement('a');
    button.classList.add('btn', 'btn-primary', 'addToCart');
    button.type = 'button';
    button.innerText = 'Add To Cart';
        
    cardBody.appendChild(cardTitle);
    cardBody.appendChild(cardtext1);
    cardBody.appendChild(cardtext2);
    cardBody.appendChild(cardtext3);
    cardBody.appendChild(cardtext4);

    card.appendChild(image);
    card.appendChild(cardBody);
    card.appendChild(button);

    return card;
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