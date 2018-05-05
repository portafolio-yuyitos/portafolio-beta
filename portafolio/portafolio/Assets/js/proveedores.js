function validarTodo() {
  var nombre = $('#nombre');
  var numero = document.getElementById('numero');
  var email = $('#email');
  var rubro = $('#rubro');

  var valido = true;

  if (!valTexto(nombre, 4, 50)) {
    valido = false;
  }
  if (!valNumber(numero, 5, 12)) {
    valido = false;
  }
  if (!valEmail(email)) {
    valido = false;
  }
  if (!valTexto(rubro, 4, 50)) {
    valido = false;
  }

  if (valido) {
    return proveedor = {
      "nombre": nombre.val(),
      "numero": numero.value,
      "email": email.val(),
      "rubro": rubro.val()
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
  fila += '<p>' + proveedor.nombre + '</p>';
  fila += '<input type="text" value=' + proveedor.nombre + ' class="form-control editar d-none" onkeyup="valTexto(this,4,50)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.numero + '</p>';
  fila += '<input type="text" value=' + proveedor.numero + ' class="form-control editar d-none" onkeyup="valNumber(this,9,12)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.email + '</p>';
  fila += '<input type="text" value=' + proveedor.email + ' class="form-control editar d-none" onkeyup="valEmail(this)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>' + proveedor.rubro + '</p>';
  fila += '<input type="text" value=' + proveedor.rubro + ' class="form-control editar d-none" onkeyup="valTexto(this,4,50)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<a class="btn btn-primary editar d-none cursor-pointer" onclick="guardar(this)" data-toggle="tooltip" data-placement="top" title="Guardar contacto"><i class="fas fa-check-circle"></i></a>';
  fila += '<a class="btn btn-danger btnEliminar mr-2 cursor-pointer" onclick="eliminar(this)" data-toggle="tooltip" data-placement="top" title="Eliminar contacto"><i class="fas fa-trash-alt"></i></a>';
  fila += '<a class="btn btn-secondary btnEditar cursor-pointer" onclick="editar(this)" data-toggle="tooltip" data-placement="top" title="Editar contacto"><i class="fas fa-edit"></i></a>';
  fila += '</td>';
  fila += '</tr>';

  tabla.find('tbody').append(fila);
  alert('Se ha agregado el cliente');
}