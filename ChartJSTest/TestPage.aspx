<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="ChartJSTest.TestPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="SensorTable" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Addr</asp:TableCell>
                <asp:TableCell runat="server">Description</asp:TableCell>
                <asp:TableCell runat="server">Selection</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="SearchTable" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Searchbox" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="TimeSelect" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Start Time</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="StartTime" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">End Time</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="EndTime" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="ShowGraphButton" runat="server" OnClick="ShowGraphButton_Click" Text="ShowGraph" />

    </form>
</body>
</html>
