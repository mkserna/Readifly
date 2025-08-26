# Readifly - Sistema de Gestión de Préstamos Bibliográficos

## Descripción
Sistema para la gestión de préstamos de material bibliográfico (Libros y Revistas) desarrollado con Clean Architecture, CQRS, y Entity Framework Core.

## Características
- ✅ Arquitectura Clean Architecture
- ✅ Patrón CQRS con MediatR
- ✅ Entity Framework Core con MySQL
- ✅ AutoFac para inyección de dependencias
- ✅ FluentValidation para validaciones
- ✅ AutoMapper para mapeo de objetos
- ✅ API REST con Swagger
- ✅ Pruebas unitarias con MSTest

## Reglas de Negocio Implementadas
- Las revistas no pueden ser prestadas para el fin de semana y solo por dos días
- El material bibliográfico con ISBN palíndromo no se puede prestar
- Los libros se prestan por 15 días hábiles si la suma de dígitos del ISBN > 30, sino 10 días
- Si la fecha de entrega cae en domingo, se entrega el siguiente día hábil
- No se puede prestar material que ya está prestado

## Configuración de Base de Datos

### Variables de Entorno
```
DB_HOST=bqljebmd1qbgpncyr3kd-mysql.services.clever-cloud.com
DB_DATABASE=bqljebmd1qbgpncyr3kd
DB_PORT=3306
DB_USERNAME=uymof1nkbx5nzt45
DB_PASSWORD=OgzR3sLQQwIhMBsPGwiz
```

### Conexión Configurada
La aplicación está configurada para conectarse a MySQL en Clever Cloud con las credenciales proporcionadas.

## Instalación y Configuración

### Prerrequisitos
- .NET 8.0 SDK
- MySQL (o acceso a la base de datos configurada)
- Visual Studio 2022 o VS Code

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone <repository-url>
   cd Readifly-1
   ```

2. **Restaurar paquetes NuGet**
   ```bash
   dotnet restore
   ```

3. **Crear y aplicar migraciones**
   ```bash
   # Ejecutar desde PowerShell
   .\scripts\create-migration.ps1
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run --project src/Readifly.API
   ```

5. **Acceder a la API**
   - Swagger UI: https://localhost:7000/swagger
   - API Base: https://localhost:7000/api

## Estructura del Proyecto

```
src/
├── Readifly.API/                 # Capa de presentación (Controllers, Program.cs)
├── Readifly.Application/         # Capa de aplicación (CQRS, DTOs, Validators)
├── Readifly.Domain/             # Capa de dominio (Entidades, Interfaces, Servicios)
├── Readifly.Infrastructure/     # Capa de infraestructura (EF Core, Repositorios)
└── Readifly.Common/             # Utilidades comunes

tests/
├── Readifly.UnitTests/          # Pruebas unitarias
└── Readifly.IntegrationTests/   # Pruebas de integración
```

## Endpoints de la API

### Materiales
- `GET /api/materiales` - Obtener todos los materiales
- `GET /api/materiales/{isbn}` - Obtener material por ISBN
- `POST /api/materiales/libros` - Crear nuevo libro
- `POST /api/materiales/revistas` - Crear nueva revista

### Préstamos
- `GET /api/prestamos` - Obtener préstamos
- `POST /api/prestamos` - Realizar préstamo
- `POST /api/prestamos/{id}/devolucion` - Registrar devolución

## Scripts Disponibles

- `scripts/create-migration.ps1` - Crear y aplicar migración inicial
- `scripts/update-database.ps1` - Aplicar migraciones existentes

## Tecnologías Utilizadas

- **Backend**: .NET 8.0, ASP.NET Core
- **Base de Datos**: MySQL (Clever Cloud)
- **ORM**: Entity Framework Core
- **Patrones**: CQRS, Repository, Clean Architecture
- **Inyección de Dependencias**: AutoFac
- **Validación**: FluentValidation
- **Mapeo**: AutoMapper
- **Testing**: MSTest, NSubstitute

## Próximos Pasos

1. ✅ Implementar capa de aplicación (CQRS)
2. ✅ Implementar capa de infraestructura (EF Core)
3. ✅ Configurar AutoFac
4. ✅ Crear controllers de API
5. ✅ Configurar MySQL
6. 🔄 Crear pruebas unitarias
7. 🔄 Crear pruebas de integración
8. 🔄 Configurar CI/CD
9. 🔄 Integrar SonarQube

## Contribución

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request
