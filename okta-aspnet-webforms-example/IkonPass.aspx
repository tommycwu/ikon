﻿<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="IkonPass.aspx.cs" Inherits="okta_aspnet_webforms_example.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="gridview.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div>
            
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
            
        </div>
        <div class="text-center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Scan your Ikon Pass to see how many days remain."></asp:Label></div>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Img/19-20 season pass.png" OnClick="ImageButton1_ClickAsync" CssClass="center-block" />
        <div class="text-center">
            <br />
            <asp:Label ID="Label4" runat="server" Text="Pass Id:"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register This Pass!" Visible="False" />
            <br />
            <br />
        <br />
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Access Token" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:GridView runat="server" ID="GridViewAccess" CssClass="mGrid" CellPadding="0"></asp:GridView>
        </div>
    </form>
</body>
</html>
