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

namespace CallTransfer
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button disconnectButton1;
		private System.Windows.Forms.TextBox port1;
		private System.Windows.Forms.ComboBox protocol1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox contact1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button registerButton1;
		private System.Windows.Forms.TextBox from1;
		private System.Windows.Forms.TextBox password1;
		private System.Windows.Forms.TextBox username1;
		private System.Windows.Forms.TextBox domain1;
		private System.Windows.Forms.TextBox log1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button registerButton2;
		private System.Windows.Forms.Button registerButton3;
		private System.Windows.Forms.Button disconnectButton2;
		private System.Windows.Forms.Button disconnectButton3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private SipClient client1;
		private SipClient client2;
		private SipClient client3;
		private Dialog callDialog;
		private System.Windows.Forms.TextBox port2;
		private System.Windows.Forms.ComboBox protocol2;
		private System.Windows.Forms.TextBox contact2;
		private System.Windows.Forms.TextBox from2;
		private System.Windows.Forms.TextBox password2;
		private System.Windows.Forms.TextBox username2;
		private System.Windows.Forms.TextBox domain2;
		private System.Windows.Forms.TextBox port3;
		private System.Windows.Forms.ComboBox protocol3;
		private System.Windows.Forms.TextBox contact3;
		private System.Windows.Forms.TextBox from3;
		private System.Windows.Forms.TextBox password3;
		private System.Windows.Forms.TextBox username3;
		private System.Windows.Forms.TextBox domain3;
		private System.Windows.Forms.TextBox log2;
		private System.Windows.Forms.Button callButton;
		private System.Windows.Forms.Button transferButton;
		private System.Windows.Forms.TextBox log3;
		public delegate void UpdateTextCallback(string text); 

		public Form1()
		{
			InitializeComponent();
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

			if(client3 != null)
			{
				client3.Disconnect();
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
			this.transferButton = new System.Windows.Forms.Button();
			this.callButton = new System.Windows.Forms.Button();
			this.disconnectButton1 = new System.Windows.Forms.Button();
			this.port1 = new System.Windows.Forms.TextBox();
			this.protocol1 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.contact1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.registerButton1 = new System.Windows.Forms.Button();
			this.from1 = new System.Windows.Forms.TextBox();
			this.password1 = new System.Windows.Forms.TextBox();
			this.username1 = new System.Windows.Forms.TextBox();
			this.domain1 = new System.Windows.Forms.TextBox();
			this.log1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.disconnectButton2 = new System.Windows.Forms.Button();
			this.port2 = new System.Windows.Forms.TextBox();
			this.protocol2 = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.contact2 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.registerButton2 = new System.Windows.Forms.Button();
			this.from2 = new System.Windows.Forms.TextBox();
			this.password2 = new System.Windows.Forms.TextBox();
			this.username2 = new System.Windows.Forms.TextBox();
			this.domain2 = new System.Windows.Forms.TextBox();
			this.log2 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.disconnectButton3 = new System.Windows.Forms.Button();
			this.port3 = new System.Windows.Forms.TextBox();
			this.protocol3 = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.contact3 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.registerButton3 = new System.Windows.Forms.Button();
			this.from3 = new System.Windows.Forms.TextBox();
			this.password3 = new System.Windows.Forms.TextBox();
			this.username3 = new System.Windows.Forms.TextBox();
			this.domain3 = new System.Windows.Forms.TextBox();
			this.log3 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.transferButton);
			this.groupBox1.Controls.Add(this.callButton);
			this.groupBox1.Controls.Add(this.disconnectButton1);
			this.groupBox1.Controls.Add(this.port1);
			this.groupBox1.Controls.Add(this.protocol1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.contact1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.registerButton1);
			this.groupBox1.Controls.Add(this.from1);
			this.groupBox1.Controls.Add(this.password1);
			this.groupBox1.Controls.Add(this.username1);
			this.groupBox1.Controls.Add(this.domain1);
			this.groupBox1.Controls.Add(this.log1);
			this.groupBox1.Location = new System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 716);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User1";
			// 
			// transferButton
			// 
			this.transferButton.Location = new System.Drawing.Point(200, 152);
			this.transferButton.Name = "transferButton";
			this.transferButton.Size = new System.Drawing.Size(128, 23);
			this.transferButton.TabIndex = 49;
			this.transferButton.Text = "Transfer call to User3";
			this.transferButton.Click += new System.EventHandler(this.transferButton_Click);
			// 
			// callButton
			// 
			this.callButton.Location = new System.Drawing.Point(104, 152);
			this.callButton.Name = "callButton";
			this.callButton.Size = new System.Drawing.Size(88, 23);
			this.callButton.TabIndex = 48;
			this.callButton.Text = "Call User2";
			this.callButton.Click += new System.EventHandler(this.callButton_Click);
			// 
			// disconnectButton1
			// 
			this.disconnectButton1.Location = new System.Drawing.Point(8, 184);
			this.disconnectButton1.Name = "disconnectButton1";
			this.disconnectButton1.Size = new System.Drawing.Size(88, 23);
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
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "Contact:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contact1
			// 
			this.contact1.Enabled = false;
			this.contact1.Location = new System.Drawing.Point(96, 120);
			this.contact1.Name = "contact1";
			this.contact1.ReadOnly = true;
			this.contact1.Size = new System.Drawing.Size(216, 20);
			this.contact1.TabIndex = 14;
			this.contact1.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
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
			this.label2.Location = new System.Drawing.Point(24, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Username:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Domain:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// registerButton1
			// 
			this.registerButton1.Location = new System.Drawing.Point(8, 152);
			this.registerButton1.Name = "registerButton1";
			this.registerButton1.Size = new System.Drawing.Size(88, 23);
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
			this.log1.Location = new System.Drawing.Point(8, 216);
			this.log1.Multiline = true;
			this.log1.Name = "log1";
			this.log1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.log1.Size = new System.Drawing.Size(320, 496);
			this.log1.TabIndex = 2;
			this.log1.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.disconnectButton2);
			this.groupBox2.Controls.Add(this.port2);
			this.groupBox2.Controls.Add(this.protocol2);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.contact2);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.registerButton2);
			this.groupBox2.Controls.Add(this.from2);
			this.groupBox2.Controls.Add(this.password2);
			this.groupBox2.Controls.Add(this.username2);
			this.groupBox2.Controls.Add(this.domain2);
			this.groupBox2.Controls.Add(this.log2);
			this.groupBox2.Location = new System.Drawing.Point(340, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(336, 716);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "User2";
			// 
			// disconnectButton2
			// 
			this.disconnectButton2.Location = new System.Drawing.Point(96, 184);
			this.disconnectButton2.Name = "disconnectButton2";
			this.disconnectButton2.Size = new System.Drawing.Size(88, 23);
			this.disconnectButton2.TabIndex = 47;
			this.disconnectButton2.Text = "Disconnect";
			this.disconnectButton2.Click += new System.EventHandler(this.disconnectButton2_Click);
			// 
			// port2
			// 
			this.port2.Location = new System.Drawing.Point(224, 24);
			this.port2.Name = "port2";
			this.port2.Size = new System.Drawing.Size(40, 20);
			this.port2.TabIndex = 46;
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
			this.protocol2.TabIndex = 45;
			this.protocol2.Text = "UDP";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "Contact:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contact2
			// 
			this.contact2.Enabled = false;
			this.contact2.Location = new System.Drawing.Point(96, 120);
			this.contact2.Name = "contact2";
			this.contact2.ReadOnly = true;
			this.contact2.Size = new System.Drawing.Size(216, 20);
			this.contact2.TabIndex = 14;
			this.contact2.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 12;
			this.label9.Text = "From:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 11;
			this.label10.Text = "Password:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(24, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 10;
			this.label11.Text = "Username:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(24, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 9;
			this.label12.Text = "Domain:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// registerButton2
			// 
			this.registerButton2.Location = new System.Drawing.Point(96, 152);
			this.registerButton2.Name = "registerButton2";
			this.registerButton2.Size = new System.Drawing.Size(88, 23);
			this.registerButton2.TabIndex = 4;
			this.registerButton2.Text = "Register";
			this.registerButton2.Click += new System.EventHandler(this.registerButton2_Click);
			// 
			// from2
			// 
			this.from2.Location = new System.Drawing.Point(96, 96);
			this.from2.Name = "from2";
			this.from2.Size = new System.Drawing.Size(216, 20);
			this.from2.TabIndex = 3;
			this.from2.Text = "sip:Alice@mydomain.com";
			// 
			// password2
			// 
			this.password2.Location = new System.Drawing.Point(96, 72);
			this.password2.Name = "password2";
			this.password2.PasswordChar = '*';
			this.password2.Size = new System.Drawing.Size(216, 20);
			this.password2.TabIndex = 2;
			this.password2.Text = "Alice";
			// 
			// username2
			// 
			this.username2.Location = new System.Drawing.Point(96, 48);
			this.username2.Name = "username2";
			this.username2.Size = new System.Drawing.Size(216, 20);
			this.username2.TabIndex = 1;
			this.username2.Text = "Alice";
			// 
			// domain2
			// 
			this.domain2.Location = new System.Drawing.Point(96, 24);
			this.domain2.Name = "domain2";
			this.domain2.Size = new System.Drawing.Size(128, 20);
			this.domain2.TabIndex = 0;
			this.domain2.Text = "mydomain.com";
			// 
			// log2
			// 
			this.log2.Location = new System.Drawing.Point(8, 216);
			this.log2.Multiline = true;
			this.log2.Name = "log2";
			this.log2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.log2.Size = new System.Drawing.Size(320, 496);
			this.log2.TabIndex = 2;
			this.log2.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.disconnectButton3);
			this.groupBox3.Controls.Add(this.port3);
			this.groupBox3.Controls.Add(this.protocol3);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.contact3);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.registerButton3);
			this.groupBox3.Controls.Add(this.from3);
			this.groupBox3.Controls.Add(this.password3);
			this.groupBox3.Controls.Add(this.username3);
			this.groupBox3.Controls.Add(this.domain3);
			this.groupBox3.Controls.Add(this.log3);
			this.groupBox3.Location = new System.Drawing.Point(676, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(336, 716);
			this.groupBox3.TabIndex = 48;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "User3";
			// 
			// disconnectButton3
			// 
			this.disconnectButton3.Location = new System.Drawing.Point(96, 184);
			this.disconnectButton3.Name = "disconnectButton3";
			this.disconnectButton3.Size = new System.Drawing.Size(88, 23);
			this.disconnectButton3.TabIndex = 47;
			this.disconnectButton3.Text = "Disconnect";
			this.disconnectButton3.Click += new System.EventHandler(this.disconnectButton3_Click);
			// 
			// port3
			// 
			this.port3.Location = new System.Drawing.Point(224, 24);
			this.port3.Name = "port3";
			this.port3.Size = new System.Drawing.Size(40, 20);
			this.port3.TabIndex = 46;
			this.port3.Text = "5060";
			// 
			// protocol3
			// 
			this.protocol3.Items.AddRange(new object[] {
														   "UDP",
														   "TCP"});
			this.protocol3.Location = new System.Drawing.Point(264, 24);
			this.protocol3.Name = "protocol3";
			this.protocol3.Size = new System.Drawing.Size(48, 21);
			this.protocol3.TabIndex = 45;
			this.protocol3.Text = "UDP";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(32, 120);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 16);
			this.label13.TabIndex = 15;
			this.label13.Text = "Contact:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contact3
			// 
			this.contact3.Enabled = false;
			this.contact3.Location = new System.Drawing.Point(96, 120);
			this.contact3.Name = "contact3";
			this.contact3.ReadOnly = true;
			this.contact3.Size = new System.Drawing.Size(216, 20);
			this.contact3.TabIndex = 14;
			this.contact3.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(24, 96);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 16);
			this.label15.TabIndex = 12;
			this.label15.Text = "From:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(24, 72);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 16);
			this.label16.TabIndex = 11;
			this.label16.Text = "Password:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(24, 48);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 10;
			this.label17.Text = "Username:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(24, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 9;
			this.label18.Text = "Domain:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// registerButton3
			// 
			this.registerButton3.Location = new System.Drawing.Point(96, 152);
			this.registerButton3.Name = "registerButton3";
			this.registerButton3.Size = new System.Drawing.Size(88, 23);
			this.registerButton3.TabIndex = 4;
			this.registerButton3.Text = "Register";
			this.registerButton3.Click += new System.EventHandler(this.registerButton3_Click);
			// 
			// from3
			// 
			this.from3.Location = new System.Drawing.Point(96, 96);
			this.from3.Name = "from3";
			this.from3.Size = new System.Drawing.Size(216, 20);
			this.from3.TabIndex = 3;
			this.from3.Text = "sip:Carol@mydomain.com";
			// 
			// password3
			// 
			this.password3.Location = new System.Drawing.Point(96, 72);
			this.password3.Name = "password3";
			this.password3.PasswordChar = '*';
			this.password3.Size = new System.Drawing.Size(216, 20);
			this.password3.TabIndex = 2;
			this.password3.Text = "Carol";
			// 
			// username3
			// 
			this.username3.Location = new System.Drawing.Point(96, 48);
			this.username3.Name = "username3";
			this.username3.Size = new System.Drawing.Size(216, 20);
			this.username3.TabIndex = 1;
			this.username3.Text = "Carol";
			// 
			// domain3
			// 
			this.domain3.Location = new System.Drawing.Point(96, 24);
			this.domain3.Name = "domain3";
			this.domain3.Size = new System.Drawing.Size(128, 20);
			this.domain3.TabIndex = 0;
			this.domain3.Text = "mydomain.com";
			// 
			// log3
			// 
			this.log3.Location = new System.Drawing.Point(8, 216);
			this.log3.Multiline = true;
			this.log3.Name = "log3";
			this.log3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.log3.Size = new System.Drawing.Size(320, 496);
			this.log3.TabIndex = 2;
			this.log3.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1016, 726);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "Form1";
			this.Text = "Call Transfer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

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

		private void callButton_Click(object sender, System.EventArgs e)
		{
			SessionDescription session = new SessionDescription();
			session.Version = 0;

			Owner owner = new Owner();
			owner.Username = "root";
			owner.SessionID = 2980;
			owner.Version = 2980;
			owner.Address = "192.168.0.1";

			session.Owner = owner;
			session.Name = "SIP Call";

			Connection connection = new Connection();
			connection.Address = "192.168.0.1";

			session.Connection = connection;

			Time time = new Time(0,0);
			session.Time.Add(time);

			Media media1 = new Media();
			media1.Type = "audio";
			media1.Port = 13596;
			media1.TransportProtocol = "RTP/AVP";
			media1.MediaFormats.Add("3");
			media1.MediaFormats.Add("0");
			media1.MediaFormats.Add("8");
			media1.MediaFormats.Add("101");

			media1.Attributes.Add("rtpmap:","3 GSM/8000");
			media1.Attributes.Add("rtpmap:","0 PCMU/8000");
			media1.Attributes.Add("rtpmap:","8 PCMA/8000");
			media1.Attributes.Add("rtpmap:","101 telephone-event/8000");
			media1.Attributes.Add("fmtp:","101 0-16");
			media1.Attributes.Add("rtpmap:","silenceSupp:off - - - -");

			session.Media.Add(media1);

			Invite invite = new Invite();
			invite.Uri = from2.Text;
			invite.From = new ContactInfo(from1.Text);
			invite.To = new ContactInfo(from2.Text);
			invite.Contact = new Contact(contact1.Text);
			invite.ContentType = "application/sdp";
			invite.Body = session.ToString();

			RequestResponse inviteRequestResponse = client1.SendRequest(invite);
			callDialog = client1.GetDialog(inviteRequestResponse);

			client1.Ack(inviteRequestResponse);
		}

		private void transferButton_Click(object sender, System.EventArgs e)
		{
			client1.Refer(callDialog,from3.Text);
		}

		private void disconnectButton1_Click(object sender, System.EventArgs e)
		{
			client1.Disconnect();
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
		}

		private void OnReceiveResponse1(object sender,ResponseEventArgs e) 
		{ 
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

		private void disconnectButton2_Click(object sender, System.EventArgs e)
		{
			client2.Disconnect();
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
			client2.AcceptRequest(e.Request);
		}

		private void OnReceiveResponse2(object sender,ResponseEventArgs e) 
		{ 
		}

		private void registerButton3_Click(object sender, System.EventArgs e)
		{
			ProtocolType protocol = ProtocolType.Udp;

			if(protocol3.Text == "TCP")
			{
				protocol = ProtocolType.Tcp;
			}

			client3 = new SipClient(domain3.Text, Int32.Parse(port3.Text), protocol, username3.Text, password3.Text);
			
			Logger logger = new Logger();
			logger.WriteLog += new WriteLogEventHandler(OnWriteLog3);
			client3.Logger = logger;

			client3.ReceiveRequest += new ReceiveRequestEventHandler(OnReceiveRequest3);
			client3.ReceiveResponse += new ReceiveResponseEventHandler(OnReceiveResponse3);

			client3.Connect();

			contact3.Text = "sip:" + username3.Text + "@" + client3.LocalIPEndPoint.ToString();

			client3.Register(domain3.Text,from3.Text,contact3.Text);
		}

		private void disconnectButton3_Click(object sender, System.EventArgs e)
		{
			client3.Disconnect();
		}

		private void OnWriteLog3(object sender, WriteLogEventArgs e) 
		{ 
			Append3(e.Log);
		}

		public void Append3(string text) 
		{ 
			BeginInvoke(new UpdateTextCallback(AppendText3), new object[] {text}); 
		} 

		private void AppendText3(string text)
		{
			log3.AppendText(text);
		}

		private void OnReceiveRequest3(object sender, RequestEventArgs e) 
		{ 
			client3.AcceptRequest(e.Request);
		}

		private void OnReceiveResponse3(object sender,ResponseEventArgs e) 
		{ 
		}

	}
}
