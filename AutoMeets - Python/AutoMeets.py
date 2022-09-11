from datetime import date, datetime, time
from time import strftime
import time
import re
import pickle
import os
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from win10toast import ToastNotifier
from itertools import cycle
from colorama import init, Fore, Back, Style
import shutil
from random import randint
import winshell
from win32com.client import Dispatch
import pyperclip as pc
import atexit
import ctypes

# Allows color
init(convert=True)

# Variables
automationFinish = False
startScan = False
daysOffAns = ""
DaysofWeek = [0, 1, 2, 3]
daysOffNum = []
sundaySetUpVar = False

startup_path = f"C:{os.environ['HOMEPATH']}\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\AutoMeetsStartup.LNK"
startup_dir = f"C:{os.environ['HOMEPATH']}\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\"
saveinfo_parentdir = f"C:{os.environ['HOMEPATH']}\\AppData\\Roaming\\"
saveinfo_dir = "AutoMeets\\"
saveinfo_path = os.path.join(saveinfo_parentdir, saveinfo_dir)

current_dir = os.getcwd()
# desktop = current_dir
desktop = os.path.sep.join(current_dir.split(os.path.sep)[:-3])
path = os.path.join(desktop, "AutoMeetsStartup.bat - Shortcut.LNK")
wDir = f"{os.path.sep.join(current_dir.split(os.path.sep)[:-3])}\\"
# wDir = f"{current_dir}\\"
target = f"{wDir}AutoMeetsStartup.bat"
icon = f"{wDir}app.ico"

Odd = []
Even = []
FridaySet = [4]

regex = '^[a-z0-9]+[\._]?[a-z0-9]+[@]\w+[.]\w+$'

# MB_OK = 0
# MB_OKCANCEL = 1
# MB_ABORTRETRYIGNORE = 2
# MB_YESNOCANCEL = 3
# MB_YESNO = 4
# MB_RETRYNO = 5
# MB_CANCELTRYAGAINCONTINUE = 6

# IDOK = 0
# IDCANCEL = 2
# IDABORT = 3
# IDYES = 6
# IDNO = 7

# MB_HELP = 0x4000
# ICON_EXLAIM = 0x30
# ICON_INFO = 0x40
# ICON_STOP = 0x10


# def Mbox(title, text, style):
#     return ctypes.windll.user32.MessageBoxW(0, text, title, style)


# def exit_handler(driver):
#     isClosed = isBrowserClosed(driver)

#     if isClosed != True:
#         mbox = Mbox("Chrome Still Open!",
#                     "Are you sure you want to close AutoMeets because if you do, the Chrome Window will also close.", MB_YESNO | ICON_EXLAIM)
#         if mbox == IDYES:
#             pass


# def isBrowserClosed(driver):
#     isClosed = False
#     try:
#         title = driver.title
#     except:
#         isClosed = True

#     return isClosed


def setUp():
    print(f"{Style.RESET_ALL}")
    print(f"Welcome to {Fore.GREEN}AutoMeets!{Fore.RESET}")
    print("This is a program that will automatically launch Google Meets when it is time.")
    print("Before we get started, I will require a few things.\n")
    EMAIL = input(
        "Please provide your school email here (None of this information will be gathered):")

    while not re.search(regex, EMAIL):
        print(f"\n{Fore.RED}INVALID EMAIL!{Fore.RESET}")
        EMAIL = input(
            "Please provide your actual school email here (None of this information will be gathered):")

    if re.search(regex, EMAIL):
        print(f"\n{Fore.YELLOW}VALID EMAIL!{Fore.RESET}")

    PASSWORD = input(
        "\nNow, please provide your school password here (None of this information will be gathered):")
    CONFIRMPASS = input("Please retype your school password to validate it:")

    while CONFIRMPASS != PASSWORD:
        print(f"\n{Fore.RED}CONFIM PASSWORD DOESN'T MATCH!{Fore.RESET}")
        PASSWORD = input(
            "Please provide your school password here (None of this information will be gathered):")
        CONFIRMPASS = input(
            "Please retype your school password to validate it:")

    if CONFIRMPASS == PASSWORD:
        print(f"\n{Fore.YELLOW}REGISTERED!{Fore.RESET}\n")

    P1Ans = input(
        'Please provide the name of your class followed by the code/link associated with it for Period 1 (Please seperate the class name and meet code/link with a comma and space). If you have a Free Period, please type in "None" for the class name and the meet code with a comma and space to seperate it:')
    P1Ans = P1Ans.casefold()

    while ", " not in P1Ans:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        P1Ans = input(
            'Please provide the name of your class FOLLOWED by the code/link associated with it for Period 1 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please provide "None" for the class name and the meet code with a comma and space to seperate it:')
        P1Ans = P1Ans.casefold()

    P1Ans = P1Ans.split(", ")

    P1LinkCode = input(
        'Did you specify a code or a link for the Google Meet? (Code/Link). If you have a Free Period, please type "None":')
    P1LinkCode = P1LinkCode.casefold()

    while (P1LinkCode != "code" and P1LinkCode != "link" and P1LinkCode != "none") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        P1LinkCode = input(
            'Please provide "Code" if you specified a code for the Google Meets or "Link" if you specified a link for the Google Meets. If you have a Free Period, please type "None":')
        P1LinkCode = P1LinkCode.casefold()

    P1Name, P1Code = [P1Ans[i] for i in (0, 1)]

    P2Ans = input(
        '\nPlease provide the name of your class followed by the code/link associated with it for Period 2 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please type in "None" for the class name and the meet code with a comma and space to seperate it:')
    P2Ans = P2Ans.casefold()

    while ", " not in P2Ans:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        P2Ans = input(
            'Please provide the name of your class FOLLOWED by the code/link associated with it for Period 2 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please provide "None" for the class name and the meet code with a comma and space to seperate it:')
        P2Ans = P2Ans.casefold()

    P2Ans = P2Ans.split(", ")

    P2LinkCode = input(
        'Did you specify a code or a link for the Google Meet? (Code/Link). If you have a Free Period, please type "None":')
    P2LinkCode = P2LinkCode.casefold()

    while (P2LinkCode != "code" and P2LinkCode != "link" and P2LinkCode != "none") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        P2LinkCode = input(
            'Please provide "Code" if you specified a code for the Google Meets or "Link" if you specified a link for the Google Meets. If you have a Free Period, please type "None":')
        P2LinkCode = P2LinkCode.casefold()
        print(Fore.RESET, end='')

    P2Name, P2Code = [P2Ans[i] for i in (0, 1)]

    P3Ans = input(
        '\nPlease provide the name of your class followed by the code/link associated with it for Period 3 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please type in "None" for the class name and the meet code with a comma and space to seperate it:')
    P3Ans = P3Ans.casefold()

    while ", " not in P3Ans:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        P3Ans = input(
            'Please provide the name of your class FOLLOWED by the code/link associated with it for Period 3 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please provide "None" for the class name and the meet code with a comma and space to seperate it:')
        P3Ans = P3Ans.casefold()

    P3Ans = P3Ans.split(", ")

    P3LinkCode = input(
        'Did you specify a code or a link for the Google Meet? (Code/Link). If you have a Free Period, please type "None":')
    P3LinkCode = P3LinkCode.casefold()

    while (P3LinkCode != "code" and P3LinkCode != "link" and P3LinkCode != "none") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        P3LinkCode = input(
            'Please provide "Code" if you specified a code for the Google Meets or "Link" if you specified a link for the Google Meets. If you have a Free Period, please type "None":')
        P3LinkCode = P3LinkCode.casefold()

    P3Name, P3Code = [P3Ans[i] for i in (0, 1)]

    P4Ans = input(
        '\nPlease provide the name of your class followed by the code/link associated with it for Period 4 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please type in "None" for the class name and the meet code with a comma and space to seperate it:')
    P4Ans = P4Ans.casefold()

    while ", " not in P4Ans:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        P4Ans = input(
            'Please provide the name of your class FOLLOWED by the code/link associated with it for Period 4 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please provide "None" for the class name and the meet code with a comma and space to seperate it:')
        P4Ans = P4Ans.casefold()

    P4Ans = P4Ans.split(", ")

    P4LinkCode = input(
        'Did you specify a code or a link for the Google Meet? (Code/Link). If you have a Free Period, please type "None":')
    P4LinkCode = P4LinkCode.casefold()

    while (P4LinkCode != "code" and P4LinkCode != "link" and P4LinkCode != "none") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        P4LinkCode = input(
            'Please provide "Code" if you specified a code for the Google Meets or "Link" if you specified a link for the Google Meets. If you have a Free Period, please type "None":')
        P4LinkCode = P4LinkCode.casefold()

    P4Name, P4Code = [P4Ans[i] for i in (0, 1)]

    P5Ans = input(
        '\nPlease provide the name of your class followed by the code/link associated with it for Period 5 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please type in "None" for the class name and the meet code with a comma and space to seperate it:')
    P5Ans = P5Ans.casefold()

    while ", " not in P5Ans:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        P5Ans = input(
            'Please provide the name of your class FOLLOWED by the code/link associated with it for Period 5 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please provide "None" for the class name and the meet code with a comma and space to seperate it:')
        P5Ans = P5Ans.casefold()

    P5Ans = P5Ans.split(", ")

    P5LinkCode = input(
        'Did you specify a code or a link for the Google Meet? (Code/Link). If you have a Free Period, please type "None":')
    P5LinkCode = P5LinkCode.casefold()

    while (P5LinkCode != "code" and P5LinkCode != "link" and P5LinkCode != "none") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        P5LinkCode = input(
            'Please provide "Code" if you specified a code for the Google Meets or "Link" if you specified a link for the Google Meets. If you have a Free Period, please type "None":')
        P5LinkCode = P5LinkCode.casefold()

    P5Name, P5Code = [P5Ans[i] for i in (0, 1)]

    P6Ans = input(
        '\nPlease provide the name of your class followed by the code/link associated with it for Period 6 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please type in "None" for the class name and the meet code with a comma and space to seperate it:')
    P6Ans = P6Ans.casefold()

    while ", " not in P6Ans:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        P6Ans = input(
            'Please provide the name of your class FOLLOWED by the code/link associated with it for Period 6 (Please seperate the class name and meet code with a comma and space). If you have a Free Period, please provide "None" for the class name and the meet code with a comma and space to seperate it:')
        P6Ans = P6Ans.casefold()

    P6Ans = P6Ans.split(", ")

    P6LinkCode = input(
        'Did you specify a code or a link for the Google Meet? (Code/Link). If you have a Free Period, please type "None":')
    P6LinkCode = P6LinkCode.casefold()

    while (P6LinkCode != "code" and P6LinkCode != "link" and P6LinkCode != "none") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        P6LinkCode = input(
            'Please provide "Code" if you specified a code for the Google Meets or "Link" if you specified a link for the Google Meets. If you have a Free Period, please type "None":')
        P6LinkCode = P6LinkCode.casefold()

    P6Name, P6Code = [P6Ans[i] for i in (0, 1)]

    if not os.path.exists(saveinfo_path):
        os.mkdir(saveinfo_path)

    with open(f"{saveinfo_path}INFO.txt", "ab") as f:
        pickle.dump(EMAIL, f)
        pickle.dump(PASSWORD, f)
        pickle.dump(P1Name, f)
        pickle.dump(P1Code, f)
        pickle.dump(P1LinkCode, f)
        pickle.dump(P2Name, f)
        pickle.dump(P2Code, f)
        pickle.dump(P2LinkCode, f)
        pickle.dump(P3Name, f)
        pickle.dump(P3Code, f)
        pickle.dump(P3LinkCode, f)
        pickle.dump(P4Name, f)
        pickle.dump(P4Code, f)
        pickle.dump(P4LinkCode, f)
        pickle.dump(P5Name, f)
        pickle.dump(P5Code, f)
        pickle.dump(P5LinkCode, f)
        pickle.dump(P6Name, f)
        pickle.dump(P6Code, f)
        pickle.dump(P6LinkCode, f)

    print(f"\n{Fore.YELLOW}Information has been saved to INFO.txt!{Fore.RESET}")

    dayOffAnsYN = input(
        "\nDo you have any days off through the week? (y/n):")
    dayOffAnsYN = dayOffAnsYN.casefold()

    while (dayOffAnsYN != "y" and dayOffAnsYN != "yes" and dayOffAnsYN != "n" and dayOffAnsYN != "no") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        dayOffAnsYN = input(
            'Please provide "y" if there are days off throughout the week or provide "n" if there is not any days off throughout the week:')
        dayOffAnsYN = dayOffAnsYN.casefold()

    if dayOffAnsYN == "y" or dayOffAnsYN == "yes":
        daysOff = input(
            "\nWhich days do you have off? (Please make sure to seperate them with commas and a space):")
        daysOff = daysOff.casefold()
        daysOffAns = daysOff.split(", ")

        if "monday" in daysOffAns:
            daysOffNum.insert(0, 0)

        if "tuesday" in daysOffAns:
            daysOffNum.insert(1, 1)

        if "wednesday" in daysOffAns:
            daysOffNum.insert(2, 2)

        if "thursday" in daysOffAns:
            daysOffNum.insert(3, 3)

        if "friday" in daysOffAns:
            daysOffNum.insert(4, 4)

        for i in daysOffNum:
            if i in DaysofWeek:
                DaysofWeek.remove(i)
            elif i in FridaySet:
                FridaySet.remove(i)

    beginDayAns = input(
        "\nDoes the week start with an Odd or Even day?:")
    beginDayAns = beginDayAns.casefold()

    while (beginDayAns != "odd" and beginDayAns != "even") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        beginDayAns = input(
            f'Please provide "Odd" if the week starts with 1-3-5 day or provide "Even" if the week starts with 2-4-6 day:')
        beginDayAns = beginDayAns.casefold()

    t = 0
    o = 0
    e = 0

    if beginDayAns == "odd":
        for i in DaysofWeek:
            if t == 0:
                Odd.insert(0, i)
                t = 1
                o += 1
            elif t == 1:
                Even.insert(e, i)
                t = 0
                e += 1

    elif beginDayAns == "even":
        for i in DaysofWeek:
            if t == 0:
                Even.insert(e, i)
                t = 1
                e += 1
            elif t == 1:
                Odd.insert(o, i)
                t = 0
                o += 1

    fridayDayAns = input(
        "\nWhich class do you have this friday? (P1, P2, P3, P4, P5, P6):")
    fridayDayAns = fridayDayAns.casefold()

    while (fridayDayAns != "p1" and fridayDayAns != "p2" and fridayDayAns != "p3" and fridayDayAns != "p4" and fridayDayAns != "p5" and fridayDayAns != "p6") == True:
        print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
        fridayDayAns = input(
            f'Please provide "P1", "P2", "P3", "P4", "P5", or "P6" about which class you have this friday:')
        fridayDayAns = fridayDayAns.casefold()
        print(Fore.RESET, end='')

    if "p1" in fridayDayAns:
        fridayName = P1Name
        fridayCode = P1Code
        fridayLinkCode = P1LinkCode
    elif "p2" in fridayDayAns:
        fridayName = P2Name
        fridayCode = P2Code
        fridayLinkCode = P2LinkCode
    elif "p3" in fridayDayAns:
        fridayName = P3Name
        fridayCode = P3Code
        fridayLinkCode = P3LinkCode
    elif "p4" in fridayDayAns:
        fridayName = P4Name
        fridayCode = P4Code
        fridayLinkCode = P4LinkCode
    elif "p5" in fridayDayAns:
        fridayName = P5Name
        fridayCode = P5Code
        fridayLinkCode = P5LinkCode
    elif "p6" in fridayDayAns:
        fridayName = P6Name
        fridayCode = P6Code
        fridayLinkCode = P6LinkCode

    if not os.path.exists(saveinfo_path):
        os.mkdir(saveinfo_path)

    with open(f"{saveinfo_path}ClassesWeekly.txt", "ab") as w:
        pickle.dump(fridayName, w)
        pickle.dump(fridayCode, w)
        pickle.dump(fridayLinkCode, w)
        pickle.dump(Odd, w)
        pickle.dump(Even, w)
        pickle.dump(FridaySet, w)

    sundaySetUpVar = True

    with open(f"{saveinfo_path}SundaySetupDone.txt", "ab") as s:
        pickle.dump(sundaySetUpVar, s)

    print(
        f"\n{Fore.YELLOW}Week Planned Out and Saved in ClassesWeekly.txt!{Fore.RESET}")

    startUpAns = input(
        "\nDo you allow AutoMeets to automatically boot up when your computer starts up? (y/n):")
    startUpAns = startUpAns.casefold()

    while (startUpAns != "y" and startUpAns != "n") == True:
        print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        startUpAns = input(
            'Please provide "y" if you allow AutoMeets to automatically boot up at start up or "n" if you do not allow AutoMeets to automatically boot up at start up:')
        startUpAns = startUpAns.casefold()

    if startUpAns == "y":
        try:
            shutil.move("AutoMeetsStartup.bat", f"{wDir}AutoMeetsStartup.bat")

            shell = Dispatch('WScript.Shell')
            shortcut = shell.CreateShortCut(path)
            shortcut.Targetpath = target
            shortcut.WorkingDirectory = wDir
            shortcut.IconLocation = icon
            shortcut.save()

            os.rename("../../../AutoMeetsStartup.bat - Shortcut.LNK",
                      "../../../AutoMeetsStartup.LNK")
            shutil.move("../../../AutoMeetsStartup.LNK", startup_path)

            print(
                f"\n{Fore.YELLOW}Now on, AutoMeets will boot up with the boot up of your computer.{Fore.RESET}")
            bootUpWorks = True

            with open(f"{saveinfo_path}BOOTUP.txt", "ab") as f:
                pickle.dump(bootUpWorks, f)
        except:
            print(
                f"\n{Fore.RED}Trouble making AutoMeets boot up with your computer!{Fore.RESET}")
            print(
                "Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
            time.sleep(10)
            exit(0)

    print("\nEverything that you just filled out was needed in order to know what each class name was and how to enter the Google Meet in order to remind you when it is time.")
    print("This program will run 24/7 in the background and will give you a notification to look at AutoMeets to launch your class.")
    print("If your class hasn't started yet, AutoMeets will copy the code/link into your clipboard so you can always paste it when you feel like it is time.")
    print("Feel free to close the app once you launch it because it will work in the background.")
    print('Whenever you want to shut down the program, navigate to the System Tray, right-click on AutoMeets, and press "Quit".')
    print("Currently this program is in a Console Interface but this will change in the future.")
    print("Every Sunday, the program will ask you a few questions in order to figure out how to plan out your week.")
    print("This program uses 0% of your information, everything is stored locally.")
    print('If you ever wish to delete your personal information, navigate to the System Tray, right-click on AutoMeets, and press "Delete My Personal Information".')
    print('If you ever wish to delete your Weekly Schedule for this week, navigate to the System Tray, right-click on AutoMeets, and press "Delete My Weekly Schedule".')
    print("Now reopen AutoMeets and you can fill out your personal information again.")
    print("AutoMeets is currently in its infancy so please bare with any issues and crashes. These can always be reported to Kartik on Discord(KarTech:tm:#3772) or Mahavir on Discord(TheRedDragon#3414).")
    print("Thank You for using the tool, I hope you will enjoy it and any feedback can be send directly to Kartik on Discord(KarTech:tm:#3772) or Mahavir on Discord(TheRedDragon#3414).")

    firstTime = False

    with open(f"{saveinfo_path}INFO.txt", "ab") as f:
        pickle.dump(firstTime, f)


def startUp():
    NameEE = randint(0, 100)
    # NameEE = 5

    if NameEE <= 5:
        print(
            f"{Fore.LIGHTYELLOW_EX}AutoEats{Fore.RESET} [Buttermilk Pancakes 1.1.6]")
        print(f"Baked by Kartik Yedumbaka in confection with Mahavir Dondeti.")
    else:
        print(f"{Fore.GREEN}AutoMeets{Fore.RESET} [Beta 1.1.6]")
        print(f"Made by Kartik Yedumbaka in association with Mahavir Dondeti.")

    EasterEggNum = randint(0, 100)
    # EasterEggNum = 15

    if EasterEggNum <= 15:
        os.startfile("Kartik_Scare.mp4")

    if date.today().weekday() == 4:
        FunkyFridayEE = randint(0, 100)

        if FunkyFridayEE <= 25:
            print(f"\n{Fore.YELLOW}FUNKY MONKEY FRIDAY!!!")
            print("\nFUNKY MONKEY FRIDAY!!!")
            print(f"\nFUNKY MONKEY FRIDAY!!!{Fore.RESET}")

    firstTime = True
    bootUpWorks = False

    if os.path.exists(f"{saveinfo_path}BOOTUP.txt") and os.path.exists(f"{startup_dir}AutoMeetsST.exe - Shortcut.LNK"):
        os.remove(f"{saveinfo_path}BOOTUP.txt")

    try:
        EMAIL, PASSWORD, P1Name, P1Code, P1LinkCode, P2Name, P2Code, P2LinkCode, P3Name, P3Code, P3LinkCode, P4Name, P4Code, P4LinkCode, P5Name, P5Code, P5LinkCode, P6Name, P6Code, P6LinkCode, firstTime = readVarsFirstTime()
        bootUpWorks = bootUpVarFT()
    except:
        pass

    if firstTime == True:
        setUp()

    if firstTime == False and bootUpWorks != True:
        try:
            if os.path.exists(f"{startup_dir}AutoMeetsST.exe - Shortcut.LNK"):
                os.remove(f"{startup_dir}AutoMeetsST.exe - Shortcut.LNK")
                print(
                    f"\n{Fore.YELLOW}Sucessfully uninstalled old AutoMeets Startup!{Fore.YELLOW}")

            shutil.move("AutoMeetsStartup.bat", f"{wDir}AutoMeetsStartup.bat")

            shell = Dispatch('WScript.Shell')
            shortcut = shell.CreateShortCut(path)
            shortcut.Targetpath = target
            shortcut.WorkingDirectory = wDir
            shortcut.IconLocation = icon
            shortcut.save()

            os.rename("../../../AutoMeetsStartup.bat - Shortcut.LNK",
                      "../../../AutoMeetsStartup.LNK")
            shutil.move("../../../AutoMeetsStartup.LNK", startup_path)

            print(
                f"\n{Fore.YELLOW}Now on, AutoMeets will boot up with the boot up of your computer.{Fore.RESET}")
            bootUpWorks = True

            with open(f"{saveinfo_path}BOOTUP.txt", "ab") as f:
                pickle.dump(bootUpWorks, f)
        except:
            print(
                f"\n{Fore.RED}Trouble making AutoMeets boot up with your computer!{Fore.RESET}")
            print(
                "Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
            pass

    sundaySetUp()

    global startScan
    startScan = True

    global automationFinish

    timeScanLook()


def core(name, code, linkorcode):
    EMAIL, PASSWORD, P1Name, P1Code, P1LinkCode, P2Name, P2Code, P2LinkCode, P3Name, P3Code, P3LinkCode, P4Name, P4Code, P4LinkCode, P5Name, P5Code, P5LinkCode, P6Name, P6Code, P6LinkCode, firstTime = readVarsConst()

    notification(name)

    launchAns = input("\nDo you want to launch Google Meets (y/n):")
    launchAns = launchAns.casefold()

    while (launchAns != "y" and launchAns != "yes" and launchAns != "n" and launchAns != "no") == True:
        print(f"\n{Fore.RED}INVAILD INPUT!{Fore.RESET}")
        launchAns = input(
            'Please provide "y" if you wish to launch Google Meets or "n" if you do not wish to launch Google Meets:')
        launchAns = launchAns.casefold()

    pc.copy(code)

    if launchAns == "y" or launchAns == "yes":
        print(f"\nLaunching Google Meets for {name}.")

        if linkorcode == "code":
            options = Options()
            options.add_argument("start-maximized")
            options.add_extension(
                f"{current_dir}\\Extensions\\Google Grid View.crx")
            options.add_extension(
                f"{current_dir}\\Extensions\\Visual Effects.crx")

            browser = webdriver.Chrome(
                "chromedriver.exe", options=options)
            browser.implicitly_wait(60)

            browser.get(
                'https://accounts.google.com/ServiceLogin?ltmpl=meet&continue=https%3A%2F%2Fmeet.google.com%3Fhs%3D193&')

            browser.find_element_by_xpath(
                '//*[@id="identifierId"]').send_keys(EMAIL)
            browser.find_element_by_xpath('//*[@id="identifierNext"]').click()
            browser.find_element_by_xpath(
                '//*[@id="password"]/div[1]/div/div[1]/input').send_keys(PASSWORD)
            browser.find_element_by_xpath(
                '//*[@id="passwordNext"]/div/button/div[2]').click()
            browser.find_element_by_class_name('XyfuP').click()
            browser.find_element_by_xpath(
                '//*[@id="yDmH0d"]/div[3]/div/div[2]/span/div/div[2]/div[1]/div[1]/input').send_keys(code)
            browser.find_element_by_xpath(
                '//*[@id="yDmH0d"]/div[3]/div/div[2]/span/div/div[4]/div[2]/div/span/span').click()
        elif linkorcode == "link":
            options = Options()
            options.add_argument("start-maximized")
            options.add_extension(
                f".\\Extensions\\Google Grid View.crx")
            options.add_extension(
                f".\\Extensions\\Visual Effects.crx")

            browser = webdriver.Chrome(
                "chromedriver.exe", options=options)
            browser.implicitly_wait(60)

            browser.get("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin")

            browser.find_element_by_xpath(
                '//*[@id="identifierId"]').send_keys(EMAIL)
            browser.find_element_by_xpath(
                '//*[@id="identifierNext"]/div/button/div[2]').click()
            browser.find_element_by_xpath(
                '//*[@id="password"]/div[1]/div/div[1]/input').send_keys(PASSWORD)
            browser.find_element_by_xpath(
                '//*[@id="passwordNext"]/div/button/div[2]').click()

            browser.get(code)

        print(f"\n{Fore.YELLOW}Finished Automation.{Fore.RESET}")

    global startScan
    startScan = True

    global automationFinish
    automationFinish = True

    timeScanLook()


def timeScanLook():
    print(f"\n{Fore.YELLOW}Checking Time...{Fore.RESET}")
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
        print(f"\n{Fore.RED}Trouble retrieving information...{Fore.RESET}")
        print("Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
        time.sleep(10)
        exit(0)


def readVarsFirstTime():
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
        # print(f"\n{Fore.RED}Trouble retrieving information...{Fore.RESET}")
        # print("Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
        # time.sleep(10)
        pass


def bootUpVarFT():
    try:
        with open(f'{saveinfo_path}BOOTUP.txt', 'rb') as f:
            bootUpWorks = pickle.load(f)

        return bootUpWorks
    except:
        # print(f"\n{Fore.RED}Trouble retrieving information...{Fore.RESET}")
        # print("Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
        # time.sleep(10)
        pass


def SundaySetupVarFT():
    try:
        with open(f'{saveinfo_path}SundaySetupDone.txt', 'rb') as f:
            sundaySetUpVar = pickle.load(f)

        return sundaySetUpVar
    except:
        # print(f"\n{Fore.RED}Trouble retrieving information...{Fore.RESET}")
        # print("Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
        # time.sleep(10)
        pass


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
        print(f"\n{Fore.RED}Trouble retrieving information...{Fore.RESET}")
        print("Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
        time.sleep(10)
        exit(0)


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
                    core(P1Name, P1Code, P1LinkCode)

                elif current_time >= "10:20" and current_time < "10:25" and automationFinish == False or not "none" in P3Name and current_time >= "10:20" and current_time < "10:25" and automationFinish == False:
                    startScan = False
                    core(P3Name, P3Code, P3LinkCode)

                elif current_time >= "12:45" and current_time < "12:50" and automationFinish != True or not "none" in P5Name and current_time >= "12:45" and current_time < "12:50" and automationFinish == False:
                    startScan = False
                    core(P5Name, P5Code, P5LinkCode)

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
                    core(P2Name, P2Code, P2LinkCode)

                elif current_time >= "10:20" and current_time < "10:25" and automationFinish == False or not "none" in P4Name and current_time >= "10:20" and current_time < "10:25" and automationFinish == False:
                    startScan = False
                    core(P4Name, P4Code, P4LinkCode)

                elif current_time >= "12:45" and current_time < "12:50" and automationFinish == False or not "none" in P6Name and current_time >= "12:45" and current_time < "12:50" and automationFinish == False:
                    startScan = False
                    core(P6Name, P6Code, P6LinkCode)

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
                core(fridayName, fridayCode, fridayLinkCode)

            elif current_time >= "09:15" and current_time <= "09:16" and automationFinish == True or not "none" in fridayName and current_time >= "09:15" and current_time <= "09:16" and automationFinish == True:
                automationFinish = False

            else:
                time.sleep(1)
    else:
        time.sleep(1)


def notification(name):
    toast = ToastNotifier()
    toast.show_toast(
        "Class Reminder", f"{name} is going to start in 5 minutes. Go to AutoMeets to launch the meet when you are ready.", duration=6, threaded=True, icon_path="app.ico")


def sundaySetUp():
    sundaySetUpVar = False
    sundaySetUpVar = SundaySetupVarFT()

    # Monday is 0, Tuesday is 1, Wednesday is 2, Thursday is 3... Sunday is 6
    if not date.today().weekday() == 5 and sundaySetUpVar != True:
        EMAIL, PASSWORD, P1Name, P1Code, P1LinkCode, P2Name, P2Code, P2LinkCode, P3Name, P3Code, P3LinkCode, P4Name, P4Code, P4LinkCode, P5Name, P5Code, P5LinkCode, P6Name, P6Code, P6LinkCode, firstTime = readVarsConst()

        try:
            os.remove(f"{saveinfo_path}ClassesWeekly.txt")
        except:
            # print(f"\n{Fore.RED}ERROR!{Fore.RESET}")
            # print(
            #     "Consider direct messaging Kartik on Discord(KarTech:tm:#3772) the problem.")
            # time.sleep(5)
            # exit(0)
            pass

        dayOffAnsYN = input(
            "\nDo you have any days off through the week? (y/n):")
        dayOffAnsYN = dayOffAnsYN.casefold()

        while (dayOffAnsYN != "y" and dayOffAnsYN != "yes" and dayOffAnsYN != "n" and dayOffAnsYN != "no") == True:
            print(f"\n{Fore.RED}INVAILD INPUT!{Fore.RESET}")
            dayOffAnsYN = input(
                'Please provide "y" if there are days off throughout the week or provide "n" if there is not any days off throughout the week:')
            dayOffAnsYN = dayOffAnsYN.casefold()

        if dayOffAnsYN == "y" or dayOffAnsYN == "yes":
            daysOff = input(
                "\nWhich days do you have off? (Please make sure to seperate them with commas and a space):")
            daysOff = daysOff.casefold()
            daysOffAns = daysOff.split(", ")

            if "monday" in daysOffAns:
                daysOffNum.insert(0, 0)

            if "tuesday" in daysOffAns:
                daysOffNum.insert(1, 1)

            if "wednesday" in daysOffAns:
                daysOffNum.insert(2, 2)

            if "thursday" in daysOffAns:
                daysOffNum.insert(3, 3)

            if "friday" in daysOffAns:
                daysOffNum.insert(4, 4)

            for i in daysOffNum:
                if i in DaysofWeek:
                    DaysofWeek.remove(i)
                elif i in FridaySet:
                    FridaySet.remove(i)

        beginDayAns = input(
            "\nDoes the week start with an Odd or Even day?:")
        beginDayAns = beginDayAns.casefold()

        while (beginDayAns != "odd" and beginDayAns != "even") == True:
            print(f"{Fore.RED}INVAILD INPUT!{Fore.RESET}")
            beginDayAns = input(
                f'Please provide "Odd" if the week starts with 1-3-5 day or provide "Even" if the week starts with 2-4-6 day:')
            beginDayAns = beginDayAns.casefold()

        t = 0
        o = 0
        e = 0

        if beginDayAns == "odd":
            for i in DaysofWeek:
                if t == 0:
                    Odd.insert(0, i)
                    t = 1
                    o += 1
                elif t == 1:
                    Even.insert(e, i)
                    t = 0
                    e += 1

        elif beginDayAns == "even":
            for i in DaysofWeek:
                if t == 0:
                    Even.insert(e, i)
                    t = 1
                    e += 1
                elif t == 1:
                    Odd.insert(o, i)
                    t = 0
                    o += 1

        fridayDayAns = input(
            "\nWhich class do you have this friday? (P1, P2, P3, P4, P5, P6):")
        fridayDayAns = fridayDayAns.casefold()

        while (fridayDayAns != "p1" and fridayDayAns != "p2" and fridayDayAns != "p3" and fridayDayAns != "p4" and fridayDayAns != "p5" and fridayDayAns != "p6") == True:
            print(f"\n{Fore.RED}INVALID INPUT!{Fore.RESET}")
            fridayDayAns = input(
                f'Please provide "P1", "P2", "P3", "P4", "P5", or "P6" about which class you have this friday:')
            fridayDayAns = fridayDayAns.casefold()
            print(Fore.RESET, end='')

        if "p1" in fridayDayAns:
            fridayName = P1Name
            fridayCode = P1Code
            fridayLinkCode = P1LinkCode
        elif "p2" in fridayDayAns:
            fridayName = P2Name
            fridayCode = P2Code
            fridayLinkCode = P2LinkCode
        elif "p3" in fridayDayAns:
            fridayName = P3Name
            fridayCode = P3Code
            fridayLinkCode = P3LinkCode
        elif "p4" in fridayDayAns:
            fridayName = P4Name
            fridayCode = P4Code
            fridayLinkCode = P4LinkCode
        elif "p5" in fridayDayAns:
            fridayName = P5Name
            fridayCode = P5Code
            fridayLinkCode = P5LinkCode
        elif "p6" in fridayDayAns:
            fridayName = P6Name
            fridayCode = P6Code
            fridayLinkCode = P6LinkCode

        if not os.path.exists(saveinfo_path):
            os.mkdir(saveinfo_path)

        with open(f"{saveinfo_path}ClassesWeekly.txt", "ab") as w:
            pickle.dump(fridayName, w)
            pickle.dump(fridayCode, w)
            pickle.dump(fridayLinkCode, w)
            pickle.dump(Odd, w)
            pickle.dump(Even, w)
            pickle.dump(FridaySet, w)

        sundaySetUpVar = True

        with open(f"{saveinfo_path}SundaySetupDone.txt", "ab") as s:
            pickle.dump(sundaySetUpVar, s)

        print(
            f"\n{Fore.YELLOW}Week Planned Out and Saved in ClassesWeekly.txt!{Fore.RESET}")

    if date.today().weekday() == 5 and sundaySetUpVar == True:
        os.remove(f"{saveinfo_path}SundaySetupDone.txt")


if __name__ == "__main__":
    startUp()
