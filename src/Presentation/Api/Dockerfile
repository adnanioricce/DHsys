FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
#For development purposes
WORKDIR /src
COPY . .
RUN dotnet restore ./src/Presentation/Api/Api.csproj
RUN dotnet build ./src/Presentation/Api/Api.csproj
RUN dotnet publish ./src/Presentation/Api/
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS release
ENV DH_CONNECTION_STRING "User ID=postgres;Password=postgres;Host=dhsysdb;Port=5432;Database=dhsysdb_dev;Pooling=true;"
WORKDIR /app
COPY --from=build /src/build/Api .
ENTRYPOINT ["dotnet","Api.dll","--environment=Production"]