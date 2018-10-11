<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="WebApplication1.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="Button1" style="Z-INDEX: 100; LEFT: 104px; POSITION: absolute; TOP: 152px" runat="server"
				Text="Register" Width="104px"></asp:Button>
			<asp:Label id="Label5" style="Z-INDEX: 113; LEFT: 16px; POSITION: absolute; TOP: 120px" runat="server"
				Width="80px">From</asp:Label>
			<asp:TextBox id="from" style="Z-INDEX: 112; LEFT: 104px; POSITION: absolute; TOP: 120px" runat="server"
				Width="232px">sip:Bob@mydomain.com</asp:TextBox>
			<asp:TextBox id="domain" style="Z-INDEX: 101; LEFT: 104px; POSITION: absolute; TOP: 24px" runat="server"
				Width="176px">mydomain.com</asp:TextBox>
			<asp:TextBox id="username" style="Z-INDEX: 102; LEFT: 104px; POSITION: absolute; TOP: 56px" runat="server"
				Width="232px">Bob</asp:TextBox>
			<asp:TextBox id="password" style="Z-INDEX: 103; LEFT: 104px; POSITION: absolute; TOP: 88px" runat="server"
				Width="232px">Bob</asp:TextBox>
			<asp:TextBox id="port" style="Z-INDEX: 105; LEFT: 288px; POSITION: absolute; TOP: 24px" runat="server"
				Width="48px">5060</asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 106; LEFT: 16px; POSITION: absolute; TOP: 24px" runat="server"
				Width="72px">Domain</asp:Label>
			<asp:Label id="label2" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 56px" runat="server"
				Width="72px">Username</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 108; LEFT: 16px; POSITION: absolute; TOP: 88px" runat="server"
				Width="72px" Height="19px">Password</asp:Label>
			<asp:TextBox id="log" style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 184px" runat="server"
				Width="672px" Height="498px" TextMode="MultiLine"></asp:TextBox>
		</form>
	</body>
</HTML>
