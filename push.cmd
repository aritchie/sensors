@echo off
nuget push .\Plugin.Sensors\bin\Release\*.nupkg -Source https://www.nuget.org/api/v2/package
pause