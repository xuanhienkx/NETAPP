#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["api/api.csproj", "api/"]
COPY ["api.resources/api.resources.csproj", "api.resources/"]
COPY ["api.common/api.common.csproj", "api.common/"]
COPY ["api.domain/api.domain.csproj", "api.domain/"]
COPY ["api.audit/api.audit.csproj", "api.audit/"]
RUN dotnet restore "api/api.csproj"
COPY . .
WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN apt-get -y -q update
RUN apt-get -y -q install libgdiplus

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]