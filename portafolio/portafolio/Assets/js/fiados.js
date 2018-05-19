function cambiarFiado() {
    var rut = $(e).closest('tr').find('.rut').val();
    var data = {
        "rut": rut
    }

    $.ajax({
        type: 'POST',
        url: '/Fiados/cambiarFiado',
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                $(e).closest('tr').remove();
                mostrarTabla(tabla);//Muestra tabla si tiene filas
                alert('Se ha eliminado el cliente');
            } else if (data == "False") {
                alert("No se ha podido eliminar el cliente");
            }
        },
        error: function (ex) {
            alert('Error al eliminar cliente');
        }
    });
}