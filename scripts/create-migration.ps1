# Script para crear migraciones de Entity Framework para MySQL
# Ejecutar desde la raíz del proyecto

Write-Host "Creando migración inicial para MySQL..." -ForegroundColor Green

# Navegar al directorio de Infrastructure
Set-Location "src/Readifly.Infrastructure"

# Crear la migración
dotnet ef migrations add InitialCreate --startup-project ../Readifly.API

Write-Host "Migración creada exitosamente!" -ForegroundColor Green

# Aplicar la migración a la base de datos
Write-Host "Aplicando migración a la base de datos..." -ForegroundColor Yellow
dotnet ef database update --startup-project ../Readifly.API

Write-Host "Base de datos actualizada exitosamente!" -ForegroundColor Green

# Volver al directorio raíz
Set-Location "../.."
