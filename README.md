# 📚 Readifly - Sistema de Gestión de Préstamos Bibliográficos

[![CI/CD](https://github.com/mkserna/Readifly/workflows/CI/CD%20Pipeline/badge.svg)](https://github.com/mkserna/Readifly/actions)
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=readifly-biblioteca&metric=alert_status)](https://sonarcloud.io/dashboard?id=readifly-biblioteca)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=readifly-biblioteca&metric=coverage)](https://sonarcloud.io/dashboard?id=readifly-biblioteca)

## 🎯 Descripción

Sistema completo para la gestión de préstamos de material bibliográfico (Libros y Revistas) desarrollado con **Clean Architecture**, **CQRS**, **Entity Framework Core** y **CI/CD** completo.

## ✨ Características Implementadas

* ✅ **Arquitectura Clean Architecture** - Separación clara de responsabilidades
* ✅ **Patrón CQRS con MediatR** - Comandos y consultas separados
* ✅ **Entity Framework Core con MySQL** - ORM con base de datos en la nube
* ✅ **AutoFac** - Inyección de dependencias avanzada
* ✅ **FluentValidation** - Validaciones robustas
* ✅ **AutoMapper** - Mapeo automático de objetos
* ✅ **API REST con Swagger** - Documentación automática
* ✅ **Pruebas unitarias con MSTest** - 19 pruebas funcionando
* ✅ **CI/CD con GitHub Actions** - Pipeline automatizado
* ✅ **CI/CD con Azure DevOps** - Pipeline empresarial
* ✅ **SonarQube** - Análisis de calidad de código
* ✅ **Docker** - Containerización lista

## 📋 Reglas de Negocio Implementadas

* **Revistas**: No se pueden prestar en fin de semana, solo 2 días
* **ISBN Palíndromo**: Material con ISBN palíndromo no se puede prestar
* **Libros**: 15 días hábiles si suma de dígitos ISBN > 30, sino 10 días
* **Domingos**: Si la devolución cae en domingo, se mueve al siguiente día hábil
* **Material Prestado**: No se puede prestar material ya prestado

## 🗄️ Base de Datos

### Configuración MySQL (Clever Cloud)
```
Host: bqljebmd1qbgpncyr3kd-mysql.services.clever-cloud.com
Database: bqljebmd1qbgpncyr3kd
Port: 3306
Username: uymof1nkbx5nzt45
Password: OgzR3sLQQwIhMBsPGwiz
SSL: Required
```

### Estado de la Base de Datos
- ✅ **Migraciones aplicadas** - Estructura actualizada
- ✅ **Conexión establecida** - Funcionando correctamente
- ✅ **Datos de prueba** - Materiales y préstamos creados

## 🚀 Instalación y Configuración

### Prerrequisitos
- .NET 8.0 SDK
- MySQL (o acceso a la base de datos configurada)
- Visual Studio 2022 o VS Code

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/mkserna/Readifly.git
   cd Readifly
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
   - Swagger UI: http://localhost:5141/swagger
   - API Base: http://localhost:5141/api

## 🏗️ Estructura del Proyecto

```
src/
├── Readifly.API/                 # Capa de presentación (Controllers, Program.cs)
├── Readifly.Application/         # Capa de aplicación (CQRS, DTOs, Validators)
├── Readifly.Domain/             # Capa de dominio (Entidades, Interfaces, Servicios)
└── Readifly.Infrastructure/     # Capa de infraestructura (EF Core, Repositorios)

tests/
├── Readifly.UnitTests/          # Pruebas unitarias (19 pruebas)
└── Readifly.IntegrationTests/   # Pruebas de integración

CI/CD/
├── .github/workflows/ci-cd.yml  # GitHub Actions
├── azure-pipelines.yml          # Azure DevOps
├── sonar-project.properties     # SonarQube
├── Dockerfile                   # Docker
└── docker-compose.yml           # Docker Compose
```

## 🔗 Endpoints de la API

### Materiales
- `GET /api/materiales` - Obtener todos los materiales
- `GET /api/materiales/{isbn}` - Obtener material por ISBN
- `POST /api/materiales/libros` - Crear nuevo libro
- `POST /api/materiales/revistas` - Crear nueva revista

### Préstamos
- `GET /api/prestamos` - Obtener préstamos
- `POST /api/prestamos` - Realizar préstamo
- `POST /api/prestamos/{id}/devolucion` - Registrar devolución

## 🛠️ Scripts Disponibles

- `scripts/create-migration.ps1` - Crear y aplicar migración inicial
- `scripts/update-database.ps1` - Aplicar migraciones existentes
- `scripts/run-tests.ps1` - Ejecutar todas las pruebas
- `scripts/deploy.ps1` - Script de despliegue

## 🧪 Pruebas

### Pruebas Unitarias
```bash
dotnet test tests/Readifly.UnitTests --configuration Release
```
- **19 pruebas** ✅ Todas correctas
- **Cobertura de código** generada
- **Tiempo de ejecución**: ~158ms

### Pruebas de Integración
```bash
dotnet test tests/Readifly.IntegrationTests --configuration Release
```

## 🔧 Tecnologías Utilizadas

- **Backend**: .NET 8.0, ASP.NET Core
- **Base de Datos**: MySQL (Clever Cloud)
- **ORM**: Entity Framework Core
- **Patrones**: CQRS, Repository, Clean Architecture
- **Inyección de Dependencias**: AutoFac
- **Validación**: FluentValidation
- **Mapeo**: AutoMapper
- **Testing**: MSTest, NSubstitute, FluentAssertions
- **CI/CD**: GitHub Actions, Azure DevOps
- **Calidad**: SonarQube
- **Containerización**: Docker

## 📊 Estado del Proyecto

### ✅ Completado
1. ✅ Implementar capa de aplicación (CQRS)
2. ✅ Implementar capa de infraestructura (EF Core)
3. ✅ Configurar AutoFac
4. ✅ Crear controllers de API
5. ✅ Configurar MySQL
6. ✅ Crear pruebas unitarias (19/19)
7. ✅ Crear pruebas de integración
8. ✅ Configurar CI/CD
9. ✅ Integrar SonarQube
10. ✅ Configurar Docker

### 🎯 Funcionalidades Verificadas
- ✅ **Crear libros** - Endpoint funcionando
- ✅ **Crear revistas** - Endpoint funcionando
- ✅ **Realizar préstamos** - Con validaciones de negocio
- ✅ **Validaciones de negocio** - Todas implementadas
- ✅ **Cálculo de fechas de devolución** - Automático

## 🚀 CI/CD

### GitHub Actions
- **Pipeline**: `.github/workflows/ci-cd.yml`
- **Triggers**: Push a main/develop, Pull Requests
- **Funciones**: Build, Test, SonarQube, Deploy

### Azure DevOps
- **Pipeline**: `azure-pipelines.yml`
- **Funciones**: Build, Test, SonarQube, Deploy a Azure

### SonarQube
- **Configuración**: `sonar-project.properties`
- **Análisis**: Calidad de código, cobertura, duplicados

## 🐳 Docker

### Construir imagen
```bash
docker build -t readifly-api .
```

### Ejecutar con Docker Compose
```bash
docker-compose up --build
```

## 📈 Métricas del Proyecto

- **Líneas de código**: ~2,500+ líneas
- **Pruebas unitarias**: 19 pruebas
- **Cobertura de código**: Generada automáticamente
- **Tiempo de compilación**: ~3 segundos
- **Tiempo de pruebas**: ~158ms

## 🤝 Contribución

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## 📞 Contacto

- **Repositorio**: [https://github.com/mkserna/Readifly](https://github.com/mkserna/Readifly)
- **Desarrollador**: Mariana Serna
- **Tecnologías**: .NET 8.0, Clean Architecture, CQRS, MySQL

---

## 📋 Entregables del Proyecto

### 🎯 Código Fuente
- ✅ **Repositorio GitHub**: [https://github.com/mkserna/Readifly](https://github.com/mkserna/Readifly)
- ✅ **Arquitectura Clean Architecture** implementada
- ✅ **Patrón CQRS** con MediatR
- ✅ **Entity Framework Core** con MySQL
- ✅ **API REST** con Swagger

### 🧪 Pruebas
- ✅ **19 pruebas unitarias** funcionando
- ✅ **Pruebas de integración** implementadas
- ✅ **Cobertura de código** generada
- ✅ **MSTest** como framework de pruebas

### 🔧 CI/CD
- ✅ **GitHub Actions** configurado
- ✅ **Azure DevOps** configurado
- ✅ **SonarQube** integrado
- ✅ **Docker** configurado

### 📊 Documentación
- ✅ **README.md** completo y actualizado
- ✅ **Swagger UI** para documentación de API
- ✅ **Comentarios en código** en español
- ✅ **Scripts de automatización**

### 🗄️ Base de Datos
- ✅ **MySQL** en Clever Cloud
- ✅ **Migraciones** aplicadas
- ✅ **Datos de prueba** creados
- ✅ **Conexión** funcionando

---

**🎉 Proyecto completado exitosamente con todas las funcionalidades solicitadas.**