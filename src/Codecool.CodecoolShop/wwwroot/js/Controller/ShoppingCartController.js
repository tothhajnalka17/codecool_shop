import { fetchUpdateProductToCart ,fetchAddProductToCart, fetchRemoveOneProductFromCart, fetchRemoveAllProductFromCart, fetchRemoveCart, fetchCart } from "../Model/ShoppingCartModel.js"
import { TableFactory, TableRowFactory, FooterFactory } from "../View/ShoppingCartView.js"
export { AddToCartButtonEventListener, AddListener }

async function AddToCartButtonEventListener() {
    const addToCartButtons = await document.querySelectorAll('.cart')
    await addToCartButtons.forEach((button) => AddListener(button));
};

async function AddListener(button) {
    button.addEventListener("click", async () => {
        await fetchAddProductToCart(button.getAttribute("data-id"));
    })
};

async function UpdateListener(button, quantity) {
    await fetchUpdateProductToCart(button.getAttribute("data-id"), quantity);
};

function AddCartPageButtonEventListener() {
    addOneButtons.forEach((button) => AddListener(button));//fel
    removeOneButtons.forEach((button) => RemoveOneListener(button));//le
    removeAllButtons.forEach((button) => RemoveAllListener(button));//törlmind
    removeCartButtons.forEach((button) => RemoveCartListener(button));// egész
};

async function RemoveOneListener(button) {
    await fetchRemoveOneProductFromCart(button.getAttribute("data-id"));
};

async function RemoveAllListener(button) {
    await fetchRemoveAllProductFromCart(button.getAttribute("data-id"));
};

async function RemoveCartListener(button) {
    button.addEventListener("click", async () => {
        await fetchRemoveCart();
        RefreshCart();
    })
};


/* Set values + misc */

var fadeTime = 300;

/* Assign actions */
$('.quantity input').change(function () {
    updateQuantity(this);
});

$('.remove button').click(function () {
    RemoveAllListener(this);
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
        UpdateListener(this, sumItems)
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