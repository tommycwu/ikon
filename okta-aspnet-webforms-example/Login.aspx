<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="okta_aspnet_webforms_example.WebForm3" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="background2.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style type="text/css">
        .auto-style1 {
            height: 32px;
            width: 403px;
            bottom: 195px;
        }
        .auto-style4 {
            width: 280px;
        }
        .auto-style5 {
            height: 80px;
            width: 334px;
            margin-left: 48px;
        }
        .auto-style6 {
            width: 3px;
        }
        .auto-style7 {
            height: 25px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="text-right">
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Img/usd.png" />
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Img/passes.png" />
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Img/search.png" />
            </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <div style="width: 50%; align-self:center">
            <table class="auto-style1" style="position: fixed; left: 175px; top: 125px;">
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFFF">
                        &nbsp;</td>
                    <td class="auto-style4" style="background-color: #FFFFFF; clip: rect(auto, auto, auto, auto);">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFFF">
                        &nbsp;</td>
                    <td class="auto-style4" style="background-color: #FFFFFF; clip: rect(auto, auto, auto, auto);">
                        <table class="auto-style5">
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/details.png" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="EMAIL" Font-Names="Arial Black"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" Width="300px" Height="30px" BackColor="#F3F3F3" BorderStyle="None"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="PASSWORD" Font-Names="Arial Black"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" TextMode="Password" Width="300px" Height="30px" BackColor="#F3F3F3" BorderStyle="None"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_ClickAsync" Text="LOG IN" Width="305px" BackColor="#0066CC" Font-Bold="True" Font-Names="Arial Black" Font-Size="Smaller" ForeColor="White" Height="40px" BorderStyle="None" />
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Font-Names="Calibri"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Img/signin.png" OnClick="ImageButton1_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/oktaAddPerson.html">New to Ikon Pass? Create an Account</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            </table>
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </form>
</body>
</html>
