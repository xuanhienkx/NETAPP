#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Authen/DSoft.Authen/DSoft.Authen.csproj", "src/Authen/DSoft.Authen/"]
RUN dotnet restore "src/Authen/DSoft.Authen/DSoft.Authen.csproj"
COPY . .
WORKDIR "/src/src/Authen/DSoft.Authen"
RUN dotnet build "DSoft.Authen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSoft.Authen.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "DSoft.Authen.dll"]