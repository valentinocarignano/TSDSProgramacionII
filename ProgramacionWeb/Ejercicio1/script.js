function alertRegister(){
    alert("Se registro exitosamente");
}

function cancelar() {
    document.getElementById("nombre").value = "";     
    document.getElementById("apellido").value = "";
}


function validarFormulario() {
    const nombre = document.getElementById("nombre").value.trim();
    const apellido = document.getElementById("apellido").value.trim();
    const errores = [];

    let validarNombre = "";

    // Validar que los campos no estén vacíos
    if (nombre === "" && apellido === "") {
        document.getElementById("validarNombre").hidden = false;
        document.getElementById("validarApellido").hidden = false;
        document.getElementById("validarNombre").textContent = "EL CAMPO NO PUEDE ESTAR VACIO";
        document.getElementById("validarApellido").textContent = "EL CAMPO NO PUEDE ESTAR VACIO";
    }
    else if (nombre === ""){
        document.getElementById("validarNombre").hidden = false;
        document.getElementById("validarApellido").hidden = true;
        document.getElementById("validarNombre").textContent = "EL CAMPO NO PUEDE ESTAR VACIO";
    }
    else if (apellido === ""){
        document.getElementById("validarNombre").hidden = true;
        document.getElementById("validarApellido").hidden = false;
        document.getElementById("validarApellido").textContent = "EL CAMPO NO PUEDE ESTAR VACIO";
    }
    else{
        document.getElementById("validarNombre").hidden = true;
        document.getElementById("validarApellido").hidden = true;
    }

    // Validar que el nombre no tenga más de 10 caracteres
    if (nombre.length > 10) {
        document.getElementById("validarNombre").hidden = false;
        document.getElementById("validarNombre").textContent = "EL CAMPO NO PUEDE TENER MAS DE DIEZ CARACTERES";
    }
    else {
        document.getElementById("validarNombre").hidden = true;
    }

    // Validar que el apellido no contenga números
    if (/\d/.test(apellido)) {
        document.getElementById("validarApellido").hidden = false;
        document.getElementById("validarApellido").textContent = "EL CAMPO NO PUEDE TENER NUMEROS";
    }
    else {
        document.getElementById("validarApellido").hidden = true;
    }

    const divErrores = document.getElementById("errores");

    if (errores.length > 0) {
        divErrores.innerHTML = errores.join("<br>");
        divErrores.style.display = "block";
        return false; // Evita el envío del formulario
    } else {
        divErrores.style.display = "none";
        return true; // Permite enviar el formulario
    }
}

function cancelar() {
    document.getElementById("nombre").value = "";
    document.getElementById("apellido").value = "";
    document.getElementById("errores").style.display = "none";
}
