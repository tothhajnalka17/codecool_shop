export { fetchProducts }

async function fetchProducts() {
    try {
        let url = "https://localhost:44334/Products/";
        //TODO parameterized query
        //${url}FetchData/?topic=${topic}&page=${page}
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