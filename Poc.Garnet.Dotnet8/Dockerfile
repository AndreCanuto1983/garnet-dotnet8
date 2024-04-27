FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["poc-dotnet8-garnet/poc-dotnet8-garnet.csproj", "poc-dotnet8-garnet/"]
RUN dotnet restore "./poc-dotnet8-garnet/poc-dotnet8-garnet.csproj"
COPY . .
WORKDIR "/src/poc-dotnet8-garnet"
RUN dotnet build "./poc-dotnet8-garnet.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./poc-dotnet8-garnet.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc-dotnet8-garnet.dll"]