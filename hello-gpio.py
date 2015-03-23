from flask import Flask, render_template
import datetime
import RPi.GPIO as GPIO
from Adafruit_BMP085 import BMP085

bmp = BMP085(0x77)
app = Flask(__name__)

GPIO.setmode(GPIO.BCM)

@app.route("/")
def hello():
   now = datetime.datetime.now()
   timeString = now.strftime("%Y-%m-%d %H:%M")
   templateData = {
      'title' : 'HELLO!',
      'time': timeString
      }
   return render_template('main.html', **templateData)

@app.route("/readPin/<pin>")
def readPin(pin):
   try:
      GPIO.setup(int(pin), GPIO.IN)
      if GPIO.input(int(pin)) == True:
         response = "Pin number " + pin + " is high!"
      else:
         response = "Pin number " + pin + " is low!"
   except:
      response = "There was an error reading pin " + pin + "."

   templateData = {
      'title' : 'Status of Pin' + pin,
      'response' : response
      }

   return render_template('pin.html', **templateData)

@app.route("/readTemp")
def readTemp():
        try:
                response = bmp.readTemperature()
        except:
                response = "There was an error reading the temperature."
        templateData={
                'title' : 'The current temperature',
                'celsius' : float(response),
		'fahrenheit' : float(response) * (9.0 / 5.0) + 32.0,
		'response' : response 
        }
        return render_template('temperature.html', **templateData)

@app.route("/readPressure")
def readPressure():
        try:
                response = bmp.readPressure()
        except:
                response = "There was an error reading the pressure."
        templateData={
                'title' : 'The current pressure',
		'kpa' : '%.2f hPa' % (response / 100.0),
		'psi' : response * 6894.75729,
                'response' : response
        }
        return render_template('pressure.html', **templateData)
#This is a test
if __name__ == "__main__":
   app.run(host='0.0.0.0', port=80, debug=True)

