#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 3030

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Notify.Services.Sender/Notify.Services.Sender.csproj", "Services/Notify.Services.Sender/"]
RUN dotnet restore "./Services/Notify.Services.Sender/Notify.Services.Sender.csproj"
COPY . .
WORKDIR "/src/Services/Notify.Services.Sender"
RUN dotnet build "./Notify.Services.Sender.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notify.Services.Sender.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notify.Services.Sender.dll"]