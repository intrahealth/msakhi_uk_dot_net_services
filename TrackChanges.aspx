<%@ Page Title="TrackChanges" Language="C#" MasterPageFile="~/PISMasterPage.master" AutoEventWireup="true"
    CodeFile="TrackChanges.aspx.cs" Inherits="TrackChanges" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/textinput.css" rel="stylesheet" type="text/css" />
    <script src="../jscripts/jquery-1.4.1.min.js" type="text/javasc3ript"></script>
    <script type="text/javascript" src="//www.google.com/jsapi"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../jscripts/gridviewScroll.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePageMethods="true" ID="ScriptManager2" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <div style="vertical-align: middle; width: 100%; background-color: White; height: 30px;
                    text-align: left" align="right">
                    <asp:Label ID="LblModule" runat="server" ForeColor="#000" Width="380px" Height="20px"
                        Font-Bold="True" Font-Names="Arial" Font-Size="20px">Track Changes/Updates</asp:Label>
                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel2">
                        <ProgressTemplate>
                            <div id="IMGDIV11" runat="server" align="center" style="visibility: visible; vertical-align: middle;
                                width: 99%; height: 150%; position: absolute; z-index: 999999;" valign="middle"
                                class="modalBackground">
                                <asp:Image ID="Image11" runat="server" Style="position: relative; top: 40%; left: 0px;"
                                    Height="120px" ImageUrl="images/progress2.gif" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="LblForm" runat="server" ForeColor="Navy" Width="300px" Height="20px"
                        Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="Label322" runat="server" ForeColor="Black" Width="40px" CssClass="labelClass"
                        Font-Bold="True"></asp:Label></div>
                <div style="width: 100%" id="divadd">
                    <table style="width: 100%; background-color: #eee;">
                        <tbody>
                            <tr>
                                <td style="vertical-align: top; text-align: left" colspan="2">
                                    <table style="width: 100%;" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                
                                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                    <asp:Label ID="LabelBLOCK" runat="server" Width="70px" CssClass="labelTitle" Text="ASHA Name"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                    <asp:Label ID="LabelDISTRICT" runat="server" Width="65px" CssClass="labelTitle" Text="Month"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                                </td>
                                            </tr>
                                            <tr>
                                                
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                    <asp:DropDownList ID="ddlashaName" runat="server" CssClass="shg_textbox" Width="161px"
                                                        Height="24px" AutoPostBack="false" TabIndex="20">
                                                    </asp:DropDownList>
                                                </td>

                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                            <asp:DropDownList ID="ddlmonth" TabIndex="19" runat="server" Width="161px" Height="24px" CssClass="shg_textbox" AutoPostBack="true">
                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                            <asp:ListItem Value="1">Current Month</asp:ListItem>
                                             <asp:ListItem Value="3">Last 3 Months</asp:ListItem>
                                            </asp:DropDownList>
                                                </td>

                                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                                    <asp:Button ID="BtnSearch" TabIndex="3" Style="float: none;" OnClick="BtnSearch_Click1"
                                                    runat="server" Height="24px" ValidationGroup="GRPSearch" Text="Search" CssClass="submit_butt-new"
                                                    ToolTip="Search"></asp:Button>&nbsp;
                                                    <asp:Button ID="ImgClear" Style="float: none;" runat="server" Height="24px" Text="Clear"
                                                        ToolTip="Clear" CssClass="submit_butt-new"></asp:Button>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdData" colspan="3">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="width: 100%;">
                                        <tbody>
                                            <tr>
                                                <td colspan="3" style="vertical-align: top; height: 0px; text-align: center">
                                                    <asp:Label ID="lblmessage" runat="server" ForeColor="OrangeRed" Width="200px" Height="8px"
                                                        Font-Bold="True" Font-Names="Arial"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <td colspan="2">
                                <tr>
                                    <td colspan="3" style="vertical-align: top; height: 0px; text-align: left">
                                        <asp:Label ID="Label1" Text="Count :" runat="server" ForeColor="Black" Width="44px"
                                            Height="20px" Font-Names="Arial"></asp:Label>
                                        <asp:Label ID="lblcount" runat="server" ForeColor="dimgray" Width="100px" Height="20px"
                                            Font-Names="Arial"></asp:Label>
                                       
                                </tr>
                            </td>
                    </table>
                </div>
                <tr>
                    <asp:Panel ID="Panel5" runat="server" Height="300px" Width="100%" ScrollBars="Vertical"
                        BorderColor="Navy">
                        <asp:GridView ID="GVtrackchanges" runat="server" Width="100%" CssClass="mGrid" OnSorting="GVtrackchanges_Sorting"
                            PageSize="50"  AutoGenerateColumns="True"
                            AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GVtrackchanges_PageIndexChanging"
                            
                            PagerStyle-CssClass="pgr" GridLines="None" HeaderStyle-BackColor="#545454" ShowFooter="True">
                            <PagerSettings Position="top"></PagerSettings>
                          
                            <RowStyle BackColor="#F2F8FC" />
                            <AlternatingRowStyle BackColor="White" />
                            <PagerStyle CssClass="pgr"></PagerStyle>
                        </asp:GridView>
                    </asp:Panel>
                </tr>
                </tbody>
            </asp:Panel>
          
            <asp:HiddenField ID="hfcode" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
