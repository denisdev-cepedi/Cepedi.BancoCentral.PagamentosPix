#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cepedi.BancoCentral.PagamentoPix.ServiceWorker/Cepedi.BancoCentral.PagamentoPix.ServiceWorker.csproj", "Cepedi.BancoCentral.PagamentoPix.ServiceWorker/"]
RUN dotnet restore "./Cepedi.BancoCentral.PagamentoPix.ServiceWorker/Cepedi.BancoCentral.PagamentoPix.ServiceWorker.csproj"
COPY . .
WORKDIR "/src/Cepedi.BancoCentral.PagamentoPix.ServiceWorker"
RUN dotnet build "./Cepedi.BancoCentral.PagamentoPix.ServiceWorker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cepedi.BancoCentral.PagamentoPix.ServiceWorker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cepedi.BancoCentral.PagamentoPix.ServiceWorker.dll"]