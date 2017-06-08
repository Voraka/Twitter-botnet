using System;

namespace Twient
{
	// Token: 0x0200000B RID: 11
	public class GlobalVars
	{
		// Token: 0x04000015 RID: 21
		public static string Autostart = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

		public static string Backpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		
		// Token: 0x04000011 RID: 17
		public static bool Beeper = false;

		// Token: 0x04000013 RID: 19
		public static bool Blockinput = false;

		// Token: 0x04000014 RID: 20
		public static bool filemgr = false;

		// Token: 0x04000012 RID: 18
		public static bool Monitor = false;

		// Token: 0x0400000E RID: 14
		public static string path = "C:\\Program Files (x86)\\PDTS\\Twient\\";

		public static string[] cmds;
		
		// Token: 0x0400000F RID: 15
		public static string Version = "2.0.1";
		
		// Token: 0x04000010 RID: 16
		public static string VersionPath = GlobalVars.path + GlobalVars.Version;
		
		public static string DesktopIP = "192.168.0.1";
	}
}
