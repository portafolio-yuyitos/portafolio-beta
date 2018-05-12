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
  debugger;
  var tabla = $('#tabla');
  var largoTabla = tabla.find('tbody tr').length;
  var fila = '<tr>';

  fila += '<tr>';
  fila += '<th scope="row">' + (largoTabla + 1) + '</th>';
  fila += '<td>';
  fila += '<p>' + proveedor.rutProveedor + '</p>';
  fila += '<input type="text" value="' + proveedor.rutProveedor + '" class="form-control editar d-none" onkeyup="valTexto(this,10,20)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.email + '</p>';
  fila += '<input type="text" value=' + proveedor.email + ' class="form-control editar d-none" onkeyup="valEmail(this)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.razonSocial + '</p>';
  fila += '<input type="text" value=' + proveedor.razonSocial + ' class="form-control editar d-none" onkeyup="valTexto(this,4,50)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.giro + '</p>';
  fila += '<input type="text" value=' + proveedor.giro + ' class="form-control editar d-none" onkeyup="valTexto(this,4,50)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.fono + '</p>';
  fila += '<input type="text" value=' + proveedor.fono + ' class="form-control editar d-none" onkeyup="valNumber(this,9,12)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<a class="btn btn-primary editar d-none cursor-pointer" onclick="guardar(this)" data-toggle="tooltip" data-placement="top" title="Guardar contacto"><i class="fas fa-check-circle"></i></a>';
  fila += '<a class="btn btn-danger btnEliminar mr-2 cursor-pointer" onclick="eliminar(this)" data-toggle="tooltip" data-placement="top" title="Eliminar contacto"><i class="fas fa-trash-alt"></i></a>';
  fila += '<a class="btn btn-secondary btnEditar cursor-pointer" onclick="editar(this)" data-toggle="tooltip" data-placement="top" title="Editar contacto"><i class="fas fa-edit"></i></a>';
  fila += '</td>';
  fila += '</tr>';

  tabla.find('tbody').append(fila);
  alert('Se ha agregado el proveedor');
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
            if (data == "True") {
                llenarTabla(proveedor);
            } else if (data == "False") {
                alert("No Logeado");
            }
        },
        error: function (ex) {
            alert('Error al agregar cliente');
        }
    });
}