<%@ Page Title="Add new person" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddData.aspx.cs" Inherits="RWAProject.WebFormsClient.Pages.AddData" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:ObjectDataSource runat="server" ID="roles" SelectMethod="GetRoles" TypeName="RWAProject.WebFormsClient.Utils" />
    <asp:ObjectDataSource runat="server" ID="cities" SelectMethod="GetCities" TypeName="RWAProject.WebFormsClient.Utils" />

    <div class="col-sm-4">

        <%--Name--%>
        <div class="form-group">
            <asp:Label Text="Name:" ID="lblName" runat="server" AssociatedControlID="txtName" CssClass="textBoxLabel" meta:resourcekey="lblNameResource1" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server"
                Text="*" CssClass="error" ErrorMessage="Name is required" meta:resourcekey="RequiredFieldValidator1Resource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtName" meta:resourcekey="txtNameResource1" />
        </div>

        <%--Surname--%>
        <div class="form-group">
            <asp:Label Text="Surname:" ID="lblSurname" runat="server" AssociatedControlID="txtSurname" CssClass="textBoxLabel" meta:resourcekey="lblSurnameResource1" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSurname" runat="server"
                Text="*" CssClass="error" ErrorMessage="Surname is required" meta:resourcekey="RequiredFieldValidator2Resource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtSurname" meta:resourcekey="txtSurnameResource1" />
        </div>

        <%--Email--%>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" CssClass="textBoxLabel" Text="Email:" meta:resourcekey="lblEmailResource1" />

            <asp:PlaceHolder runat="server" ID="phEmails" />
            <asp:LinkButton Text="Add more email addresses..." runat="server" ID="btnAddEmail" OnClick="btnAddEmail_Click" CausesValidation="False" meta:resourcekey="btnAddEmailResource1" />
        </div>
    </div>
    <div class="col-sm-4">

        <%--Telephone--%>
        <div class="form-group">
            <asp:Label Text="Telephone:" ID="lblTelephone" runat="server" AssociatedControlID="txtTelephone" CssClass="textBoxLabel" meta:resourcekey="lblTelephoneResource1" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtTelephone" runat="server"
                Text="*" CssClass="error" ErrorMessage="Telephone is required" meta:resourcekey="RequiredFieldValidator3Resource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtTelephone" meta:resourcekey="txtTelephoneResource1" />
        </div>

        <%--City--%>
        <div class="form-group">
            <asp:Label ID="lblCity" runat="server" AssociatedControlID="ddlCities" CssClass="textBoxLabel" Text="City:" meta:resourcekey="lblCityResource1" />
            <asp:RequiredFieldValidator ID="ddlCitiesValidator" ControlToValidate="ddlCities" runat="server"
                Text="*" CssClass="error" ErrorMessage="City is required" meta:resourcekey="ddlCitiesValidatorResource1" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCities" DataSourceID="cities"
                DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlCitiesResource1" />
        </div>

        <%--Role--%>
        <div class="form-group">
            <asp:Label ID="lblRole" runat="server" AssociatedControlID="ddlRoles" CssClass="textBoxLabel" Text="Status:" meta:resourcekey="lblRoleResource1" />
            <asp:RequiredFieldValidator ID="ddlRolesValidator" ControlToValidate="ddlRoles" runat="server"
                Text="*" CssClass="error" ErrorMessage="Status is required" meta:resourcekey="ddlRolesValidatorResource1" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRoles" DataSourceID="roles"
                DataTextField="Name" DataValueField="ID" meta:resourcekey="ddlRolesResource1" />
        </div>
    </div>
    <div class="col-sm-4">

        <%--Password--%>
        <div class="form-group">
            <asp:Label Text="Password:" ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="textBoxLabel" meta:resourcekey="lblPasswordResource1" />
            <asp:RequiredFieldValidator ID="txtPasswordValidator" ControlToValidate="txtPassword" runat="server"
                Text="*" CssClass="error" ErrorMessage="Password is required" meta:resourcekey="txtPasswordValidatorResource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword"
                TextMode="Password" meta:resourcekey="txtPasswordResource1" />
        </div>

        <%--Confirm Password--%>
        <div class="form-group">
            <asp:Label Text="Confirm Password:" ID="lblConfirmPassword" runat="server"
                AssociatedControlID="txtConfirmPassword" CssClass="textBoxLabel" meta:resourcekey="lblConfirmPasswordResource1" />
            <asp:RequiredFieldValidator ID="txtConfirmPasswordValidator" ControlToValidate="txtConfirmPassword" runat="server"
                Text="*" CssClass="error" ErrorMessage="Password confirmation is required" meta:resourcekey="txtConfirmPasswordValidatorResource1" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmPassword"
                TextMode="Password" meta:resourcekey="txtConfirmPasswordResource1" />
            <asp:CompareValidator ErrorMessage="Passwords must match" ControlToValidate="txtConfirmPassword" runat="server"
                ControlToCompare="txtPassword" Display="None" meta:resourcekey="CompareValidatorResource1" />
        </div>

        <asp:Button Text="Add" runat="server" ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-primary" meta:resourcekey="btnAddResource1" />
    </div>

    <div style="padding-top: 10px; clear: both;" />

    <asp:ValidationSummary runat="server" CssClass="error" />
</asp:Content>
