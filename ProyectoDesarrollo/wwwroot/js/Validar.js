function validarCampos() {
    var user = document.getElementsByName("usuD")[0].value;
    var password = document.getElementsByName("contraD")[0].value;

    if (user === "" || password === "") {
        alert("Por favor, rellene todos los campos.");
        return false;
    }
    return true;
}