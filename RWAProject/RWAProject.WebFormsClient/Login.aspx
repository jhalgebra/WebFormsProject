<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RWAProject.WebFormsClient.Login" %>

<%@ Register Src="~/Controls/LabelledTextbox.ascx" TagPrefix="uc1" TagName="LabelledTextbox" %>
<%@ Register Src="~/Controls/ErrorInfo.ascx" TagPrefix="uc1" TagName="ErrorInfo" %>
<%@ Register Src="~/Controls/EditUser.ascx" TagPrefix="uc1" TagName="EditUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:EditUser runat="server" ID="EditUser1" ValidationGroup="User1" />
    <uc1:EditUser runat="server" ID="EditUser2" ValidationGroup="User2" />
    <uc1:EditUser runat="server" ID="EditUser3" ValidationGroup="User3" />
    <uc1:EditUser runat="server" ID="EditUser" ValidationGroup="User4" />

    <div class="row" style="clear: both;">
        <div class="col-sm-4"></div>

        <div class="col-sm-4">
            <uc1:LabelledTextbox runat="server" ID="txtEmail" Label="E-mail:"
                ValidatorErrorMessage="E-mail is required" />
            <uc1:LabelledTextbox runat="server" ID="txtPassword" Label="Password:"
                ValidatorErrorMessage="Password is required" />

            <asp:Button runat="server" Text="Enter" ID="btnLogin" OnClick="btnLogin_Click"
                CssClass="btn btn-primary btn-sm" />
            <uc1:ErrorInfo runat="server" ID="error" />
        </div>

        <div class="col-sm-4"></div>
    </div>
</asp:Content>
