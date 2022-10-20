import { fetchProducts } from "../Model/Model.js"
import { fetchAddProductToCart, fetchCart } from "../Model/ShoppingCartModel.js"
import { TableFactory, TableRowFactory } from "../View/ShoppingCartView.js"

async function AddToCartButtonEventListener() {
    const addToCartButtons = await document.querySelectorAll('.addToCart')
    let allproducts = await fetchProducts();
    await addToCartButtons.forEach((button) => button.addEventListener("click", () => {
        fetchAddProductToCart(allproducts.Where(product => product.Id == button.parentElement.querySelector('.card-title').innerText.slice(-2, -1)));
        console.log(fetchCart());
    }))
}

async function RefreshCart() {
    const container = await document.querySelector('#cart_container');

    var cart = await fetchCart();

    if (cart == null) {
        const message = await document.createElement('p');
        message.innerText = "There is nothing in your cart.";
        await container.appendChild(message);
    }
    else {
        const table = await TableFactory();

        const tablebody = await document.querySelector("#shopping_cart--body");

        const cartlist = await TableRowFactory();

        await tablebody.parentElement(cartlist);

        await container.appendChild(table);
    }

    AddToCartButtonEventListener();
}