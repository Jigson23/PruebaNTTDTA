

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /app
COPY ./ ./

WORKDIR /app/MicroService.Infraestructura.API/

RUN dotnet restore

RUN dotnet publish -c release -o ./../build

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

COPY --from=builder /app/build/ ./

EXPOSE 80

ENTRYPOINT ["dotnet", "MicroService.Infraestructura.API.dll"]