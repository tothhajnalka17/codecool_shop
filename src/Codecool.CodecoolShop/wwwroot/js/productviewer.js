var selected = document.querySelectorAll(".headerAlign");
for (var i = 0; i < selected.length; i++) {
    selected[i].addEventListener('click', Examine);
}


function Examine() {
    var link = `/product/viewer/${this.dataset.id}`;
    window.location = link;
}