<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="CalculatePoints.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.aa.CalculatePoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Calculate Points</h1>

    <div class="formBlock">
        <div class="button">
    <asp:Button ID="_BTCalcPoints" runat="server" Text="Calculate Season Champ Points" OnClick="_BTCalcPoints_Click" />
            </div>
        </div>

</asp:Content>
