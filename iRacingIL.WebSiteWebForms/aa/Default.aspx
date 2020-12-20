<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul>
        <li><a href="AddTrack">Add Track</a></li>
        <li><a href="AddSeason">Add Season</a></li>
        <li><a href="AddRace">Add Race</a></li>
     </ul>
    <hr />
    <ul>
        <li><a href="EditRace">Edit Race</a></li>
        <li><a href="ManageIncidents">Manage Incidents</a></li>
        <li><a href="AssignSteward">Assign Stewards</a></li>
        <li><a href="CalculatePoints">Calculate Points</a></li>
    </ul>
</asp:Content>
