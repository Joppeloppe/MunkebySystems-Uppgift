<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication.Views.User" MasterPageFile="~/Views/Site.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="col-sm-10">
        <div>
            <h1>User information</h1>
        </div>
    </div>

    <br />

    <div>
        <asp:Label CssClass="col-sm-2" ID="LabelUsername" AssociatedControlID="LabelUsername" runat="server" Text="Username" />
    </div>
    <br />
    <div>
        <asp:Label CssClass="col-sm-2" ID="LabelNewPassword" AssociatedControlID="LabelNewPassword" runat="server" Text="Change Password" />
        <div class="col-sm-10">
            <asp:TextBox ID="TextBoxNewPassword" CssClass="form-control" runat="server" TextMode="Password" />
        </div>
        <asp:Label CssClass="col-sm-2" ID="Label1" AssociatedControlID="LabelPassword" runat="server" Text="Re-enter new password" />
        <div class="col-sm-10">
            <asp:TextBox ID="TextBoxPasswordCheck" CssClass="form-control" runat="server" TextMode="Password" OnTextChanged="TextBoxPasswordCheck_TextChanged" />
        </div>
        <br />
        <asp:Label CssClass="col-sm-2" ID="LabelPassword" AssociatedControlID="LabelPassword" runat="server" Text="Enter current Password" />
        <div class="col-sm-10">
            <asp:TextBox ID="TextBoxPassword" CssClass="form-control" runat="server" TextMode="Password" />
        </div>
    </div>

    <br />

    <div>
        <asp:Button ID="ButtonSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
    </div>
</asp:Content>
