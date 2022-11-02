export { fetchAddProductToCart, fetchRemoveOneProductFromCart, fetchRemoveAllProductFromCart, fetchCart }

async function fetchAddProductToCart(productId) {
    try {
        let url = "ShoppingCartApi/Add";
        let response = await fetch(`${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({id: productId})
        });
        if (response.ok !== true) {
            throw new Error(`Error making fetch request: ${response}`);
        }
    } catch (error) {
        console.log(error);
    }
}

async function fetchRemoveOneProductFromCart(productId) {
    try {
        let url = "ShoppingCartApi/RemoveOne";
        let response = await fetch(`${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ id: productId })
        });
        if (response.ok !== true) {
            throw new Error(`Error making fetch request: ${response}`);
        }
    } catch (error) {
        console.log(error);
    }
}

async function fetchRemoveAllProductFromCart(productId) {
    try {
        let url = "ShoppingCartApi/RemoveAll";
        let response = await fetch(`${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ id: productId })
        });
        if (response.ok !== true) {
            throw new Error(`Error making fetch request: ${response}`);
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