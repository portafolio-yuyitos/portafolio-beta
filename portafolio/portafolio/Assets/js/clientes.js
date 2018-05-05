function validarTodo(){
  var rut = document.getElementById('rut');
  var nombres = $('#nombres');
  var apellidos = $('#apellidos');
  var email = $('#email');
  var numero = $('#numero');

  var valido = true;

  if(!checkRut(rut)){
    valido = false;  
  }
  if(!valTexto(nombres, 4, 50)){
    valido = false;  
  }
  if(!valTexto(apellidos, 4, 50)){
    valido = false;  
  }
  if(!valEmail(email)){
    valido = false;  
  }
  if(!valTexto(numero, 5, 10)){
    valido = false;  
  }

  if(valido){
      return cliente = {
        "rut":rut.value,
        "nombres": nombres.val(),
        "apellidos": apellidos.val(),
        "email": email.val(),
        "numero": numero.val()
      }
  }else{
    return valido;
  }
}

function llenarTabla(cliente){
  debugger;
  var tabla = $('#tablaClientes');
  var largoTabla = tabla.find('tbody tr').length;
  var fila = '<tr>';
  fila += '<th scope="row">'+(largoTabla+1)+'</th>';
  fila += '<td>';
  fila += '<p>'+cliente.rut+'</p>';
  fila += '<input type="text" value="'+cliente.rut+'" class="form-control editar d-none" onkeyup="valTexto(this,10,20)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>'+cliente.nombres+'</p>';
  fila += '<input type="text" value="'+cliente.nombres+'" class="form-control editar d-none" onkeyup="valTexto(this,10,20)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>'+cliente.apellidos+'</p>';
  fila += '<input type="text" value="'+cliente.apellidos+'" class="form-control editar d-none" onkeyup="valTexto(this,10,20)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<input type="text" value="'+cliente.email+'" class="form-control editar d-none">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '<p>'+cliente.email+'</p>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>'+cliente.numero+'</p>';
  fila += '<input type="text" value="'+cliente.numero+'" class="form-control editar d-none" onkeyup="valNumber(this,5,10)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td class="d-flex">';
  fila += '<a  class="btn btn-primary editar d-none cursor-pointer" onclick="guardar(this)" data-toggle="tooltip" data-placement="top" title="Guardar cliente"><i class="fas fa-check-circle"></i></a>';
  fila += '<a  class="btn btn-danger btnEliminar mr-2 cursor-pointer" onclick="eliminar(this)" data-toggle="tooltip" data-placement="top" title="Eliminar cliente"><i class="fas fa-trash-alt"></i></a>';
  fila += '<a  class="btn btn-secondary btnEditar cursor-pointer" onclick="editar(this)" data-toggle="tooltip" data-placement="top" title="Editar cliente"><i class="fas fa-edit"></i></a>';
  fila += '</td>';
  fila += '</tr>';

  tabla.find('tbody').append(fila);
  alert('Se ha agregado el cliente');
}