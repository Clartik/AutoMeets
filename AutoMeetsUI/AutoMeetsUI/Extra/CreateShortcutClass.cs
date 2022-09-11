using System;
using System.Collections.Generic;
using System.Text;
using IWshRuntimeLibrary;

namespace AutoMeetsUI
{
	public class CreateShortcutClass
	{
        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string workingDir, string shortcutDescription = "Shortcut Description")
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = shortcutDescription;   // The description of the shortcut
            //shortcut.IconLocation = $"{iconPath}";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.WorkingDirectory = workingDir;
            shortcut.Save();                                    // Save the shortcut
        }
    }
}