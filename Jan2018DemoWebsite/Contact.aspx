<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Jan2018DemoWebsite.Contact" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address><br /><br />
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    <asp:Label ID="Label1" runat="server" Text="User Name">
    </asp:Label>&nbsp;&nbsp;
        <asp:Label ID="UserDisplayName" runat="server">
    </asp:Label>&nbsp;&nbsp;
        <asp:Label ID="EmployeeID" runat="server" Text=>
    </asp:Label>&nbsp;&nbsp;
        <asp:Label ID="EmployeeName" runat="server" >
    </asp:Label>&nbsp;&nbsp;
    <asp:LinkButton ID="GetUserID" runat="server" OnClick="GetUserID_Click">Press</asp:LinkButton>
</asp:Content>
