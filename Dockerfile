FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

EXPOSE 80

ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Development

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ToyStore/ToyStore.csproj", "ToyStore/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "ToyStore/ToyStore.csproj"

COPY . .
FROM build AS publish
RUN dotnet publish "ToyStore/ToyStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","ToyStore.dll"]