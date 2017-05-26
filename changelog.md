# CHANGE LOG

## 2.2
* [feature] device orientation

## 2.1.0
* [feature][android] compass implementation
* [fix][android] proximity sensor now returns relevant boolean values.  Thanks to Emil Aplipiev
* [fix][android] sensors now fire at fastest trigger speed.  Use observable.sample(timespan) to make this consumable
* [fix][uwp] barometer was not firing event
* [fix] remove any reference to timers as they are not used

## 2.0.1
* [fix][uwp] barometer was not reporting
* remove signatures with report interval since it isn't intended to be used.  Use the observable Sample or Buffer

## 2.0
* [netstandard] this release only changes the bait/switch to netstandard.  If you need PCL, use 1.0

## 1.0.1
* [uwp] merge in UWP ADXL345 accelerometer sensor

## 1.0
* Initial Release for iOS, Android, UWP, & WinIot
* Supported Sensors
  * Accelerometer
  * Ambient Light
  * Barometer
  * Compass
  * Gyroscope
  * Magnetometer
  * Pedometer
  * Proximity