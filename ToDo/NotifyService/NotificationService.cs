﻿using System;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using BAL.Manager;
using DAL;

namespace NotifyService
{
	public partial class NotificationService : ServiceBase
	{
		private readonly int sleepTime = 2000;
		private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

		public NotificationService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			var task = Task.Run(() =>
			{
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

		private static void WriteErrorLog(Exception ex)
		{
			try
			{
				StreamWriter sw = null;
				sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
				sw.WriteLine(DateTime.UtcNow + ":" + ex.Source.Trim() + ";" + ex.Message.Trim());
				sw.Flush();
				sw.Close();
			}
			catch
			{
			}
		}

		private static void WriteLogMessage(string message)
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