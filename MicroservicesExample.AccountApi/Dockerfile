FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 8080
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MicroservicesExample.AccountApi/MicroservicesExample.AccountApi.csproj", "src/MicroservicesExample.AccountApi/"]
COPY ["MicroservicesExample.Infrastructure/MicroservicesExample.Infrastructure.csproj", "src/MicroservicesExample.Infrastructure/"]

RUN dotnet restore "src/MicroservicesExample.AccountApi/MicroservicesExample.AccountApi.csproj"
COPY . .
WORKDIR "/src/MicroservicesExample.AccountApi"
RUN dotnet build "MicroservicesExample.AccountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesExample.AccountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesExample.AccountApi.dll"]

### TO BUILD MANUALLY: in root project folder 'docker build -f MicroservicesExample.AccountApi/Dockerfile .'
### TO RUN: docker run -p 3000:80 ab20339c56b1, then test http://localhost:3000/api/getAccount