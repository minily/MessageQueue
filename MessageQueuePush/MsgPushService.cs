using System.ServiceProcess;
using System.Threading;
using Zhongmubao.Push.Service;

namespace Zhongmubao.Push.WinServer
{
    public partial class MsgPushService : ServiceBase
    {
        public MsgPushService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Process.Start();
        }

        protected override void OnStop()
        {
        }
    }

    /// <summary>
    /// 启动线程
    /// </summary>
    public static class Process
    {
        public static void Start()
        {
            ThreadStart start = ThreadAction;
            Thread th = new Thread(start) {IsBackground = true};
            th.Start();
        }

        public static void ThreadAction()
        {
            while (true)
            {
                // 每三秒执行一次消息推送
                new SystemService().Push();
                Thread.Sleep(3000);
            }
        }
    }
}
