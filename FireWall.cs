using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;
using System.Diagnostics;
using System.Security.Principal;

namespace FireWallSwitcher
{
    public static class FireWall
    {
        private static NetFwTypeLib.INetFwMgr GetFirewallManager()
        {
            //const string CLSID_FIREWALL_MANAGER = 
            Type objType = Type.GetTypeFromProgID("HNetCfg.FwMgr");
            return Activator.CreateInstance(objType) as NetFwTypeLib.INetFwMgr;
        }

        public static bool Firewall_Is_Open()
        {
            INetFwMgr netFwMgr = GetFirewallManager();
            return netFwMgr.LocalPolicy.CurrentProfile.FirewallEnabled;
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void useCommand(string fireWall, string status)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c" + $"netsh advfirewall set {fireWall} state {status}";
            process.StartInfo.UseShellExecute = false;   //是否使用操作系统shell启动 
            process.StartInfo.CreateNoWindow = true;   //是否在新窗口中启动该进程的值 (不显示程序窗口)
            process.Start();
            //process.WaitForExit();  //等待程序执行完退出进程
            process.Close();
        }
    }
}
