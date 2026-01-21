# Prueba Técnica - Personas API

## Descripción
Este proyecto es una API en ASP.NET Core para manejar **Personas** y **Usuarios**, junto con un frontend simple en HTML para interactuar con la API.  
Incluye:

- CRUD de personas (crear y listar)
- Consultar personas usando un Stored Procedure
- Registro y login de usuarios

---

## Requisitos
- .NET 8 SDK
- SQL Server (LocalDB o instancia normal)

---

## Configuración de la Base de Datos

**SCRIPT SQL:**

```sql

-- Crear la base de datos
CREATE DATABASE PersonasDB;
GO

USE PersonasDB;
GO

-- Tabla Personas
CREATE TABLE Personas (
    Identificador INT IDENTITY PRIMARY KEY,
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    NumeroIdentificacion NVARCHAR(50) NOT NULL,
    TipoIdentificacion NVARCHAR(50) NOT NULL,
    Email NVARCHAR(150),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    NombreCompleto AS Nombres + ' ' + Apellidos,
    IdentificacionCompleta AS TipoIdentificacion + ' ' + NumeroIdentificacion
);
GO

-- Tabla Usuario
CREATE TABLE Usuario (
    Identificador INT IDENTITY PRIMARY KEY,
    Usuario NVARCHAR(100) NOT NULL UNIQUE,
    Pass NVARCHAR(255) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO

-- Stored Procedure para consultar personas
CREATE PROCEDURE sp_ConsultarPersonas
AS
BEGIN
    SELECT * FROM Personas;
END;
GO

```


## Actualizar la connection string en appsettings.json si tu servidor SQL es diferente.

```json

    "ConnectionStrings": {
  "Default": "Server=TU_SERVIDOR;Database=PersonasDB;Trusted_Connection=True;"
}
```

---

## Ejecutar la API

Abrir terminal en la carpeta del proyecto.

Ejecutar:

dotnet run


La API estará disponible en http://localhost:5207.

Swagger: http://localhost:5207/swagger/index.html

Frontend simple: http://localhost:5207/index.html

---

## Uso del Frontend

index.html permite:

- Registrar usuarios

- Login de usuarios

- Crear nuevas personas

- Consultar personas (normal y con SP)

Solo abre el navegador y navega a: http://localhost:5207/index.html

---

## Notas importantes

La contraseña de usuario se hashea automáticamente al registrarse, por seguridad.

No incluyo datos precargados; el entrevistador puede registrar usuarios y crear personas desde la interfaz.

El frontend es muy simple: solo HTML, CSS y JavaScript sin frameworks, para facilidad de prueba.
