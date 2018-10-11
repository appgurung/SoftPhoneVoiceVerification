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

namespace PC2PCMessenger
{
	public class ConnectDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox localName;
		private System.Windows.Forms.TextBox localAddress;
		private System.Windows.Forms.TextBox localIPAddress;
		private System.Windows.Forms.TextBox localPort;
		private System.Windows.Forms.TextBox remotePort;
		private System.Windows.Forms.TextBox remoteIPAddress;
		private System.Windows.Forms.TextBox remoteAddress;
		private System.Windows.Forms.TextBox remoteName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;

		private System.ComponentModel.Container components = null;

		public ConnectDialog()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.localPort = new System.Windows.Forms.TextBox();
            this.localIPAddress = new System.Windows.Forms.TextBox();
            this.localAddress = new System.Windows.Forms.TextBox();
            this.localName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.remotePort = new System.Windows.Forms.TextBox();
            this.remoteIPAddress = new System.Windows.Forms.TextBox();
            this.remoteAddress = new System.Windows.Forms.TextBox();
            this.remoteName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.localPort);
            this.groupBox1.Controls.Add(this.localIPAddress);
            this.groupBox1.Controls.Add(this.localAddress);
            this.groupBox1.Controls.Add(this.localName);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My Computer";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP Address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // localPort
            // 
            this.localPort.Location = new System.Drawing.Point(280, 72);
            this.localPort.Name = "localPort";
            this.localPort.Size = new System.Drawing.Size(56, 20);
            this.localPort.TabIndex = 3;
            this.localPort.Text = "13060";
            // 
            // localIPAddress
            // 
            this.localIPAddress.Location = new System.Drawing.Point(96, 72);
            this.localIPAddress.Name = "localIPAddress";
            this.localIPAddress.Size = new System.Drawing.Size(176, 20);
            this.localIPAddress.TabIndex = 2;
            this.localIPAddress.Text = "192.168.2.101";
            // 
            // localAddress
            // 
            this.localAddress.Location = new System.Drawing.Point(96, 48);
            this.localAddress.Name = "localAddress";
            this.localAddress.Size = new System.Drawing.Size(240, 20);
            this.localAddress.TabIndex = 1;
            this.localAddress.Text = "Bob@mydomain.com";
            // 
            // localName
            // 
            this.localName.Location = new System.Drawing.Point(96, 24);
            this.localName.Name = "localName";
            this.localName.Size = new System.Drawing.Size(240, 20);
            this.localName.TabIndex = 0;
            this.localName.Text = "Bob";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.remotePort);
            this.groupBox2.Controls.Add(this.remoteIPAddress);
            this.groupBox2.Controls.Add(this.remoteAddress);
            this.groupBox2.Controls.Add(this.remoteName);
            this.groupBox2.Location = new System.Drawing.Point(8, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote Computer";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "IP Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // remotePort
            // 
            this.remotePort.Location = new System.Drawing.Point(280, 62);
            this.remotePort.Name = "remotePort";
            this.remotePort.Size = new System.Drawing.Size(56, 20);
            this.remotePort.TabIndex = 7;
            this.remotePort.Text = "14060";
            // 
            // remoteIPAddress
            // 
            this.remoteIPAddress.Location = new System.Drawing.Point(96, 62);
            this.remoteIPAddress.Name = "remoteIPAddress";
            this.remoteIPAddress.Size = new System.Drawing.Size(176, 20);
            this.remoteIPAddress.TabIndex = 6;
            this.remoteIPAddress.Text = "192.168.2.101";
            // 
            // remoteAddress
            // 
            this.remoteAddress.Location = new System.Drawing.Point(96, 38);
            this.remoteAddress.Name = "remoteAddress";
            this.remoteAddress.Size = new System.Drawing.Size(240, 20);
            this.remoteAddress.TabIndex = 5;
            this.remoteAddress.Text = "Alice@mydomain.com";
            // 
            // remoteName
            // 
            this.remoteName.Location = new System.Drawing.Point(96, 14);
            this.remoteName.Name = "remoteName";
            this.remoteName.Size = new System.Drawing.Size(240, 20);
            this.remoteName.TabIndex = 4;
            this.remoteName.Text = "Alice";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(96, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(200, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            // 
            // ConnectDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(368, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConnectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public string LocalName
		{
			get
			{
				return localName.Text;
			}
		}

		public string LocalAddress
		{
			get
			{
				return localAddress.Text;
			}
		}

		public string LocalIPAddress
		{
			get
			{
				return localIPAddress.Text;
			}
		}

		public string LocalPort
		{
			get
			{
				return localPort.Text;
			}
		}

		public string RemoteName
		{
			get
			{
				return remoteName.Text;
			}
		}

		public string RemoteAddress
		{
			get
			{
				return remoteAddress.Text;
			}
		}

		public string RemoteIPAddress
		{
			get
			{
				return remoteIPAddress.Text;
			}
		}

		public string RemotePort
		{
			get
			{
				return remotePort.Text;
			}
		}
	}
}
