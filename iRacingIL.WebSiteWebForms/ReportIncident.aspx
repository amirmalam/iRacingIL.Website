<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportIncident.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.ReportIncident" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>report incident</h1>

    <h3 style="color:white;"> <asp:Literal ID="_LIRaceName" runat="server" /></h3>
    <asp:Label ID="_LAReportClosed" runat="server" CssClass="redmessage" />
    <div class="table">
        <table id="table1" class="hover compact row-border dataTable no-footer">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Lap</th>
                    <th>Turn</th>
                    <th>Driver 1</th>
                    <th>Driver 2</th>
                    <th>Driver 3</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="_REPReports" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("incidentid") %></td>
                            <td><%# Eval("lap") %></td>
                            <td class="text-left"><%# Eval("turn") %></td>
                            <td class="text-left">
                                <asp:Literal ID="LIDriver1" runat="server" /></td>
                            <td class="text-left">
                                <asp:Literal ID="LIDriver2" runat="server" /></td>
                            <td class="text-left">
                                <asp:Literal ID="LIDriver3" runat="server" /></td>
                            <td class="text-left"><%# Eval("desc") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <div class="formBlock" id="divForm" runat="server">

        <div class="title">
            <asp:Literal ID="_LIRace" runat="server" />
        </div>

        <div class="input number">
            <label for="<%=_TBLap.ClientID %>">Lap:</label>

            <asp:TextBox Width="80" ID="_TBLap" TextMode="Number" runat="server" />
            <div class="note">Number Only</div>

        </div>
        <div class="input">
            <label for="<%=_TBTurn.ClientID %>">Turn:</label>

            <asp:TextBox ID="_TBTurn" runat="server" Width="350" />
            <div class="note">Number or Text</div>

        </div>
        <div class="select">
            <label for="<%=_DDLDriver1.ClientID %>">Drivers Involve:</label>

            <asp:DropDownList ID="_DDLDriver1" ClientIDMode="Static" runat="server" Width="250" />
            <asp:DropDownList ID="_DDLDriver2" ClientIDMode="Static" runat="server" Width="250" />
            <asp:DropDownList ID="_DDLDriver3" ClientIDMode="Static" runat="server" Width="250" />
            <div class="note">Up to 3 drivers involve in this incident in order to find it</div>
        </div>

        <div class="input">
            <label for="<%=_DDLDesc.ClientID %>">Description:</label>

            <asp:DropDownList ID="_DDLDesc" runat="server">
                <asp:ListItem Text="Rear Bump" />
                <asp:ListItem Text="Dive Bomb" />
                <asp:ListItem Text="Not Leaving Space" />
                <asp:ListItem Text="General Collision" />
                <asp:ListItem Text="Unsafe Return" />
                <asp:ListItem Text="Blue Flag" />
                <asp:ListItem Text="Other" />
            </asp:DropDownList>
            <div class="note">Select item most describe the incident</div>
        </div>
        <div class="button">
            <asp:Button ID="_BTSubmit" runat="server" Text="Save" OnClick="_BTSubmit_Click" />
        </div>

    </div>
    
     <script type="text/javascript">
         $(document).ready(function () {
             $("#table1").DataTable(
                 {
                     "pageLength": 100,
                     "lengthChange": false,
                     "searching": false,
                     "paging": false,
                     "info": false,
                     "createdRow": function (row, data, dataIndex, cells) {
                     }
                 }
             );
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


    </script>
</asp:Content>



