<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="iRacingIL.WebSiteWebForms.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="intro">
        <div id="introText">
            <h1>Contact/Join IIL</h1>
            <h3 class="redmessage"><asp:Literal ID="_LIMessage" runat="server" /></h3>
            <div class="formBlock">
                <div class="title">Contact the iRacing Israel League</div>
                <p>If you wish to join the league or want to contact us for any reason - please fill up this form and we will do our best to response quickly</p>
                <div class="input">
                    <label>Full name</label>
                    <asp:TextBox ID="_TBFullName" runat="server" />
                    <div class="note">* Same as your iRacing account name if possible</div>
                </div>
                <div class="input">
                    <label>Email</label>
                    <asp:TextBox ID="_TBEmail" runat="server" />
                </div>
                <div class="select">
                    <label>Subject</label>
                    <asp:DropDownList ID="_DDLSubject" runat="server">
                        <asp:ListItem Value="join" Text="Join the league" />
                        <asp:ListItem Value="other" Text="Other" />
                    </asp:DropDownList>
                </div>
                <div class="textarea" >
                    <label>Message</label>
                    <p>If you wish to join out league, please provide some information of your racing experience</p>
                    <textarea rows="14"></textarea>
                </div>
                
                <div class="button">
                    <asp:Button ID="_BTSubmit" runat="server" text="Send" OnClick="_BTSubmit_Click" />
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
