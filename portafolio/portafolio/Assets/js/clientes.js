function validarTodo() {
    var rut = document.getElementById('rut');
    var nombres = $('#nombres');

    var valido = true;

    if (!checkRut(rut)) {
        valido = false;
    }
    if (!valTexto(nombres, 4, 50)) {
        valido = false;
    }

    if (valido) {
        return cliente = {
            "rut": rut.value,
            "nombre": nombres.val()
        }
    } else {
        return valido;
    }
}

function llenarTabla(cliente) {
    var tabla = $('#tablaClientes');
    var largoTabla = tabla.find('tbody tr').length;
    var fila = '<tr>';
    fila += '<th scope="row">' + (largoTabla + 1) + '</th>';
    fila += '<td>';
    fila += '<p><span>' + cliente.rut + '</span></p>';
    fila += '<input type="text" value="' + cliente.rut + '" class="rut form-control editar d-none" onkeyup="valTexto(this,10,20)">';
    fila += '<label class="error text-danger d-none "></label>';
    fila += '</td>';
    fila += '<td>';
    fila += '<p>' + cliente.nombre + '</p>';
    fila += '<input type="text" value="' + cliente.nombre + '" class="nombres form-control editar d-none" onkeyup="valTexto(this,10,20)">';
    fila += '<label class="error text-danger d-none "></label>';
    fila += '</td>';
    fila += '<td class="d-flex">';
    fila += '<a  class="btn btn-primary editar d-none cursor-pointer" onclick="guardar(this,' + "'clientes'" + ')" data-toggle="tooltip" data-placement="top" title="Guardar cliente"><i class="fas fa-check-circle"></i></a>';
    fila += '<a  class="btn btn-danger btnEliminar mr-2 cursor-pointer" onclick="eliminar(this,' + "'clientes'" + ')" data-toggle="tooltip" data-placement="top" title="Eliminar cliente"><i class="fas fa-trash-alt"></i></a>';
    fila += '<a  class="btn btn-secondary btnEditar cursor-pointer" onclick="editar(this,' + "'clientes'" + ')" data-toggle="tooltip" data-placement="top" title="Editar cliente"><i class="fas fa-edit"></i></a>';

    fila += '<label class="switch ml-2" data-toggle="tooltip" data-placement="top" title="Autorizar para fiar">';
    fila += '<input type="checkbox" class="autorizarFiado" onchange="autorizarFiado(this)" checked="true"><span class="slider round"></span></label>';

    fila += '</td>';
    fila += '</tr>';

    tabla.find('tbody').append(fila);
}

function agregarCliente(cliente,e) {
    $.ajax({
        type: 'POST',
        url: '/Clientes/agregar',
        cache: false,
        data: JSON.stringify(cliente),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "OK") {
                llenarTabla(cliente);
                toast('Se ha agregado el cliente', "success");
                limpiar();
            } else if (data == "Ya existe el registro") {
                toast("Ya existe el registro", "error");
            } else if (data == "Registro eliminado") {
                document.getElementById('myModal').dataset.rut = cliente.rut;
                document.getElementById('myModal').dataset.nombre = cliente.nombre;
                $('#myModal').modal('show');
            }
        },
        error: function (ex) {
            toast('Error al agregar cliente', "error");
        },
        complete: function () {
            refrescarFunction();
        }
    });
}

function eliminarCliente(e, tabla) {
    var rut = $(e).closest('tr').find('.rut').val();
    var data = {
        "rut": rut
    }

    $.ajax({
        type: 'POST',
        url: '/Clientes/eliminar',
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                $(e).closest('tr').remove();
                mostrarTabla(tabla);//Muestra tabla si tiene filas
                toast('Se ha eliminado el cliente', "success");
            } else if (data == "False") {
                toast("No se ha podido eliminar el cliente", "error");
            }
        },
        error: function (ex) {
            toast('Error al eliminar cliente', "error");
        },
        complete: function () {
            refrescarFunction();
        }
    });
}

function updateCliente(cliente, editores) {
    $.ajax({
        type: 'POST',
        url: '/Clientes/update',
        cache: false,
        data: JSON.stringify(cliente),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                $.each(editores, function (i, editor) {
                    //Si es la ultima columna
                    if (editores.length - 1 === i) {
                        $(editor).addClass('d-none');
                        $(editor).siblings('.btnEliminar').removeClass('d-none');
                        $(editor).siblings('.btnEditar').removeClass('d-none');
                    } else {
                        $(editor).addClass('d-none');
                        var texto = $(editor).val();
                        $(editor).siblings('p').find('span').text(texto);
                        $(editor).siblings('p').removeClass('d-none');
                    }
                })
                toast('Se ha editado correctamente', "success");
            } else if (data == "False") {
                toast("No se ha podido editar", "error");
            }
        },
        error: function (ex) {
            toast('Error al editar cliente', "error");
        },
        complete: function () {
            refrescarFunction();
        }
    });
}

function autorizarFiado(e) {

    var url = '/clientes/desautorizar';
    var autorizar = 0;

    if (e.checked) {
        autorizar = 1;
    }

    var rut = $(e).closest('tr').find('.rut').val();

    var cliente = {
        "Rut": rut,
        "Autorizado_fiado": autorizar

    };

    $.ajax({
        type: 'POST',
        url: '/clientes/autorizar',
        cache: false,
        data: cliente,
        contenttype: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                toast('Se ha modificado al cliente', "success");
            } else if (data == "False") {
                e.checked = !e.checked;
                toast("No se ha podido modificar al cliente", "error");
            }
        },
        error: function (ex) {
            toast('Error al modificar al cliente', "error");
        },
        complete: function () {
            refrescarFunction();
        }
    });
}

function activarCliente() {
    var rut = document.getElementById('myModal').dataset.rut;
    var nombre = document.getElementById('myModal').dataset.nombre;
    var estado = 1;
    var cli = {
        "rut": rut,
        "nombre": nombre,
        "estado": estado
    };
    $.ajax({
        type: 'POST',
        url: '/Clientes/update',
        cache: false,
        data: JSON.stringify(cli),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                llenarTabla(cli);
                toast('Se ha editado correctamente', "success");
                $('#myModal').modal('hide');
                limpiar();
            } else if (data == "False") {
                toast("No se ha podido editar", "error");
            }
        },
        error: function (ex) {
            toast('Error al editar cliente', "error");
        },
        complete: function () {
            refrescarFunction();
        }
    });
}

function limpiar() {
    document.getElementById('rut').value = '';
    $('#nombres').val('');
}

$('document').ready(function () {
    mostrarTabla($('#tablaClientes'));

   
});

