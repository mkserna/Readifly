# Dockerfile para Readifly API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Readifly.API/Readifly.API.csproj", "src/Readifly.API/"]
COPY ["src/Readifly.Application/Readifly.Application.csproj", "src/Readifly.Application/"]
COPY ["src/Readifly.Domain/Readifly.Domain.csproj", "src/Readifly.Domain/"]
COPY ["src/Readifly.Infrastructure/Readifly.Infrastructure.csproj", "src/Readifly.Infrastructure/"]
RUN dotnet restore "src/Readifly.API/Readifly.API.csproj"
COPY . .
WORKDIR "/src/src/Readifly.API"
RUN dotnet build "Readifly.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Readifly.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Readifly.API.dll"]
