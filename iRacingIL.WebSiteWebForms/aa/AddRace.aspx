<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRace.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.AddRace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add Race</h1>

    <div class="formBlock">
        <label style="color: white;" for="<%=_DDLSeasons.ClientID %>">Season:</label>
        <asp:DropDownList ClientIDMode="Static" ID="_DDLSeasons" runat="server" AutoPostBack="false" OnSelectedIndexChanged="_DDLSeasons_SelectedIndexChanged" />
    </div>

    <div class="formBlock">
        <div class="input number">
            <label>Race Number:</label>
            <asp:TextBox ID="_TBNum" runat="server" TextMode="Number" />
        </div>
        <div class="select">
            <label>Track:</label>
            <asp:DropDownList ClientIDMode="Static" ID="_DDLTrack" runat="server" />
        </div>
	<div class="input">
            <label>You Tube URL:</label>
            <asp:TextBox ID="_TBYouTubeURL" runat="server" />
        </div>
	<div class="input">
            <label>When:</label>
            <asp:TextBox ID="_TBWhen" runat="server" />
        </div>
        <div class="button">
            <asp:Button ID="_BTSubmit" runat="server" Text="Save" />
        </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLSeasons');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLTrack');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
    </script>

</asp:Content>
