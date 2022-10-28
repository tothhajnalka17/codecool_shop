export { fetchProducts, fetchFilteredProducts}

async function fetchProducts() {
    try {
        let url = "Products";
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

async function fetchFilteredProducts(dict) {
    try {
        let url = "Products/Filter";
        let response = await fetch(`${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dict)
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