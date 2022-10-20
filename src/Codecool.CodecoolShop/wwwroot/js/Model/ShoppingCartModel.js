export { fetchAddProductToCart, fetchCart }

async function fetchAddProductToCart(product) {
    try {
        let url = "ShoppingCartApi/Add";
        let response = await fetch(`${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(product)
        });
        if (response.ok !== true) {
            throw new Error(`Error making fetch request: ${response}`);
        } else {
            return response.json();
        }
    } catch (error) {
        console.log(error);
    }
}

async function fetchCart() {
    try {
        let url = "ShoppingCartApi/Get";
        let response = await fetch(`${url}`);
        if (response.ok !== true) {
            throw new Error(`Error making fetch request: ${response}`);
        } else {
            return response.json();
        }
    } catch (error) {
        console.log(error);
    }
}