import { fetchAddProductToCart, fetchRemoveOneProductFromCart, fetchRemoveAllProductFromCart, fetchRemoveCart, fetchCart } from "../Model/ShoppingCartModel.js"
import { TableFactory, TableRowFactory, FooterFactory } from "../View/ShoppingCartView.js"
export { AddToCartButtonEventListener, AddListener }

async function AddToCartButtonEventListener() {
    const addToCartButtons = await document.querySelectorAll('.cart')
    await addToCartButtons.forEach((button) => AddListener(button));
};

async function AddListener(button) {
    button.addEventListener("click", async () => {
        await fetchAddProductToCart(button.getAttribute("data-id"));
        RefreshCart();
    })
}

function AddCartPageButtonEventListener() {
    const removeOneButtons = document.querySelectorAll('.remove_one_button');
    const addOneButtons = document.querySelectorAll('.add_one_button');
    const removeAllButtons = document.querySelectorAll('.remove_all_button');
    const removeCartButtons = document.querySelectorAll('.remove_cart_button');
    addOneButtons.forEach((button) => AddListener(button));
    removeOneButtons.forEach((button) => RemoveOneListener(button));
    removeAllButtons.forEach((button) => RemoveAllListener(button));
    removeCartButtons.forEach((button) => RemoveCartListener(button));
}

async function RemoveOneListener(button) {
    button.addEventListener("click", async () => {
        await fetchRemoveOneProductFromCart(button.getAttribute("data-id"));
        
    })
}

async function RemoveAllListener(button) {
    button.addEventListener("click", async () => {
        await fetchRemoveAllProductFromCart(button.getAttribute("data-id"));
        RefreshCart();
    })
}

async function RemoveCartListener(button) {
    button.addEventListener("click", async () => {
        await fetchRemoveCart();
        RefreshCart();
    })
}

async function RefreshCart() {
    const container = await document.querySelector('#cart_container');
    container.innerHTML = "";

    var cart = await fetchCart();
    console.log(cart);

    if (Object.keys(cart).length == 0) {
        const message = await document.createElement('p');
        message.innerText = "There is nothing in your cart.";
        await container.appendChild(message);
    }
    else {
        const table = await TableFactory();

        await container.appendChild(table);

        const tablebody = await document.querySelector("#shopping_cart--body");

        let totalprice = 0;

        for (var item in cart) {
            let currentItem = JSON.parse(item);
            let itemid = await currentItem.Id;
            let itemname = await currentItem.Name;
            let itemcurrency = await currentItem.Currency;
            let itemprice = await currentItem.DefaultPrice;
            let quantity = await cart[item];
            
            var tablerow = await TableRowFactory(itemid, itemname, itemprice, itemcurrency, quantity);
            tablebody.appendChild(tablerow);
            totalprice += cart[item] * currentItem.DefaultPrice;
        }

        const total = document.createElement('div');
        total.innerHTML = `<strong>Total: ${totalprice}</strong>`;
        container.appendChild(total);

        const footer = FooterFactory();

        container.appendChild(footer);

        AddCartPageButtonEventListener();

    }
}

RefreshCart();

/* Set values + misc */
var promoCode;
var promoPrice;
var fadeTime = 300;

/* Assign actions */
$('.quantity input').change(function () {
    updateQuantity(this);
});

$('.remove button').click(function () {
    RemoveOneListener(this);
    removeItem(this);
});

$(document).ready(function () {
    updateSumItems();
});

/* Recalculate cart */
function recalculateCart(onlyTotal) {
    var subtotal = 0;

    /* Sum up row totals */
    $('.basket-product').each(function () {
        subtotal += parseFloat($(this).children('.subtotal').text());
    });

    /* Calculate totals */
    var total = subtotal;


    /*If switch for update only total, update only total display*/
    if (onlyTotal) {
        /* Update total display */
        $('.total-value').fadeOut(fadeTime, function () {
            $('#basket-total').html(total.toFixed(2));
            $('.total-value').fadeIn(fadeTime);
        });
    } else {
        /* Update summary display. */
        $('.final-value').fadeOut(fadeTime, function () {
            $('#basket-subtotal').html(subtotal.toFixed(2));
            $('#basket-total').html(total.toFixed(2));
            if (total == 0) {
                $('.checkout-cta').fadeOut(fadeTime);
            } else {
                $('.checkout-cta').fadeIn(fadeTime);
            }
            $('.final-value').fadeIn(fadeTime);
        });
    }
}

/* Update quantity */
function updateQuantity(quantityInput) {
    /* Calculate line price */
    var productRow = $(quantityInput).parent().parent();
    var price = parseFloat(productRow.children('.price').text());
    var quantity = $(quantityInput).val();
    var linePrice = price * quantity;

    /* Update line price display and recalc cart totals */
    productRow.children('.subtotal').each(function () {
        $(this).fadeOut(fadeTime, function () {
            $(this).text(linePrice.toFixed(2));
            recalculateCart();
            $(this).fadeIn(fadeTime);
        });
    });

    productRow.find('.item-quantity').text(quantity);
    updateSumItems();
}

function updateSumItems() {
    var sumItems = 0;
    $('.quantity input').each(function () {
        sumItems += parseInt($(this).val());
    });
    $('.total-items').text(sumItems);
    //TODO: update dao with new amount
}

/* Remove item from cart */
function removeItem(removeButton) {
    
    /* Remove row from DOM and recalc cart total */
    var productRow = $(removeButton).parent().parent();
    productRow.slideUp(fadeTime, function () {
        productRow.remove();
        recalculateCart();
        updateSumItems();
    });

    //TODO: delete item from shopping cart dao too 
}