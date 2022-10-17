var selected = document.querySelectorAll(".card");
for (var i = 0; i < selected.length; i++) {
    selected[i].addEventListener('click', Examine);
}


function Examine() {
    console.log(this);
    return '/product/viewer/';
}