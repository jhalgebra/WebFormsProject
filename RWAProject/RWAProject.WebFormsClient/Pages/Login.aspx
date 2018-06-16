<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="RWAProject.WebFormsClient.Login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Controls/EditUser.ascx" TagPrefix="uc1" TagName="EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="centered">

        <%--Email--%>
        <div class="form-group">
            <asp:Label Text="Email:" ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="textBoxLabel" meta:resourcekey="lblEmailResource1" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server"
                Text="*" CssClass="error" ErrorMessage="Email is required" meta:resourcekey="RequiredFieldValidator1Resource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" Width="300" meta:resourcekey="txtEmailResource1" />
        </div>

        <%--Password--%>
        <div class="form-group">
            <asp:Label Text="Password:" ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="textBoxLabel" meta:resourcekey="lblPasswordResource1" />
            <asp:RequiredFieldValidator ID="txtPasswordValidator" ControlToValidate="txtPassword" runat="server"
                Text="*" CssClass="error" ErrorMessage="Password is required" meta:resourcekey="txtPasswordValidatorResource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" Width="300"
                TextMode="Password" meta:resourcekey="txtPasswordResource1" />
        </div>

        <asp:CheckBox Text="Remember me" runat="server" ID="cbRememberUser" meta:resourcekey="cbRememberUserResource1" />
        <br />
        <asp:Button runat="server" Text="Enter" ID="btnLogin" OnClick="btnLogin_Click"
            CssClass="btn btn-primary" meta:resourcekey="btnLoginResource1" />
        
        <br />
        <br />

        <asp:ValidationSummary runat="server" CssClass="error" />
        <asp:Label Text="" runat="server" CssClass="error" ID="lblError" Width="300" />
    </div>
</asp:Content>
