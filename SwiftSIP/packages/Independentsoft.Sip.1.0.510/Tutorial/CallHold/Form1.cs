/*
 * SIP .NET samples
 * Copyright (c) 2013 - Independensoft.
 * 
 * This file is part of Independentsoft SIP .NET. The source code in this file 
 * is only intended as a supplement to the documentation, and is provided 
 * "as is", without warranty of any kind, either expressed or implied.
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;
using Independentsoft.Sip.Responses;

namespace CallHold
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox log1;
		private System.Windows.Forms.TextBox domain1;
		private System.Windows.Forms.TextBox username1;
		private System.Windows.Forms.TextBox password1;
		private System.Windows.Forms.TextBox from1;
		private System.Windows.Forms.TextBox to1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox contact1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button registerButton1;
		private System.Windows.Forms.Button inviteButton;
		private System.Windows.Forms.Button callHoldButton;
		private System.Windows.Forms.Button callOffHoldButton;
		private System.Windows.Forms.Button byeButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox contact2;
		private System.Windows.Forms.TextBox to2;
		private System.Windows.Forms.Button registerButton2;
		private System.Windows.Forms.TextBox from2;
		private System.Windows.Forms.TextBox password2;
		private System.Windows.Forms.TextBox username2;
		private System.Windows.Forms.TextBox domain2;
		private System.Windows.Forms.TextBox log2;

		private SipClient client1;
		private SipClient client2;
		private System.Windows.Forms.TextBox port1;
		private System.Windows.Forms.ComboBox protocol1;
		private System.Windows.Forms.TextBox port2;
		private System.Windows.Forms.ComboBox protocol2;
		private System.Windows.Forms.Button disconnectButton1;
		private System.Windows.Forms.Button disconnectButton2;
		public delegate void UpdateTextCallback(string text); 
		private SessionDescription session;
		private Dialog inviteDialog;
		private RequestResponse inviteRequestResponse;
		private int rtpPort1 = 49170;
		private int rtpPort2 = 3456;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(client1 != null)
			{
				client1.Disconnect();
			}

			if(client2 != null)
			{
				client2.Disconnect();
			}

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}

			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.disconnectButton1 = new System.Windows.Forms.Button();
			this.port1 = new System.Windows.Forms.TextBox();
			this.protocol1 = new System.Windows.Forms.ComboBox();
			this.byeButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.contact1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.to1 = new System.Windows.Forms.TextBox();
			this.callOffHoldButton = new System.Windows.Forms.Button();
			this.callHoldButton = new System.Windows.Forms.Button();
			this.inviteButton = new System.Windows.Forms.Button();
			this.registerButton1 = new System.Windows.Forms.Button();
			this.from1 = new System.Windows.Forms.TextBox();
			this.password1 = new System.Windows.Forms.TextBox();
			this.username1 = new System.Windows.Forms.TextBox();
			this.domain1 = new System.Windows.Forms.TextBox();
			this.log1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.port2 = new System.Windows.Forms.TextBox();
			this.protocol2 = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.contact2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.to2 = new System.Windows.Forms.TextBox();
			this.registerButton2 = new System.Windows.Forms.Button();
			this.from2 = new System.Windows.Forms.TextBox();
			this.password2 = new System.Windows.Forms.TextBox();
			this.username2 = new System.Windows.Forms.TextBox();
			this.domain2 = new System.Windows.Forms.TextBox();
			this.log2 = new System.Windows.Forms.TextBox();
			this.disconnectButton2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.disconnectButton1);
			this.groupBox1.Controls.Add(this.port1);
			this.groupBox1.Controls.Add(this.protocol1);
			this.groupBox1.Controls.Add(this.byeButton);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.contact1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.to1);
			this.groupBox1.Controls.Add(this.callOffHoldButton);
			this.groupBox1.Controls.Add(this.callHoldButton);
			this.groupBox1.Controls.Add(this.inviteButton);
			this.groupBox1.Controls.Add(this.registerButton1);
			this.groupBox1.Controls.Add(this.from1);
			this.groupBox1.Controls.Add(this.password1);
			this.groupBox1.Controls.Add(this.username1);
			this.groupBox1.Controls.Add(this.domain1);
			this.groupBox1.Controls.Add(this.log1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(500, 760);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User1";
			// 
			// disconnectButton1
			// 
			this.disconnectButton1.Location = new System.Drawing.Point(328, 176);
			this.disconnectButton1.Name = "disconnectButton1";
			this.disconnectButton1.Size = new System.Drawing.Size(120, 23);
			this.disconnectButton1.TabIndex = 47;
			this.disconnectButton1.Text = "Disconnect";
			this.disconnectButton1.Click += new System.EventHandler(this.disconnectButton1_Click);
			// 
			// port1
			// 
			this.port1.Location = new System.Drawing.Point(224, 24);
			this.port1.Name = "port1";
			this.port1.Size = new System.Drawing.Size(40, 20);
			this.port1.TabIndex = 46;
			this.port1.Text = "5060";
			// 
			// protocol1
			// 
			this.protocol1.Items.AddRange(new object[] {
														   "UDP",
														   "TCP"});
			this.protocol1.Location = new System.Drawing.Point(264, 24);
			this.protocol1.Name = "protocol1";
			this.protocol1.Size = new System.Drawing.Size(48, 21);
			this.protocol1.TabIndex = 45;
			this.protocol1.Text = "UDP";
			// 
			// byeButton
			// 
			this.byeButton.Location = new System.Drawing.Point(328, 144);
			this.byeButton.Name = "byeButton";
			this.byeButton.Size = new System.Drawing.Size(120, 23);
			this.byeButton.TabIndex = 16;
			this.byeButton.Text = "Bye";
			this.byeButton.Click += new System.EventHandler(this.byeButton_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "Contact:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contact1
			// 
			this.contact1.Enabled = false;
			this.contact1.Location = new System.Drawing.Point(96, 144);
			this.contact1.Name = "contact1";
			this.contact1.ReadOnly = true;
			this.contact1.Size = new System.Drawing.Size(216, 20);
			this.contact1.TabIndex = 14;
			this.contact1.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "To:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "From:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Password:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Username:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Domain:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// to1
			// 
			this.to1.Location = new System.Drawing.Point(96, 120);
			this.to1.Name = "to1";
			this.to1.Size = new System.Drawing.Size(216, 20);
			this.to1.TabIndex = 8;
			this.to1.Text = "sip:Alice@mydomain.com";
			// 
			// callOffHoldButton
			// 
			this.callOffHoldButton.Location = new System.Drawing.Point(328, 112);
			this.callOffHoldButton.Name = "callOffHoldButton";
			this.callOffHoldButton.Size = new System.Drawing.Size(120, 23);
			this.callOffHoldButton.TabIndex = 7;
			this.callOffHoldButton.Text = "Call Off Hold";
			this.callOffHoldButton.Click += new System.EventHandler(this.callOffHoldButton_Click);
			// 
			// callHoldButton
			// 
			this.callHoldButton.Location = new System.Drawing.Point(328, 80);
			this.callHoldButton.Name = "callHoldButton";
			this.callHoldButton.Size = new System.Drawing.Size(120, 23);
			this.callHoldButton.TabIndex = 6;
			this.callHoldButton.Text = "Call Hold";
			this.callHoldButton.Click += new System.EventHandler(this.callHoldButton_Click);
			// 
			// inviteButton
			// 
			this.inviteButton.Location = new System.Drawing.Point(328, 48);
			this.inviteButton.Name = "inviteButton";
			this.inviteButton.Size = new System.Drawing.Size(120, 23);
			this.inviteButton.TabIndex = 5;
			this.inviteButton.Text = "Invite";
			this.inviteButton.Click += new System.EventHandler(this.inviteButton_Click);
			// 
			// registerButton1
			// 
			this.registerButton1.Location = new System.Drawing.Point(328, 16);
			this.registerButton1.Name = "registerButton1";
			this.registerButton1.Size = new System.Drawing.Size(120, 23);
			this.registerButton1.TabIndex = 4;
			this.registerButton1.Text = "Register";
			this.registerButton1.Click += new System.EventHandler(this.registerButton1_Click);
			// 
			// from1
			// 
			this.from1.Location = new System.Drawing.Point(96, 96);
			this.from1.Name = "from1";
			this.from1.Size = new System.Drawing.Size(216, 20);
			this.from1.TabIndex = 3;
			this.from1.Text = "sip:Bob@mydomain.com";
			// 
			// password1
			// 
			this.password1.Location = new System.Drawing.Point(96, 72);
			this.password1.Name = "password1";
			this.password1.PasswordChar = '*';
			this.password1.Size = new System.Drawing.Size(216, 20);
			this.password1.TabIndex = 2;
			this.password1.Text = "Bob";
			// 
			// username1
			// 
			this.username1.Location = new System.Drawing.Point(96, 48);
			this.username1.Name = "username1";
			this.username1.Size = new System.Drawing.Size(216, 20);
			this.username1.TabIndex = 1;
			this.username1.Text = "Bob";
			// 
			// domain1
			// 
			this.domain1.Location = new System.Drawing.Point(96, 24);
			this.domain1.Name = "domain1";
			this.domain1.Size = new System.Drawing.Size(128, 20);
			this.domain1.TabIndex = 0;
			this.domain1.Text = "mydomain.com";
			// 
			// log1
			// 
			this.log1.Location = new System.Drawing.Point(8, 208);
			this.log1.Multiline = true;
			this.log1.Name = "log1";
			this.log1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.log1.Size = new System.Drawing.Size(480, 544);
			this.log1.TabIndex = 2;
			this.log1.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.port2);
			this.groupBox2.Controls.Add(this.protocol2);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.contact2);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.to2);
			this.groupBox2.Controls.Add(this.registerButton2);
			this.groupBox2.Controls.Add(this.from2);
			this.groupBox2.Controls.Add(this.password2);
			this.groupBox2.Controls.Add(this.username2);
			this.groupBox2.Controls.Add(this.domain2);
			this.groupBox2.Controls.Add(this.log2);
			this.groupBox2.Controls.Add(this.disconnectButton2);
			this.groupBox2.Location = new System.Drawing.Point(520, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(500, 760);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "User2";
			// 
			// port2
			// 
			this.port2.Location = new System.Drawing.Point(224, 24);
			this.port2.Name = "port2";
			this.port2.Size = new System.Drawing.Size(40, 20);
			this.port2.TabIndex = 48;
			this.port2.Text = "5060";
			// 
			// protocol2
			// 
			this.protocol2.Items.AddRange(new object[] {
														   "UDP",
														   "TCP"});
			this.protocol2.Location = new System.Drawing.Point(264, 24);
			this.protocol2.Name = "protocol2";
			this.protocol2.Size = new System.Drawing.Size(48, 21);
			this.protocol2.TabIndex = 47;
			this.protocol2.Text = "UDP";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(26, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 33;
			this.label7.Text = "Contact:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contact2
			// 
			this.contact2.Enabled = false;
			this.contact2.Location = new System.Drawing.Point(96, 144);
			this.contact2.Name = "contact2";
			this.contact2.ReadOnly = true;
			this.contact2.Size = new System.Drawing.Size(216, 20);
			this.contact2.TabIndex = 32;
			this.contact2.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(26, 120);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 31;
			this.label8.Text = "To:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(18, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 30;
			this.label9.Text = "From:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(26, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 29;
			this.label10.Text = "Password:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(18, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 28;
			this.label11.Text = "Username:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(18, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 16);
			this.label12.TabIndex = 27;
			this.label12.Text = "Domain:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// to2
			// 
			this.to2.Location = new System.Drawing.Point(96, 120);
			this.to2.Name = "to2";
			this.to2.Size = new System.Drawing.Size(216, 20);
			this.to2.TabIndex = 26;
			this.to2.Text = "";
			// 
			// registerButton2
			// 
			this.registerButton2.Location = new System.Drawing.Point(344, 16);
			this.registerButton2.Name = "registerButton2";
			this.registerButton2.Size = new System.Drawing.Size(120, 23);
			this.registerButton2.TabIndex = 22;
			this.registerButton2.Text = "Register";
			this.registerButton2.Click += new System.EventHandler(this.registerButton2_Click);
			// 
			// from2
			// 
			this.from2.Location = new System.Drawing.Point(96, 96);
			this.from2.Name = "from2";
			this.from2.Size = new System.Drawing.Size(216, 20);
			this.from2.TabIndex = 21;
			this.from2.Text = "sip:Alice@mydomain.com";
			// 
			// password2
			// 
			this.password2.Location = new System.Drawing.Point(96, 72);
			this.password2.Name = "password2";
			this.password2.PasswordChar = '*';
			this.password2.Size = new System.Drawing.Size(216, 20);
			this.password2.TabIndex = 19;
			this.password2.Text = "Alice";
			// 
			// username2
			// 
			this.username2.Location = new System.Drawing.Point(96, 48);
			this.username2.Name = "username2";
			this.username2.Size = new System.Drawing.Size(216, 20);
			this.username2.TabIndex = 18;
			this.username2.Text = "Alice";
			// 
			// domain2
			// 
			this.domain2.Location = new System.Drawing.Point(96, 24);
			this.domain2.Name = "domain2";
			this.domain2.Size = new System.Drawing.Size(128, 20);
			this.domain2.TabIndex = 17;
			this.domain2.Text = "mydomain.com";
			// 
			// log2
			// 
			this.log2.Location = new System.Drawing.Point(10, 208);
			this.log2.Multiline = true;
			this.log2.Name = "log2";
			this.log2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.log2.Size = new System.Drawing.Size(480, 544);
			this.log2.TabIndex = 20;
			this.log2.Text = "";
			// 
			// disconnectButton2
			// 
			this.disconnectButton2.Location = new System.Drawing.Point(344, 48);
			this.disconnectButton2.Name = "disconnectButton2";
			this.disconnectButton2.Size = new System.Drawing.Size(120, 23);
			this.disconnectButton2.TabIndex = 48;
			this.disconnectButton2.Text = "Disconnect";
			this.disconnectButton2.Click += new System.EventHandler(this.disconnectButton2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 773);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Call Hold";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void registerButton1_Click(object sender, System.EventArgs e)
		{
			ProtocolType protocol = ProtocolType.Udp;

			if(protocol1.Text == "TCP")
			{
				protocol = ProtocolType.Tcp;
			}

			client1 = new SipClient(domain1.Text, Int32.Parse(port1.Text), protocol, username1.Text, password1.Text);
			
			Logger logger = new Logger();
			logger.WriteLog += new WriteLogEventHandler(OnWriteLog1);
			client1.Logger = logger;

			client1.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest1);
			client1.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse1);

			client1.Connect();

			contact1.Text = "sip:" + username1.Text + "@" + client1.LocalIPEndPoint.ToString();

			client1.Register(domain1.Text,from1.Text,contact1.Text);
		}

		private void OnWriteLog1(object sender, WriteLogEventArgs e) 
		{ 
			Append1(e.Log);
		}

		public void Append1(string text) 
		{ 
			BeginInvoke(new UpdateTextCallback(AppendText1), new object[] {text}); 
		} 

		private void AppendText1(string text)
		{
			log1.AppendText(text);
		}

		private void OnReceiveRequest1(object sender, RequestEventArgs e) 
		{ 
			client1.AcceptRequest(e.Request);
		}

		private void OnReceiveResponse1(object sender,ResponseEventArgs e) 
		{ 
		}

		private void inviteButton_Click(object sender, System.EventArgs e)
		{
			session = new SessionDescription();

			Owner owner = new Owner();
			owner.Username = username1.Text;
			owner.SessionID = 2890844526;
			owner.Version = 2890844526;
			owner.Address = client1.LocalIPEndPoint.Address.ToString();

			session.Owner = owner;
			session.Name = "SIP Call";

			Connection connection = new Connection();
			connection.Address = client1.LocalIPEndPoint.Address.ToString();
			session.Connection = connection;

			Time time = new Time(0,0);
			session.Time.Add(time);

			Media media1 = new Media();
			media1.Type = "audio";
			media1.Port = rtpPort1;
			media1.TransportProtocol = "RTP/AVP";
			media1.Attributes.Add("rtpmap","0 pcmu/8000");
			session.Media.Add(media1);

			Invite invite = new Invite();
			invite.Uri = to1.Text;
			invite.From = new ContactInfo(from1.Text);
			invite.To = new ContactInfo(to1.Text);
			invite.Contact = new Contact(contact1.Text);
			invite.ContentType = "application/sdp";
			invite.Body = session.ToString();

			inviteRequestResponse = client1.SendRequest(invite);
			client1.Ack(inviteRequestResponse);
		}

		private void callHoldButton_Click(object sender, System.EventArgs e)
		{
			session.Media[0].Attributes.Add("sendonly");

			inviteDialog = client1.GetDialog(inviteRequestResponse);

			inviteRequestResponse = client1.Reinvite(inviteDialog,session.ToString(),"application/sdp");
			client1.Ack(inviteRequestResponse);
		}

		private void callOffHoldButton_Click(object sender, System.EventArgs e)
		{
			session.Media[0].Attributes.Remove("sendonly");

			inviteDialog = client1.GetDialog(inviteRequestResponse);

			inviteRequestResponse = client1.Reinvite(inviteDialog,session.ToString(),"application/sdp");
			client1.Ack(inviteRequestResponse);
		}

		private void byeButton_Click(object sender, System.EventArgs e)
		{
			inviteDialog = client1.GetDialog(inviteRequestResponse);
			client1.Bye(inviteDialog);
		}

		private void disconnectButton1_Click(object sender, System.EventArgs e)
		{
			client1.Disconnect();
		}

		private void registerButton2_Click(object sender, System.EventArgs e)
		{
			ProtocolType protocol = ProtocolType.Udp;

			if(protocol2.Text == "TCP")
			{
				protocol = ProtocolType.Tcp;
			}

			client2 = new SipClient(domain2.Text, Int32.Parse(port2.Text), protocol, username2.Text, password2.Text);
			
			Logger logger = new Logger();
			logger.WriteLog += new WriteLogEventHandler(OnWriteLog2);
			client2.Logger = logger;

			client2.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest2);
			client2.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse2);

			client2.Connect();

			contact2.Text = "sip:" + username2.Text + "@" + client2.LocalIPEndPoint.ToString();
			client2.Register(domain2.Text,from2.Text,contact2.Text);
		}

		private void OnWriteLog2(object sender, WriteLogEventArgs e) 
		{ 
			Append2(e.Log);
		}

		public void Append2(string text) 
		{ 
			BeginInvoke(new UpdateTextCallback(AppendText2), new object[] {text}); 
		} 

		private void AppendText2(string text)
		{
			log2.AppendText(text);
		}

		private void OnReceiveRequest2(object sender, RequestEventArgs e) 
		{ 
			if(e.Request.Method == SipMethod.Invite)
			{
				SessionDescription receivedSession = e.Request.SessionDescription;
				receivedSession.Owner.Username = username2.Text;
				receivedSession.Owner.SessionID = session.Owner.SessionID+1;
				receivedSession.Owner.Version = session.Owner.Version+1;
				receivedSession.Media[0].Port = rtpPort2;

				Independentsoft.Sip.Sdp.AttributeCollection attributes = receivedSession.Media[0].Attributes;
				
				if(attributes.Contains("sendonly"))
				{
					attributes.Remove("sendonly");
					attributes.Add("recvonly");
				}
	
				OK okResponse = new OK();
				okResponse.SessionDescription = receivedSession;
				okResponse.Contact = new Contact(contact2.Text);

				client2.SendResponse(okResponse, e.Request);
			}
			else
			{
				client2.AcceptRequest(e.Request);
			}
		}

		private void OnReceiveResponse2(object sender,ResponseEventArgs e) 
		{ 
		}

		private void disconnectButton2_Click(object sender, System.EventArgs e)
		{
			client2.Disconnect();
		}
	}
}
