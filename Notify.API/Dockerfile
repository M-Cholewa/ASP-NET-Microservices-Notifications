#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Notify.API/Notify.API.csproj", "Notify.API/"]
RUN dotnet restore "Notify.API/Notify.API.csproj"
COPY . .
WORKDIR "/src/Notify.API"
RUN dotnet build "Notify.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notify.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notify.API.dll"]