#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Cepedi.BancoCentral.PagamentoPix.Api/Cepedi.BancoCentral.PagamentoPix.Api.csproj", "src/Cepedi.BancoCentral.PagamentoPix.Api/"]
COPY ["src/Cepedi.BancoCentral.PagamentoPix.IoC/Cepedi.BancoCentral.PagamentoPix.IoC.csproj", "src/Cepedi.BancoCentral.PagamentoPix.IoC/"]
COPY ["src/Cepedi.BancoCentral.PagamentoPix.Dados/Cepedi.BancoCentral.PagamentoPix.Dados.csproj", "src/Cepedi.BancoCentral.PagamentoPix.Dados/"]
COPY ["src/Cepedi.BancoCentral.PagamentoPix.Dominio/Cepedi.BancoCentral.PagamentoPix.Dominio.csproj", "src/Cepedi.BancoCentral.PagamentoPix.Dominio/"]
COPY ["src/Cepedi.BancoCentral.PagamentoPix.Compartilhado/Cepedi.BancoCentral.PagamentoPix.Compartilhado.csproj", "src/Cepedi.BancoCentral.PagamentoPix.Compartilhado/"]
RUN dotnet restore "./src/Cepedi.BancoCentral.PagamentoPix.Api/Cepedi.BancoCentral.PagamentoPix.Api.csproj"
COPY . .
WORKDIR "/src/src/Cepedi.BancoCentral.PagamentoPix.Api"
RUN dotnet build "./Cepedi.BancoCentral.PagamentoPix.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cepedi.BancoCentral.PagamentoPix.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cepedi.BancoCentral.PagamentoPix.Api.dll"]