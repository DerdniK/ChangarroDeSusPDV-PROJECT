//const API_URL = 'https://lvk5buixqe.execute-api.us-east-1.amazonaws.com/api/health';

// endpoint de login y registrer
const API_USER = 'https://lvk5buixqe.execute-api.us-east-1.amazonaws.com/api/auth';

const formulario = document.getElementById('login');
const mensaje = document.getElementById('mensaje');

formulario.addEventListener('submit', async (event) => {

    event.preventDefault();

    const usuario = document.getElementById('username').value;
    const password = document.getElementById('password').value;

        try {

        const respuesta = await fetch(API_USER, {
            method: 'POST',

            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify({
                Username: usuario,
                Password: password
            })
        });

        const data = await respuesta.json();

        console.log('HTTP Status:', respuesta.status);
        console.log('Respuesta del backend:', data);

        if (!respuesta.ok) {

            console.error('Error completo:', data);

            const errorBackend =
                data.error ||
                data.Error ||
                data.message ||
                data.Message ||
                `Error HTTP ${respuesta.status}`;

            throw new Error(errorBackend);
        }

        console.log('Login exitoso:', data);

        // Guardar JWT
        const token = data.authData?.token;

        if (!token) {
            throw new Error('El backend no devolvió un JWT');
        }

        localStorage.setItem('authToken', token);

        // Redireccionar
        window.location.href = 'catalogo.html';

    } catch (error) {

        console.error('Error:', error);

        mensaje.textContent = error.message;
    }

    // try {
        
    //     const respuesta = await fetch(API_USER, {
    //         method: 'POST',
    //         headers: {
    //             'Content-Type': 'application/json'
    //         },
    //         body: JSON.stringify({
    //             Username: usuario,
    //             Password: password
    //         })
    //     });

    //     const data = await respuesta.json();


    //     //chequeo de la respuesta del backend

    //     console.log('HTTP Status:', respuesta.status);
    //     console.log('Respuesta del backend:', data);


    //     if (!respuesta.ok) {
    //         throw new Error(data.message || data.Message || 'Error al iniciar sesión');
    //     }
        
    //     // Si la respuesta es exitosa
    //     console.log('Login exitoso');

    //     // Primero revisemos qué devuelve realmente el backend
    //     console.log('Token:', data.authData?.token);


    //     if (respuesta.ok) {
    //         // Guardar el token en el almacenamiento local
    //         localStorage.setItem('authtoken', data.authData.token);
    //         // Redirigir al usuario a la página de catálogo
    //         window.location.href = 'catalogo.html';
    //     }

    //     // // Simulación temporal
    //     // if (usuario === 'admin' && password === '1234') {
    //     //     window.location.href = 'catalogo.html';
    //     // } else {
    //     //     mensaje.textContent = 'Usuario o contraseña incorrectos';
    //     // }

    // } catch (error) {

    //     console.error('Error:', error);

    //     mensaje.textContent = error.message;
    // }


});