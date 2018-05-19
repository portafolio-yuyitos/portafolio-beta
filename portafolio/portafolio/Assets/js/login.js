
function login() {
    
    var nombre = $('#nombre').val();
    var pass = $('#pass').val();

    var data = {
        "nombre": nombre,
        "pass": pass
    };



   $.ajax({
     type: 'POST',
     url: '/Login/validaUsuario',
     cache: false,
     data: JSON.stringify(data),
     contentType: "application/json",
     async: false,
     success: function (data) {
         if (data == "True") {
             
             var redirect = window.location.origin;
             $(location).attr('href', redirect);
         } else if (data == "False"){
             alert("No Logeado");
         }
     },
     error: function (ex) {
       alert('ERROOOOOOR');
     }
   });

}