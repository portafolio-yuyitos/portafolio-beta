// Valida cantidad pasandole su minimo y su maximo
function valCantidad(e, min, max) {
  let valor = e.value;
  var reg = new RegExp('^[0-9]+$');
  var error = $(e).siblings('.error');
  var valido = true;

  if (valor.trim() === "") {
    error.text('No debe estar vacío');
    error.removeClass('d-none');
    $(e).addClass('is-invalid');
    valido = false;
  } else if (!reg.test(valor)) {
    e.value = valor.substring(0, valor.length - 1)//quitar ultimo caracter
    error.text('Ingrese sólo números');
    error.removeClass('d-none');
    $(e).addClass('is-invalid');
    valido = false;
  } else if (valor < min) {
    error.text('Mínimo: ' + min);
    error.removeClass('d-none');
    $(e).addClass('is-invalid');
    valido = false;
  } else if (valor > max) {
    error.text('Máximo: ' + max);
    error.removeClass('d-none');
    $(e).addClass('is-invalid');
    valido = false;
  } else {
    error.addClass('d-none');
    $(e).removeClass('is-invalid');
  }
  return valido;
}

//Valida todos los input antes de llenar la tabla
function validarTodo() {
  var proveedor = $('#proveedor');
  var producto = $('#producto');
  var cantidad = document.getElementById('cantidad');

  var valido = true;

  if (!valSelect(proveedor)) {
    valido = false;
  }
  if (!valSelect(producto)) {
    valido = false;
  }
  if (!valCantidad(cantidad, 1, 99999999)) {
    valido = false;
  }
  if (valido) {
    llenarProductos(cantidad, proveedor, producto);//Llena los productos
  }

  return valido;
}

//Llena la tabla de productos con una fila nueva
function llenarProductos(cantidad, proveedor, producto) {
  var precio = $('#precio')['0'].value * cantidad.value;
  var productos = $('#productosContainer');
  var fila = '<tr class="border-bottom">'; //Crea fila
  fila += '<td class="p-2">' + proveedor.val() + '</td>';
  fila += '<td>' + producto.val() + '</td>';
  fila += '<td>' + cantidad.value + '</td>';
  fila += '<td class="precio">' + precio + '</td>';
  fila += '<td><button class="btn btn-danger mr-2 my-2" onclick="eliminar(this,true)">Eliminar</button>';
  fila += '<button class="btn btn-secondary">Editar</button>';
  fila += '</td></tr>';
  //Pinta en tabla productos
  productos.find('tbody').append(fila);
  //Limpiar campos
  proveedor['0'].value = "Seleccione";
  producto['0'].value = "Seleccione";
  $('#precio')['0'].value = 1000;
  cantidad.value = 0;
  debugger
  mostrarTabla(productos.closest('table'), true);
}

//Agregar Producto
function agregarProducto() {
  var valido = validarTodo(); //Valida

  if (!valido) {
    alert('Hay campos no válidos')
    return false;
  } else {
    sumarTotal();//Suma el total de los productos
    return true;
  }
}

//Suma el total de los productos
function sumarTotal() {
  var productos = $('#productosContainer').find('tbody tr');//Busca todos los productos
  var total = 0;
  $.each(productos, function (i, producto) {//Recorre los productos
    var precio = $(producto).find('.precio').text();//Busca solo los precios por su clase .precio
    total = parseInt(precio) + total;//Suma los precios de cada producto
  });
  $('#total strong').text(total);//pinta en total
}

//Genera la Orden de Pedido
function generarOP() {
  var total = $('#total strong');//Total
  if (total.text() === "0") {//Si es 0
    alert('Debes agregar al menos un producto');
    return false;
  } else {//Si es mas de cero
    var tabla = $('#productosContainer');
    var filas = tabla.find('tbody tr');
    var productos = [];//Array Productos, se llenará con Objeto Producto
    //Llenar productos
    $.each(filas, function (i, producto) {
      var columnas = $(producto).find('td');
      var producto = {};//Objeto Producto
      //Recorrer columnas de la fila
      $.each(columnas, function (j, columna) {
        switch (j) {//verificar columna paa llenar objeto Producto
          case 0://Proveedor
            producto.proveedor = columna.textContent;
            break;
          case 1://Producto
            producto.nombre = columna.textContent;
            break;
          case 2://Cantidad
            producto.cantidad = columna.textContent;
            break;
          case 3://precio
            producto.precio = columna.textContent;
            break;
          default:
            break;
        }
      });
      productos.push(producto);
    });
    var OP = {//Objeto de orden de pedido
      'id': 123321,
      'total': total.text(),
      'productos': JSON.stringify(productos)
    }

    llenarTabla(OP);//Llenar la tabla
    $('#vacio').addClass('d-flex');
    $('#vacio').removeClass('d-none');
    tabla.closest('.productos').addClass('d-none');
    tabla.closest('.productos').removeClass('d-flex');
    tabla.closest('.productos').siblings('.productos').addClass('d-none');
    tabla.closest('.productos').siblings('.productos').removeClass('d-flex');
    tabla.find('tbody').html('');
  }
}

//Llena la tabla, pasandole un objeto con la orden de pedido
function llenarTabla(OP) {
  var tabla = $('#tablaOP');
  var largoTabla = tabla.find('tbody tr').length + 1;
  var fila = '<tr data-enviada="1" data-productos=' + OP.productos + '>';//Genera fila
  fila += '<th scope="row">' + largoTabla + '</th>';
  fila += '<td>' + OP.id + '</td>';
  fila += '<td>' + OP.total + '</td>';
  fila += '<td><button class="btn btn-danger mr-2" onclick="eliminarOP(this)">Eliminar</button>';
  fila += '<button class="btn btn-secondary" onclick="muestraOP(this)">Editar</button>';
  fila += '</td></tr>';
  tabla.find('tbody').append(fila);//pinta fila
  mostrarTabla(tabla);
}

//Eliminar orden de pedido si no ha sido enviada
function eliminarOP(elem) {
  var fila = $(elem).closest('tr');//Fila
  var enviada = fila['0'].dataset.enviada;//Data en la fila con valor de enviada
  if (enviada === "1") {//Si esta eviada === 1
    alert('No se puede eliminar, está enviada');
    return false;
  } else {
    eliminar(elem);//eliminar fila
    return true;
  }
}

//Muestra la Orden de Pedido, se le pasa elemento
function muestraOP(elem) {
  var productos = $('#productosContainer');//body de tabla productos
  limpiarTablaProductos(productos);
  var fila = $(elem).closest('tr');
  var productosObjeto = JSON.parse(fila['0'].dataset.productos); //Objeto de propductos guardado en la fila
  $.each(productosObjeto, function (i, prod) {//Recorrer el array con los produtos para pintarlos en la tabla
    var fila = '<tr class="border-bottom">'; //Crea fila
    fila += '<td class="p-2">' + prod.proveedor + '</td>';
    fila += '<td>' + prod.nombre + '</td>';
    fila += '<td>' + prod.cantidad + '</td>';
    fila += '<td class="precio">' + prod.precio + '</td>';
    fila += '<td><button class="btn btn-danger mr-2 my-2" onclick="eliminar(this,true)">Eliminar</button>';
    fila += '<button class="btn btn-secondary">Editar</button>';
    fila += '</td></tr>';
    //Pinta en tabla productos
    productos.find('tbody').append(fila);
  });
  //Mostrar la tabla
  mostrarTabla(productos, true);
}

function limpiarTablaProductos(tabla){
  tabla.find('tbody').html('');
}
