<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="ChartJSTest.TestPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="TestTable" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Addr</asp:TableCell>
                    <asp:TableCell runat="server">Description</asp:TableCell>
                    <asp:TableCell runat="server">Selection</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">1/1/2</asp:TableCell>
                    <asp:TableCell runat="server">Temp Raum 206</asp:TableCell>
                    <asp:TableCell runat="server">
                        <div>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Min</asp:ListItem>
                                <asp:ListItem>Max</asp:ListItem>
                                <asp:ListItem>Average</asp:ListItem>
                                <asp:ListItem>Last</asp:ListItem>
                                <asp:ListItem>First</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        
    </form>
</body>
</html>
