function pagarFiado(e) {
    var idFiado = $(e).closest('tr').find('.idFiado').text();
    var estadoFiado = $(e).closest('tr').find('.estadoFiado').text();

    var data = {
        "idFiado": parseInt(idFiado),
        "estadoFiado": estadoFiado
    }

    $.ajax({
        type: 'POST',
        url: '/Fiados/pagarFiado',
        cache: false,
        data: JSON.stringify(fiado),
        contentType: "application/json",
        async: false,
        success: function (data) {
            debugger;
            if (data == "True") {
                $(e).closest('tr').remove();
                mostrarTabla(tabla);//Muestra tabla si tiene filas
                alert('Se ha eliminado el cliente');
            } else if (data == "False") {
                alert("No se ha podido eliminar el cliente");
            }
        },
        error: function (ex) {
            alert('Error al pagar fiado');
        }
    });
}

function getFiados() {

    $.ajax({
        type: 'POST',
        url: '/Fiados/ObtenerFiadosCliente',
        cache: false,
        contentType: "application/json",
        success: function (data) {
            debugger;

            if (data.length > 0) {
                var array = [];

                $.each(data, function (i, fiado) {
                    array.push([
                        fiado.Cliente.Rut.toString(),
                        fiado.Cliente.Nombre.toString(),
                        (fiado.Cliente.Autorizado_fiado == 1 ? "Si" : "No").toString(),
                        fiado.Cliente.Id.toString(),
                    ]);
                });

                //var dataTable = {
                //    "data": array
                //};

                //$('#example').DataTable({
                //    "data": array,
                //    columns: [
                //        {
                //            "className": 'btn',
                //            "orderable": false,
                //            "data": null,
                //            "defaultContent": ''
                //        },
                //        { title: "Rut" },
                //        { title: "Nombre" },
                //        { title: "Autorizado" },
                //        { title: "ID" }
                //    ]
                //});

            }
            else {
                alert('No se ha podido obtener fiados');
            }

        },
        error: function (ex) {
            alert('Error al eliminar cliente');
        }
    });
}

function abrirBoletas(e) {
    debugger;
    var boletas = $(e).closest('tr').next();
    if (boletas.hasClass('d-none')) {
        boletas.removeClass('d-none');
        $(e).html('Ocultar boletas<i class="ml-2 fas fa-chevron-circle-up"></i>');
    } else {
        boletas.addClass('d-none');
        $(e).html('Mostrar boletas<i class="ml-2 fas fa-chevron-circle-down"></i>');
    }
}

function pagarBoleta(e) {
    debugger;

    //$.ajax({
    //    type: 'POST',
    //    url: '/Fiados/ObtenerFiadosCliente',
    //    cache: false,
    //    contentType: "application/json",
    //    success: function (data) {
    //        debugger;

    //        if (data.length > 0) {
    //            var array = [];

    //            $.each(data, function (i, fiado) {
    //                array.push([
    //                    fiado.Cliente.Rut.toString(),
    //                    fiado.Cliente.Nombre.toString(),
    //                    (fiado.Cliente.Autorizado_fiado == 1 ? "Si" : "No").toString(),
    //                    fiado.Cliente.Id.toString(),
    //                ]);
    //            });

    //        }
    //        else {
    //            alert('No se ha podido obtener fiados');
    //        }

    //    },
    //    error: function (ex) {
    //        alert('Error al eliminar cliente');
    //    }
    //});
}