var ordenCompra = null;

function buscarOrden(numePedido) {
    var data = {
        numePedido: numePedido
    };
    $.ajax({
        type: 'POST',
        url: '/RecepcionProducto/ObPedidoPorNPedido',
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data == 5) {
                toast("Orden de pedido no existe.", "error");
            } else {

            
            console.log(data);
            var proveedor = retornaProveedor(data.Encabezado.IdProveedor);
            sessionStorage.setItem('proveedor', JSON.stringify(proveedor));
            ordenCompra = data;
            sessionStorage.setItem('orden', JSON.stringify(ordenCompra));
            var encabezado =
                `<div id="titulo" class="col-12" >
                            <h2 class="text-center">Orden de Pedido</h2>
                            <h4 class="text-center">Almacen Yutitos</h4>
                            <h4 class="text-center" id="numeroPedido">N° ${data.Encabezado.NumeroPedido}</h4>
                        </div>
                        <div class="col-4 bg-secondary text-light my-4 py-3 rounded-left d-flex flex-column justify-content-center pl-3">
                            <p id="idProveedor">Id Proveedor: ${data.Encabezado.IdProveedor}</p>
                            <p id="idProveedor">Rut Proveedor: ${proveedor.RutProveedor}</p>
                            <p id="idProveedor">Razon Social: ${proveedor.RazonSocial}</p>
                        </div>
                        <div class="col-4 bg-secondary text-light my-4 py-3 d-flex flex-column justify-content-center pr-3">
                            <p id="idProveedor">Giro: ${proveedor.Giro}</p>
                            <p id="idProveedor">Fono: ${proveedor.Fono}</p>
                            <p id="idProveedor">Email: ${proveedor.Email}</p>
                        </div>
                        <div class="col-4 bg-secondary text-light my-4 py-3 d-flex flex-column justify-content-center pr-3">
                            <p id="usuario">Responsable: ${retornaUsuario(data.Encabezado.IdUsuario)}</p>
                            <p id="isEnviado">Estado de Envío: ${data.Encabezado.IsEnviado == 0 ? "No enviada" : "Enviada"}</p>
                            <p id="isEnviado">Anulada: ${data.Encabezado.IsAnulado == 1 ? "Si" : "No"}</p>
                            <p id="isEnviado">Aceptada: ${data.Encabezado.IsAnulado == 2 ? "Si" : "No"}</p>
                            <p id="isEnviado">Eliminada: ${data.Encabezado.Estado == 1 ? "Si" : "No"}</p>
                        </div>
                    `;

            var detalle = `<div class="col-2">N°</div>
                                    <div class="col-2">ID PROD</div>
                                    <div class="col-4">PRODUCTO</div>
                                    <div class="col-2">Cantidad</div>
                                    <div class="col-2">Precio</div>`;
            var total = 0;
            console.log(data);
            for (i in data.Detalles) {

                detalle += `<div class="col-2">${data.Detalles[i].NumeroDetalle}</div>
                                        <div class="col-2">${data.Detalles[i].IdProducto}</div>
                                        <div class="col-4">${data.Detalles[i].NombreProducto}</div>
                                        <div class="col-2">${data.Detalles[i].CantidadProducto}</div>
                                        <div class="col-2">${data.Detalles[i].PrecioProducto}</div>`;

                total += data.Detalles[i].PrecioProducto;
            };
            detalle += `<div class="col-12 mt-4"><h3 class="text-right">TOTAL: ${total}</h3></div>`;

            var botonAnular = `<div id="btnAceptarOP" class="col-md-12 justify-content-end d-flex align-items-center mt-4" >
                <button style="margin-right=10px" class="btn btn-primary d-block" onclick="anulaOP(this)">Anular Orden de pedido</button>&nbsp;`
            var boton = `
                <button  class="btn btn-primary d-block" onclick="aceptarOP(this)">Aceptar Orden de pedido</button></div >`
            if (data.Encabezado.IsAnulado == 1) {
                botonAnular = `<div id="btnAceptarOP" class="col-md-12 justify-content-end d-flex align-items-center mt-4" >
                            <div class="alert alert-success">La orden ha sido anulada.</div></div>
                      `;
                boton = '';
            }

            if (data.Encabezado.IsAnulado == 2) {
                botonAnular = '';
                boton = `<div id="btnAceptarOP" class="col-md-12 justify-content-end d-flex align-items-center mt-4" >
                            <div class="alert alert-success">La orden ha sido aceptada.</div></div>
                      `
            }

            $("#llenar").html(encabezado + detalle + botonAnular + boton).removeClass('d-none');


            }
        },
        error: function (err) {
            toast("No se ha podido enviar.", "error");
        }
    });
};

function retornaUsuario(idUsuario) {
    var data = {
        idUsuario: idUsuario
    }
    var usuario = "";
    $.ajax({
        type: 'POST',
        url: '/RecepcionProducto/BuscarUsuario',
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json",
        async: false,
        success: function (data) {
            usuario = data;
        },
        error: function (err) {
            toast("No se ha podido enviar.", "error");
        }
    });
    return usuario;
}

function retornaProveedor(idProveedor) {
    var data = {
        idProveedor: idProveedor
    }
    var proveedor = "";
    $.ajax({
        type: 'POST',
        url: '/RecepcionProducto/BuscarProveedor',
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json",
        async: false,
        success: function (data) {
            proveedor = data;
        },
        error: function (err) {
            toast("No se ha podido enviar.", "error");
        }
    });
    return proveedor;
}

function aceptarOP(e) {
    debugger;

    $('#btnAceptarOP').html(`<div class="alert alert-success">La orden ya ha sido aceptada.</div>`);

    toast("Se han aceptado los productos de la orden de pedido", "success");

    var aceptado = {//Objeto de orden de pedido
        orden: JSON.parse(sessionStorage.orden)
    };

    $.ajax({
        type: 'POST',
        url: '/RecepcionProducto/AceptarPedido',
        cache: false,
        data: JSON.stringify(aceptado.orden),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data !== "-1") {
                toast("Se han aceptado los productos de la orden de pedido","success");
            } else {
                toast("No se ha logrado aceptar los productos de la orden de pedido","error");
            }
        },
        error: function (ex) {
            toast("Error al aceptar los productos de la orden de pedido","error");
        }
    });

    
    ordenCompra = null;
}

function anulaOP(e) {
    debugger;

    $('#btnAceptarOP').display = 'none';

    toast("Se han aceptado los productos de la orden de pedido", "success");

    var anulado = {//Objeto de orden de pedido
        orden: JSON.parse(sessionStorage.orden)
    };

    $.ajax({
        type: 'POST',
        url: '/RecepcionProducto/AnularPedido',
        cache: false,
        data: JSON.stringify(anulado.orden),
        contentType: "application/json",
        async: false,
        success: function (data) {
            if (data !== "-1") {
                toast("Se ha rechazado la orden de pedido", "success");
            } else {
                toast("No se ha logrado aceptar los productos de la orden de pedido", "error");
            }
        },
        error: function (ex) {
            toast("Error al aceptar los productos de la orden de pedido", "error");
        }
    });


    ordenCompra = null;
}
