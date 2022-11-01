export { ButtonFactory, CardFactory }
import { AddListener } from "../Controller/ShoppingCartController.js"


// Create the dom elements that hold the card data
function CardFactory(name, description, price, id) {
    let card = document.createElement('div');
    card.classList.add("el-wrapper");

    // card header
    let cardHeaderBox = document.createElement('div');
    cardHeaderBox.classList.add('box-up');
    cardHeaderBox.setAttribute("data-id", id);

    let image = document.createElement('img');
    image.src = `img/${ name }.jpg`;
    image.classList.add('img');

    let imageInfo = document.createElement('div');
    imageInfo.classList.add('img-info');

    let infoInner = document.createElement('div');
    infoInner.classList.add('info-inner');

    let productName = document.createElement('span');
    productName.classList.add('p-name');
    productName.innerText = name;
    

    let productSupplier = document.createElement('span');
    productSupplier.classList.add('p-company');
    
    let productDescription = document.createElement('div');
    productDescription.classList = 'a-size';
    productDescription.innerText = "Description";

    let descriptionDetails = document.createElement('span');
    descriptionDetails.classList.add('size')
    descriptionDetails.innerText = description


    // card footer
    let cardFooterBox = document.createElement('div');
    cardFooterBox.classList.add('box-down');

    let priceBackground = document.createElement('div');
    priceBackground.classList.add('h-bg');

    let priceBgInner = document.createElement('div');
    priceBgInner.classList.add('h-bg-inner');

    let cart = document.createElement('p');
    cart.classList.add('cart');
    cart.setAttribute("data-id", id);

    let priceTag = document.createElement('span');
    priceTag.classList.add('price');
    priceTag.innerText = price;

    let addToCart = document.createElement('span');
    addToCart.classList.add('add-to-cart');
    AddListener(addToCart);
    

    let addToCartTxt = document.createElement('span');
    addToCartTxt.classList.add('txt');
    addToCartTxt.innerText = "Add in cart"


    // build structure
    infoInner.appendChild(productName);
    infoInner.appendChild(productSupplier);

    productDescription.appendChild(descriptionDetails);

    imageInfo.appendChild(infoInner);
    imageInfo.appendChild(productDescription);

    cardHeaderBox.appendChild(image);
    cardHeaderBox.appendChild(imageInfo);

    priceBackground.appendChild(priceBgInner);

    addToCart.appendChild(addToCartTxt);

    cart.appendChild(priceTag);
    cart.appendChild(addToCart);

    cardFooterBox.appendChild(priceBackground);
    cardFooterBox.appendChild(cart);

    card.appendChild(cardHeaderBox);
    card.appendChild(cardFooterBox);
    
    return card;
}

function ButtonFactory(filterType, filterValue) {
   
    let filterLabel = document.createElement('label');
    filterLabel.classList.add('toggle');
   
    let filterCheckBox = document.createElement('input');
    filterCheckBox.classList.add('toggle-checkbox');
    filterCheckBox.type = "checkbox";
    filterCheckBox.checked = false;

    let filterSwitch = document.createElement('div');
    filterSwitch.classList.add('toggle-switch');
    filterSwitch.setAttribute('filter-type', filterType);

    let filterToggleLable = document.createElement('span');
    filterToggleLable.classList.add('toggle-label');
    filterToggleLable.innerText = filterValue;

    filterLabel.appendChild(filterCheckBox);
    filterLabel.appendChild(filterSwitch);
    filterLabel.appendChild(filterToggleLable);
   
    return filterLabel;
}

