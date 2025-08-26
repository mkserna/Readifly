# Script para aplicar migraciones a la base de datos MySQL
# Ejecutar desde la raíz del proyecto

Write-Host "Aplicando migraciones a la base de datos MySQL..." -ForegroundColor Green

# Navegar al directorio de Infrastructure
Set-Location "src/Readifly.Infrastructure"

# Aplicar la migración a la base de datos
dotnet ef database update --startup-project ../Readifly.API

Write-Host "Base de datos actualizada exitosamente!" -ForegroundColor Green

# Volver al directorio raíz
Set-Location "../.."
