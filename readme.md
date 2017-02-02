# ACR Reactive Sensors Plugin for Xamarin & Windows
Easy to use, cross platform, REACTIVE Sensor Plugin for iOS, Android, and Windows UWP

[![NuGet](https://img.shields.io/nuget/v/Plugin.Sensors.svg?maxAge=2592000)](https://www.nuget.org/packages/Plugin.Sensors/)
[![Downloads](https://www.nuget.org/packages/Plugin.Sensors")](https://img.shields.io/nuget/dt/Plugin.Sensors.svg)

[Change Log - Feb 1, 2017](changelog.md)


## PLATFORMS

* Android 4.3+
* iOS 7+
* Windows UWP 
* PCL Profile 259
* Windows Core IoT (ADXL 345 Accelerometer)


## FEATURES

* Accelerometer
* Gyroscope
* Magnetometer


## SETUP

Be sure to install the Plugin.Sensors nuget package in all of your main platform projects as well as your core/PCL project

[![NuGet](https://img.shields.io/nuget/v/Plugin.Sensors.svg?maxAge=2592000)](https://www.nuget.org/packages/Plugin.Sensors/)


## HOW TO USE BASICS

```csharp

// discover some devices
CrossSensors.Accelerometer
CrossSensors.Gyroscope
CrossSensors.Magnetometer.WhenReadingTaken().Subscribe(reading => {});

```
