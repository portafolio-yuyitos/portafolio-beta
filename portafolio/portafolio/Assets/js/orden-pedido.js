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
    debugger;
    var proveedor = $('#proveedor');
    var producto = $('#productos');
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
    var nombreProveedor = $('#select2-proveedor-container').text();
    var nombreProducto = producto[0].selectedOptions[0].innerText;
    var precio = $('#precio')['0'].value * cantidad.value;
    var productos = $('#productosContainer');
    var fila = '<tr>'; //Crea fila
    fila += '<td data-id="' + proveedor.val() + '">' + nombreProveedor + '</td>';
    fila += '<td data-id="' + producto.val() + '">' + nombreProducto + '</td>';
    fila += '<td>' + cantidad.value + '</td>';
    fila += '<td class="precio">' + precio + '</td>';
    fila += '<td><button class="btn btn-danger mr-2" onclick="eliminar(this,' + "'productos'" + ')">Eliminar</button>';
    fila += '</td></tr>';
    //Pinta en tabla productos
    productos.find('tbody').append(fila);
    mostrarTabla(productos.closest('table'), true);
    limpiarCamposProducto(cantidad, proveedor, producto);
}

//Limpia campos al agregar producto
function limpiarCamposProducto(cantidad, proveedor, producto) {
    cantidad.value = 0;
    proveedor.attr('disabled', true);
    proveedor.siblings('.error').addClass('d-none');
    producto.val('-1');
    $('#precio')['0'].value = 0;
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
function generarOP(e) {

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
                        producto.proveedor = columna.dataset.id;
                        producto.nombreProveedor = columna.textContent;
                        break;
                    case 1://Producto
                        producto.id = columna.dataset.id;
                        producto.nombreProducto = columna.textContent;
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

        //Acá hay que llamar a un ajax
        if (e.id === "editarOP") {
            editarOP(tabla, productos, total, e);
        } else {
            agregarOP(tabla, productos, total);
        }
    }
}

//Agrega orden de pedido
function editarOP(tabla, productos, total, e) {

    var objProductos = JSON.stringify(productos);
    objProductos = objProductos.replace(/\s/g, "_");

    var OP = {//Objeto de orden de pedido
        'id': 123321,//Esto se quitaría luego
        'total': total.text(),
        'productos': objProductos
    };

    //$.ajax({
    //    type: 'POST',
    //    url: '/OrdenPedido/agregar',
    //    cache: false,
    //    data: JSON.stringify(OP),
    //    contentType: "application/json",
    //    async: false,
    //    success: function (data) {
    //        if (data == "True") {
    //            llenarTabla(OP);//Llenar la tabla
    //            $('#vacio').addClass('d-flex');
    //            $('#vacio').removeClass('d-none');
    //            tabla.closest('.productos').addClass('d-none');
    //            tabla.closest('.productos').removeClass('d-flex');
    //            tabla.closest('.productos').siblings('.productos').addClass('d-none');
    //            tabla.closest('.productos').siblings('.productos').removeClass('d-flex');
    //            tabla.find('tbody').html('');
    //        } else if (data == "False") {
    //            alert("No se ha podido generar la orden pedido");
    //        }
    //    },
    //    error: function (ex) {
    //        alert('Error al generar la orden de pedido');
    //    }
    //});

    //Remover fila de la tabla y luego pintar la nueva

    var filas = $('#tablaOP').find('tbody').find('tr');
    $.each(filas, function (i, val) {
        if ($(val).find('th')[0].textContent === idOPModificar) {
            $(val).closest('tr').remove();
        }
    });

    llenarTabla(OP);//Llenar la tabla
    $('#vacio').addClass('d-flex');
    $('#vacio').removeClass('d-none');
    tabla.closest('.productos').addClass('d-none');
    tabla.closest('.productos').removeClass('d-flex');
    tabla.closest('.productos').siblings('.productos').addClass('d-none');
    tabla.closest('.productos').siblings('.productos').removeClass('d-flex');
    tabla.find('tbody').html('');
    $('#editarOP').addClass('d-none');
    $('#generarOP').removeClass('d-none');
}

//Edita orden de pedido
function agregarOP(tabla, productos, total) {
    debugger;
    var objProductos = JSON.stringify(productos);
    objProductos = objProductos.replace(/\s/g, "_");

    var ped = {//Objeto de orden de pedido
        'IdProveedor': parseInt(productos[0].proveedor),
        'IdUsuario': 1
    };

    $.ajax({
        type: 'POST',
        url: '/OrdenPedido/agregar',
        cache: false,
        data: JSON.stringify(ped),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data !== "-1") {
                $.each(productos, function (i, val) {

                    var detaPed = {
                        "NumeroPedido": parseInt(data),
                        "IdProducto": parseInt(val.id),
                        "CantidadProducto": parseInt(val.cantidad),
                        "PrecioProducto": parseInt(val.precio)
                    };

                    $.ajax({
                        type: 'POST',
                        url: '/OrdenPedido/AgregarDetalle',
                        cache: false,
                        data: JSON.stringify(detaPed),
                        contentType: "application/json",
                        async: false,
                        success: function (data) {
                            if (data == "True") {

                            } else {
                                alert("No se ha podido generar la orden pedido");
                            }
                        },
                        error: function (err) {
                            alert("No se ha podido generar la orden pedido");
                        }
                    });
                });
            } else {
                alert("No se ha podido generar la orden pedido");
            }

            //if (data == "True") {
            //    llenarTabla(OP);//Llenar la tabla
            //    $('#vacio').addClass('d-flex');
            //    $('#vacio').removeClass('d-none');
            //    tabla.closest('.productos').addClass('d-none');
            //    tabla.closest('.productos').removeClass('d-flex');
            //    tabla.closest('.productos').siblings('.productos').addClass('d-none');
            //    tabla.closest('.productos').siblings('.productos').removeClass('d-flex');
            //    tabla.find('tbody').html('');
            //    $('#proveedor').val('-1').trigger('change.select2');
            //    $('#proveedor').attr('disabled', false);
            //} else if (data == "False") {
            //    alert("No se ha podido generar la orden pedido");
            //}
        },
        error: function (ex) {
            alert('Error al generar la orden de pedido');
        }
    });

    llenarTabla(OP);//Llenar la tabla
    $('#vacio').addClass('d-flex');
    $('#vacio').removeClass('d-none');
    tabla.closest('.productos').addClass('d-none');
    tabla.closest('.productos').removeClass('d-flex');
    tabla.closest('.productos').siblings('.productos').addClass('d-none');
    tabla.closest('.productos').siblings('.productos').removeClass('d-flex');
    tabla.find('tbody').html('');
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
        //$.ajax({
        //    type: 'POST',
        //    url: '/OrdenPedido/agregar',
        //    cache: false,
        //    data: JSON.stringify(OP),
        //    contentType: "application/json",
        //    async: false,
        //    success: function (data) {
        //        if (data == "True") {
        //            llenarTabla(OP);//Llenar la tabla
        //            $('#vacio').addClass('d-flex');
        //            $('#vacio').removeClass('d-none');
        //            tabla.closest('.productos').addClass('d-none');
        //            tabla.closest('.productos').removeClass('d-flex');
        //            tabla.closest('.productos').siblings('.productos').addClass('d-none');
        //            tabla.closest('.productos').siblings('.productos').removeClass('d-flex');
        //            tabla.find('tbody').html('');
        //        } else if (data == "False") {
        //            alert("No se ha podido generar la orden pedido");
        //        }
        //    },
        //    error: function (ex) {
        //        alert('Error al generar la orden de pedido');
        //    }
        //});

        return true;
    }
}

var idOPModificar = 0;

//Muestra la Orden de Pedido, se le pasa elemento
function muestraOP(elem) {

    idOPModificar = $(elem).closest('tr').find('th')[0].textContent;
    var productos = $('#productosContainer');//body de tabla productos
    limpiarTablaProductos(productos);
    var fila = $(elem).closest('tr');
    var productosObjeto = JSON.parse(fila['0'].dataset.productos); //Objeto de productos guardado en la fila
    $.each(productosObjeto, function (i, prod) {//Recorrer el array con los produtos para pintarlos en la tabla
        var nombreProveedor = prod.nombreProveedor.replace(/_/g, " ");
        var nombreProducto = prod.nombreProducto.replace(/_/g, " ");
        var fila = '<tr class="border-bottom">'; //Crea fila
        fila += '<td class="p-2" data-id="' + prod.proveedor + '">' + nombreProveedor + '</td>';
        fila += '<td class="p-2" data-id="' + prod.id + '">' + nombreProducto + '</td>';
        fila += '<td>' + prod.cantidad + '</td>';
        fila += '<td class="precio">' + prod.precio + '</td>';
        fila += '<td><button class="btn btn-danger mr-2 my-2" onclick="eliminar(this,' + "'productos'" + ')">Eliminar</button>';
        fila += '</td></tr>';
        //Pinta en tabla productos
        productos.find('tbody').append(fila);
    });
    //Mostrar la tabla
    $('#generarOP').addClass('d-none');
    $('#editarOP').removeClass('d-none');
    mostrarTabla(productos, true);
}

function limpiarTablaProductos(tabla) {
    tabla.find('tbody').html('');
}

function fillSelectProveedor() {

    $.ajax({
        type: 'POST',
        url: '/Proveedores/Proveedores',
        cache: false,
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.length > 0) {
                var proveedores = [];
                proveedores.push({
                    id: -1,
                    text: "Seleccione"
                });
                $.each(data, function (i, val) {
                    proveedores.push({
                        id: val.IdProveedor,
                        text: val.RazonSocial
                    });
                });
                $('#proveedor').select2({ data: proveedores });
            }
        },
        error: function (ex) {
            console.log('no se han traído los proveedores');
        }
    });

}

function fillSelectProductos(idProveedor) {

    var data = {
        idProveedor: idProveedor
    };

    $.ajax({
        type: 'POST',
        url: '/Productos/ProductosPorProveedor',
        cache: false,
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (data) {
            var str = '<option value="-1" data-precio="0">Seleccione</option>';
            if (data.length > 0) {
                $.each(data, function (i, val) {
                    str += '<option value="' + val.IdProducto + '" data-precio="' + val.PrecioVenta + '">' + val.Descripcion + '</option>';
                });
                $('#productos').html(str).trigger('change');
            } else {
                $('#productos').html(str).trigger('change');
            }
        },
        error: function (ex) {
            console.log('no se han traído los productos');
        }
    });

}

function eliminarProducto(e, tabla) {
    $(e).closest('tr').remove();
    mostrarTabla(tabla, 'producto');//Muestra tabla si tiene filas
}

$(document).ready(function () {
    fillSelectProveedor();
    $('#proveedor').on('select2:select', function (e) {
        // Do something
        var idProveedor = e.target.value;
        fillSelectProductos(idProveedor);
    });
    $('#productos').on('change', function (e) {
        // Do something
        var precio = e.target.selectedOptions
        if (precio.length > 0) {
            precio = precio['0'].dataset.precio;
            $('#precio').val(precio);
        } else {
            $('#precio').val(0);
        }

    });
});
