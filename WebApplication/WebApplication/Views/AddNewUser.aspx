<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="WebApplication.AddNewUser" MasterPageFile="~/Views/Site.Master"%>

<asp:content runat="server" contentplaceholderid="MainContent">

    <div class="w-75" style="padding-left:5%">
        <div class="col-sm-10">
            <div>
                <h1>Register new user</h1>
            </div>
        </div>

        <br />

        <div>
            <asp:Label CssClass="col-sm-2" ID="LabelUsername" AssociatedControlID="LabelUsername" runat="server" Text="Username" />
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxUsername" CssClass="form-control" runat="server" />
            </div>
        </div>
        <br />
        <div>
            <asp:Label CssClass="col-sm-2" ID="LabelPassword" AssociatedControlID="LabelPassword" runat="server" Text="Password" />
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxPassword" CssClass="form-control" runat="server" TextMode="Password" />
            </div>
        </div>

        <br />

        <div>
            <asp:Button ID="ButtonSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        </div>
    </div>
</asp:content>
