@echo off
del *.nupkg
nuget pack Plugin.Sensors.nuspec
nuget pack Plugin.Sensors.Adxl345.Uwp.nuspec
pause