<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUser.ascx.cs" Inherits="RWAProject.WebFormsClient.Controls.EditUser" %>

<style>
    th, td {
        padding: 5px 0;
    }

    tr td:last-child{
        padding-left: 5px;
    }
</style>

<asp:ObjectDataSource runat="server" ID="roles" SelectMethod="GetRoles" TypeName="RWAProject.WebFormsClient.Utils" />
<asp:ObjectDataSource runat="server" ID="cities" SelectMethod="GetCities" TypeName="RWAProject.WebFormsClient.Utils" />

<div runat="server" id="wrapper" class="editUser col-sm-6 col-lg-4">
    <div class="editUserBorder">
        <table>
            <tbody runat="server" id="inputFields">

                <%--Name--%>
                <tr>
                    <th>
                        <asp:Label Text="Name:" ID="lblName" runat="server" AssociatedControlID="txtName" CssClass="textBoxLabel" meta:resourcekey="lblNameResource1" />
                    </th>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtName" meta:resourcekey="txtNameResource1" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtNameValidator" ControlToValidate="txtName" runat="server"
                            Text="*" CssClass="error" meta:resourcekey="RequiredFieldValidator3Resource1" ErrorMessage="Name is required" />
                    </td>
                </tr>

                <%--Surname--%>
                <tr>
                    <th>
                        <asp:Label Text="Surname:" ID="lblSurname" runat="server" AssociatedControlID="txtSurname" CssClass="textBoxLabel" meta:resourcekey="lblSurnameResource1" />
                    </th>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtSurname" meta:resourcekey="txtSurnameResource1" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtSurnameValidator" ControlToValidate="txtSurname" runat="server"
                            Text="*" CssClass="error" meta:resourcekey="RequiredFieldValidator2Resource1" ErrorMessage="Surname is required" />
                    </td>
                </tr>

                <%--Email Selection--%>
                <tr>
                    <td></td>
                    <td>
                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlEmails"
                            OnSelectedIndexChanged="ddlEmails_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="ddlEmailsResource1"/>
                    </td>
                    <td></td>
                </tr>

                <%--Email--%>
                <tr>
                    <th>
                        <asp:Label CssClass="textBoxLabel" ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email:" meta:resourcekey="lblEmailResource1" />
                    </th>
                    <td>
                        <div class="input-group" style="width: 100%;">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" meta:resourcekey="txtEmailResource1" />

                            <span class="input-group-btn">
                                <asp:LinkButton Text="
                                    &lt;span class=&quot;glyphicon glyphicon-save&quot; style=&quot;color: dodgerblue&quot; /&gt;
                                " runat="server" ID="btnEditEmail" CssClass="btn btn-default btn-sm"
                                    OnClick="btnEditEmail_Click" meta:resourcekey="btnEditEmailResource1"></asp:LinkButton>
                            </span>
                        </div>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtEmailRequiredValidator" ControlToValidate="txtEmail" runat="server"
                            ErrorMessage="Email is required" Text="*" CssClass="error"
                            meta:resourcekey="RequiredFieldValidator2Resource1" />
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server" ID="txtRegexValidator"
                            Text="*" CssClass="error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            meta:resourcekey="RegularExpressionValidatorResource1" ErrorMessage="Email format is invalid" />
                    </td>
                </tr>

                <%--Telephone--%>
                <tr>
                    <th>
                        <asp:Label Text="Telephone:" ID="lblTelephone" runat="server" AssociatedControlID="txtTelephone" CssClass="textBoxLabel" meta:resourcekey="lblTelephoneResource1" />
                    </th>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtTelephone" meta:resourcekey="txtTelephoneResource1" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtTelephoneValidator" ControlToValidate="txtTelephone" runat="server"
                            Text="*" CssClass="error" meta:resourcekey="RequiredFieldValidator1Resource1" ErrorMessage="Telephone is required" />
                    </td>
                </tr>

                <%--Password--%>
                <tr>
                    <th>
                        <asp:Label Text="Password:" ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="textBoxLabel" meta:resourcekey="lblPasswordResource1" />
                    </th>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" meta:resourcekey="txtPasswordResource1" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtPasswordValidator" ControlToValidate="txtPassword" runat="server"
                            Text="*" CssClass="error" meta:resourcekey="txtPasswordValidatorResource1" ErrorMessage="Password is required" />
                    </td>
                </tr>

                <%--Role--%>
                <tr>
                    <th>
                        <asp:Label CssClass="textBoxLabel" ID="lblRole" AssociatedControlID="ddlRoles" runat="server" Text="Status:" meta:resourcekey="lblRoleResource1" />
                    </th>
                    <td>
                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlRoles"
                            DataSourceID="roles" meta:resourcekey="ddlRolesResource1" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="ddlRoles" runat="server" ErrorMessage="Status is required"
                            Text="*" CssClass="error" meta:resourcekey="RequiredFieldValidatorResource1"
                            ID="ddlRolesValidator"/>
                    </td>
                </tr>

                <%--City--%>
                <tr>
                    <th>
                        <asp:Label CssClass="textBoxLabel" ID="lblCity" AssociatedControlID="ddlCities" runat="server" Text="City:" meta:resourcekey="lblCityResource1" />
                    </th>
                    <td>
                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlCities"
                            DataSourceID="cities" meta:resourcekey="ddlCitiesResource1" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="ddlCities" runat="server" ErrorMessage="City is required"
                            Text="*" CssClass="error" meta:resourcekey="RequiredFieldValidatorResource2"
                            ID="ddlCitiesValidator"/>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td></td>
                    <td style="padding-top: 5px;">
                        <asp:Button Text="Edit" CssClass="btn btn-sm btn-primary" runat="server" Width="100px" ID="btnEdit"
                            OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" />
                        <asp:Button Text="Delete" CssClass="btn btn-sm btn-warning" runat="server" Width="100px" ID="btnDelete"
                            OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-top: 5px;">
                        <asp:ValidationSummary CssClass="error" runat="server" ID="validationSummary"
                             meta:resourcekey="validationSummaryResource1"/>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</div>
