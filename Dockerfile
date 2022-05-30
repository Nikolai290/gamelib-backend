#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["./gamelib-backend/gamelib-backend.csproj", "gamelib-backend/"]
RUN dotnet restore "gamelib-backend/gamelib-backend.csproj"
COPY . .
WORKDIR "/src/gamelib-backend"
RUN dotnet build "gamelib-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gamelib-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gamelib-backend.dll"]