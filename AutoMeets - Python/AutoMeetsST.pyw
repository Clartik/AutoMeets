# import datetime
from datetime import date, datetime, time
from time import strftime
import time
# # import re
import pickle
import os
# from selenium import webdriver
from win10toast import ToastNotifier
from infi.systray import SysTrayIcon
# import subprocess
# # from colorama import init, Fore, Back, Style
# # import shutil
# # from random import randint
# from os import startfile
# # import winshell
# # from win32com.client import Dispatch
from infi.systray import SysTrayIcon
import psutil
import sys
import ctypes
# import signal

# Variables
automationFinish = False
startScan = False
daysOffAns = ""
DaysofWeek = [0, 1, 2, 3, 4]
daysOffNum = []
sundaySetUpVar = False

startup_path = f"C:{os.environ['HOMEPATH']}\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\AutoMeetsStartup.LNK"
startup_dir = f"C:{os.environ['HOMEPATH']}\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\"
saveinfo_parentdir = f"C:{os.environ['HOMEPATH']}\\AppData\\Roaming\\"
saveinfo_dir = "AutoMeets\\"
saveinfo_path = os.path.join(saveinfo_parentdir, saveinfo_dir)

current_dir = os.getcwd()
desktop = os.path.sep.join(current_dir.split(os.path.sep)[:-3])
# desktop = current_dir
path = os.path.join(desktop, "AutoMeetsStartup.bat - Shortcut.LNK")
wDir = f"{os.path.sep.join(current_dir.split(os.path.sep)[:-3])}\\"
# wDir = f"{current_dir}\\"
target = f"{wDir}AutoMeetsStartup.bat"
icon = f"{wDir}app.ico"

Odd = []
Even = []
FridaySet = [4]

MB_OK = 0
MB_OKCANCEL = 1
MB_ABORTRETRYIGNORE = 2
MB_YESNOCANCEL = 3
MB_YESNO = 4
MB_RETRYNO = 5
MB_CANCELTRYAGAINCONTINUE = 6

IDOK = 0
IDCANCEL = 2
IDABORT = 3
IDYES = 6
IDNO = 7

# MB_OK = 0x0
# MB_OKCXL = 0x01
# MB_YESNOCXL = 0x03
# MB_YESNO = 0x04
MB_HELP = 0x4000
ICON_EXLAIM = 0x30
ICON_INFO = 0x40
ICON_STOP = 0x10


# def process_exists(process_name):
#     call = 'TASKLIST', '/FI', 'imagename eq %s' % process_name
#     # use buildin check_output right away
#     output = subprocess.check_output(call).decode()
#     # check in last line for process name
#     last_line = output.strip().split('\r\n')[-1]
#     # because Fail message could be translated
#     return last_line.lower().startswith(process_name.lower())

def Mbox(title, text, style):
    return ctypes.windll.user32.MessageBoxW(0, text, title, style)


def openAutoMeets(systray):
    checkIfRun()


def deleteInfo(systray):
    mbox = Mbox("Deleting Your Personal Information?",
                "Are you sure you want to delete your personal information? This cannot be undone.", MB_YESNO | ICON_EXLAIM)
    if mbox == IDYES:
        try:
            os.remove(f"{saveinfo_path}INFO.txt")
            mbox2 = Mbox("Deleted Information!",
                         "Finished Deleting Your Personal Information. Please restart AutoMeets to input your Personal Information again.", MB_OK | ICON_INFO)
        except:
            mbox1 = Mbox("Information already deleted!",
                         "You have already deleted your personal information!", MB_OK | ICON_STOP)


def deleteClasses(systray):
    mbox = Mbox("Deleting This Week's Schedule?",
                "Are you sure you want to delete this week's schedule? This cannot be undone.", MB_YESNO | ICON_EXLAIM)
    if mbox == IDYES:
        try:
            os.remove(f"{saveinfo_path}ClassesWeekly.txt")
            os.remove(f"{saveinfo_path}SundaySetupDone.txt")
            mbox2 = Mbox("Deleted This Week's Schedule!",
                         "Finished Deleting This Week's Schedule. Please restart AutoMeets to input this Week's Schedule again.", MB_OK | ICON_INFO)
        except:
            mbox1 = Mbox("Week's Schedule already deleted!",
                         "You have already deleted this Week's Schedule!", MB_OK | ICON_STOP)


def checkIfRun():
    if ("AutoMeets.exe" in (p.name() for p in psutil.process_iter())) == False:
        os.startfile("AutoMeets.exe")


def on_quit_callback(systray):
    if ("AutoMeets.exe" in (p.name() for p in psutil.process_iter())) == True:
        os.system("TASKKILL /F /IM AutoMeets.exe")

    os._exit(1)
    systray.shutdown()


def startUp():
    menu_options = (("Open AutoMeets", None, openAutoMeets),
                    ("Delete My Personal Information", None, deleteInfo), ("Delete This Week's Schedule", None, deleteClasses))
    systray = SysTrayIcon("app.ico", "AutoMeets",
                          menu_options, on_quit=on_quit_callback)
    systray.start()

    checkIfRun()

    sundaySetUpVar = False
    sundaySetUpVar = SundaySetupVarFT()

    if not date.today().weekday() == 5 and sundaySetUpVar != True:
        checkIfRun()

    if date.today().weekday() == 5 and sundaySetUpVar == True:
        checkIfRun()

    global startScan
    startScan = True

    timeScanLook()


def core():
    if ("AutoMeets.exe" in (p.name() for p in psutil.process_iter())) == False:
        os.startfile("AutoMeets.exe")

    global startScan
    startScan = True

    global automationFinish
    automationFinish = True
    timeScanLook()


def timeScanLook():
    while startScan == True:
        timeScan()


def readVarsConst():
    try:
        with open(f'{saveinfo_path}INFO.txt', 'rb') as f:
            EMAIL = pickle.load(f)
            PASSWORD = pickle.load(f)
            P1Name = pickle.load(f)
            P1Code = pickle.load(f)
            P1LinkCode = pickle.load(f)
            P2Name = pickle.load(f)
            P2Code = pickle.load(f)
            P2LinkCode = pickle.load(f)
            P3Name = pickle.load(f)
            P3Code = pickle.load(f)
            P3LinkCode = pickle.load(f)
            P4Name = pickle.load(f)
            P4Code = pickle.load(f)
            P4LinkCode = pickle.load(f)
            P5Name = pickle.load(f)
            P5Code = pickle.load(f)
            P5LinkCode = pickle.load(f)
            P6Name = pickle.load(f)
            P6Code = pickle.load(f)
            P6LinkCode = pickle.load(f)
            firstTime = pickle.load(f)

        return EMAIL, PASSWORD, P1Name, P1Code, P1LinkCode, P2Name, P2Code, P2LinkCode, P3Name, P3Code, P3LinkCode, P4Name, P4Code, P4LinkCode, P5Name, P5Code, P5LinkCode, P6Name, P6Code, P6LinkCode, firstTime
    except:
        mbox = Mbox("Error Retrieving Information!",
                    "AutoMeets had trouble retrieving your personal information! Please retry or consider messaging Kartik on Discord.", MB_OK | ICON_STOP)
        time.sleep(10)
        os._exit(1)


def readVarsWeekly():
    try:
        with open(f'{saveinfo_path}ClassesWeekly.txt', 'rb') as w:
            fridayName = pickle.load(w)
            fridayCode = pickle.load(w)
            fridayLinkCode = pickle.load(w)
            Odd = pickle.load(w)
            Even = pickle.load(w)
            FridaySet = pickle.load(w)

        return fridayName, fridayCode, fridayLinkCode, Odd, Even, FridaySet
    except:
        mbox = Mbox("Error Retrieving Week Schedule!",
                    "AutoMeets had trouble retrieving this week's schedule! Please retry or consider messaging Kartik on Discord.", MB_OK | ICON_STOP)
        time.sleep(10)
        os._exit(1)


def SundaySetupVarFT():
    try:
        with open(f'{saveinfo_path}SundaySetupDone.txt', 'rb') as f:
            sundaySetUpVar = pickle.load(f)

        return sundaySetUpVar
    except:
        pass


def timeScan():
    now = datetime.now()
    current_time = now.strftime("%H:%M")
    global automationFinish
    global startScan

    if not date.today().weekday() == 4 and not date.today().weekday() == 5 and not date.today().weekday() == 6 and current_time >= "08:24" and current_time <= "12:51":
        if current_time > "08:30" and current_time < "10:20" or current_time > "10:25" and current_time < "12:45":
            time.sleep(1)
        else:
            EMAIL, PASSWORD, P1Name, P1Code, P1LinkCode, P2Name, P2Code, P2LinkCode, P3Name, P3Code, P3LinkCode, P4Name, P4Code, P4LinkCode, P5Name, P5Code, P5LinkCode, P6Name, P6Code, P6LinkCode, firstTime = readVarsConst()
            fridayName, fridayCode, fridayLinkCode, Odd, Even, FridaySet = readVarsWeekly()

            if date.today().weekday() in Odd:
                if current_time >= "08:25" and current_time < "08:30" and automationFinish == False or not "none" in P1Name and current_time >= "08:25" and current_time < "08:30" and automationFinish == False:
                    startScan = False
                    core()

                elif current_time >= "10:20" and current_time < "10:25" and automationFinish == False or not "none" in P3Name and current_time >= "10:20" and current_time < "10:25" and automationFinish == False:
                    startScan = False
                    core()

                elif current_time >= "12:45" and current_time < "12:50" and automationFinish == False or not "none" in P5Name and current_time >= "12:45" and current_time < "12:50" and automationFinish == False:
                    startScan = False
                    core()

                if current_time >= "08:30" and current_time <= "08:31" and automationFinish == True or not "none" in P1Name and current_time >= "08:30" and current_time <= "08:31" and automationFinish == True:
                    automationFinish = False

                elif current_time >= "10:25" and current_time <= "10:26" and automationFinish == True or not "none" in P3Name and current_time >= "10:25" and current_time <= "10:26" and automationFinish == True:
                    automationFinish = False

                elif current_time >= "12:50" and current_time <= "12:51" and automationFinish == True or not "none" in P5Name and current_time >= "12:50" and current_time <= "12:51" and automationFinish == True:
                    automationFinish = False

                else:
                    time.sleep(1)

            elif date.today().weekday() in Even:
                if current_time >= "08:25" and current_time < "08:30" and automationFinish == False or not "none" in P2Name and current_time >= "08:25" and current_time < "08:30" and automationFinish == False:
                    startScan = False
                    core()

                elif current_time >= "10:20" and current_time < "10:25" and automationFinish == False or not "none" in P4Name and current_time >= "10:20" and current_time < "10:25" and automationFinish == False:
                    startScan = False
                    core()

                elif current_time >= "12:45" and current_time < "12:50" and automationFinish == False or not "none" in P6Name and current_time >= "12:45" and current_time < "12:50" and automationFinish == False:
                    startScan = False
                    core()

                if current_time >= "08:30" and current_time <= "08:31" and automationFinish == True or not "none" in P2Name and current_time >= "08:30" and current_time <= "08:31" and automationFinish == True:
                    automationFinish = False

                elif current_time >= "10:25" and current_time <= "10:26" and automationFinish == True or not "none" in P4Name and current_time >= "10:25" and current_time <= "10:26" and automationFinish == True:
                    automationFinish = False

                elif current_time >= "12:50" and current_time <= "12:51" and automationFinish == True or not "none" in P6Name and current_time >= "12:50" and current_time <= "12:51" and automationFinish == True:
                    automationFinish = False

                else:
                    time.sleep(1)
            else:
                time.sleep(1)

    elif date.today().weekday() == 4 and current_time >= "09:09" and current_time <= "09:17":
        EMAIL, PASSWORD, P1Name, P1Code, P1LinkCode, P2Name, P2Code, P2LinkCode, P3Name, P3Code, P3LinkCode, P4Name, P4Code, P4LinkCode, P5Name, P5Code, P5LinkCode, P6Name, P6Code, P6LinkCode, firstTime = readVarsConst()
        fridayName, fridayCode, fridayLinkCode, Odd, Even, FridaySet = readVarsWeekly()

        if date.today().weekday() in FridaySet:
            if current_time >= "09:10" and current_time < "09:15" and automationFinish == False or not "none" in fridayName and current_time >= "09:10" and current_time < "09:15" and automationFinish == False:
                startScan = False
                core()

            elif current_time >= "09:15" and current_time <= "09:16" and automationFinish == True or not "none" in fridayName and current_time >= "09:15" and current_time <= "09:16" and automationFinish == True:
                automationFinish = False

            else:
                time.sleep(1)
    else:
        time.sleep(1)


if __name__ == "__main__":
    startUp()
