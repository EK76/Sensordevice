#!/usr/bin/python
import Adafruit_GPIO as GPIO
import Adafruit_GPIO.SPI as SPI
from gpiozero import LED
import mysql.connector, sys, Adafruit_DHT, datetime, time
from mysql.connector import Error
from mysql.connector import errorcode
from time import *
import RPi.GPIO as GPIO
import board
import adafruit_dht
import atexit
import os
from luma.core.interface.serial import i2c
from luma.core.render import canvas
from luma.oled.device import sh1106

import time
import datetime

serial = i2c(port=1, address=0x3C)
device = sh1106(serial, width=128, height=64, rotate=2)

def disabledevice():
   greenled.off()
   redled.off()
   device.hide()

def addmysqlrecord(temp, hum):
   try:
     connection = mysql.connector.connect(**config)
     mysql_insert_query = "INSERT INTO sensorlog(temp, hum) VALUES ('%s','%s')"
     cursor = connection.cursor()
     record = (temp, hum)
     cursor.execute(mysql_insert_query, record)
     connection.commit()
     print(f"Record inserted successfully into table sensorlog with temp: {temp}, hum: {hum}.")
     cursor.close()  
     checkSensor = True
   except mysql.connector.Error as error:
     oledinfo("DATABASE ERROR", "","","")
     checkSensor = False
     print(error)
   return checkSensor

def addmysqlrecord2(info, code, sensorError):
   try:
     connection = mysql.connector.connect(**config)
     cursor = connection.cursor()
     query = "insert into loginfo(logtext, infocode, comment) values (%s, %s, %s)"
     cursor.execute(query, (info, code, sensorError))
     connection.commit()   
     print(f"Record inserted successfully into table loginfo with info: {info}, and code: {code}.")
     cursor.close()
     checkSensor = True
   except mysql.connector.Error as error:
     oledinfo("DATABASE ERROR", "","","")
     checkSensor = False
     print(error)
   return checkSensor

def deletemysqlrecords(limit):
   try:
     connection = mysql.connector.connect(**config)
     cursor = connection.cursor()
     query = "delete from loginfo where id not in (select id from(select id from loginfo order by id desc limit " + str(limit) + ")info);"
     cursor.execute(query)
     connection.commit()   
     cursor.close()
     checkSensor = True
     print("Record deleted successfully from table loginfo.")
   except mysql.connector.Error as error:
     oledinfo("DATABASE ERROR", "","","")
     checkSensor = False
     print(error)
   return checkSensor
 
def oledinfo(row1, row2, row3, row4):
  with canvas(device) as draw:
    draw.rectangle(device.bounding_box, outline="white", fill="black")
    draw.text((5, 10), row1, fill="white")
    draw.text((5, 22), row2, fill="white")
    draw.text((5, 34), row3, fill="white")
    draw.text((5, 46), row4, fill="white")

sensor = adafruit_dht.DHT22(board.D18)
redled = LED(17) 
greenled = LED(27)

config = {
  'host':'localhost',
  'user':'loguser',
  'password':os.getenv("sqlpass"),
  'database':'sensorinfo'
}

try:
   greenled.on()
   redled.off()
   checkSensor = True
   allow = True
   counter = 0 
   counter2 = 0
   counter3 = 0
   row1 = "Sensor device."
   row2 = "version 3.24."
   row3 = "(C) Ken Ekholm"
   row4 = "Device started."
   oledinfo(row1, row2, row3, row4)
   sleep(5)
   try:
      connection = mysql.connector.connect(**config)
      cursor = connection.cursor()
      cursor.execute("select database();")
      record = cursor.fetchone()
      cursor.close()
      cursor = connection.cursor()
      query = "select delay, numberofrows from settings where id=1"
      cursor = connection.cursor()
      cursor.execute(query)
      row = cursor.fetchone()
      delay = row[0]
      limit = row[1]
      connection.commit()
      cursor.close()
      addmysqlrecord2("Sensor device started.",0,"")
      deletemysqlrecords(limit)
      print(delay)
   except mysql.connector.Error as error:
      oledinfo("DATABASE ERROR", "","","")
      greenled.off()
      redled.on()
      print(error)
      checkSensor = False

   while True:
    #  print(checkSensor)
      if checkSensor == True:
         now = datetime.datetime.now()
         showdate = now.strftime("%d.%m.%Y")
         showtime = now.strftime("%H:%M")
         if counter2 == 60 or allow == True:
            try:
               sensorError = ""
               temperature = sensor.temperature
               humidity = sensor.humidity
               temperature=(round(temperature,2))
               humidity=(round(humidity,4))
               row1 = showdate + "  " + showtime
               row2 = "Temp: "+str(temperature)+"C"  
               row3 = "Humidity: "+str(humidity)+"%"
               row4 = ""
               print(f"Loop (60) {counter2}")
               print(f"Delay {counter}") 
               oledinfo(row1, row2, row3, row4)
               if counter == delay:
                  print(f"Delay {counter} reached, adding record to database.")
                  checkSensor = addmysqlrecord(temperature, humidity)
                  counter = 0
               counter2 = 0 
            except RuntimeError as sensorError:    
               sensorError = str(sensorError)
               print(f"Sensor error: {sensorError}")
               row1 = showdate + "  " + showtime
               row2 = "Sensor device"
               row3 = "mailfunction"
               row4 = ""
               oledinfo(row1, row2, row3, row4)
               print("Sensor mailfunction.")
               addmysqlrecord2("Sensor mailfunction.",0,"")
               deletemysqlrecords(limit)
               checkSensor = False 
      else:
         greenled.off()
         redled.on()   
      allow = False
      counter+=1  
      counter2+=1
      sleep(1)
      atexit.register(disabledevice)
except mysql.connector.Error as error:
   print("Failed to insert record into table {}".format(error))
   greenled.off()
   redled.on()

except KeyboardInterrupt:
   print("Exit!")
   GPIO.cleanup()

finally:
   if connection.is_connected():
      connection.close()
      print("MySQL connection is closed.")
