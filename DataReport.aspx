<%@ Page Title="Data Report" Language="C#" MasterPageFile="~/PISMasterPage.master" AutoEventWireup="true" CodeFile="DataReport.aspx.cs" Inherits="DataReport"
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
                        Font-Bold="True" Font-Names="Arial" Font-Size="20px">Update Summary</asp:Label>
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
                        Font-Bold="True"></asp:Label>
                       
                </div>
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
                                <td>
                                <asp:Button ID="BtnExport"  runat="server" Text="Export" CssClass="submit_butt-new" width="20%" 
                                Style="float: right;" OnClick="BtnExport_Click"/>
                                </td>
                                </tr>
                            </td>
                    </table>
                </div>
                <tr>
                    <asp:Panel ID="Panel5" runat="server" Height="300px" Width="100%" ScrollBars="Vertical"
                        BorderColor="Navy">
                        <asp:GridView ID="GVreportData" runat="server" Width="100%" CssClass="mGrid" OnSorting="GVreportData_Sorting"
                            PageSize="50"  AutoGenerateColumns="false" OnRowDataBound = "GVreportData_RowDataBound"
                            AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GVreportData_PageIndexChanging"
                            PagerStyle-CssClass="pgr" GridLines="None" HeaderStyle-BackColor="#545454" ShowFooter="True">
                            <PagerSettings Position="top"></PagerSettings>
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                                <ItemStyle Width="5%" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="ashaname" HeaderText="Asha Name">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="subcentername" HeaderText="SubCenter Name">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="username" HeaderText="User ID">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Month" HeaderText="Month">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="hhdata" HeaderText="HH Data Updated">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Pregnent" HeaderText="Pregnancies">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="anccount" HeaderText="ANCs">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="deliveries" HeaderText="Deliveries">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                 <asp:BoundField DataField="pnc" HeaderText="PNCs">
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                  <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="immunization" HeaderText="Immunizations">
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                  <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#F2F8FC" />
                            <AlternatingRowStyle BackColor="White" />
                            <PagerStyle CssClass="pgr"></PagerStyle>
                        </asp:GridView>
                    </asp:Panel>
                </tr>
                </tbody>
            </asp:Panel>
      
           </ContentTemplate>
           
           <Triggers>
            <asp:PostBackTrigger ControlID="BtnExport"></asp:PostBackTrigger>
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>


