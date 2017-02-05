@echo off
del *.nupkg
nuget pack Plugin.Sensors.nuspec
pause