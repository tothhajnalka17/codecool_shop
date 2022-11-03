import { fetchAddProductToCart } from "../Model/ShoppingCartModel.js"

$('.card-desc a').click(async function () {
    const id = await this.getAttribute("data-id");
    await fetchAddProductToCart(id);
    window.location = "/ShoppingCart";
})
