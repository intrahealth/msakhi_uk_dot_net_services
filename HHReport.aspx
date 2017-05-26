<%@ Page Title="HH Report" Language="C#" MasterPageFile="~/PISMasterPage.master" AutoEventWireup="true" CodeFile="HHReport.aspx.cs" Inherits="HHReport" 
EnableEventValidation="false" StylesheetTheme="NewTheme" %>

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
                        Font-Bold="True" Font-Names="Arial" Font-Size="20px">Household Report</asp:Label>
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
                        <asp:GridView ID="GVhhreportData" runat="server" Width="100%" CssClass="mGrid" OnSorting="GVhhreportData_Sorting"
                            PageSize="50"  AutoGenerateColumns="false" DataKeyNames="anmcode,anmname"
                            AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GVhhreportData_PageIndexChanging"
                            OnRowCommand="GVhhreportData_RowCommand"
                            PagerStyle-CssClass="pgr" GridLines="None" HeaderStyle-BackColor="#545454" ShowFooter="True">
                            <PagerSettings Position="top"></PagerSettings>
                            <Columns>
                               <%-- <asp:BoundField DataField="RowNumber" HeaderText="S.No">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="anmcode" HeaderText="ANM Code" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="anmname" HeaderText="ANM Name" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Number of asha" HeaderText="No Of ASHA" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Number of HH" HeaderText="Number Of HH" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="population" HeaderText="Population" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Number of HH verified" HeaderText="No Of HH Verified" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="percentage of hh verified" HeaderText="% Of HH Verified" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Population verified" HeaderText="Population Verified" SortExpression="">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="percentage of population verified" HeaderText="% Of Population Verified" SortExpression="">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Number of new hh added" HeaderText="New HH Added" SortExpression="">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:ButtonField CommandName="Editdata" ButtonType="Button" CausesValidation="True"
                                HeaderText="Asha Details">
                                <ControlStyle BorderWidth="0px" CssClass="mGridEditCommand"></ControlStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="30px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                            <RowStyle BackColor="#F2F8FC" />
                            <AlternatingRowStyle BackColor="White" />
                            <PagerStyle CssClass="pgr"></PagerStyle>
                        </asp:GridView>
                    </asp:Panel>
                </tr>
                </tbody>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="MpexdrBlock" BehaviorID="mpe" runat="server"
                PopupControlID="pnlPopup" TargetControlID="hfcode" BackgroundCssClass="modalBackground"
                CancelControlID="BtnExit">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" Style="display: none;" Width="900px" Height="405px"
                class="ModalPopup" BackColor="White" BorderColor="white" BorderStyle="Ridge"
                BorderWidth="1">
                <div style="height: 45px; width: 100%; background-color: #4db8ff; text-align: center;
                    font-size: large;">
                    
                    <table style="color: White; margin-top: 5px">
                        <tr>
                            <td style="text-align: center; width: 15%;">
                                ASHA Wise HH Details
                            </td>
                        </tr>
                    </table>
                    <%--<div style="height: 900px; width: 100%;">--%>
                        <table style="margin-top: 2%; width: 100%">
                            
                             <tr>
                                <td colspan="3" style="vertical-align: top; height: 0px; text-align: left; padding-top: 0%;">
                                   
                                   <asp:Label ID="Label2" Text="ANM :" runat="server" ForeColor="Black" Style="font-family: Arial;
                                        width: 60px; font-size: small;"></asp:Label>
                                    <asp:Label ID="lblanm" runat="server" ForeColor="dimgray" Style="font-family: Arial;
                                        width: 60px; font-size: small;"></asp:Label>

                                </td>
                                <td>
                                 
                                         <asp:Label ID="Label4" Text="Count :" runat="server" ForeColor="Black" Style="font-family: Arial;
                                        width: 60px; font-size: small;"></asp:Label>
                                    <asp:Label ID="lblcountmem" runat="server" ForeColor="dimgray" Style="font-family: Arial;
                                        width: 60px; font-size: small;"></asp:Label>
                                    <asp:Label ID="lblmsg" runat="server" Style="display: inline-block; color: Red; font-family: Arial;
                                        width: 196px; margin-left: 33%;">
                                    </asp:Label>
                                        
                                     <asp:Button ID="BtnExit" runat="server" Style="float: right;" CssClass="submit_butt-new"
                                        Text="Close" ToolTip="Close"></asp:Button>
                                </td>
                            </tr>
                        </table>
                   <%-- </div>--%>
                </div>
                <div style="height: 300px; width: 100%; margin-top: 5%; overflow: auto">
                    <asp:GridView ID="GVhhashadet" runat="server" Width="100%" CssClass="mGrid" AutoGenerateColumns="true">
                        
                    </asp:GridView>
                    <asp:Label ID="Lblerror" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hfcode" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
