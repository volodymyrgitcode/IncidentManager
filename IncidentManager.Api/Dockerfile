#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IncidentManager.Api/IncidentManager.Api.csproj", "IncidentManager.Api/"]
COPY ["IncidentManager.Application/IncidentManager.Application.csproj", "IncidentManager.Application/"]
COPY ["IncidentManager.Domain/IncidentManager.Domain.csproj", "IncidentManager.Domain/"]
COPY ["IncidentManager.Infrastructure/IncidentManager.Infrastructure.csproj", "IncidentManager.Infrastructure/"]
RUN dotnet restore "./IncidentManager.Api/./IncidentManager.Api.csproj"
COPY . .
WORKDIR "/src/IncidentManager.Api"
RUN dotnet build "./IncidentManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IncidentManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentManager.Api.dll"]