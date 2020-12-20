<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Championship.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.Championship" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(function () {
            $("#tabs").tabs();
            $("#innerTabs").tabs();
        });
    </script>
    <h1>standings</h1>
    <div class="filters">
        <select class="link" id="slcSeasons">
            <asp:Repeater ID="_REPSeasons" runat="server">
                <ItemTemplate>
                    <option runat="server" id="opt"><%# Eval("name") %></option>
                </ItemTemplate>
            </asp:Repeater>
        </select>
    </div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Leaderboard</a></li>
            <li><a href="#tabs-2">Race Results</a></li>
        </ul>
        <div id="tabs-1">
            <div class="table">
                <table id="table1" class="hover compact row-border dataTable no-footer" role="grid">
                    <thead>
                        <tr role="row">
                            <th>#</th>
                            <th>Name</th>
                            <th>Races</th>
                            <th>Wins</th>
                            <th>Poles</th>
                            <th>Podiums</th>
                            <th>Points</th>
                            <th title="Points minus drops">Points D</th>
                            <th>sR Index</th>
                            <th title="Safty Points">SP</th>
                            <th>1</th>
                            <th>2</th>
                            <th>3</th>
                            <th>4</th>
                            <th>5</th>
                            <th>6</th>
                            <th>7</th>
                            <th>8</th>
                            <th>9</th>
                            <th>10</th>
                            <th>11</th>
                            <th>12</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="_REPStanding" runat="server">
                            <ItemTemplate>

                                <tr role="row" class="odd">
                                    <td class="bold"><%# Container.ItemIndex + 1 %></td>
                                    <td class="bold"><%# Eval("name") %></td>
                                    <td class="text-center"><%# Eval("races") %></td>
                                    <td class="text-center"><%# Eval("wins") %></td>
                                    <td class="text-center"><%# Eval("poles") %></td>
                                    <td class="text-center"><%# Eval("podiums") %></td>
                                    <td class="text-center"><%# Eval("champpoints") %></td>
                                    <td class="text-center"><%# Eval("minusdrops") %></td>
                                    <td class="text-center"><%# Eval("srindex") %></td>
                                    <td class="text-center"><%# Eval("saftypoints") %></td>
                                    <td class="text-center"><%# Eval("race1") %></td>
                                    <td class="text-center"><%# Eval("race2") %></td>
                                    <td class="text-center"><%# Eval("race3") %></td>
                                    <td class="text-center"><%# Eval("race4") %></td>
                                    <td class="text-center"><%# Eval("race5") %></td>
                                    <td class="text-center"><%# Eval("race6") %></td>
                                    <td class="text-center"><%# Eval("race7") %></td>
                                    <td class="text-center"><%# Eval("race8") %></td>
                                    <td class="text-center"><%# Eval("race9") %></td>
                                    <td class="text-center"><%# Eval("race10") %></td>
                                    <td class="text-center"><%# Eval("race11") %></td>
                                    <td class="text-center"><%# Eval("race12") %></td>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
        <div id="tabs-2">
            <div class="filters border">
                <select id="slcRaces" class="filters border link">
                    <asp:Repeater ID="_REPRaces" runat="server">
                        <ItemTemplate>
                            <option runat="server" id="opt"><%# Eval("racenumber") %>: <%# Eval("track.name") %></option>
                        </ItemTemplate>
                    </asp:Repeater>
                </select>
            </div>
            <div id="innerTabs">
                <ul>
                    <li><a href="#tabs-3">Race</a></li>
                    <li><a href="#tabs-5">Incidents (<asp:Literal ID="_LIIncCount" runat="server" />)</a></li>
                    <li><a href="#tabs-6">Replay</a></li>
                </ul>
                <div id="tabs-3">
                    <div class="table">
                        <table id="table2" class="stripe hover compact row-border dataTable no-footer" role="grid">
                            <thead>
                                <tr role="row">
                                    <th>#</th>
                                    <th>Name</th>
                                    <th class="text-center" title="Interval">Interval</th>
                                    <th class="text-center" title="Start Position">Start</th>
                                    <th class="text-center" title="Best Race Lap">Best Lap</th>
                                    <th class="text-center" title="Laps Completed">Laps Completed</th>
                                    <th class="text-center" title="Laps Leds">Laps Led</th>
                                    <th class="text-center" title="Incidents">Incidents</th>
                                    <th class="text-center" title="sR Index">sr Index</th>
                                    <th class="text-center" title="Safty Points">SP</th>
                                    <th class="text-center" title="Championship Points">Champ Points</th>
                                    <th class="text-center" title="Base points by position">BP</th>
                                    <th class="text-center" title="Extra points for pole position">PP</th>
                                    <th class="text-center" title="Extra poinsts for fastest lap">FLP</th>
                                    <th class="text-center" title="Extra points for lap led">LLP</th>
                                    <th class="text-center" title="Extra points for positions gain">PGP</th>
                                    
                                </tr>
                            </thead>
                            <tbody>
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
                                            <td class="text-center"><%# ((decimal)Eval("srindex")) %></td>
                                            <td class="text-center"><%# Eval("saftypointsaddition") %></td>
                                            <td class="text-center bold"><%# Eval("champpoints") %></td>
                                            <td class="text-center bold"><%# Eval("cpbase") %></td>
                                            <td class="text-center bold"><%# Eval("cpquali") %></td>
                                            <td class="text-center bold"><%# Eval("cpfastestlap") %></td>
                                            <td class="text-center bold"><%# Eval("cplapsled") %></td>
                                            <td class="text-center bold"><%# Eval("cpplacegain") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <ul class="notes" style="color: white;">
                            <li>Champ Points column is the current season champointship points.</li>
                            <li>All "Points B" columns are next season point system simulation.</li>
                        </ul>
                    </div>

                </div>
                <div id="tabs-6">
                    <div id="broadcastEmbed">
                        <iframe id="_IFYouTubeURL" runat="server" width="100%" height="100%" src="https://www.youtube.com/embed/" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                    </div>

                </div>
                <div id="tabs-5">
                    <h3 style="color: white;">
                        <asp:Literal ID="_LINoIncidents" runat="server" /></h3>
                    <ul id="incidentList" runat="server">
                        <asp:Repeater ID="_REPIncidents" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="incidentTitle"><span>Lap: <%# Eval("lap") %></span> <span>Turn: <%# Eval("turn") %></span> <span>Drivers: <asp:Literal ID="LIDrivers" runat="server" /></span></div>
                                    <div class="incidentContainer">

                                        <div class="incidentDetails block">
                                            <div class="title">Incident Report</div>
                                            <div class="text"><%# Eval("desc") %></div>
                                        </div>
                                        <div class="incidentResponse block">
                                            <div class="title">Incident Response</div>
                                            <div class="responseContainer text">
                                                <asp:Repeater ID="REPResponses" runat="server">
                                                    <ItemTemplate>
                                                        <div class="response">
                                                            <div class="name"><%# Eval("driver.name") %></div>
                                                            <div class="desc"><%# Eval("response") %></div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>

                                        <div class="incidentReviews block">
                                            <div class="title">Incident Reviews</div>
                                            <div class="reviewsContainer text">
                                                <asp:Repeater ID="REPStuarts" runat="server">
                                                    <ItemTemplate>
                                                        <div class="review">
                                                            <div class="stuart">Steward <%# Container.ItemIndex + 1 %></div>
                                                            <div class="desc"><%# Eval("desc") %></div>
                                                            <asp:Repeater ID="REPStuartResult" runat="server">
                                                                <ItemTemplate>
                                                                    <div class="result"><span class="resultName"><%# Eval("driver.name") %></span><span class="resultCat cat<%# Eval("cat") %>">Category <%# Eval("cat") %></span></div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <div class="result" id="catzero" runat="server" ClientIDMode="Static"><span class="resultCat cat0">Category 0</span></div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                        <div class="incidentResult block">
                                            <div class="title">Incident Final Decision</div>
                                            <asp:Repeater ID="REPFinalResults" runat="server">
                                                <ItemTemplate>
                                                    <div class="result text"><span class="resultName"><%# Eval("driver.name") %></span><span class="resultCat cat<%# Eval("cat") %>">Category <%# Eval("cat") %></span></div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <div class="result text" id="catzero" runat="server" ClientIDMode="Static"><span class="resultName">Racing Incident</span><span class="resultCat cat0">Category 0</span></div>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', (event) => {

            //initialize choices to the relevant class
            const element = document.querySelector('#slcRaces');
            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });

            element.addEventListener('choice', e => {
                if (e.target.classList.contains('link')) {
                    window.location.href = e.detail.choice.value
                }
            });

         
        });

        document.addEventListener('DOMContentLoaded', (event) => {
            const element = document.querySelector('#slcSeasons');

            const elementChoice = new Choices(element, {
                itemSelectText: ''
            });

            element.addEventListener('choice', e => {
                if (e.target.classList.contains('link')) {
                    window.location.href = e.detail.choice.value
                }
            })

        });

        $(document).ready(function () {
            SetTable1();
            SetTable2();

            var r = $.urlParam('r');
            if (r)
                $("#tabs").tabs({ active: 1 });

            var inc = $.urlParam('i');
            if (inc)
                $("#innerTabs").tabs({ active: 1 });

            $('#slcRaces').val('<%=mRace.raceid%>');

        });

        $.urlParam = function (name) {
            var results = new RegExp('[\?&]' + name + '=([^&#]*)')
                .exec(window.location.href);
            if (results == null) {
                return 0;
            }
            return results[1] || 0;

        }

        function SetTable2() {
            var start = { tableid: 'table2', cssname: 'pointsrev', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 3 }
            var incidents = { tableid: 'table2', cssname: 'bad', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 7 }
            var sRIndex = { tableid: 'table2', cssname: 'bad', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 8 }
            var points = { tableid: 'table2', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 10 }
            var pointsbase = { tableid: 'table2', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 11 }
            var pointspole = { tableid: 'table2', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 12 }
            var pointsfastestlap = { tableid: 'table2', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 13 }
            var pointsquali = { tableid: 'table2', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 14 }
            var pointslapsled = { tableid: 'table2', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 15 }


            var cols = [start, incidents, sRIndex, points, pointsbase, pointspole, pointsfastestlap, pointsquali, pointslapsled];

            $("#table2").DataTable(
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
        }

        function SetTable1() {
            var wins = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 3 }
            var poles = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 4 }
            var podiums = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 5 }
            var points = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 6 }
            var pointsd = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 7 }
            var sRIndex = { tableid: 'table1', cssname: 'bad', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 8 }
            var sp = { tableid: 'table1', cssname: 'bad', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 9 }
            var race1 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 10 }
            var race2 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 11 }
            var race3 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 12 }
            var race4 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 13 }
            var race5 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 14 }
            var race6 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 15 }
            var race7 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 16 }
            var race8 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 17 }
            var race9 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 18 }
            var race10 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 19 }
            var race11 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 20 }
            var race12 = { tableid: 'table1', cssname: 'points', levels: 10, maxValue: 0, minValue: 0, diffValue: 0, colIndex: 21 }

            var cols = [wins, poles, podiums, points, pointsd, sRIndex, sp,
                race1, race2, race3, race4, race5, race6, race7, race8, race9, race10, race11, race12];


            $("#table1").DataTable(
                {
                    "pageLength": 100,
                    "lengthChange": false,
                    "searching": false,
                    "paging": false,
                    "info": false,
                    "createdRow": function (row, data, dataIndex, cells) {
                        createHeatTable(cols, data, cells);
                    }
                }
            );
        }


    </script>
</asp:Content>
