# Use ASP.NET Core Runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY . .

# Restore and publish
RUN dotnet restore "MemoryCRUDMVC.sln"
RUN dotnet publish "MemoryCRUDMVC/MemoryCRUDMVC.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MemoryCRUDMVC.dll"]
