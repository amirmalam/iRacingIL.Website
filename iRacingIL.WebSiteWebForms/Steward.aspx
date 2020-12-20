<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Steward.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.Steward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Steward</h1>

    <h3 class="redmessage">
        <asp:Literal ID="_LIMessage" runat="server" /></h3>

    <div class="formBlock">
        <label style="color:white;" for="<%=_DDLNeedTo.ClientID %>">In Queue:</label>
        <asp:DropDownList ID="_DDLNeedTo" ClientIDMode="Static" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_DDLNeedTo_SelectedIndexChanged" />
        <label  style="color:white;" for="<%=_DDLDone.ClientID %>">Done:</label>
        <asp:DropDownList ID="_DDLDone" ClientIDMode="Static" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_DDLNeedTo_SelectedIndexChanged" />

    </div>
    <div class="formBlock" runat="server" id="_DVForm">

        <div class="title">
            Incident Details
        </div>

        <div class="input">
            <label>Lap:</label>
            <asp:Label ID="_LALap" runat="server" />
        </div>
        <div class="input">
            <label>Turn:</label>
            <asp:Label ID="_LATurn" runat="server" />
        </div>
        <div class="input">
            <label>Description:</label>
            <p>
                <asp:Label ID="_LADesc" runat="server" />
            </p>
        </div>

        <asp:Repeater ID="_REPResponses" runat="server">
            <ItemTemplate>
                <div class="input">
                    <label>Response From: <%# Eval("driver.name") %></label>
                    <p><%# string.IsNullOrEmpty(Eval("response").ToString()) ? "N/A" : Eval("response").ToString() %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="input">
            <label for="<%=_TBConclutions.ClientID %>">Your Conclutions:</label>
            <asp:TextBox ID="_TBConclutions" runat="server" TextMode="MultiLine" Height="100" />
        </div>
        <div class="select">
            <label>Choose up to 3 drivers and their CAT:</label>
            <div class="multiSelect">
            <asp:DropDownList ClientIDMode="Static" ID="_DDLDriver1" runat="server" Width="350" />
            <asp:DropDownList ClientIDMode="Static" ID="_DDLPunish1" runat="server" Width="350" />
                </div>
        </div>
        <div class="select">
        <div class="multiSelect">
            <asp:DropDownList ClientIDMode="Static" ID="_DDLDriver2" runat="server" Width="350" />
            <asp:DropDownList ClientIDMode="Static" ID="_DDLPunish2" runat="server" Width="350" />
        </div>
            </div>
        <div class="select">
        <div class="multiSelect">
            <asp:DropDownList ClientIDMode="Static" ID="_DDLDriver3" runat="server" Width="350" />
            <asp:DropDownList ClientIDMode="Static" ID="_DDLPunish3" runat="server" Width="350" />
        </div>
            </div>
        <div class="button">
            <asp:Button ID="_BTSubmit" runat="server" Text="Save" OnClick="_BTSubmit_Click" />
        </div>

    </div>

    <script>
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLNeedTo');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDone');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });

        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDriver1');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDriver2');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDriver3');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLPunish1');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLPunish2');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLPunish3');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
    </script>
</asp:Content>
