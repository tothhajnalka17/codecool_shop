function ModifyAddress() {
    const shippingdiv = document.querySelector('#shipping');

    const submitbutton = document.querySelector("#checkOutSubmit");

    const checkbox = document.querySelector('#isShippingBilling');

    const shippingdata = document.querySelectorAll('.shipping');

    const billingdata = document.querySelectorAll('.billing');



    checkbox.addEventListener('change', function () {
        if (this.checked) {
            shippingdiv.setAttribute("hidden", "hidden");
        } else {
            shippingdiv.removeAttribute("hidden");
        }
    })

    submitbutton.addEventListener('click', function () {
        if (checkbox.checked) {
            shippingdata[0].value = billingdata[0].value;
            shippingdata[1].value = billingdata[1].value;
            shippingdata[2].value = billingdata[2].value;
            shippingdata[3].value = billingdata[3].value;
        }
    })

    

}

ModifyAddress();