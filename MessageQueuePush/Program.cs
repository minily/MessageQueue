using System.ServiceProcess;

namespace Zhongmubao.Push.WinServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MsgPushService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
