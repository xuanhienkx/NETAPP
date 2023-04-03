echo off
setx ASPNETCORE_ENVIRONMENT "Development"
dotnet bin\Debug\netcoreapp2.0\VSDGateway.dll
pause