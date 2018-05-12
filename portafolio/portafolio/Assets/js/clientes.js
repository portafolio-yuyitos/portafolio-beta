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

  if(valido){
      return cliente = {
        "rut":rut.value,
        "nombre": nombres.val()
      }
  }else{
    return valido;
  }
}

function llenarTabla(cliente){
  var tabla = $('#tablaClientes');
  var largoTabla = tabla.find('tbody tr').length;
  var fila = '<tr>';
  fila += '<th scope="row">'+(largoTabla+1)+'</th>';
  fila += '<td>';
  fila += '<p>'+cliente.rut+'</p>';
  fila += '<input type="text" value="' + cliente.rut +'" class="rut form-control editar d-none" onkeyup="valTexto(this,10,20)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td>';
  fila += '<p>'+cliente.nombre+'</p>';
  fila += '<input type="text" value="'+cliente.nombre+'" class="form-control editar d-none" onkeyup="valTexto(this,10,20)">';
  fila += '<label class="error text-danger d-none "></label>';
  fila += '</td>';
  fila += '<td class="d-flex">';
  fila += '<a  class="btn btn-primary editar d-none cursor-pointer" onclick="guardar(this,'+"'clientes'"+')" data-toggle="tooltip" data-placement="top" title="Guardar cliente"><i class="fas fa-check-circle"></i></a>';
  fila += '<a  class="btn btn-danger btnEliminar mr-2 cursor-pointer" onclick="eliminar(this,' + "'clientes'" +')" data-toggle="tooltip" data-placement="top" title="Eliminar cliente"><i class="fas fa-trash-alt"></i></a>';
  fila += '<a  class="btn btn-secondary btnEditar cursor-pointer" onclick="editar(this,' + "'clientes'" +')" data-toggle="tooltip" data-placement="top" title="Editar cliente"><i class="fas fa-edit"></i></a>';
  fila += '</td>';
  fila += '</tr>';

  tabla.find('tbody').append(fila);
  alert('Se ha agregado el cliente');
}

function agregarCliente(cliente) {
    $.ajax({
        type: 'POST',
        url: '/Clientes/agregar',
        cache: false,
        data: JSON.stringify(cliente),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == "True") {
                llenarTabla(cliente);
            } else if (data == "False") {
                alert("No Logeado");
            }
        },
        error: function (ex) {
            alert('Error al agregar cliente');
        }
    });
}

function eliminarCliente(e, tabla) {
    var rut = $(e).closest('tr').find('.rut').val();
    var data = {
        "rut":rut
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