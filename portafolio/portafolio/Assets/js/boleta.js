function validarTodo() {
    //var numBoleta = $('#numBoleta');
    var montoFiado = $('#montoFiado');
    var tipoPago = $('#tipoPago');
    var totalBoleta = $('#montoTotal');
    var fechaBoleta = $('#fechaBoleta');
    var idCliente = $('#idCliente');

    var valido = true;
    if (!valNumber(montoFiado[0], 1, 15)) {
        valido = false;
    }
    if (!valSelect(tipoPago)) {
        valido = false;
    }
    if (!valNumber(totalBoleta[0], 1, 15)) {
        valido = false;
    }
    if (!valSelect(idCliente)) {
        valido = false;
    }

    var parts = fechaBoleta.val().split("/");
    var dt = new Date(parseInt(parts[2], 10),
        parseInt(parts[1], 10) - 1,
        parseInt(parts[0], 10));

    if (valido) {
        return boleta = {
            "fiado": parseInt(montoFiado.val()),
            "tipoPago": tipoPago.val(),
            "totalBoleta": parseInt(totalBoleta.val()),
            "fechaBoleta": fechaBoleta.val(),
            "idCliente": parseInt(idCliente.val())
        };
    } else {
        return valido;
    }
}

function llenarTabla(boleta) {
    var tabla = $('#tablaBoletas');
    var largoTabla = tabla.find('tbody tr').length;
    var fila = '<tr>';

    var fecha = moment(boleta.FechaBoleta).format("DD-MM-YYYY");

    fila += '<th scope="row">' + (largoTabla + 1) + '</th>';
    fila += '<td><p>' + boleta.NumeroBoleta + '</p></td>';
    fila += '<td><p>' + boleta.Fiado + '</p></td>';
    fila += '<td><p>' + getNombreTipo(boleta.TipoPago) + '</p></td>';
    fila += '<td><p>' + fecha + '</p></td>';
    fila += '<td><p>' + boleta.IdCliente + '</p></td>';
    fila += '<td><p>' + boleta.TotalBoleta + '</p></td>';
    fila += '</tr>';

    tabla.find('tbody').append(fila);
}

function agregarBoleta(bol) {
    $.ajax({
        type: 'POST',
        url: '/boletas/agregar',
        cache: false,
        data: bol,
        contenttype: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                fillTablaBoletas();
                alert('Se ha agregado la boleta');
            } else if (data == "False") {
                alert("no logeado");
            }
        },
        error: function (ex) {
            alert('error al agregar cliente');
        }
    });
}

function fillSelectClientes() {
    $.ajax({
        type: 'POST',
        url: '/clientes/clientes',
        cache: false,
        contenttype: "application/json",
        async: false,
        success: function (data) {
            if (data !== "") {
                var slcClientes = $('#idCliente');
                var str = '<option value="-1">Seleccione</option>';
                $.each(data, function (i, opt) {
                    str += '<option data-autorizado="' + opt.Autorizado_fiado + '" value="' + opt.Id + '">' + opt.Nombre + ' / ' + opt.Rut + '</option>';
                });
                slcClientes.html(str);
            } else {
                alert("No se pudo traer los clientes");
            }
        },
        error: function (ex) {
            alert('Error al traer los clientes');
        }
    });
}

function fillTablaBoletas() {
    $.ajax({
        type: 'POST',
        url: '/boletas/ObtenerBoletasJSON',
        cache: false,
        contenttype: "application/json",
        async: false,
        success: function (data) {
            if (data !== "") {
                $('#tablaBoletas').find('tbody').html('');
                $.each(data, function (i, opt) {
                    llenarTabla(opt);
                });
                mostrarTabla($('#tablaBoletas'));
                limpiarCampos();
            } else {
                alert("No se pudo traer las boletas");
            }
        },
        error: function (ex) {
            alert('Error al traer las boletas');
        }
    });
}

function fechaHoy(input) {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    today = dd + '/' + mm + '/' + yyyy;

    input.val(today);
}

function limpiarCampos() {
    $('#numBoleta').val('');
    $('#montoFiado').val('');
    $('#tipoPago').val('-1');
    $('#montoTotal').val('');
    //$('#fechaBoleta').val();
    $('#idCliente').val('-1');
}

function getNombreTipo(id) {
    var nombreTipo = "";
    switch (id) {
        case "1":
            nombreTipo = "Efectivo";
            break;
        case "2":
            nombreTipo = "Tarjeta";
            break;
        default:
    }
    return nombreTipo;
}

//Valida los select
function valSelectBoletas(e) {
    let valor = $(e).val();
    var error = $(e).siblings('.error');
    var valido = true;

    if (valor !== null) {
        if (valor.trim() === "Seleccione" || valor.trim() === "-1") {
            error.text('Debe estar seleccionado');
            error.removeClass('d-none');
            $(e).addClass('is-invalid');
            valido = false;
        } else {
            error.addClass('d-none');
            $(e).removeClass('is-invalid');
            if (e.selectedOptions[0].dataset.autorizado != 0) {
                $('#fiado').removeClass('d-none');
            } else {
                $('#fiado').addClass('d-none');
            }
        }
    } else {
        error.addClass('d-none');
        $(e).removeClass('is-invalid');
    }
    return valido;
}


$('document').ready(function () {
    //mostrarTabla($('#tablaBoletas'));
    fechaHoy($('#fechaBoleta'));
    fillSelectClientes();
    fillTablaBoletas();
});

