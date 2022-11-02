export { TableRowFactory, TableFactory }

function TableRowFactory(id, name, price, currency, quantity) {

    const tablerow = document.createElement('tr');

    let itemname = document.createElement('td');
    itemname.innerText = name;

    let itemprice = document.createElement('td');
    itemprice.innerText = price;

    let pricecurrency = document.createElement('td');
    pricecurrency.innerText = currency;

    let itemquantity = document.createElement('td');
    itemquantity.innerText = quantity;

    let action = document.createElement('td');
    let addButton = document.createElement('button');
    addButton.innerText = "+";
    addButton.setAttribute("id", id);
    addButton.classList.add('add_one_button');
    let removeOneButton = document.createElement('button');
    removeOneButton.innerText = "-";
    removeOneButton.setAttribute("id", id);
    removeOneButton.classList.add('remove_one_button');
    let removeAllButton = document.createElement('button');
    removeAllButton.innerText = "Remove";
    removeAllButton.setAttribute("id", id);
    removeAllButton.classList.add('remove_all_button');

    action.appendChild(addButton);
    action.appendChild(removeOneButton);
    action.appendChild(removeAllButton);

    tablerow.appendChild(itemname);
    tablerow.appendChild(itemprice);
    tablerow.appendChild(pricecurrency);
    tablerow.appendChild(itemquantity);
    tablerow.appendChild(action);

    return tablerow;
}

function TableFactory() {
    const table = document.createElement('table');
    table.classList.add('table');

    const tablehead = document.createElement('thead');

    const tablerow = document.createElement('tr');

    const tableheader1 = document.createElement('th');
    tableheader1.setAttribute("scope", "col");
    tableheader1.innerText = "Name";

    const tableheader2 = document.createElement('th');
    tableheader2.setAttribute("scope", "col");
    tableheader2.innerText = "Price";

    const tableheader3 = document.createElement('th');
    tableheader3.setAttribute("scope", "col");
    tableheader3.innerText = "Currency";

    const tableheader4 = document.createElement('th');
    tableheader4.setAttribute("scope", "col");
    tableheader4.innerText = "Quantity";

    const tableheader5 = document.createElement('th');
    tableheader5.setAttribute("scope", "col");
    tableheader5.innerText = "Action";

    tablerow.appendChild(tableheader1);
    tablerow.appendChild(tableheader2);
    tablerow.appendChild(tableheader3);
    tablerow.appendChild(tableheader4);
    tablerow.appendChild(tableheader5);

    tablehead.appendChild(tablerow);

    table.appendChild(tablehead);

    const tablebody = document.createElement('tbody');
    tablebody.setAttribute("id", "shopping_cart--body")

    table.appendChild(tablebody);

    return table;
}