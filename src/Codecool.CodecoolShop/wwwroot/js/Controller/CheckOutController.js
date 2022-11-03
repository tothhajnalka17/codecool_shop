function ModifyAddress() {
   
    const shippingdata = document.querySelectorAll('.shipping');
    const billingdata = document.querySelectorAll('.billing');

    $('input[name=checkbox]').change(function () {
        if ($(this).is(':checked')) {
            
            shippingdata[0].value = billingdata[0].value;
            shippingdata[1].value = billingdata[1].value;
            shippingdata[2].value = billingdata[2].value;
            shippingdata[3].value = billingdata[3].value;
        }
        else {
            shippingdata[0].value = "";
            shippingdata[1].value = "";
            shippingdata[2].value = "";
            shippingdata[3].value = ""; 
        }
    })
}
ModifyAddress();