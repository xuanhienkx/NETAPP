#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6000
EXPOSE 6001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DSoftCore/DSoft.Api/DSoft.Api.csproj", "src/DSoftCore/DSoft.Api/"]
COPY ["src/DSoftCore/DSoft.MarketParser/DSoft.MarketParser.csproj", "src/DSoftCore/DSoft.MarketParser/"]
COPY ["src/DSoftCore/DSoft.Common/DSoft.Common.csproj", "src/DSoftCore/DSoft.Common/"]
RUN dotnet restore "src/DSoftCore/DSoft.Api/DSoft.Api.csproj"
COPY . .
WORKDIR "/src/src/DSoftCore/DSoft.Api"
RUN dotnet build "DSoft.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSoft.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "DSoft.Api.dll"]