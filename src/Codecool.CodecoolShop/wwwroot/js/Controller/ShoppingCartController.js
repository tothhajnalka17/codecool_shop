async function AddToCartButtonEventListener() {
    const addToCartButtons = await document.querySelectorAll('.addToCart')
    addToCartButtons.forEach((button) => button.addEventListener("click", (e) => {
        var products = await fetchProducts();
        var cart = await fetchAddProductToCart(products.Where(product => product.Id == button.parentElement.id))

    }))
}