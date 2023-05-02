#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Alsofer.FluxoCaixa.API/Alsofer.FluxoCaixa.API.csproj", "Alsofer.FluxoCaixa.API/"]
RUN dotnet restore "Alsofer.FluxoCaixa.API/Alsofer.FluxoCaixa.API.csproj"
COPY . .
WORKDIR "/src/Alsofer.FluxoCaixa.API"
RUN dotnet build "Alsofer.FluxoCaixa.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alsofer.FluxoCaixa.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alsofer.FluxoCaixa.API.dll"]