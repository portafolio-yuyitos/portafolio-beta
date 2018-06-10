function buscarOP(e) {
    debugger;
    var listadoProductos = $('#listadoProductos');
    listadoProductos.removeClass('d-none');
}

function aceptarOP(e) {
    debugger;

    alert("Se han aceptado los productos de la orden de pedido");
    $('#listadoProductos').addClass('d-none');

    //var orden = {//Objeto de orden de pedido
    //    idOrden:0
    //};

    //$.ajax({
    //    type: 'POST',
    //    url: '/RecepcionProducto/aceptar',
    //    cache: false,
    //    data: JSON.stringify(orden),
    //    contentType: "application/json",
    //    async: false,
    //    success: function (data) {
    //        if (data !== "-1") {
    //            alert("Se han aceptado los productos de la orden de pedido");
    //        } else {
    //            alert("No se ha logrado aceptar los productos de la orden de pedido");
    //        }
    //    },
    //    error: function (ex) {
    //        alert("Error al aceptar los productos de la orden de pedido");
    //    }
    //});
}