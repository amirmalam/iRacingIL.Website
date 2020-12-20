<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSeason.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.AddSeason" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h1>Add Season</h1>

    <div class="formBlock">
        <div class="input">
            <label for="<%=_TBName.ClientID %>">Name:</label>
            <asp:TextBox ID="_TBName" runat="server" />
        </div>
        <div class="input">
            <label for="<%=_TBCar.ClientID %>">Car:</label>
            <asp:TextBox ID="_TBCar" runat="server" />
        </div>
        <div class="input number">
            <label for="<%=_TBNumber.ClientID %>">Car:</label>
            <asp:TextBox ID="_TBNumber" runat="server" TextMode="Number" />
        </div>
        <div class="input">
            <label for="<%=_CBIsCurrent.ClientID %>">Car:</label>
            <asp:CheckBox ID="_CBIsCurrent" runat="server" />
        </div>
        <div class="button">
            <asp:Button ID="_BTSubmit" runat="server" Text="Send" />
        </div>
       
    </div>

</asp:Content>
