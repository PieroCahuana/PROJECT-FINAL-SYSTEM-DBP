/* Funcion para cuando clickee en el logo y salir, vaya a inicio*/ 
var logoLink = document.getElementById('logoLink');
var logoutLink = document.getElementById('logoutLink');

logoLink.addEventListener('click', function (event) {
    event.preventDefault();
    window.location.href = '/Proyecto/Inicio';
});

logoutLink.addEventListener('click', function (event) {
    event.preventDefault();
    window.location.href = '/Proyecto/Inicio';
});


// Función para cambiar la clase de una sección a "mostrar"
function mostrarSeccion(seccion) {
    // Oculta todas las páginas
    var paginas = document.querySelectorAll('.pagina');
    paginas.forEach(function (pagina) {
        pagina.classList.remove('mostrar');
    });

    // Muestra la sección correspondiente y cambia su clase a "mostrar"
    seccion.classList.add('mostrar');
}

// Selecciona todos los enlaces en el menú de navegación
var enlaces = document.querySelectorAll('nav a');

// Itera a través de los enlaces y agrega un manejador de eventos para hacer clic
enlaces.forEach(function (enlace) {
    enlace.addEventListener('click', function (event) {
        // Evita el comportamiento predeterminado del enlace
        event.preventDefault();

        // Obtiene el destino del enlace (el atributo "href")
        var destino = enlace.getAttribute('href');

        // Obtiene la sección correspondiente al destino
        var seccion = document.querySelector(destino);

        // Cambia la clase de la sección a "mostrar"
        mostrarSeccion(seccion);
    });
});

// Obtener el hash de la URL actual
var hash = window.location.hash;

// Si hay un hash en la URL
if (hash) {
    // Obtener la sección correspondiente al hash
    var seccionHash = document.querySelector(hash);

    // Cambiar la clase de la sección a "mostrar"
    mostrarSeccion(seccionHash);
}
// Selecciona todos los enlaces en el menú de navegación
var enlaces = document.querySelectorAll('nav a');

// Itera a través de los enlaces y agrega un manejador de eventos para hacer clic
enlaces.forEach(function (enlace) {
    enlace.addEventListener('click', function () {
        // Oculta todas las páginas
        var paginas = document.querySelectorAll('.pagina');
        paginas.forEach(function (pagina) {
            pagina.classList.remove('mostrar');
        });
        // Muestra la página correspondiente al enlace que se hizo clic
        var destino = enlace.getAttribute('href');
        document.querySelector(destino).classList.add('mostrar');
    });
});
