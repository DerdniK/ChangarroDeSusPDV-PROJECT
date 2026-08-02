## Contratos

##### 1. Registro de Usuario(Menu de administrador)

Método HTTP: POST
Ruta: /auth/register

Request Body (Lo que Web/Mobile envía):

```JSON
{
  "email": "cajero1@changarro.com",
  "password": "Password123!"
}
```

Respuesta Exitosa (201 Created):

```JSON
{
  "message": "Usuario registrado exitosamente",
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

Respuesta con Error (400 Bad Request):

```JSON
{
  "message": "El correo ya está registrado"
}
```

---
##### 2. Inicio de Sesión (Pagina principal)

Método HTTP: POST
Ruta: /auth/login

Request Body (Lo que Web/Mobile envía):

```JSON
{
  "email": "cajero1@changarro.com",
  "password": "Password123!"
}
```
Respuesta Exitosa (200 OK):

```JSON
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "role": "Cajero",
  "email": "cajero1@changarro.com"
}
```
Respuesta con Error (401 Unauthorized):

```JSON
{
  "message": "Token invalido"
}
```

Respuesta no existe (404 Not found):

```JSON
{
    "message": "Usuario no encontrado"
}
```