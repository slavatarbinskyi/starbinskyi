﻿using System.ServiceProcess;

namespace NotifyService
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		private static void Main()
		{
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				new NotificationService()
			};
			ServiceBase.Run(ServicesToRun);
		}
	}
}