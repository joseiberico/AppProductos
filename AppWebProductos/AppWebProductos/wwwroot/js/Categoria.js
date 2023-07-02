const form = document.getElementById('form');

form.addEventListener('submit', function (event) {
    event.preventDefault();

    const nombre = document.getElementById('nombre').value.trim();
    const descripcion = document.getElementById('descripcion').value.trim();

    if (!nombre || !descripcion) {
        swal("Error al mandar el formulario!!!", "Es necesario llenar todos los campos.", "error");
    } else {
        swal("Formulario enviado!!!", "El formulario se envi� satisfactoriamente", "success")
            .then(function () {
                form.submit(); // Env�a el formulario despu�s de que se cierra el mensaje
            });
    }
});


