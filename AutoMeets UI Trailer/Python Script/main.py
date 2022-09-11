import time
from colorama import init, Fore, Back, Style

# Allows color
init(convert=True)

print(f"{Fore.GREEN}AutoMeets{Fore.RESET} [Beta 1.1.6]")
print(f"Made by Kartik Yedumbaka in association with Mahavir Dondeti.\n")

time.sleep(1)
input("Would you like to update? (Yes/No):")
time.sleep(1000)