using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using BAL.Manager;
using DAL;


namespace NotifyService
{
	public partial class NotificationService : ServiceBase
	{
	 private int sleepTime = 2000;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
		
        public NotificationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //set only one thread(ex:  task.sleep(5sec))
            var t = Task.Run(() => {

                while (!tokenSource.Token.IsCancellationRequested)
                {
                    DoWork();
                    Thread.Sleep(sleepTime);
                }

            }, tokenSource.Token);
        }

        private void DoWork()
        {
	        try
	        {
		        var notificationService = new NotificationEmailService(new UnitOfWork());
		        var email_s = ConfigurationManager.AppSettings["Email"];
		        var pass_s = ConfigurationManager.AppSettings["Password"];
		        notificationService.NotifyOnEmail(email_s, pass_s);
		        WriteLogMessage("Notification was sended: " + Thread.CurrentThread.ManagedThreadId);
	        }
	        catch (Exception ex)
	        {
				WriteErrorLog(ex);

	        }
        }

        protected override void OnStop()
        {
            tokenSource.Cancel();
			WriteLogMessage("Service stopped.");
        }

		public static void WriteErrorLog(Exception ex)
		{
			StreamWriter sw = null;
			try
			{
				sw=new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"\\LogFile.txt",true);
				sw.WriteLine(DateTime.UtcNow +":"+ex.Source.ToString().Trim()+";"+ex.Message.ToString().Trim());
				sw.Flush();
				sw.Close();
			}
			catch 
			{
				
			}
		}
		public static void WriteLogMessage(string message)
		{
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
				sw.WriteLine(DateTime.UtcNow + ":" + message);
				sw.Flush();
				sw.Close();
			}
			catch
			{

			}
		}
	}
}
