<%@ Page Title="VHND Schedule" Language="C#" MasterPageFile="~/PISMasterPage.master"
    AutoEventWireup="true" CodeFile="VHND_Schedule.aspx.cs" Inherits="VHND_Schedule"
    EnableEventValidation="false" StylesheetTheme="NewTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePageMethods="true" ID="ScriptManager2" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <div style="vertical-align: middle; width: 100%; background-color: White; height: 30px;
                    text-align: left" align="right">
                    <asp:Label ID="LblModule" runat="server" ForeColor="#000" Width="380px" Height="20px"
                        Font-Bold="True" Font-Names="Arial" Font-Size="20px">VHND Micro Plan</asp:Label>
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
                                                    <asp:Label ID="lblyear" runat="server" Width="65px" CssClass="labelTitle" Text="Select Year"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                    <asp:Label ID="lblsubcenter" runat="server" Width="70px" CssClass="labelTitle" Text="Select SubCenter"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                    <asp:Label ID="lblanm" runat="server" Width="70px" CssClass="labelTitle" Text="Select ANM"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                    <asp:DropDownList ID="ddlyear" runat="server" CssClass="shg_textbox" Width="161px"
                                                        Height="24px" AutoPostBack="false" TabIndex="20">
                                                        <%--<asp:ListItem Value="">---All---</asp:ListItem>
                                                        <asp:ListItem Value="2018">2018-19</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                    <asp:DropDownList ID="ddlsubcenter" TabIndex="19" runat="server" Width="161px" Height="24px"
                                                        CssClass="shg_textbox" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcenter_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                    <asp:DropDownList ID="ddlanm" runat="server" CssClass="shg_textbox" Width="161px"
                                                        Height="24px" AutoPostBack="false" TabIndex="20">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                                    <asp:Button ID="Btnshow" TabIndex="3" Style="float: none;" OnClick="Btnshow_Click"
                                                        runat="server" Height="24px" ValidationGroup="GRPSearch" Text="Show Records"
                                                        CssClass="submit_butt-new" ToolTip="Show Records"></asp:Button>&nbsp;
                                                    <asp:Button ID="btnprevyear" TabIndex="3" Style="float: none;" OnClick="btnprevyear_Click"
                                                        runat="server" Height="24px" ValidationGroup="GRPSearch" Text="Copy From Prev Year"
                                                        CssClass="submit_butt-new" ToolTip="Copy From Prev Year"></asp:Button>&nbsp;
                                                    <asp:Button ID="btnsave" TabIndex="3" Style="float: right;" OnClick="Btngenerate_Click"
                                                        runat="server" Height="24px" ValidationGroup="GRPSearch" Text="Generate Record"
                                                        CssClass="submit_butt-new" ToolTip="Generate Records"></asp:Button>&nbsp;&nbsp;&nbsp;
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
                        <asp:GridView ID="GVVHND" runat="server" Width="100%" CssClass="mGrid" OnSorting="GVVHND_Sorting"
                            PageSize="50" DataKeyNames="VillageID,asha_id" AutoGenerateColumns="False" AllowSorting="True"
                            AllowPaging="True" OnPageIndexChanging="GVVHND_PageIndexChanging" OnRowCommand="GVVHND_RowCommand"
                            OnRowDataBound="GVVHND_OnRowDataBound" PagerStyle-CssClass="pgr" GridLines="None"
                            HeaderStyle-BackColor="#545454" ShowFooter="True">
                            <PagerSettings Position="top"></PagerSettings>
                            <Columns>
                                <asp:TemplateField HeaderText="ID" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSchedule_Id" runat="server" Text='<%#Eval("Schedule_Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:BoundField DataField="asha_id" Visible="false" HeaderText="ASHA ID" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="650px"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="ASHAName" HeaderText="ASHA Name" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="650px"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Village/AWC" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <%--  <asp:HiddenField ID="hdnvillage" runat="server" Value='<%#Eval("Village/AWC")%>' />--%>
                                        <asp:DropDownList ID="ddlVillage" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occurence" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <%--   <asp:HiddenField ID="hdnoccurence" runat="server" Value='<%#Eval("Occurence") %>' />--%>
                                        <asp:DropDownList ID="ddlOccurence" runat="server" SelectedValue='<%# Eval("Occurence") %>'>
                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">First</asp:ListItem>
                                            <asp:ListItem Value="2">Second</asp:ListItem>
                                            <asp:ListItem Value="3">Third</asp:ListItem>
                                            <asp:ListItem Value="4">Fourth</asp:ListItem>
                                            <asp:ListItem Value="5">Fifth</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Day" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <%-- <asp:HiddenField ID="hdndays" runat="server" Value='<%#Eval("Days") %>' />--%>
                                        <asp:DropDownList ID="ddlDays" runat="server" SelectedValue='<%# Eval("Days") %>'>
                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Monday</asp:ListItem>
                                            <asp:ListItem Value="2">Tuesday</asp:ListItem>
                                            <asp:ListItem Value="3">Wesnesday</asp:ListItem>
                                            <asp:ListItem Value="4">Thursday</asp:ListItem>
                                            <asp:ListItem Value="5">Friday</asp:ListItem>
                                            <asp:ListItem Value="6">Saturday</asp:ListItem>
                                            <asp:ListItem Value="7">Sunday</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="Apr" HeaderText="April" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="May" HeaderText="May" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Jun" HeaderText="June" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Jul" Visible="false" HeaderText="July" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Aug" HeaderText="August" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Sep" HeaderText="Septembet" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Oct" HeaderText="October" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Nov" HeaderText="November" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Dec" HeaderText="December" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                 <asp:BoundField DataField="Jan" HeaderText="January" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Feb" HeaderText="Febuary" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Mar" HeaderText="March" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
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
    </asp:UpdatePanel>
</asp:Content>
