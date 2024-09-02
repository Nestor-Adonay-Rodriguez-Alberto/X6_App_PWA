// service-worker.js

// Evento de instalación del Service Worker
self.addEventListener('install', function (event) {
    event.waitUntil(
        Promise.resolve()
    );
});


// Evento de activación del Service Worker
self.addEventListener('activate', function (event) {
    // Realizar tareas de activación aquí
});

// Evento fetch (intercepta las solicitudes de red)
self.addEventListener('fetch', function (event) {
    event.respondWith(
        fetch(event.request)
            .catch(function (error) {
                console.log('Error en la solicitud:', error);
                // Aquí puedes realizar acciones adicionales en caso de error, como mostrar un mensaje al usuario o cargar una página de error personalizada.
            })
    );
});

