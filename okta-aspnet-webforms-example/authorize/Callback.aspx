<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Callback.aspx.cs" Inherits="okta_aspnet_webforms_example.authorize.Callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="background6.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 90px;
        }
        .auto-style2 {
            width: 180px;
        }
        .auto-style3 {
            width: 160px;
        }
        .auto-style4 {
            width: 275px;
        }
        .auto-style5 {
            width: 200px;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style7 {
            width: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style6">
        <script type="text/javascript">

            function JavaScriptFunction() {
                document.getElementById('<%= hdnResultValue.ClientID %>').value = document.URL;
            }

        </script>

        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Img/usd.png" />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Img/logout.png" OnClick="ImageButton3_Click" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Img/search.png" />

        <asp:HiddenField ID="hdnResultValue" Value="0" runat="server" />
        <br />
        <br />
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial Black" Font-Size="XX-Large" Text="HI, USER"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial Black" Text="OVERVIEW"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Font-Names="Arial Black" Text="BILLING &amp; SHIPPING"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label4" runat="server" Font-Names="Arial Black" Text="ORDER HISTORY"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" Font-Names="Arial Black" Font-Size="Medium" Font-Underline="False" ForeColor="Black" OnClick="LinkButton1_Click" OnClientClick="JavaScriptFunction();">PROFILE</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Text="No pass registered"></asp:Label>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        </div>
    </form>
</body>
</html>
