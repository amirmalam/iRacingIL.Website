<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditRace.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.EditRace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Race</h1>
    <h3 class="redmessage">
        <asp:Label ID="_LAMessage" runat="server" CssClass="redmessage" />
    </h3>
    <div class="formBlock">
        <label style="color:white;" for="<%=_DDLSeasons.ClientID %>">Season:</label>
        <asp:DropDownList ClientIDMode="Static" ID="_DDLSeasons" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_DDLSeasons_SelectedIndexChanged" />
        <label  style="color:white;" for="<%=_DDLRaces.ClientID %>">Races:</label>
        <asp:DropDownList ClientIDMode="Static" ID="_DDLRaces" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_DDLRaces_SelectedIndexChanged" />
    </div>

    <div class="formBlock">
        <div class="title">
            Edit Race
        </div>
        <div class="input">

            <asp:Label ID="_LASeasonName" runat="server" />

        </div>
        <div class="input number">

            <label>Number</label>


            <asp:TextBox ID="_TBNum" runat="server" />

        </div>
        <div class="select">

            <label>Track</label>


            <asp:DropDownList ID="_DDLTrack" runat="server" />

        </div>
        <div class="input">

            <label>YouTube ID</label>


            <asp:TextBox ID="_TBYouTubeURL" runat="server" />

        </div>
        <div class="input">

            <label>When</label>


            <asp:TextBox ID="_TBWhen" runat="server" />

        </div>
        <div class="input">

            <label>IsRaced</label>


            <asp:CheckBox ID="_CBIsRaced" runat="server"  />

        </div>

        <div class="input">
            Upload Race Results
         
                <asp:FileUpload ID="_FURaceResult" runat="server" />

        </div>

        <div class="button">


            <asp:Button ID="_BTSubmit" runat="server" Text="Save Form/Upload Result" OnClick="_BTSubmit_Click" />

        </div>

        <div class="button" style="margin-top:5px;">


            <asp:Button runat="server" ID="_BTCalcSrIndex" Text="Calc sR & Champ Points" OnClick="_BTCalcSrIndex_Click" />

        </div>
    </div>

    <div class="table">
    <table id="table1" class="stripe hover compact row-border dataTable no-footer">
        <thead>
        <tr>
            <th>Num</th>
            <th>Track</th>
            <th>Is Raced</th>
        </tr>
            </thead>
        <tbody>
        <asp:Repeater ID="_REPRaces" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("racenumber") %></td>
                    <td><%# Eval("track.name") %></td>
                    <td><%# Eval("israced") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
            </tbody>
    </table>
        </div>

    <script>
        $("#table1").DataTable(
            {
                "pageLength": 100,
                "lengthChange": false,
                "searching": false,
                "paging": false,
                "info": false,
                "responsive": true
            }
        );

        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLSeasons');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#_DDLRaces');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });
        });

    </script>
</asp:Content>
