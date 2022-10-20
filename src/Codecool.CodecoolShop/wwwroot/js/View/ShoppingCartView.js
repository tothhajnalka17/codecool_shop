export { TableRowFactory, TableFactory }

function TableRowFactory(name, supplier, price, currency) {

    const tablerow = document.createElement('tr');
    
    let itemmaker = document.createElement('td');
    itemmaker.innerText = supplier;

    let itemname = document.createElement('td');
    itemname.innerText = name;

    let itemprice = document.createElement('td');
    itemprice.innerText = price;

    let pricecurrency = document.createElement('td');
    pricecurrency.innerText = currency;

    tablerow.appendChild(itemmaker);
    tablerow.appendChild(itemname);
    tablerow.appendChild(itemprice);
    tablerow.appendChild(pricecurrency);

    return tablerow;
}

function TableFactory() {
    const table = document.createElement('table');
    table.classList.add('table');

    const tablehead = document.createElement('thead');

    const tablerow = document.createElement('tr');

    const tableheader1 = document.createElement('th');
    tableheader1.setAttribute("scope", "col");
    tableheader1.innerText = "Maker";

    const tableheader2 = document.createElement('th');
    tableheader2.setAttribute("scope", "col");
    tableheader2.innerText = "Name";

    const tableheader3 = document.createElement('th');
    tableheader3.setAttribute("scope", "col");
    tableheader3.innerText = "Price";

    const tableheader4 = document.createElement('th');
    tableheader4.setAttribute("scope", "col");
    tableheader4.innerText = "Currency";

    tablerow.appendChild(tableheader1);
    tablerow.appendChild(tableheader2);
    tablerow.appendChild(tableheader3);
    tablerow.appendChild(tableheader4);

    tablehead.appendChild(tablerow);

    table.appendChild(tablehead);

    const tablebody = document.createElement('tbody');
    tablebody.setAttribute("id", "shopping_cart--body")

    table.appendChild(tablebody);

    return table;
}