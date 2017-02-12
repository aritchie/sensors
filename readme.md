# ACR Reactive Sensors Plugin for Xamarin & Windows
Easy to use, cross platform, REACTIVE Sensor Plugin for iOS, Android, and Windows UWP

[![NuGet](https://img.shields.io/nuget/v/Plugin.Sensors.svg?maxAge=2592000)](https://www.nuget.org/packages/Plugin.Sensors/)

[Change Log - Feb 12, 2017](changelog.md)


## PLATFORMS
* PCL Profile 259 (use v1.0)
* NET Standard (use v2.0)
* Android 4.3+
* iOS 7+
* Windows UWP 
* Windows Core IoT (ADXL 345 Accelerometer)


## SUPPORTED SENSORS

* Accelerometer
* Ambient Light
* Barometer
* Compass
* Gyroscope
* Magnetometer
* Pedometer
* Proximity


## SETUP

Be sure to install the Plugin.Sensors nuget package in all of your main platform projects as well as your core/PCL project

[![NuGet](https://img.shields.io/nuget/v/Plugin.Sensors.svg?maxAge=2592000)](https://www.nuget.org/packages/Plugin.Sensors/)

### iOS

If you plan to use the pedometer on iOS, you need to add the following to your Info.plist

```xml
<dict>
	<key>NSMotionUsageDescription</key>
	<string>Using some motion</string>
</dict>
```

## UWP Core IoT

There are two providers in the UWP library to support an ADXL345 accelerometer sensor via I2C or SPI
To use them:

```csharp
CrossSensors.Accelerometer = new Adxl345.I2cAccelerometer();

// or
CrossSensors.Accelerometer = new Adxl345.SpiAccelerometer();
```


## HOW TO USE BASICS

```csharp

// discover some devices
CrossSensors.Accelerometer
CrossSensors.Gyroscope
CrossSensors.Magnetometer.WhenReadingTaken().Subscribe(reading => {});

```
