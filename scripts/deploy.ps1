# Script de despliegue para Readifly
param(
    [Parameter(Mandatory=$true)]
    [string]$Environment,
    
    [Parameter(Mandatory=$true)]
    [string]$ConnectionString
)

Write-Host "=== DESPLEGANDO READIFLY A $Environment ===" -ForegroundColor Green

# Variables
$projectPath = "src/Readifly.API"
$outputPath = "publish"
$zipFile = "readifly-$Environment.zip"

try {
    # Limpiar directorio de publicación
    if (Test-Path $outputPath) {
        Remove-Item -Path $outputPath -Recurse -Force
    }
    
    # Publicar aplicación
    Write-Host "Publicando aplicación..." -ForegroundColor Yellow
    dotnet publish $projectPath -c Release -o $outputPath --self-contained false
    
    if ($LASTEXITCODE -ne 0) {
        throw "Error al publicar la aplicación"
    }
    
    # Crear archivo ZIP
    Write-Host "Creando archivo ZIP..." -ForegroundColor Yellow
    Compress-Archive -Path "$outputPath\*" -DestinationPath $zipFile -Force
    
    # Configurar variables de entorno
    Write-Host "Configurando variables de entorno..." -ForegroundColor Yellow
    $envFile = "$outputPath\appsettings.$Environment.json"
    if (Test-Path $envFile) {
        $content = Get-Content $envFile -Raw
        $content = $content -replace "#\{ConnectionStrings\.DefaultConnection\}#", $ConnectionString
        Set-Content -Path $envFile -Value $content
    }
    
    Write-Host "✅ Despliegue completado exitosamente!" -ForegroundColor Green
    Write-Host "Archivo creado: $zipFile" -ForegroundColor Cyan
    
} catch {
    Write-Host "❌ Error durante el despliegue: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
