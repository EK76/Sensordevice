# Sensor Device

The goal of this project was to build a simple weather monitoring application using Visual Studio 2022 C#. The application reads temperature and humidity data from a MySQL database table. 
These values are collected by a Raspberry Pi 5 using a DHT22 sensor and then stored in the database.
Another objective of the project was to create a portable solution that could be deployed on any network of the user's choosing with minimal configuration.

A Python application is responsible for reading the temperature and humidity values from the DHT22 sensor and storing them in the MySQL database. The Python source code is included in the Python folder 
within this project. Python version 3.13.5 was used during the development of the project.

In addition to the Visual Studio C# application, the stored sensor data can also be viewed through a web browser. To provide web access, Apache HTTP Server 2.4.66 was installed and configured on the Raspberry Pi 5.
The Raspberry Pi 5 runs Debian GNU/Linux 13 (Trixie), which serves as the operating system for the weather monitoring system.

#### Visual Studio C# project requirements
- .NET 9.0
-  C# language version 13.0

The device can be connected to any network, provided that DHCP is enabled and a wired network connection is available. If you prefer to use a Wi-Fi connection instead of a wired connection, 
you can use the SCP command to transfer the addwifi Bash script to the device. The addwifi script is included with this project in the System folder.

The Sensor Device application is compatible only with computers running the Windows 11 operating system. However, the web-based version of the application can be accessed from most common operating systems, 
including Windows, Linux, and macOS. To use the web-based version, you must install PHP in addition to Apache and MySQL on the device. PHP retrieves data from the MySQL database and displays it in a web browser 
through the Apache web server. The PHP source files are included with this project in the HomePage folder.
For this project, I used PHP 8.4.16.

**HomePage Folder Contents**
- index.php
The HomePage folder contains the PHP files and resources required for the web-based version of the application.
- files.php
Displays the temperature and humidity data retrieved from the MySQL database.
- config.php
Stores exported data from the MySQL database in CSV format.
- style.css    
Contains the database connection and configuration settings.
  
Defines the visual appearance and layout of the website.
To display sensor data in graphical form, I used Google Charts, which provides a collection of interactive chart and graph components for web applications. Additional information can be found in Google Chart Gallery. [https://de...cs/gallery]
In my setup, I assigned the hostname **sensordevice** to the Raspberry Pi 5. As a result, the web-based version of the application can be accessed from a web browser using the address http://sensordevice/, provided that hostname resolution is available on the network.

**Hardware used in this poject**
- Raspberry Pi 5
- DHT22 sensor
- 16x2 display with I2C interface
- 1 RGB (red/green) led

### Raspberry Pi 5
<img width="851" height="478" alt="raspberrypi" src="https://github.com/user-attachments/assets/25529bb9-281e-4447-8c56-1aaf83976acd" />

An overview of the Rasperry PI 5 GPIO pins.

### Sensor DHT22.
<img width="568" height="364" alt="dht22" src="https://github.com/user-attachments/assets/909912d9-66f4-4da3-a7a7-8a44d279c72f" />

The DHT22 sensor operates with a supply voltage ranging from 3.3 V to 5.5 V, making it fully compatible with the Raspberry Pi 5.

Connection Between the DHT22 Sensor and the Raspberry Pi 5
- The VCC pin of the DHT22 sensor is connected to a 3.3 V or 5 V power pin on the Raspberry Pi 5.
- The DATA pin of the DHT22 sensor is connected to GPIO 18 (Pin 12) on the Raspberry Pi 5.
- The GND pin of the DHT22 sensor is connected to a ground (GND) pin on the Raspberry Pi 5.

### Installation of library for the Sensor DHT22.

```
sudo pip3 install adafruit-circuitpython-dht
```
### 1.3" oled display.

<img width="263" height="285" alt="oled" src="https://github.com/user-attachments/assets/8c84f64e-cf72-41dd-84b8-30bb26221663" />

This OLED (organic light-emitting diode) display module combines bright white and deep blue colors to provide a sharp 128×64 pixel resolution. 
Its 1.3-inch display is ideal for a wide range of applications, providing a clear and sharp image even in small devices. 
The module uses the IIC communication protocol. IIC communication (also written as I²C or I2C) stands for Inter-Integrated Circuit,
a popular two-wire serial communication protocol used to connect low-speed peripheral chips, sensors, and displays to microcontrollers
 
Information about IIC protocol's function.
- Uses two shared signal lines: SDA (Serial Data Line) to send data, and SCL (Serial Clock Line) to keep the timing synced.
- Operates with a controller (master) device that directs traffic and a peripheral (slave) device that responds.
- Each slave device has a unique address. The master calls this address so only the correct part listens.
- Built-in acknowledgment bits tell the master if data arrived safely.

Connection between Raspberry PI5 and the oled display.

- The oled display's SDA pin is connected to SDA pin (GPIO2) on the Raspberry Pi5.
- The oled display's SCL pin is connected to SCL pin (GPIO3) on the Raspberry Pi5.
- The oled display's VCC pin is connected to 5V pin on the Raspberry Pi5.
- The oled display's GND pin is connected to ground on the Raspberry Pi5.

Before you can use this oled display, you must activate I2C.

- Type sudo raspi-config and press Enter in a terminal window.
- Use the arrow keys to select 3 Interface Options or 5 Interfacing Options (depending on your OS version) and press Enter.
- Choose I2C and select Yes to enable the ARM I2C interface.
- Select Ok and then Finish to exit the configuration menu.
- Reboot your Raspberry Pi 5 using sudo reboot for changes to take effect.

### Library installation for the OLED display.

#### Using pip (For other OS or virtual environments).
```
sudo pip3 install luma.oled
```
### RGB Leds
This project uses an RGB LED as a status indicator. In this implementation, only the red and green LEDs are used to indicate the current system status.
- Green LED = System enabled and operating correctly.
- Red LED = System disabled or an error/failure condition has occurred.
The RGB LED provides a simple visual indication of the system's operational state without requiring access to the software interface.

Connection Between the Raspberry Pi 5 and the RGB LED
The RGB LED is connected to the Raspberry Pi 5 as follows:
- The red LED pin is connected to GPIO 17 on the Raspberry Pi 5.
- The green LED pin is connected to GPIO 27 on the Raspberry Pi 5.
- The ground (GND) pin of the RGB LED is connected to a ground pin on the Raspberry Pi 5.

### The installation of library for the RGB leds.

#### Raspberry Pi OS (terminal).
```
sudo apt update
sudo apt install python3-gpiozero
```
#### Using pip (For other OS or virtual environments).
```
sudo pip3 install gpiozero
```
The code for display and indicator led functions are found in the same pyhton script, where sensor device stores it's data to MySQL table.
The RGB LED is used to provide immediate visual feedback regarding the system's status, making it easier to identify whether the application 
is running correctly or if a failure has occurred.

### Database

This project contains of three mysql tables.
- sensorlog- where sensor data (temperature and humitidy) are  stored.
- loginfo - where all the logs are stored.
- settings - where the settings are stored, delay and numberofrows.<br/>
          **- delay = the intervall value between two readings.** <br/>
          **- numberofrows = how many rows can be stored in table logtext, keeping the most recent ones.**

MySQL/MariaDB was selected as the database platform for this project because it provides reliable data storage, good performance, 
and simple integration with Python, PHP, and Visual Studio C# applications.
The database version used for this project is MariaDB 11.8.3.
To create the tables, follow the instructions below.
```
create database sensorinfo;
use sensorinfo;

create table sensorlog(
id int not null auto_increment,
temp decimal(3,1),
hum decimal(4,1),
datecreated datetime default (current_timestamp),
primary key(id)
);

create table settings(
id int not null auto_increment,
delay int,
numberofrows int,
datecreated datetime default (current_timestamp),
primary key(id)
);

create table loginfo(
id int not null auto_increment,
logtext varchar(250),
infocode varchar(250),
comment varchar(250),
datecreated datetime default (current_timestamp),
primary key(id)
);
```
Several system settings can be modified through this project. These settings are stored in the settings table within the database and can be changed using the Visual Studio C# application.
The Visual Studio C# application is designed to run on computers using the Windows 11 operating system.

To ensure that configuration changes take effect automatically, a Linux service named **sensordevice.service** has been created. Whenever one or more settings are modified through the Visual Studio C# application, 
the service automatically restarts the Python program and reloads the updated configuration.
This approach eliminates the need for manual restarts and ensures that the latest configuration settings are applied immediately.
```
[Unit]
Description=Enable/disable sensor device.
After=multi-user.target

[Service]
Type=simple
EnvironmentFile=/etc/sensordevice/sensordevice.conf
WorkingDirectory=/home/sensoruser/Sensordevice/
user=sensoruser
ExecStart=/usr/bin/python3 /home/sensoruser/Sensordevice/sensor.py
Restart=on-abort

[Install]
WantedBy=multi-user.target
```
The MySQL password used by this project is stored in the /etc/controldevice/controldevice.conf configuration file.
Sensitive information, such as passwords, API keys, tokens, and database credentials, should never be stored directly in source code. 
A recommended approach is to use environment variables, which is the method used in this project.

The sensordevice.service service can be controlled from the Visual Studio C# application. To allow the application to manage the service without prompting for a sudo password
put this line at bottom of /etc/sudoers file with the help of sudo visudo.
```
%sudo   ALL=(ALL:ALL) ALL
```
During the development of this project, I installed two external packages through the Visual Studio NuGet Package Manager.

- MySql.Data (Oracle Corporation)
The MySql.Data package, developed by Oracle Corporation, provides a .NET data provider for MySQL databases.
It enables the Visual Studio C# application to connect to a MySQL database, execute queries, retrieve data, and modify database records efficiently.

- MySqlBackup.NET
The MySqlBackup.NET package provides functionality for backing up and restoring MySQL databases and tables.
It simplifies database maintenance by allowing database contents to be exported and restored directly from the Visual Studio C# application.

**Two pictures of the application.**
<img width="2880" height="1132" alt="sensorproject2" src="https://github.com/user-attachments/assets/332e3cc5-61dd-4804-81ce-cfdb99f49456" />
<img width="901" height="917" alt="sensorproject3" src="https://github.com/user-attachments/assets/e39351ef-e9ae-4247-97e7-cb1f537d3b39" />

**Picture for web solution.**

<img width="539" height="1126" alt="sensorproject1" src="https://github.com/user-attachments/assets/274db9e7-38f0-4833-9d62-57f660a808b0" />

