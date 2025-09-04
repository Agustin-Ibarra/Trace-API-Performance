# Trace API performance
## Descriptción de la aplicación
Este sistema realiza consultas a una base de datos que contiene información de un basto catalogo de películas, en esta base de datos realiza las siguientes operaciones  
- Obtener un listado con información de las películas 
- Buscar una película por id retornando su información, 
- Crea una nueva película 
La aplicación procesa las peticiones y por cada solicitud, mide el rendimiento y recursos que require para procesarlas, obteniendo información de consumo de memoria RAM, tiempo de respuesta y porcentaje de CPU utilizado, de esta forma se puede obtener una aproximación del consumo de las peticiones.

## Tabla de contenido
1. [Características](#características)
2. [BackEnd](#backend)
3. [Base de datos](#base-de-datos)
4. [Inicio](#inicio)
<!-- 4. [Documentacion](#documentacion) -->
<!-- 5. [Pruebas unitarias](#pruebas-unitarias) -->
<!-- 6. [Monitoreo de rutas](#monitoreo-de-rutas) -->
<!-- 8. [Contenedores Docker](#contenedores-docker) -->

## Características
- Implementación Garbage collector para forzar la recoleccion de basura y obtener datos de memoria mas precisos
- Implementacion Process y su metodo GetCurrentProcess para obtener diagnostico del CPU
- Creacion de registro sorbe el rendimiento y recursos utilizados mediante logs

Ejemplo de salida de logs
```javascript
info: TraceApiPerformance.Api.Controllers.MoviesController[0]
      Path: /api/movies Method: GET, Status: 200, CPU_percent: 10.77%, RAM: 0.89MB
info: TraceApiPerformance.Api.Controllers.MoviesController[0]
      Path: /api/movies/detail/1 Method: GET, Status: 200, CPU_percent: 11.10%, RAM: 1.32MB
info: TraceApiPerformance.Api.Controllers.MoviesController[0]
      Path: /api/movies Method: POST, Status: 201, CPU_percent: 6.24%, RAM: 0.23MB
```

## BackEnd
- Tecnologías utilizadas: C# .NET Core ASP.NET dotnet 
```
App/
│
├── Controllers/   # Procesan las peticiones y contienen la lógica de las respuestas
├── Data/          # Configuración del constructor de AppDbContext y definición de entidades
├── Dtos/          # Capa de datos para la transacion de informacion
├── Helppers/      # Clases Auxiliares
├── Models/        # Capa de modelos que representan las entidades de la base de datos
├── Repository/    # Interaccion con la base de datos mediante Entity Framework
└── Program.cs     # Punto de entrada de la aplicación (configuración del servidor)
```

## Base de datos
La persistencia de información se realiza a través de una base de datos relacional, el BackEnd utiliza Entity Framework para la interacción con la base de datos, a través de un ORM
- Base de datos relacional
- Gestor de base de datos: MySql

## Inicio
- Inicio de la aplicación: una vez clonado el repositorio se debe escribir el siguiente comando en la terminal
```bash
dotnet run
```
