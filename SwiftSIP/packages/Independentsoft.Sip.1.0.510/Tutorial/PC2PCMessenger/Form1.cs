/*
 * SIP .NET samples
 * Copyright (c) 2013 - Independensoft.
 * 
 * This file is part of Independentsoft SIP .NET. The source code in this file 
 * is only intended as a supplement to the documentation, and is provided 
 * "as is", without warranty of any kind, either expressed or implied.
 */

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Independentsoft.Sip;
using Independentsoft.Sip.Sdp;
using Independentsoft.Sip.Methods;
using Independentsoft.Sip.Responses;

namespace PC2PCMessenger
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.MenuItem fileMenuItem;
		private System.Windows.Forms.MenuItem connectMenuItem;
		private System.Windows.Forms.MenuItem sendFileMenuItem;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private IContainer components;
		
		private delegate void UpdateTextCallback(string text); 
		private SipClient client;
		private ContactInfo localContactInfo;
		private ContactInfo remoteContactInfo;
		private string localName;
		private string localAddress;
        private string localIPAddress;
		private string localPort;
		private string remoteName;
		private string remoteAddress;
		private string remoteIPAddress;
		private string remotePort;

		private Socket receiveFileSocket;
		private string receiveFileName;
		private long   receiveFileSize;
		private string fileName;
		private SessionDescription responseSessionDescription;

		public Form1()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if(client != null)
			{
				client.Disconnect();
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.connectMenuItem = new System.Windows.Forms.MenuItem();
            this.sendFileMenuItem = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.connectMenuItem,
            this.sendFileMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Text = "File";
            // 
            // connectMenuItem
            // 
            this.connectMenuItem.Index = 0;
            this.connectMenuItem.Text = "Connect";
            this.connectMenuItem.Click += new System.EventHandler(this.connectMenuItem_Click);
            // 
            // sendFileMenuItem
            // 
            this.sendFileMenuItem.Index = 1;
            this.sendFileMenuItem.Text = "Send File";
            this.sendFileMenuItem.Click += new System.EventHandler(this.sendFileMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 2;
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(360, 537);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.sendButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(279, 53);
            this.textBox2.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.sendButton.Location = new System.Drawing.Point(282, 16);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 53);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(360, 609);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "PC2PC Messenger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        [STAThreadAttribute]
		public static void Main() 
		{
			Application.Run(new Form1());
		}

		private void sendButton_Click(object sender, System.EventArgs e)
		{
			RequestResponse requestResponse = client.SendMessage(localContactInfo, remoteContactInfo, textBox2.Text);
			
			if(requestResponse.Response.StatusCode == 200)
			{
				Append(localContactInfo.Name + ": " + textBox2.Text);
			}
			else
			{
				Append("Send failed !!!");
			}

			textBox2.Clear();
		}

		private void connectMenuItem_Click(object sender, System.EventArgs e)
		{
			ConnectDialog dialog = new ConnectDialog();

			if(dialog.ShowDialog() == DialogResult.OK)
			{
				this.localName       = dialog.LocalName;
				this.localPort       = dialog.LocalPort;
				this.localAddress    = dialog.LocalAddress;
				this.localIPAddress  = dialog.LocalIPAddress;
				this.localPort       = dialog.LocalPort;
				this.remoteName      = dialog.RemoteName;
				this.remotePort      = dialog.RemotePort;
				this.remoteAddress   = dialog.RemoteAddress;
				this.remoteIPAddress = dialog.RemoteIPAddress;
				this.remotePort      = dialog.RemotePort;

				localContactInfo  = new ContactInfo(dialog.LocalName, dialog.LocalAddress);
				remoteContactInfo = new ContactInfo(dialog.RemoteName, dialog.RemoteAddress);

				client = new SipClient(dialog.RemoteIPAddress, Int32.Parse(dialog.RemotePort), Independentsoft.Sip.ProtocolType.Udp);

				client.Logger = new Logger("c:\\temp\\" + dialog.LocalName + ".txt");
		
				client.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest);
				client.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse);

                IPHostEntry hostEntry = Dns.GetHostEntry(dialog.LocalIPAddress);

                IPAddress address = hostEntry.AddressList[0];

                if (hostEntry.AddressList.Length > 1)
                {
                    for (int i = 0; i < hostEntry.AddressList.Length; i++)
                    {
                        if (hostEntry.AddressList[i] != null && hostEntry.AddressList[i].ToString().IndexOf(":") == -1)
                        {
                            address = hostEntry.AddressList[i];
                            break;
                        }
                    }
                }

                IPEndPoint localIPEndPoint = new IPEndPoint(address, Int32.Parse(dialog.LocalPort));            
				client.Bind(localIPEndPoint);

				this.Text += " - " + dialog.LocalName;
			}
		}

		private void OnReceiveRequest(object sender, RequestEventArgs e) 
		{ 
			if(e.Request.Method == SipMethod.Message)
			{
				client.AcceptRequest(e.Request);
				Append(remoteContactInfo.Name + ": " +e.Request.Body);
			}
			else if(e.Request.Method == SipMethod.Invite)
			{
				SessionDescription receivedSessionDescription = e.Request.SessionDescription;

				receiveFileName = receivedSessionDescription.Media[0].Attributes[0].Value;
				receiveFileSize = Int64.Parse(receivedSessionDescription.Media[0].Attributes[1].Value);

				int fileTransferPort = ReceiveFile();

				SessionDescription session = new SessionDescription();
				session.Version = 0;

				Owner owner = new Owner();
				owner.Username = localName;
				owner.SessionID = 1;
				owner.Version = 1;
				owner.Address = localIPAddress;

				session.Owner = owner;
				session.Name = "FileTransfer";

				Connection connection = new Connection();
				connection.Address = localIPAddress;

				session.Connection = connection;

				Time time = new Time(0,0);
				session.Time.Add(time);

				Media media1 = new Media();
				media1.Type = "filetransfer";
				media1.TransportProtocol = "TCP";
				media1.Port = fileTransferPort;
				session.Media.Add(media1);

				OK ok = new OK();
				ok.SessionDescription = session;
				ok.Contact = new Contact("sip:" + localName + "@" + client.LocalIPEndPoint.ToString());

				client.SendResponse(ok,e.Request);
			}
			else
			{
				client.RejectRequest(e.Request);
			}
		}

		private void OnReceiveResponse(object sender,ResponseEventArgs e) 
		{
		}

		private void sendFileMenuItem_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Multiselect = false;

			if(dialog.ShowDialog() == DialogResult.OK)
			{
				fileName = dialog.FileName;
				FileInfo fileInfo = new FileInfo(fileName);		

				SessionDescription session = new SessionDescription();
				session.Version = 0;

				Owner owner = new Owner();
				owner.Username = localName;
				owner.SessionID = 1;
				owner.Version = 1;
				owner.Address = localIPAddress;

				session.Owner = owner;
				session.Name = "FileTransfer";

				Connection connection = new Connection();
				connection.Address = localIPAddress;

				session.Connection = connection;

				Time time = new Time(0,0);
				session.Time.Add(time);

				Media media1 = new Media();
				media1.Type = "filetransfer";
				media1.TransportProtocol = "TCP";
				media1.Attributes.Add("name",fileInfo.Name);
				media1.Attributes.Add("size",fileInfo.Length.ToString());
				session.Media.Add(media1);

				Invite invite = new Invite();
				invite.Uri = remoteAddress;
				invite.From = localContactInfo;
				invite.To = remoteContactInfo;
				invite.Contact = new Contact("sip:" + localName + "@" + client.LocalIPEndPoint.ToString());
				invite.ContentType = "application/sdp";
				invite.Body = session.ToString();

				RequestResponse inviteRequestResponse = client.SendRequest(invite);

				if(inviteRequestResponse.Response.StatusCode == 200)
				{
					client.Ack(inviteRequestResponse);
					responseSessionDescription = inviteRequestResponse.Response.SessionDescription;

					Append("Sending file "+fileName);

					Thread sendFileThread = new Thread(new ThreadStart(SendFile));
					sendFileThread.IsBackground = true;
					sendFileThread.Start();
				}
			}
		}

		private void SendFile()
		{
			Socket sendFileSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

			int remoteFileTransferPort = responseSessionDescription.Media[0].Port;
			IPEndPoint remoteIPEndPoint = new IPEndPoint(Dns.Resolve(remoteIPAddress).AddressList[1],remoteFileTransferPort);

			FileStream file = new FileStream(fileName,FileMode.Open);
			byte[] buffer = new byte[file.Length];
			file.Read(buffer,0,buffer.Length);

			sendFileSocket.Connect(remoteIPEndPoint);
			sendFileSocket.Send(buffer);
			sendFileSocket.Close();

			file.Close();
			Append("File transfer completed.");
		}

		private int ReceiveFile()
		{
			receiveFileSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

			IPHostEntry localhostEntry = Dns.Resolve(Dns.GetHostName());
			IPAddress localAddress = localhostEntry.AddressList[0];
			IPEndPoint localIPEndPoint = new IPEndPoint(localAddress,0);

			receiveFileSocket.Bind(localIPEndPoint);
			receiveFileSocket.Listen(5);

			localIPEndPoint = (IPEndPoint)receiveFileSocket.LocalEndPoint;

			Thread receiveFileThread = new Thread(new ThreadStart(ReceiveFileListener));
			receiveFileThread.IsBackground = true;
			receiveFileThread.Start();

			return localIPEndPoint.Port;
		}

		private void ReceiveFileListener()
		{
			Append("Receive file c:\\temp\\"+receiveFileName);
			Append("File size: "+receiveFileSize);

			FileStream file = new FileStream("c:\\temp\\"+receiveFileName,FileMode.Create);

			byte[] receiveBuffer = new byte[8192];
			long size = 0;

			Socket acceptSocket = receiveFileSocket.Accept();

			while(size < receiveFileSize)
			{
				int receivedSize = acceptSocket.Receive(receiveBuffer);
				size += receivedSize;
				
				file.Write(receiveBuffer,0,receivedSize);
			}

			file.Close();

			Append("File transfer completed.");

			acceptSocket.Shutdown(SocketShutdown.Both);
			acceptSocket.Close();

            receiveFileSocket.Close();
		}


		private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		public void Append(string text) 
		{ 
			BeginInvoke(new UpdateTextCallback(AppendText), new object[] {text}); 
		} 

		private void AppendText(string text)
		{
			textBox1.AppendText("\r\n" + text);
		}
	}
}
