using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace Twient
{
	// Token: 0x02000002 RID: 2
	internal class Clientinfo
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002108 File Offset: 0x00000308
		public static string FriendlyName()
		{
			string result;
			try
			{
				string registryString = Clientinfo.GetRegistryString("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName");
				string registryString2 = Clientinfo.GetRegistryString("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CSDVersion");
				if (registryString != "")
				{
					result = (registryString.StartsWith("Microsoft") ? "" : "Microsoft ") + registryString + ((registryString2 != "") ? (" " + registryString2) : "");
				}
				else
				{
					result = "";
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		public static string GetCountry()
		{
			string result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(256);
				int localeInfo = Clientinfo.GetLocaleInfo(1024u, 4098u, stringBuilder, stringBuilder.Capacity);
				if (localeInfo > 0)
				{
					result = stringBuilder.ToString().Substring(0, localeInfo - 1);
				}
				else
				{
					result = string.Empty;
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000001 RID: 1
		[DllImport("kernel32.dll")]
		private static extern int GetLocaleInfo(uint Locale, uint LCType, [Out] StringBuilder lpLCData, int cchData);

		// Token: 0x06000003 RID: 3 RVA: 0x000020B8 File Offset: 0x000002B8
		public static string GetRegistryString(string path, string key)
		{
			string result;
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(path);
				if (registryKey == null)
				{
					result = "";
				}
				else
				{
					result = (string)registryKey.GetValue(key);
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021A8 File Offset: 0x000003A8
		public static string GetSerialKey()
		{
			string text = "";
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion", false);
				byte[] sourceArray = (byte[])registryKey.GetValue("DigitalProductID");
				byte[] array = new byte[15];
				Array.Copy(sourceArray, 52, array, 0, 15);
				string text2 = "BCDFGHJKMPQRTVWXY2346789";
				for (int i = 0; i <= 24; i++)
				{
					short num = 0;
					for (int j = 14; j >= 0; j += -1)
					{
						num = Convert.ToInt16((int)(num * 256 ^ (short)array[j]));
						array[j] = Convert.ToByte(Convert.ToInt32((int)(num / 24)));
						num = Convert.ToInt16((int)(num % 24));
					}
					text = text2.Substring((int)num, 1) + text;
				}
				for (int k = 4; k >= 1; k += -1)
				{
					text = text.Insert(k * 5, "-");
				}
			}
			catch
			{
				return "****-****-****-****";
			}
			return text;
		}
	}
}
