# Script para agregar using statements faltantes
# Ejecutar desde la raíz del proyecto

Write-Host "Agregando using statements faltantes..." -ForegroundColor Green

# Lista de archivos que necesitan Microsoft.EntityFrameworkCore
$files = @(
    "src/Readifly.Application/Features/Materiales/Commands/CrearRevista/CrearRevistaCommandHandler.cs",
    "src/Readifly.Application/Features/Materiales/Queries/ObtenerMateriales/ObtenerMaterialesQueryHandler.cs",
    "src/Readifly.Application/Features/Materiales/Queries/ObtenerMaterialPorIsbn/ObtenerMaterialPorIsbnQueryHandler.cs",
    "src/Readifly.Application/Features/Prestamos/Commands/RealizarPrestamo/RealizarPrestamoCommandHandler.cs",
    "src/Readifly.Application/Features/Prestamos/Commands/RegistrarDevolucion/RegistrarDevolucionCommandHandler.cs",
    "src/Readifly.Application/Features/Prestamos/Queries/ObtenerPrestamos/ObtenerPrestamosQueryHandler.cs"
)

foreach ($file in $files) {
    if (Test-Path $file) {
        $content = Get-Content $file -Raw
        if ($content -notmatch "using Microsoft.EntityFrameworkCore;") {
            $content = $content -replace "(using AutoMapper;)", "`$1`nusing Microsoft.EntityFrameworkCore;"
            Set-Content $file $content
            Write-Host "Actualizado: $file" -ForegroundColor Yellow
        }
    }
}

Write-Host "Using statements agregados exitosamente!" -ForegroundColor Green
