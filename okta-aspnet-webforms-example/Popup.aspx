<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Popup.aspx.cs" Inherits="okta_aspnet_webforms_example.Popup" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="background5.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style type="text/css">
        .auto-style1 {
            width: 476px;
        }
        .auto-style2 {
            width: 525px;
        }
        .auto-style3 {
            width: 400px;
        }
        .auto-style4 {
            width: 24px;
        }
    </style>
</head>
<body style="height: 493px">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr style="page-break-inside: avoid;">
                    <td class="auto-style3">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr style="page-break-inside: avoid;">
                    <td class="auto-style3">
                        <table class="auto-style5">
                            <tr style="page-break-inside: avoid;">
                                <td class="auto-style6">&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Username:" Font-Names="Calibri"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid;">
                                <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Password:" Font-Names="Calibri"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" TextMode="Password" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid;">
                                <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td></td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_ClickAsync" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="page-break-inside: avoid;">
                    <td class="auto-style3">
                        <table class="auto-style2">
                            <tr style="page-break-inside: avoid;">
                        <td class="auto-style4">&nbsp;</td>
                        <td>&nbsp;</td>
                            <tr style="page-break-inside: avoid;">
                        <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td><asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                        </table>
                    </td>
                </tr>
                <tr style="page-break-inside: avoid;">
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
