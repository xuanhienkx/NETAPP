echo off 
setx ASPNETCORE_ENVIRONMENT "Development"
dotnet bin\Debug\netcoreapp2.0\CS.CoreApi.dll -url http://localhost -port 8888
pause