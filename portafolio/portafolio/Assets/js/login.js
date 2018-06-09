
function login() {
    
    var nombre = $('#nombre').val();
    var pass = $('#pass').val();

    var data = {
        "nombre": nombre,
        "pass": pass
    };

    spinner(true);

   $.ajax({
     type: 'POST',
     url: '/Login/validaUsuario',
     cache: false,
     data: JSON.stringify(data),
     contentType: "application/json",
     success: function (data) {
         if (data == "True") {
             
             var redirect = window.location.origin;
             $(location).attr('href', redirect);
         } else if (data == "False"){
             alert("El usuario o contraseña son incorrectos");
         }
     },
     error: function (ex) {
       alert('Error al logear');
        },
        complete: function () {
            spinner(false);
        }
   });

}

$('document').ready(function () {
    document.getElementById('nombre').addEventListener("keyup", function (event) {
        // Cancel the default action, if needed
        event.preventDefault();
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13) {
            // Trigger the button element with a click
            login();
        }
    });
    document.getElementById('pass').addEventListener("keyup", function (event) {
        // Cancel the default action, if needed
        event.preventDefault();
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13) {
            // Trigger the button element with a click
            login();
        }
    });
});