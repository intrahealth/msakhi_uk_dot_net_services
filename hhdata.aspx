<%@ Page Language="C#" MasterPageFile="~/PISMasterPage.master" StylesheetTheme="NewTheme"
    AutoEventWireup="true" CodeFile="hhdata.aspx.cs" Inherits="hhdata" EnableEventValidation="false"
    Title="HH Data" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/textinput.css" rel="stylesheet" type="text/css" />
    <script src="../jscripts/jquery-1.4.1.min.js" type="text/javasc3ript"></script>
    <script type="text/javascript" src="//www.google.com/jsapi"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../jscripts/gridviewScroll.min.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                gridviewScroll();
            });

            function gridviewScroll() {
                $('#<%=GVanmData.ClientID%>').gridviewScroll({
                    width: 1250,
                    height: 420,
                    enabled: true
//                    freezesize: 2
                });
            }
          </script>

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
                        Font-Bold="True" Font-Names="Arial" Font-Size="20px">Household Data</asp:Label>
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
                                                <asp:Label ID="LabelDISTRICT" runat="server" Width="65px" CssClass="labelTitle" Text="ANM Name"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                <asp:Label ID="LabelBLOCK" runat="server" Width="70px" CssClass="labelTitle" Text="ASHA Name"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                <asp:Label ID="Label5" runat="server" Width="70px" CssClass="labelTitle" Text="Verified"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                <asp:DropDownList ID="ddlanmName" TabIndex="19" runat="server" Width="161px" Height="24px"
                                                CssClass="shg_textbox" AutoPostBack="true">
                                                <%--OnSelectedIndexChanged="ddlanmName_SelectedIndexChanged"--%>
                                                </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                <asp:DropDownList ID="ddlashaName" runat="server" CssClass="shg_textbox" Width="161px"
                                                Height="24px" AutoPostBack="false" TabIndex="20">
                                                </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: top; width: 185px; height: 22px; text-align: left" class="TdData">
                                                <asp:DropDownList ID="ddlverify" runat="server" CssClass="shg_textbox" Width="161px"
                                                Height="24px" AutoPostBack="false" TabIndex="20">
                                                <asp:ListItem Value="">---All---</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>                      
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
                      
                        <asp:GridView ID="GVanmData" runat="server" Width="100%" CssClass="mGrid" OnSorting="GVanmData_Sorting"
                            PageSize="50" DataKeyNames="familycode,hhsurveyguid" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GVanmData_PageIndexChanging"
                            OnRowCommand="GVanmData_RowCommand" OnRowDataBound="GVanmData_OnRowDataBound"
                            PagerStyle-CssClass="pgr" GridLines="None" HeaderStyle-BackColor="#545454" ShowFooter="True">
                            <PagerSettings Position="top"></PagerSettings>
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="S.No">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="subcentercode" HeaderText="Sub Center Code" SortExpression="" Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="subcentername" HeaderText="Sub Center Name" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>   
                                <asp:BoundField DataField="ANMName" HeaderText="ANM Name" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ASHAName" HeaderText="Asha Name" SortExpression="">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="villageid" HeaderText="Village ID" SortExpression="" Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="familycode" HeaderText="Family Code" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="familymembername" HeaderText="HH Head" SortExpression=""
                                    Visible="True">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="caste" HeaderText="Caste" SortExpression="">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FinancialStatusID" HeaderText="Financial Status" SortExpression="">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="verified" HeaderText="Verify" SortExpression="">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:ButtonField CommandName="Editdata" ButtonType="Button" CausesValidation="True"
                                HeaderText="Member Details">
                                <ControlStyle BorderWidth="0px" CssClass="mGridEditCommand"></ControlStyle>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="30px"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                            <%--<RowStyle BackColor="#F2F8FC" />
                            <AlternatingRowStyle BackColor="White" />
                            <PagerStyle CssClass="pgr"></PagerStyle>--%>


                            <RowStyle CssClass="GridviewScrollItem" />
                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                    <HeaderStyle CssClass="HeaderFreez"/>
                                                                    <AlternatingRowStyle BackColor="White" />

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
                    <div style="height: 5px;">
                    </div>
                    <table style="color: White; margin-top: 5px">
                        <tr>
                            <td style="text-align: center; width: 15%;">
                                Member Details
                            </td>
                        </tr>
                    </table>
                    <div style="height: 1000px; width: 100%;">
                        <table style="margin-top: 2%; width: 100%">
                            <tr>
                                <td style="vertical-align: top; width: 151px; height: 22px; text-align: left" class="TdData">
                                    <asp:Label ID="Label2" runat="server" Width="125px" CssClass="labelTitle" Text="Family Member Code"></asp:Label>
                                </td>
                                <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                    <asp:Label ID="Label3" runat="server" Style="display: inline-block; width: 125px;
                                        margin-left: -61%;" CssClass="labelTitle" Text="Family Member Name"></asp:Label>
                                </td>
                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 300px; height: 22px; text-align: left" class="TdData">
                                    <asp:TextBox runat="server" ID="txt_familycode" Style="width: 45%;" placeholder="Member code 4 digit"></asp:TextBox>
                                </td>
                                <td style="vertical-align: top; width: 157px; height: 22px; text-align: left" class="TdData">
                                    <asp:TextBox runat="server" ID="txtfamilyname" Style="width: 68%; margin-left: -120px;"
                                        placeholder="Family Member Name"></asp:TextBox>
                                </td>
                                <td style="vertical-align: top; height: 22px; text-align: center" class="TdData">
                                    <asp:Button ID="btnsearc" TabIndex="3" Style="float: none; margin-left: -526px;"
                                    OnClick="BtnSearchmem_Click" runat="server" Height="24px" ValidationGroup="GRPSearch"
                                    Text="Search" CssClass="submit_butt-new" ToolTip="Search"></asp:Button>&nbsp;
                                    <asp:Button ID="Button2" Style="float: none;" runat="server" Height="24px" Text="Clear"
                                        ToolTip="Clear" CssClass="submit_butt-new"></asp:Button>&nbsp;
                                    <asp:Button ID="BtnExit" runat="server" Style="float: right;" CssClass="submit_butt-new"
                                        Text="Close" ToolTip="Close"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: top; height: 0px; text-align: left; padding-top: 1%;">
                                    <asp:Label ID="Label4" Text="Count :" runat="server" ForeColor="Black" Style="font-family: Arial;
                                        width: 60px; font-size: small;"></asp:Label>
                                    <asp:Label ID="lblcountmem" runat="server" ForeColor="dimgray" Style="font-family: Arial;
                                        width: 60px; font-size: small;"></asp:Label>
                                    <asp:Label ID="lblmsg" runat="server" Style="display: inline-block; color: Red; font-family: Arial;
                                        width: 196px; margin-left: 33%;">
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="height: 250px; width: 100%; margin-top: 11%; overflow: auto">
                    <asp:GridView ID="GVmember" runat="server" Width="100%" CssClass="mGrid" AutoGenerateColumns="False"
                        OnDataBound="GVmember_OnDataBound">
                        <Columns>
                            <asp:TemplateField Visible="true" HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lb_EmpId" runat="server" Text='<%# Bind("RowNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lb_Transfer_Id" runat="server" Text='<%# Bind("HHFamilyMemberCode") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lb_EmpName" runat="server" Text='<%# Bind("FamilyMemberName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lb_EmpName" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lb_EmpName" runat="server" Text='<%# Bind("Maritialstatus") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" HeaderText="Age Year">
                                <ItemTemplate>
                                    <asp:Label ID="lb_EmpName" runat="server" Text='<%# Bind("AprilAgeYear") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true" HeaderText="Age Month">
                                <ItemTemplate>
                                    <asp:Label ID="lb_EmpName" runat="server" Text='<%# Bind("AprilAgeMonth") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Lblerror" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hfcode" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
