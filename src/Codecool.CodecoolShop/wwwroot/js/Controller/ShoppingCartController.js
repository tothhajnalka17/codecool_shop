import { fetchAddProductToCart, fetchCart } from "../Model/ShoppingCartModel.js"
import { TableFactory, TableRowFactory } from "../View/ShoppingCartView.js"
export { AddToCartButtonEventListener }

async function AddToCartButtonEventListener() {
    const addToCartButtons = await document.querySelectorAll('.addToCart')
    await addToCartButtons.forEach((button) => button.addEventListener("click", async () => {
        await fetchAddProductToCart(1);
    }))
}

async function RefreshCart() {
    const container = await document.querySelector('#cart_container');

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

        for (var item in cart) {
            let currentItem = JSON.parse(item);
            let itemname = await currentItem.Name;
            let itemcurrency = await currentItem.Currency;
            let itemprice = await currentItem.DefaultPrice;
            let quantity = await cart[item];
            
            var tablerow = await TableRowFactory(itemname, itemprice, itemcurrency, quantity);
            tablebody.appendChild(tablerow);
        }

    }
}

RefreshCart();