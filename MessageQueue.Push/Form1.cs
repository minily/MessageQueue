using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using Zhongmubao.Push.Service;

namespace Zhongmubao.Push
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new SystemService().Push();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Application.EnableVisualStyles();
            
            //Application.SetCompatibleTextRenderingDefault(false);
            
            //string sysDisk = Environment.SystemDirectory.Substring(0, 3);
            
            //string dotNetPath = sysDisk + @"WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe";//因为当前用的是4.0的环境  
            
            //string serviceExePath = Application.StartupPath + @"\Zhongmubao.Push.exe";//把服务的exe程序拷贝到了当前运行目录下，所以用此路径  
            
            //string serviceInstallCommand = string.Format(@"{0}  {1}", dotNetPath, serviceExePath);//安装服务时使用的dos命令  
            
            //string serviceUninstallCommand = string.Format(@"{0} -U {1}", dotNetPath, serviceExePath);//卸载服务时使用的dos命令  
            
            //try
            //{
            //    if (File.Exists(dotNetPath))
            //    {
            //        string[] cmd = new string[] { serviceUninstallCommand };
            
            //        Cmd(cmd);
            
            //        CloseProcess("cmd.exe");
            //    }
            
            //}
            //catch
            //{
            //    // ignored
            //}
            
            //Thread.Sleep(1000);
            
            //try
            //{
            //    if (File.Exists(dotNetPath))
            //    {
            //        string[] cmd = new string[] { serviceInstallCommand };
            
            //        Cmd(cmd);
            
            //        CloseProcess("cmd.exe");
            //    }
            
            //}
            //catch
            //{
            //    // ignored
            //}
            
            //try
            //{
            //    Thread.Sleep(3000);
                
            //    ServiceController sc = new ServiceController("Zhongmubao.Push");
                
            //    if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) || (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            //    {
            //        sc.Start();
            //    }
            //    sc.Refresh();
            //}
            //catch
            //{
            //    // ignored
            //}
        }
        /// <summary>  
        /// 运行CMD命令  
        /// </summary>  
        /// <param name="cmd">命令</param>  
        /// <returns></returns>  
        public static string Cmd(string[] cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.AutoFlush = true;
            for (int i = 0; i < cmd.Length; i++)
            {
                p.StandardInput.WriteLine(cmd[i]);
            }
            p.StandardInput.WriteLine("exit");
            string strRst = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return strRst;
        }


        /// <summary>  
        /// 关闭进程  
        /// </summary>  
        /// <param name="procName">进程名称</param>  
        /// <returns></returns>  
        public static bool CloseProcess(string procName)
        {
            bool result = false;
            var procList = new List<string>();
            foreach (Process thisProc in Process.GetProcesses())
            {
                var tempName = thisProc.ToString();
                var begpos = tempName.IndexOf("(", StringComparison.Ordinal) + 1;
                var endpos = tempName.IndexOf(")", StringComparison.Ordinal);
                tempName = tempName.Substring(begpos, endpos - begpos);
                procList.Add(tempName);
                if (tempName == procName)
                {
                    if (!thisProc.CloseMainWindow())
                        thisProc.Kill(); // 当发送关闭窗口命令无效时强行结束进程  
                    result = true;
                }
            }
            return result;
        }
        

        private void btnStartPush_Click(object sender, EventArgs e)
        {
            new SystemService().Push();
        }
    }
}
