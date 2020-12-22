<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iRacingIL.WebSiteWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="intro">
        <div id="introText">
            <h1>iracing israel league</h1>
            <p>Featuring the some of the best of israeli sim drivers, fighting in a bi-weekly battle for 6 months to become the #1 israeli sim driver</p>
            <button id="cta" style="display:none;">join the league</button>
        </div>
    </div>
    <div id="league">
        <div id="leagueText">
            <h1>our current season</h1>
            <p>Season 4 is based on the iRacing Dallara Formula 3 official series, the season is 6 months long with a race every other monday night, for a total of 12 races.</p>
            <p>Just like the official series, we are driving the Formula 3 car. Unlike the official series, We are driving with a fixed setup for an even playing field.</p>
            <p>This league is sponsored by <a href="https://simrace.co.il/" target="_blank">SimRace.co.il</a> & Funyo Israel</p> 
            <div class="logos"> 
                <img src='./assets/dallara.png' width="170" />
                <img src='./assets/simrace.png' width="150"  />
            </div>
        </div>
        <div id="broadcastText">
            <h1>Live broadcast</h1>
            <p>All of our races are being broadcasted LIVE by <a href="http://apexracingteam.co.uk/" target="_blank">Apex Racing UK</a> a proffesional iracing eSports team</p>
            <div id="broadcastEmbed">
                <iframe id="_IFYouTubeURL" runat="server" width="100%" height="100%" src="https://www.youtube.com/embed/h2UkoxR-Z8A" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
            </div>
        </div>
        <div id="communityText">
            <h1>our community</h1>
            <p>We have over 75 members in our iRacing community, with about 45 members participating in the league</p>
            <iframe src="https://discordapp.com/widget?id=622839715191586835&theme=dark" width="350" height="320" allowtransparency="true" frameborder="0"></iframe>
        </div>
    </div>

    <div id="leaders">
        <h1>Leaderboard</h1>
        <ul id="driverList">
            <asp:Repeater ID="_REPTopStanding" runat="server">
                <ItemTemplate>
                    <li class="driver">
                        <div class="position"><%# Container.ItemIndex + 1 %></div>
                        <div class="name"><%# Eval("name") %></div>
                        <div class="points"><%# Eval("champpoints") %></div>
                    </li>

                </ItemTemplate>
            </asp:Repeater>


        </ul>
        <a href='/Championship'>Full leaderboard</a>
    </div>




    
</asp:Content>
