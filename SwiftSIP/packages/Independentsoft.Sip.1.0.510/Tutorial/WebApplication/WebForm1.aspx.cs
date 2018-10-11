/*
 * SIP .NET samples
 * Copyright (c) 2013 - Independensoft.
 * 
 * This file is part of Independentsoft SIP .NET. The source code in this file 
 * is only intended as a supplement to the documentation, and is provided 
 * "as is", without warranty of any kind, either expressed or implied.
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;
using Independentsoft.Sip.Responses;

namespace WebApplication1
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox domain;
		protected System.Web.UI.WebControls.TextBox username;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.TextBox port;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox log;
		protected System.Web.UI.WebControls.TextBox from;
		protected System.Web.UI.WebControls.Label Label5;
		private SipClient client;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			client = new SipClient(domain.Text, Int32.Parse(port.Text), ProtocolType.Udp, username.Text, password.Text);
			
			Logger logger = new Logger();
			logger.WriteLog += new WriteLogEventHandler(OnWriteLog);
			client.Logger = logger;

			client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
			client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

			client.Connect();

			string contact = "sip:" + client.LocalIPEndPoint.ToString();

			client.Register(domain.Text,from.Text,contact);
		}

		private void OnWriteLog(object sender, WriteLogEventArgs e) 
		{ 
			log.Text += e.Log;
		}

		private void OnReceiveRequest(object sender, RequestEventArgs e) 
		{ 
			client.AcceptRequest(e.Request);
		}

		private void OnReceiveResponse(object sender,ResponseEventArgs e) 
		{ 
		}
	}
}
