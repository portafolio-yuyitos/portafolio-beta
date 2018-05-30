function validarTodo() {
    var numBoleta = $('#numBoleta');
    var montoFiado = $('#montoFiado');
    var tipoPago = $('#tipoPago');
    var totalBoleta = $('#montoTotal');
    var fechaBoleta = $('#fechaBoleta');
    var idCliente = $('#idCliente');

    var valido = true;

    if (!valNumber(numBoleta[0], 1, 15)) {
        valido = false;
    }
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
    debugger;
    if (valido) {
        return boleta = {
            "numeroBoleta": parseInt(numBoleta.val()),
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
    fila += '<th scope="row">' + (largoTabla + 1) + '</th>';
    fila += '<td><p>' + boleta.numeroBoleta + '</p></td>';
    fila += '<td><p>' + boleta.fiado + '</p></td>';
    fila += '<td><p>' + getNombreTipo(boleta.tipoPago) + '</p></td>';
    fila += '<td><p>' + boleta.fechaBoleta + '</p></td>';
    fila += '<td><p>' + boleta.idCliente + '</p></td>';
    fila += '<td><p>' + boleta.totalBoleta + '</p></td>';
    fila += '</tr>';

    tabla.find('tbody').append(fila);
    alert('Se ha agregado la boleta');
}

function agregarBoleta(bol) {
    debugger;
    $.ajax({
        type: 'POST',
        url: '/boletas/agregar',
        cache: false,
        data: bol,
        contenttype: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                llenarTabla(boleta);
                mostrarTabla($('#tablaBoletas'));
                limpiarCampos();
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
                    str += '<option data="' + opt.Autorizado_fiado + '" value="' + opt.Id + '">' + opt.Nombre + ' / ' + opt.Rut + '</option>';
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
    //$('#tipoPago').val('');
    $('#montoTotal').val('');
    $('#fechaBoleta').val('-1');
    $('#idCliente').val('-1');
}

function getNombreTipo(id) {
    var nombreTipo = "";
    switch (id) {
        case 1:
            nombreTipo = "Efectivo";
            break;
        case 2:
            nombreTipo = "Tarjeta";
            break;
        default:
    }
    return nombreTipo;
}

$('document').ready(function () {
    mostrarTabla($('#tablaBoletas'));
    fechaHoy($('#fechaBoleta'));
    fillSelectClientes();
});

