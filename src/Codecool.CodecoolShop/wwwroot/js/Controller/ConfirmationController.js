import { SendMail } from "../Model/Model.js"

function onStart() {
    document.querySelector("#payment-button").addEventListener('click', () => {
        console.log("Sending mail");
        SendMail();
    })
}
onStart();