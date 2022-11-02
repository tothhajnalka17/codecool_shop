import { fetchAddProductToCart, fetchCart } from "../Model/ShoppingCartModel.js"
import { TableFactory, TableRowFactory } from "../View/ShoppingCartView.js"
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
    addOneButtons.forEach((button) => AddListener(button));
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

        AddCartPageButtonEventListener();

    }
}

RefreshCart();