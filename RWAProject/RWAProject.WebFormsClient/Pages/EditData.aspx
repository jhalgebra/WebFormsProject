<%@ Page Title="Edit data" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditData.aspx.cs" Inherits="RWAProject.WebFormsClient.EditData" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <style>

    .close {
        background: none;
        border: none;
    }

    </style>

    <asp:PlaceHolder runat="server" ID="placeholder" />
    <div style="padding-top: 1px; clear: both;"/>

    <div class="modal" tabindex="-1" role="dialog" id="modal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" style="display: inline-block;">
                        <asp:Label Text="Delete person?" ID="lblTitle" runat="server" meta:resourcekey="lblTitleResource1" />
                    </h5>
                    <asp:Button Text="&times;" runat="server" CssClass="close pull-right" meta:resourcekey="ButtonResource1" />
                </div>
                <div class="modal-footer">
                    <asp:Button Text="Delete" runat="server" CssClass="btn btn-primary" ID="btnConfirm" OnClick="btnConfirm_Click" meta:resourcekey="btnConfirmResource1" />
                    <asp:Button Text="Close" runat="server" CssClass="btn btn-secondary" ID="btnCancel" meta:resourcekey="btnCancelResource1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
