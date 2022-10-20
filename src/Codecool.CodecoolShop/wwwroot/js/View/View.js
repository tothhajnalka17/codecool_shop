export { ButtonFactory, CardFactory }

// Create the dom elements that hold the card data
function CardFactory(name, description, price, currency) {
    let card = document.createElement('div');
    card.classList.add('col-lg-3', 'productCards');
   
    let image = document.createElement('img');
    image.src = `img/${name}.jpg`;
    image.classList.add('productImage');

    let cardBody = document.createElement('div');
    cardBody.classList.add('card-body');

    let cardTitle = document.createElement('h5');
    cardTitle.classList.add('card-title', 'text-center', 'headerAlign');
    cardTitle.innerText = name;

    let cardtext1 = document.createElement('p');
    cardtext1.classList.add('card-text');
    cardtext1.innerText = description;
    cardtext1.classList.add('hidedText');


    let cardtext4 = document.createElement('strong');
    cardtext4.classList.add('card-text', 'priceAlign');
    cardtext4.innerText = `Price: ${price} ${currency}`;

    let button = document.createElement('a');
    button.classList.add('btn', 'btn-primary', 'addToCart');
    button.type = 'button';
    button.innerText = 'Add To Cart';
        
    cardBody.appendChild(cardTitle);
    cardBody.appendChild(cardtext1);
    
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