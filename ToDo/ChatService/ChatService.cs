using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using BAL.Manager;
using DAL;
using vtortola.WebSockets;
using WebApp.Helpers;

namespace ChatService
{
	public partial class ChatService : ServiceBase
	{

		public static List<WebSocket> sockets;
		public static Dictionary<string, string> names;
		public WebSocketEventListener server = null;
		public static string ImgPath;

		public ChatService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			sockets = new List<WebSocket>();
			names = new Dictionary<string, string>();
			server = new WebSocketEventListener(new IPEndPoint(IPAddress.Any, 8002),
				new WebSocketListenerOptions()
				{
					SubProtocols = new String[] {"123456"},
					NegotiationTimeout = TimeSpan.FromSeconds(30)
				});
				SetEvents(server);
				server.Start();

		}

		protected override void OnStop()
		{
			server.Stop();
			server.Dispose();
		}

		public static void SetEvents(WebSocketEventListener server)
		{
			server.OnConnect += (ws) => {
				sockets.Add(ws);
				//Console.WriteLine("Connection from " + ws.RemoteEndpoint.ToString());
			};
			server.OnDisconnect += (ws) =>
			{
				sockets.Remove(ws);
				//Console.WriteLine("Disconnection from " + ws.RemoteEndpoint.ToString());
			};
			server.OnError += (ws, ex) =>
			{
				//Console.WriteLine("Error: " + ex.Message);
			};
			server.OnMessage += (ws, msg) =>
			{
				var wsContext = ws;
				//Console.WriteLine("Message from [" + ws.RemoteEndpoint + "]: " + msg);
				var msgSplitted = msg.Split(":".ToArray(), StringSplitOptions.RemoveEmptyEntries);
				var msgData = msgSplitted[1];
				var userId = msgSplitted[2];
				var imghelper = new ImageHelper();
				ImgPath = imghelper.GetImagePath(userId);
				var msgToSend = string.Empty;
				if (msg.StartsWith("Name"))
				{
					names.Add(ws.RemoteEndpoint.ToString(), msgData);
					msgToSend = ComposeMsg(names[ws.RemoteEndpoint.ToString()], "Joined");
				}
				else
				{
					msgToSend = ComposeMsg(names[ws.RemoteEndpoint.ToString()], msgData);
				}

				//var task = Task.Factory.StartNew(() =>
				//{
				// util.ProcessMessage(wsContext);
				foreach (var w in sockets)
				{
					if (w != ws)
					{
						w.WriteString(msgToSend);
					}
				}
				//});
			};
		}

		public static string ComposeMsg(string name, string msg)
		{
			return $"<div><img src='"+ImgPath+"'/><strong>{name}</strong><span>  {msg}</span></div>";
		}
	}
}
