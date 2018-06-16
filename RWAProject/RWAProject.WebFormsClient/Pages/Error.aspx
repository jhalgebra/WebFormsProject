<%@ Page Title="Error" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="RWAProject.WebFormsClient.Error" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Label Text="An error occurred" runat="server" CssClass="error big" meta:resourcekey="LabelResource1" />

    <br />

    <asp:Label Text="Error Message:" runat="server" CssClass="textBoxLabel" ID="lblErrorMessage" meta:resourcekey="lblErrorMessageResource1" />
    <asp:Label ID="lblErrorMessageText" runat="server" CssClass="error" meta:resourcekey="lblErrorMessageTextResource1" />

    <br />
    <br />

    <asp:Label Text="Stack Trace:" runat="server" CssClass="textBoxLabel" ID="lblStackTrace" meta:resourcekey="lblStackTraceResource1" />
    <asp:Label ID="lblStackTraceText" runat="server" meta:resourcekey="lblStackTraceTextResource1" />

    <br />
    <br />

    <asp:HyperLink runat="server" Text="< Back to Login page" NavigateUrl="~/Pages/Login.aspx" ID="btnBackToLogin" meta:resourcekey="btnBackToLoginResource1" />
</asp:Content>
