import serial
import requests 

ser = serial.Serial('/dev/cu.usbmodem143101',9600, timeout=5)

print("connected to: " + ser.portstr)

#this will store the line
line = []

while True:
    x = ser.readline().decode('utf-8')
    if x == 'Press\r\n':
        print('Button Press')
        requests.post("http://localhost:5000/increment")
        

ser.close()