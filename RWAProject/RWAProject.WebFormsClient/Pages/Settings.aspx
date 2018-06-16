<%@ Page Title="Setup" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="RWAProject.WebFormsClient.Settings" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="centered">
        <%--Themes--%>
        <div class="form-group">
            <asp:Label ID="lblTheme" runat="server" AssociatedControlID="ddlThemes" CssClass="textBoxLabel" Text="Theme:" meta:resourcekey="lblThemeResource1" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlThemes" Width="300px" AutoPostBack="True"
                 OnSelectedIndexChanged="ddlThemes_SelectedIndexChanged" meta:resourcekey="ddlThemesResource1">
                <asp:ListItem Text="--- Choose ---" meta:resourcekey="ListItemResource1" />
                <asp:ListItem Text="Default" Value="#eee" meta:resourcekey="ListItemResource2" />
                <asp:ListItem Text="Blue" Value="#4d8fac" meta:resourcekey="ListItemResource3" />
                <asp:ListItem Text="Red" Value="#8f1d21" meta:resourcekey="ListItemResource4" />
            </asp:DropDownList>
        </div>

        <%--Language--%>
        <div class="form-group">
            <asp:Label ID="lblLanguage" runat="server" AssociatedControlID="ddlLanguages" CssClass="textBoxLabel" Text="Language:" meta:resourcekey="lblLanguageResource1" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlLanguages" Width="300px" AutoPostBack="True"
                 OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" meta:resourcekey="ddlLanguagesResource1">
                <asp:ListItem Text="--- Choose ---" meta:resourcekey="ListItemResource5" />
                <asp:ListItem Text="Croatian" Value="hr-HR" meta:resourcekey="ListItemResource6" />
                <asp:ListItem Text="English" Value="en-US" meta:resourcekey="ListItemResource7" />
            </asp:DropDownList>
        </div>

        <%--Repository--%>
        <div class="form-group">
            <asp:Label ID="lblRepository" runat="server" AssociatedControlID="ddlRepositories" CssClass="textBoxLabel" Text="Repository:" meta:resourcekey="lblRepositoryResource1" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRepositories" Width="300px" AutoPostBack="True"
                 OnSelectedIndexChanged="ddlRepositories_SelectedIndexChanged" meta:resourcekey="ddlRepositoriesResource1">
                <asp:ListItem Text="--- Choose ---" meta:resourcekey="ListItemResource8" />
                <asp:ListItem Text="Text File" Value="False" meta:resourcekey="ListItemResource9" />
                <asp:ListItem Text="Database" Value="True" meta:resourcekey="ListItemResource10" />
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
