import { SendMail } from "../Model/Model.js"

function onStart() {
    document.querySelector("#payment-button").addEventListener('click', async () => {
        await SendMail();
    })
}
onStart();