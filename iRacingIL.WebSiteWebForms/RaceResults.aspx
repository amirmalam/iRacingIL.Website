<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RaceResults.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.RaceResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-c-red text-white m-0">
        <div class="row m0 pl-5">
            <div class="" style="">
                <span class="text-uppercase bold" style="font-size: 140%">Races</span>
            </div>
        </div>
    </div>

    <div class="row m-2">
        <div class="btn-group">
            <button type="button" class="btn m-2 btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <%=mRace.season.name %>
            </button>
            <div class="dropdown-menu">
                <asp:Repeater ID="_REPSeasons" runat="server">
                    <ItemTemplate>
                        <a class="dropdown-item" href="/RaceResults?s=<%# Eval("seasonid") %>"><%# Eval("name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="btn-group">
            <button type="button" class="btn m-2 btn-success dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <%=mRace.racenumber + " - " + mRace.track.name %>
            </button>
            <div class="dropdown-menu">
                <asp:Repeater ID="_REPRaces" runat="server">
                    <ItemTemplate>
                        <a class="dropdown-item" href="/RaceResults?s=<%# Eval("season.seasonid") %>&r=<%# Eval("raceid") %>"><%# Eval("racenumber") %> - <%# Eval("track.name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>


    <div class="row-border m-2">
        <button id="btRace" type="button" class="btn btn-primary">Race</button>
        <button id="btIncidents" type="button" class="btn btn-danger">Incidents</button>
        <button id="btReplay" type="button" class="btn btn-secondary">Replay</button>
    </div>

    <div id="divRace">
        <div class="bg-c-red text-white m-0">
            <div class="row m0 pl-5">
                <div class="" style="">
                    <span class="text-uppercase bold" style="font-size: 140%">Race Result</span>
                </div>
            </div>
        </div>
        <table id="table1" class="stripe hover compact row-border">
            <thead>
                <tr class="bg-c-yellow">
                    <th>#</th>
                    <th>Name</th>
                    <th class="text-center" title="Interval">Interval</th>
                    <th class="text-center" title="Start Position">Start</th>
                    <th class="text-center" title="Best Race Lap">Best Lap</th>
                    <th class="text-center" title="Laps Complited">Laps Complited</th>
                    <th class="text-center" title="Laps Leds">Laps Led</th>
                    <th class="text-center" title="Incidents">Incidents</th>
                    <th class="text-center" title="sR Index">sr Index</th>
                    <th class="text-center" title="Safty Points">Safty Points</th>
                    <th class="text-center" title="Championship Points">Champ Points</th>
                    <th class="text-center" title="Championship Points">Base Points B</th>
                    <th class="text-center" title="Championship Points">Place Gain Points B</th>
                    <th class="text-center" title="Championship Points">Lap Led Points B</th>
                    <th class="text-center" title="Championship Points">Total Points B</th>
                </tr>
            </thead>
            <asp:Repeater ID="_REPResults" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="bold"><%# Eval("raceposition") %></td>
                        <td class="bold"><%# Eval("driver.name") %></td>
                        <td class="text-center"><%# Eval("interval") %></td>
                        <td class="text-center"><%# Eval("qualifyposition") %></td>
                        <td class="text-center"><%# Eval("fastlaprace") %></td>
                        <td class="text-center"><%# Eval("lapscomlited") %></td>
                        <td class="text-center"><%# Eval("lapsled") %></td>
                        <td class="text-center"><%# Eval("incidents") %></td>
                        <td class="text-center"><%# ((double)Eval("srindex")).ToString("0.00") %></td>
                        <td class="text-center"><%# Eval("saftypointsaddition") %></td>
                        <td class="text-center bold"><%# Eval("champpoints") %></td>
                        <td class="text-center bold"><%# Eval("cpbase") %></td>
                        <td class="text-center bold"><%# Eval("cpplacegain") %></td>
                        <td class="text-center bold"><%# Eval("cplapsled") %></td>
                        <td class="text-center bold"><%# Eval("cptotal") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <ul>
            <li><b>Champ Points</b> column is the current season champointship points.</li>
            <li>All <b>"Points B"</b> columns are next season point system simulation.</li>
        </ul>

    </div>
    <div id="divIncidents">
        <div class="bg-c-red text-white m-0">
            <div class="row m0 pl-5">
                <div class="" style="">
                    <span class="text-uppercase bold" style="font-size: 140%">Incidents:
                        <asp:Literal ID="_LIIncCount" runat="server" /></span>
                </div>
            </div>
        </div>
        <h3 class="ml-2">
            <asp:Literal ID="_LINoIncidents" runat="server" /></h3>
        <div id="divIncidentDetails" runat="server">
            <asp:Repeater ID="_REPIncidents" runat="server">
                <ItemTemplate>
                    <div class="container border mt-2">
                        <div class="row bg-info text-white">
                            <b>LAP:</b>&nbsp
                 <%# Eval("lap") %>&nbsp&nbsp
                <b>TURN:</b>&nbsp
                <%# Eval("turn") %>&nbsp&nbsp
                <b>DRIVERS:</b>&nbsp
                 <asp:Literal ID="LIDrivers" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col mt-1">
                                <b class="text-uppercase">Incident Details: </b>
                                <div class="jumbotron m-1 p-2 bg-c-lightyellow">

                                    <%# Eval("desc") %>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <asp:Repeater ID="REPResponses" runat="server">
                                <ItemTemplate>
                                    <div class="col" id="divResponse" runat="server">
                                        <b class="text-uppercase">Response from <%# Eval("driver.name") %>:</b>
                                        <div class="jumbotron m-1 p-2 bg-c-lightyellow">

                                            <%# Eval("response") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <b class="text-uppercase">Stewards Reviews: </b>

                        <div class="row mt-1">
                            <asp:Repeater ID="REPStuarts" runat="server">
                                <ItemTemplate>
                                    <div class="col col-sm-6">



                                        <div class="jumbotron m-1 p-2 bg-c-lightyellow">
                                            <b>Stuart <%# Container.ItemIndex + 1 %></b><br />
                                            <%# Eval("desc") %>

                                            <div class="row">
                                                <div class="col">
                                                    <asp:Repeater ID="REPStuartResult" runat="server">
                                                        <ItemTemplate>
                                                            <b><%# Eval("driver.name") %>: </b>
                                                            CAT<%# Eval("cat") %>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>


                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <b class="text-uppercase">Final Decision: </b>
                        <div class="row">
                            <div class="col">
                                <div class="jumbotron m-1 p-2 bg-c-lightyellow">
                                    <b>
                                        <asp:Literal ID="LICAT0" runat="server" /></b>
                                    <asp:Repeater ID="REPFinalResults" runat="server">
                                        <ItemTemplate>
                                            <b><%# Eval("driver.name") %>: </b>
                                            CAT<%# Eval("cat") %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="divReplay">
        <div class="bg-c-red text-white">
            <div class="row m0 mt-1 pl-5">
                <div class="" style="">
                    <span class="text-uppercase bold" style="font-size: 140%">Watch Replay</span>
                </div>
            </div>
        </div>

        <div class="row w-100 m-1">
            <div class="embed-responsive embed-responsive-16by9">

                <iframe style="max-height: 385px; max-width: 640px;" class="embed-responsive-item" runat="server" id="_IFYouTubeURL" src="https://www.youtube.com/embed/" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        //var pointsCol = 10

        var start = { tableid: 'table1', cssname: 'pointsrev', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 3 }
        var incidents = { tableid: 'table1', cssname: 'badrev', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 7 }
        var sRIndex = { tableid: 'table1', cssname: 'bad', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 8 }
        var points = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 10 }
        var pointsbase = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 11 }
        var pointsquali = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 12 }
        var pointslapsled = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 13 }
        var pointstotal = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 14 }


        var cols = [start, incidents, sRIndex, points, pointsbase, pointsquali, pointslapsled, pointstotal];

        $(document).ready(function () {

            $("#table1").DataTable(
                {
                    "pageLength": 100,
                    "lengthChange": false,
                    "searching": false,
                    "paging": false,
                    "info": false,
                    "responsive": true,
                    "createdRow": function (row, data, dataIndex, cells) {

                        createHeatTable(cols, data, cells);
                    }
                }
            );

            $("#btRace").click(function () {
                $("#divRace").show();
                $("#divIncidents").hide();
                $("#divReplay").hide();
            });
            $("#btIncidents").click(function () {
                $("#divRace").hide();
                $("#divIncidents").show();
                $("#divReplay").hide();
            });
            $("#btReplay").click(function () {
                $("#divRace").hide();
                $("#divIncidents").hide();
                $("#divReplay").show();
            });

            $("#btRace").click();
        });


    </script>
</asp:Content>
