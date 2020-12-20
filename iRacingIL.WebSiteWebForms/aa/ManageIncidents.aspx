<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageIncidents.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.ManageIncidents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <h1>Manage Incidents</h1>

        <h3 runat="server" id="PAlert" class="redmessage">Form Saved Successfull</h3>


        <div class="formBlock">

                <label for="<%=_DDLIncidents.ClientID %>">Choose Incident: </label>
                <asp:DropDownList ClientIDMode="Static" ID="_DDLIncidents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_DDLIncidents_SelectedIndexChanged" />    
            <div class="button">
                <asp:Button OnClientClick="return confirm('Close all incident and issue final decisions?');" ID="_BTCloseAllIncidents" runat="server" Text="Close All Incidents!" OnClick="_BTCloseAllIncidents_Click" />
            </div>
        </div>

        <div class="formBlock">

            <div class="title">
                <asp:Literal ID="_LIIncidentName" runat="server" />
            </div>

            <div class="input">
                <label>IncidentID:</label>

                <asp:Literal ID="_LIIncidentID" runat="server" />
            </div>
            <div class="input">
                <label>Reporter:</label>
                <asp:Literal ID="_LIReporter" runat="server" />
            </div>
            <div class="input">
                <label>Description:</label>
                <p>
                    <asp:Literal ID="_LIDescription" runat="server" /></p>
            </div>
            <div class="input">
                <label>Drivers Involve:</label>
                <asp:Literal ID="_LIDriversInvlove" runat="server" />

            </div>
            <div class="input">
                <asp:Repeater ID="_REPResponses" runat="server">
                    <ItemTemplate>
                        <label id="LAResponseDriver" runat="server">Response From: <%# Eval("driver.name") %></label>
                        <p><%# Eval("response") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <br />
            <div class="input">
                <asp:Repeater ID="_REPStuarts" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="HFIncidentStuartID" runat="server" Value='<%# Eval("idincident_stuartsid") %>' />
                        <label id="LAResponseDriver" runat="server">Stuart Response: <%# Eval("driver.name") %></label>
                        <p><%# Eval("desc") %></p>
                        <label>Decisions:</label>
                        <p runat="server" id="PNoDecition" visible="false">No Decisions: CAT0</p>
                        <asp:Repeater ID="REPDecisions" runat="server">
                            <ItemTemplate>
                                <p><%# Eval("driver.name") %>: CAT<%# Eval("cat") %></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="button">
                <asp:Button CssClass="btn btn-primary form-control" ID="_TBDelete" runat="server" Text="Delete!" OnClick="_TBDelete_Click" />
            </div>
            <div class="title">
                Final Dicision:
            </div>
            <div class="select">
            <label>Choose up to 3 drivers and their CAT:</label>
            <div class="multiSelect">
                <asp:DropDownList ClientIDMode="Static" ID="_DDLDriversFinal1" runat="server" Width="350" />
                <asp:DropDownList ClientIDMode="Static" ID="_DDLCatFinal1" runat="server" Width="350" />
                </div>
            </div>
            <div class="select">
                <div class="multiSelect">
                <asp:DropDownList ClientIDMode="Static" ID="_DDLDriversFinal2" runat="server" Width="350" />
                <asp:DropDownList ClientIDMode="Static" ID="_DDLCatFinal2" runat="server" Width="350" />
                    </div>
            </div>
            <div class="select">
                <div class="multiSelect">
                <asp:DropDownList ClientIDMode="Static" ID="_DDLDriversFinal3" runat="server" Width="350" />
                <asp:DropDownList ClientIDMode="Static" ID="_DDLCatFinal3" runat="server" Width="350" />
                    </div>
            </div>
            <div class="button">
                <asp:Button ID="_BTSubmitFinal" runat="server" Text="Save" OnClick="_BTSubmitFinal_Click" />
            </div>
        </div>




    </div>

    <script>
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLIncidents');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });

        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDriversFinal1');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDriversFinal2');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLDriversFinal3');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLCatFinal1');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLCatFinal2');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLCatFinal3');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
    </script>
</asp:Content>
