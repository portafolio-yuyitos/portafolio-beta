function validarTodo() {
  var rut = document.getElementById('rut');
  var fono = document.getElementById('fono');
  var email = $('#email');
  var giro = $('#giro');
  var razon = $('#razon');

  var valido = true;

  if (!checkRut(rut)) {
      valido = false;
  }
  if (!valNumber(fono, 5, 12)) {
    valido = false;
  }
  if (!valEmail(email)) {
    valido = false;
  }
  if (!valTexto(razon, 4, 50)) {
      valido = false;
  }
  if (!valTexto(giro, 4, 50)) {
    valido = false;
  }

  if (valido) {
    return proveedor = {
      "rutProveedor": $(rut).val(),
      "fono": fono.value,
      "email": email.val(),
      "giro": giro.val(),
      "razonSocial": razon.val()
    }
  } else {
    return valido;
  }
}

function llenarTabla(proveedor) {
  var tabla = $('#tabla');
  var largoTabla = tabla.find('tbody tr').length;
  var fila = '<tr>';

  fila += '<tr>';
  fila += '<th scope="row">' + (largoTabla + 1) + '</th>';
  fila += '<td>';
  fila += '<p>' + proveedor.rutProveedor + '</p>';
    fila += '<input type="text" value="' + proveedor.rutProveedor + '" class="rut form-control editar d-none" onkeyup="checkRut(this)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.email + '</p>';
  fila += '<input type="text" value="' + proveedor.email + '" class="email form-control editar d-none" onkeyup="valEmail(this)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.razonSocial + '</p>';
  fila += '<input type="text" value="' + proveedor.razonSocial + '" class="razon form-control editar d-none" onkeyup="valTexto(this,4,50)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.giro + '</p>';
  fila += '<input type="text" value="' + proveedor.giro + '" class="giro form-control editar d-none" onkeyup="valTexto(this,4,50)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.fono + '</p>';
  fila += '<input type="text" value="' + proveedor.fono + '" class="fono form-control editar d-none" onkeyup="valNumber(this,9,12)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<a class="btn btn-primary editar d-none cursor-pointer" onclick="guardar(this,' + "'proveedor'" +')" data-toggle="tooltip" data-placement="top" title="Guardar contacto"><i class="fas fa-check-circle"></i></a>';
  fila += '<a class="btn btn-danger btnEliminar mr-2 cursor-pointer" onclick="eliminar(this,' + "'proveedor'" +')" data-toggle="tooltip" data-placement="top" title="Eliminar contacto"><i class="fas fa-trash-alt"></i></a>';
  fila += '<a class="btn btn-secondary btnEditar cursor-pointer" onclick="editar(this,' + "'proveedor'" +')" data-toggle="tooltip" data-placement="top" title="Editar contacto"><i class="fas fa-edit"></i></a>';
  fila += '</td>';
  fila += '</tr>';

  tabla.find('tbody').append(fila);
}

function agregarProveedor(proveedor) {
    $.ajax({
        type: 'POST',
        url: '/Proveedores/agregar',
        cache: false,
        data: JSON.stringify(proveedor),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "OK") {
                llenarTabla(proveedor);
                limpiarCampos();
                alert('Se ha agregado el proveedor');
            } else if (data == "Ya existe el registro") {
                alert("Ya existe el registro");
            } else if (data == "Registro eliminado") {
                document.getElementById('myModal').dataset.rutProveedor = proveedor.rutProveedor;
                document.getElementById('myModal').dataset.fono = proveedor.fono;
                document.getElementById('myModal').dataset.email = proveedor.email;
                document.getElementById('myModal').dataset.giro = proveedor.giro;
                document.getElementById('myModal').dataset.razonSocial = proveedor.razonSocial;
                $('#myModal').modal('show');
            } else {
                alert("No se ha agregado el proveedor correctamente");
            }
        },
        error: function (ex) {
            alert("Error al agregar el proveedor");
        }
    });
}

function eliminarProveedor(e, tabla) {
    var rut = $(e).closest('tr').find('.rut').val();
    var data = {
        "rut": rut
    }

    $.ajax({
        type: 'POST',
        url: '/Proveedores/eliminar',
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                $(e).closest('tr').remove();
                mostrarTabla(tabla);//Muestra tabla si tiene filas
                alert("Se ha eliminado el proveedor correctamente");
            } else if (data == "False") {
                alert("No se ha eliminado el proveedor");
            }
            refrescarFunction();
        },
        error: function (ex) {
            alert("No se ha podido agregar el proveedor");
        }
    });
}

function updateProveedor(proveedor, editores) {
    $.ajax({
        type: 'POST',
        url: '/Proveedores/update',
        cache: false,
        data: JSON.stringify(proveedor),
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
                        $(editor).siblings('p').text(texto);
                        $(editor).siblings('p').removeClass('d-none');
                    }
                })
                alert('Se ha editado correctamente el proveedor');
            } else if (data == "False") {
                alert("No se ha podido editar el proveedor");
            }
        },
        error: function (ex) {
            alert('Error al editar proveedor');
        }
    });
}

function limpiarCampos() {
    document.getElementById('rut').value="";
    document.getElementById('fono').value="";
    $('#email').val('');
    $('#giro').val('');
    $('#razon').val('');
}

function activarProveedor() {

    var rutProveedor = document.getElementById('myModal').dataset.rutProveedor;
    var fono = document.getElementById('myModal').dataset.fono;
    var email = document.getElementById('myModal').dataset.email;
    var giro = document.getElementById('myModal').dataset.giro;
    var razonSocial = document.getElementById('myModal').dataset.razonSocial;
    var estado = 1;
    var proveedor = {
        "rutProveedor": rutProveedor,
        "fono": fono,
        "email": email,
        "giro": giro,
        "razonSocial": razonSocial,
        "estado": estado
    };
    $.ajax({
        type: 'POST',
        url: '/Proveedores/update',
        cache: false,
        data: JSON.stringify(proveedor),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                llenarTabla(proveedor);
                alert('Se ha editado correctamente');
                $('#myModal').modal('hide');
                limpiarCampos();
            } else if (data == "False") {
                alert("No se ha podido editar");
            }
        },
        error: function (ex) {
            alert('Error al editar proveedor');
        },
        complete: function () {
            refrescarFunction();
        }
    });
}

$('document').ready(function () {
    mostrarTabla($('#tabla'));
});