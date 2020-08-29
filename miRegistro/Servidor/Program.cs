using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using ChatServer.Chat;
using System.Drawing;
using System.Windows.Forms;

namespace Servidor
{
    class Program
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        static NotifyIcon notifyIcon = new NotifyIcon();

        static void Main(string[] args)
        {
            // Hide console APP
            IntPtr myWindow = GetConsoleWindow();
            
            ShowWindow(myWindow, SW_HIDE);
            Thread.Sleep(5000);

            Server server = new Server();
            Console.ReadKey();
        }

        private static void CreateNotifyicon()
        {
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(@"C:\WINDOWS\system32\notepad.exe");
            notifyIcon.Text = "Servidor";
            notifyIcon.Visible = true;

            ContextMenu menu = new ContextMenu();
            notifyIcon.ContextMenu = menu;

            Application.Run();
        }
    }
}
