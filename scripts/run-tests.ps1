# Script para ejecutar todas las pruebas
# Ejecutar desde la raíz del proyecto

Write-Host "Ejecutando pruebas unitarias..." -ForegroundColor Green

# Ejecutar pruebas unitarias
dotnet test tests/Readifly.UnitTests --verbosity normal

Write-Host "Ejecutando pruebas de integración..." -ForegroundColor Green

# Ejecutar pruebas de integración
dotnet test tests/Readifly.IntegrationTests --verbosity normal

Write-Host "Todas las pruebas completadas!" -ForegroundColor Green
