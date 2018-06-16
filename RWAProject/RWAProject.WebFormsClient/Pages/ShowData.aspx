<%@ Page Title="Person list" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ShowData.aspx.cs" Inherits="RWAProject.WebFormsClient.ShowData" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../Content/Tables.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:ObjectDataSource runat="server" ID="roles" SelectMethod="GetRoles" TypeName="RWAProject.WebFormsClient.Utils" />

    <div class="panel-group">

        <%--Grid View--%>
        <div class="panel panel-default">

            <%--Grid View Title--%>
            <div class="panel-heading" role="tab">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#gridViewContent" aria-expanded="true">Grid View</a>
                </h4>
            </div>

            <%--Grid View Content--%>
            <div id="gridViewContent" class="panel-collapse collapse in" aria-expanded="true">
                <div class="panel-body">
                    <asp:GridView runat="server" AutoGenerateColumns="False" ID="grid" OnRowDataBound="grid_RowDataBound"
                        OnRowEditing="grid_RowEditing" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowUpdating="grid_RowUpdating"
                        GridLines="Horizontal" CssClass="bottomBorder" meta:resourcekey="gridResource1">
                        <Columns>

                            <%--Name--%>
                            <asp:BoundField HeaderText="Name" DataField="Name" meta:resourcekey="BoundFieldResource1" />
                            <%--Surname--%>
                            <asp:BoundField HeaderText="Surname" DataField="Surname" meta:resourcekey="BoundFieldResource2" />

                            <%--Emails--%>
                            <asp:TemplateField HeaderText="Email addresses" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink NavigateUrl='<%# "mailto:" + Eval("Email") %>'
                                                runat="server" Text='<%# Eval("Email") %>' meta:resourcekey="HyperLinkResource1" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <div style="margin: 5px 0;">
                                                <asp:TextBox runat="server" Text='<%# Eval("Email") %>' meta:resourcekey="TextBoxResource1" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <%--Telephone--%>
                            <asp:BoundField HeaderText="Telephone" DataField="Telephone" meta:resourcekey="BoundFieldResource3" />

                            <%--Role--%>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" Enabled="False" CssClass="form-control autoWidth"
                                         DataTextField="Name" DataValueField="ID" meta:resourcekey="DropDownListResource2"/>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" CssClass="form-control autoWidth" DataSourceID="roles"
                                        DataTextField="Name" DataValueField="ID" meta:resourcekey="DropDownListResource1" />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <%--Edit--%>
                            <asp:CommandField CancelText="Cancel" DeleteText="Delete" EditText="Edit" ShowEditButton="true" meta:resourcekey="CommandFieldResource1" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>

        <%--Repeater--%>
        <div class="panel panel-default">

            <%--Repeater Title--%>
            <div class="panel-heading" role="tab">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#repeaterContent">Repeater</a>
                </h4>
            </div>

            <%--Repeater Content--%>
            <div id="repeaterContent" class="panel-collapse collapse">
                <div class="panel-body">
                    <asp:Repeater runat="server" ID="repeater" OnItemCommand="repeater_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-condensed table-hover">
                                <tr>
                                    <th>
                                        <asp:Label Text="Name" runat="server" meta:resourcekey="LabelResource1" />
                                    </th>
                                    <th>
                                        <asp:Label Text="Surname" runat="server" meta:resourcekey="LabelResource2" />
                                    </th>
                                    <th>
                                        <asp:Label Text="Email addresses" runat="server" meta:resourcekey="LabelResource3" />
                                    </th>
                                    <th>
                                        <asp:Label Text="Telephone" runat="server" meta:resourcekey="LabelResource4" />
                                    </th>
                                    <th>
                                        <asp:Label Text="Status" runat="server" meta:resourcekey="LabelResource5" />
                                    </th>
                                    <th>
                                        <asp:Label Text="City" runat="server" meta:resourcekey="LabelResource6" />
                                    </th>
                                    <th></th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label Text='<%# Eval("Name") %>' runat="server" meta:resourcekey="LabelResource7" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("Surname") %>' runat="server" meta:resourcekey="LabelResource8" />
                                </td>
                                <td>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Emails") %>'>
                                        <ItemTemplate>
                                            <asp:HyperLink NavigateUrl='<%# "mailto:" + Eval("Email") %>'
                                                runat="server" Text='<%# Eval("Email") %>' meta:resourcekey="HyperLinkResource2" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("Telephone") %>' runat="server" meta:resourcekey="LabelResource9" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("RoleName") %>' runat="server" meta:resourcekey="LabelResource10" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("CityName") %>' runat="server" meta:resourcekey="LabelResource11" />
                                </td>
                                <td>
                                    <asp:Button Text="Edit" runat="server" CssClass="btn btn-primary btn-sm" meta:resourcekey="ButtonResource1" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
