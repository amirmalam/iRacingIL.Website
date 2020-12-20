<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTrack.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.AddTrack" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add Track</h1>

    <div class="formBlock">
        <div class="input">
            <label for="<%=_TBName.ClientID %>">Name:</label>
            <asp:TextBox ID="_TBName" runat="server" />
        </div>
        <div class="input">
            <label for="<%=_TBConfig.ClientID %>">Config:</label>
            <asp:TextBox ID="_TBConfig" runat="server" />
        </div>
       
        <div class="button">
            <asp:Button ID="_BTSubmit" runat="server" Text="Save" />
        </div>
       
    </div>

</asp:Content>
