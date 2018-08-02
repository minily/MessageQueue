namespace Zhongmubao.Push.WinServer
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.msgPushServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.msgPushServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // msgPushServiceProcessInstaller
            // 
            this.msgPushServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.msgPushServiceProcessInstaller.Password = null;
            this.msgPushServiceProcessInstaller.Username = null;
            // 
            // msgPushServiceInstaller
            // 
            this.msgPushServiceInstaller.Description = "众牧宝消息推送服务";
            this.msgPushServiceInstaller.ServiceName = "Zhongmubao Message Push";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.msgPushServiceProcessInstaller,
            this.msgPushServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller msgPushServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller msgPushServiceInstaller;
    }
}