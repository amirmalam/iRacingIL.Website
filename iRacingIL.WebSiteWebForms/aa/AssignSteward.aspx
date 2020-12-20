<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignSteward.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.AssignSteward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Assign Sturats</h1>

    <h3 class="redmessage">
        <asp:Label ID="_LAMessage" runat="server" CssClass="redmessage bold" />
    </h3>

    <div class="formBlock">

        <div class="title">
            Choose stuart for last race:
            <asp:Literal ID="_LIRaceName" runat="server" />
        </div>

        <div class="select">
            <label for="<%=_DDLStuart1.ClientID %>">Steward  1:</label>
            <asp:DropDownList ID="_DDLStuart1" ClientIDMode="Static" runat="server" />
        </div>
        <div class="select">
            <label for="<%=_DDLStuart2.ClientID %>">Steward 2:</label>
            <asp:DropDownList ID="_DDLStuart2" ClientIDMode="Static" runat="server" />
        </div>
        <div class="select">
            <label for="<%=_DDLStuart3.ClientID %>">Steward 3:</label>
            <asp:DropDownList ID="_DDLStuart3" ClientIDMode="Static" runat="server" />
        </div>
        <div class="select">
            <label for="<%=_DDLStuart4.ClientID %>">Steward 4:</label>
            <asp:DropDownList ID="_DDLStuart4" ClientIDMode="Static" runat="server" />
        </div>
        <div class="button">
            <asp:Button ID="_BTSaveStuarts" runat="server" Text="Save" OnClick="_BTSaveStuarts_Click" />
        </div>
    </div>

    <script>

        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLStuart1');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLStuart2');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLStuart3');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLStuart4');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
    </script>
</asp:Content>
