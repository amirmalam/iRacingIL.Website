<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidentResponse.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.IncidentResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Incident Response - <asp:Literal ID="_LIRaceName" runat="server" /></h1>

    <h3 class="redmessage">
        <asp:Literal ID="_LIMessage" runat="server" />
    </h3>

    <div class="formBlock" style="text-align:center;">

        <asp:DropDownList Width="400" ID="_DDLIncidents" ClientIDMode="Static" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_DDLIncidents_SelectedIndexChanged" />
    </div>
    <div class="formBlock" id="divForm" runat="server">

        <div class="title">
            <asp:Literal ID="_LAIncidentName" runat="server" />
        </div>

        <div class="input">
            <label>Drivers Involves:</label>
            <asp:Literal ID="_LIDrivers" runat="server"/>

        </div>
        <div class="input">
            <label>Description</label>

            <asp:Literal ID="_LIDesc" runat="server"/>
          
               
            

        </div>
        <div class="input">
            <label for="<%=_TBResponse.ClientID %>">Your Response:</label>

            <asp:TextBox CssClass="form-control" ID="_TBResponse" runat="server" TextMode="MultiLine" Height="100" />

        </div>

        <div class="button">
            <asp:Button ID="_BTSubmit" runat="server" Text="Save" OnClick="_BTSubmit_Click" />
        </div>

    </div>

    <script>
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLIncidents');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });

        });
    </script>


</asp:Content>
