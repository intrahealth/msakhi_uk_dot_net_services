<%@ Page Language="C#" MasterPageFile="~/PISMasterPage.master" StylesheetTheme="NewTheme" AutoEventWireup="true" CodeFile="frm_ASHA.aspx.cs" EnableEventValidation="false"
Inherits="frm_ASHA" Title="ASHA Master" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" Runat="Server">

 <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
 <link href="Styles/textinput.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"> </script>

</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


  <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePageMethods="true" ID="ScriptManager2" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
      
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <div style="vertical-align: middle; width: 100%; background-color: White; height: 30px;
                    text-align: left" align="right">
                   <asp:Label ID="LblModule" runat="server" ForeColor="#000"
                        Width="380px" Height="20px" Font-Bold="True" Font-Names="Arial" Font-Size="20px">ASHA Master</asp:Label>
                        <%--<asp:Label ID="lbl_Root" runat="server" ForeColor="#000" Font-Size="20px"  CssClass="class"
                        Font-Names="Arial" Font-Bold="True">Login > Masters >ASHA </asp:Label>--%>
                          <asp:UpdateProgress ID="UpdateProgress5"  runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel2">
                                        <ProgressTemplate>
                                            <div id="IMGDIV11" runat="server" align="center" style="visibility: visible; vertical-align: middle;
                                                width: 99%; height:150%; position: absolute; z-index: 999999;" valign="middle"
                                                class="modalBackground">
                                                <asp:Image ID="Image11"  runat="server" Style="position: relative; top: 40%; left: 0px;"
                                                    Height="120px" ImageUrl="images/progress2.gif" />
                                            </div>
                                           
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                    <asp:Label ID="LblForm" runat="server" ForeColor="Navy" Width="300px" Height="20px"
                        Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
                        <asp:Label
                            ID="Label322" runat="server" ForeColor="Black" Width="40px" CssClass="labelClass"
                            Font-Bold="True"></asp:Label></div>
                <div style="width: 100%" id="divadd">
                    <table style="width: 100%; background-color: #eee;">
                        <tbody>
                            <tr>
                                <td style="vertical-align: top; text-align: left" colspan="2">
                                    <table style="width: 100%; " cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 151px; height: 22px; text-align: left" class="TdData">
                                                    <asp:Label ID="LabelDISTRICT" runat="server" Width="73px" CssClass="labelTitle" Text="ASHACode"></asp:Label>
                                                </td>
                                               <td style="vertical-align: top; width: 200px; height: 22px; text-align: left" class="TdData">
                                                    <asp:Label ID="LabelBLOCK" runat="server" style="display:inline-block;width:70px;margin-left: -61%;" CssClass="labelTitle" Text="ASHA Name"></asp:Label>
                                                </td>
                                                <td style="vertical-align: top; height: 22px; text-align: left" class="TdData">
                                                </td>
                                            </tr>
                                            <tr >
                                                <td style="vertical-align: top; width: 300px; height: 22px; text-align: left" class="TdData">
                                                <asp:TextBox runat="server" ID="txt_ashacode" Style="width: 45%;" placeholder="ASHA code 4 digit"></asp:TextBox>
                                               
                                                </td>
                                                <td style="vertical-align: top; width: 157px; height: 22px; text-align: left" class="TdData">
                                                 <asp:TextBox runat="server" ID="txtashaname" Style="width: 78%;margin-left: -120px;" placeholder="ASHA Name"></asp:TextBox>
                                             
                                                </td>
                                                <td style="vertical-align: top; height: 22px; text-align: center" class="TdData">
                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click1" runat="server" Text="Add ASHA" Style="float: right;" CssClass="submit_butt-new"
                                                        Width="100px" ToolTip="Add Center"></asp:Button>&nbsp;
                                                    <asp:Button ID="BtnSearch" TabIndex="3" Style="float: none;margin-left: -835px;" OnClick="BtnSearch_Click1" runat="server"
                                                        Height="24px" ValidationGroup="GRPSearch" Text="Search" CssClass="submit_butt-new"
                                                        ToolTip="Search"></asp:Button>&nbsp;
                                                    <asp:Button ID="ImgClear" Style="float: none;" runat="server" Height="24px" Text="Clear" ToolTip="Clear"
                                                        CssClass="submit_butt-new"></asp:Button>&nbsp;
                                                </td>
                                            </tr>
                                             <tr>
                               <td class="tdData" colspan="3">
                                   
                                </td>
                                </tr>
                                            </tbody>
                                            </table>
                                            <table style="width:100%;">
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
                          
                            <tr>
                                <td colspan="2">
                                  <asp:Panel ID="Panel5" runat="server" Height="300px" Width="100%" ScrollBars="Vertical"
                        BorderColor="Navy">
                                        <asp:GridView ID="GVashaData" runat="server" Width="100%" CssClass="mGrid" OnSorting="GVashaData_Sorting"
                                            OnRowCommand="GVashaData_RowCommand" OnRowDataBound="GVashaData_RowDataBound"
                                            PageSize="15" DataKeyNames="ASHAID,ASHACode" AutoGenerateColumns="False"
                                            AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GVashaData_PageIndexChanging"
                                            PagerStyle-CssClass="pgr">
                                            <PagerSettings Position="TopAndBottom"></PagerSettings>
                                            <Columns>
                                                <asp:BoundField DataField="ASHACode" Visible="false" HeaderText="ASHA Code" SortExpression="ASHACode" >
                                                     <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px"></ItemStyle>
                                                    </asp:BoundField>
                                                <asp:BoundField DataField="ASHAID" HeaderText="ASHA ID" SortExpression="ASHAID" Visible="True">
                                                     <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px"></ItemStyle>
                                                    </asp:BoundField>
                                                <asp:BoundField DataField="ASHAName" HeaderText="ASHA Name" SortExpression="">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="13px" Width="350px"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ASHAName_Hindi" HeaderText="ASHA Name Hindi" SortExpression="">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="13px" Width="350px"></ItemStyle>
                                                </asp:BoundField>
                                                
                                                <asp:ButtonField CommandName="EditCenter" ButtonType="Button" CausesValidation="True"
                                                    ShowHeader="True" HeaderText="Edit">
                                                    <ControlStyle BorderWidth="0px" CssClass="mGridEditCommand"></ControlStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                                                </asp:ButtonField>
                                                <asp:ButtonField CommandName="DeleteCenter" Visible="false" ButtonType="Button" CausesValidation="True"
                                                    HeaderText="Delete">
                                                    <ControlStyle BorderWidth="0px" CssClass="mGridDeleteCommand"></ControlStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                                                </asp:ButtonField>
                                            </Columns>
                                            <RowStyle BackColor="#F2F8FC" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <PagerStyle CssClass="pgr"></PagerStyle>
                                        </asp:GridView>
                                     </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>

            <div style="width: 960px">
                <asp:Panel Style="display: none; text-align: center" ID="PnlBlock" runat="server"
                    CssClass="mModalPanel">
                    <asp:Label Style="background-color:#d2dcd5; font-size:large" ID="addlabel" runat="server" Width="296px"
                        Height="25px" CssClass="pop_header"></asp:Label><table style="width: 291px; height: 122px"
                            id="tblBlock" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td style="vertical-align: top; text-align: left" class="TdData" colspan="2">
                                        <asp:Label ID="lblMsgGrpmbr" runat="server" ForeColor="OrangeRed" Width="206px" Height="8px"
                                            Font-Bold="False" Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr>


                                 <tr>
                                    <td style="vertical-align: top; text-align: left" class="TdData">
                                    <asp:Label ID="Label4" runat="server" CssClass="labelTitle" __designer:wfdid="w6"
                                    Text="ANM Name"></asp:Label><span style="color: red">*</span>
                                    </td>
                                    <td style="vertical-align: top; width: 216px; text-align: left" class="TdData">
                                    <asp:DropDownList ID="ddlanmName" runat="server" CssClass="shg_textbox" Width="200px"
                                    Height="24px" TabIndex="20" ValidationGroup="grpBlock" AutoPostBack="true" OnSelectedIndexChanged="ddlanmName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="ddlanmName" ID="RequiredFieldValidator3"
                                    ValidationGroup="grpBlock" CssClass="ErrorMsg" ErrorMessage="select ANM Name"
                                     runat="server" SetFocusOnError="True" Display="Dynamic">
                                    </asp:RequiredFieldValidator>

                                    </td>
                                </tr>


                                <tr>
                                    <td style="vertical-align: top; text-align: left" class="TdData">
                                        <asp:Label ID="Label3" runat="server" CssClass="labelTitle" __designer:wfdid="w6"
                                            Text="SubCenter Name"></asp:Label><span style="color: red">*</span>
                                    </td>
                                    <td style="vertical-align: top; width: 216px; text-align: left" class="TdData">
                       
                                       <asp:DropDownList ID="ddlsubcenter" TabIndex="19" runat="server" Width="200px" Height="24px"
                                                CssClass="shg_textbox" ValidationGroup="grpBlock" >
                                                </asp:DropDownList>

                                    <asp:RequiredFieldValidator ControlToValidate="ddlsubcenter" ID="RequiredFieldValidator4"
                                    ValidationGroup="grpBlock" CssClass="ErrorMsg" ErrorMessage="select SubCenter Name"
                                     runat="server" SetFocusOnError="True" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <td style="vertical-align: top; text-align: left" class="TdData">
                                        <asp:Label ID="Label2" runat="server" CssClass="labelTitle" __designer:wfdid="w6"
                                            Text="ASHA Name"></asp:Label><span style="color: red">*</span>
                                    </td>
                                    <td style="vertical-align: top; width: 216px; text-align: left" class="TdData">                      
                                    <asp:TextBox ID="txtashaNm" TabIndex="2" runat="server" Width="185px" CssClass="shg_selec"
                                    __designer:wfdid="w7" ValidationGroup="grpBlock" MaxLength="30"></asp:TextBox><br /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="ErrorMsg"
                                    __designer:wfdid="w8" ValidationGroup="grpBlock" SetFocusOnError="True" Display="Dynamic"
                                    ControlToValidate="txtashaNm" ErrorMessage="Enter Asha Name!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="vertical-align: top; text-align: left" class="TdData">
                                        <asp:Label ID="Label1" runat="server" CssClass="labelTitle" __designer:wfdid="w6"
                                        Text="ASHA Name Hindi"></asp:Label><span style="color: red">*</span>
                                    </td>

                                    <td style="vertical-align: top; width: 216px; text-align: left" class="TdData">                     
                                        <asp:TextBox ID="txtashaNmhindi" TabIndex="2" runat="server" Width="185px" CssClass="shg_selec"
                                            __designer:wfdid="w7" ValidationGroup="grpBlock" MaxLength="30"></asp:TextBox><br /><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="ErrorMsg"
                                            __designer:wfdid="w8" ValidationGroup="grpBlock" SetFocusOnError="True" Display="Dynamic"
                                            ControlToValidate="txtashaNmhindi" ErrorMessage="Enter Asha Name in Hindi!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>


                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="Btnsave" OnClick="Btnsave_Click1" runat="server" __designer:wfdid="w5"
                                            ValidationGroup="grpBlock" Style="float:none;" CssClass="submit_butt-new" Text="Save" ToolTip="Save"></asp:Button>&nbsp;
                                        <asp:Button ID="BtnExit" runat="server" __designer:wfdid="w6" Style="float:none;" CssClass="submit_butt-new" Text="Close" ToolTip="Close">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="MpexdrBlock" runat="server" BackgroundCssClass="modalBg"
                    TargetControlID="HdnFild" PopupControlID="PnlBlock" CancelControlID="BtnExit">
                </ajaxToolkit:ModalPopupExtender>
                <asp:HiddenField ID="HdnFild" runat="server"></asp:HiddenField>

                <asp:Panel Style="display: none; text-align: center" ID="Pnldel" runat="server" Height="60px"
                    CssClass="mModalPanel">
                    <table style="width: 100%" id="tbldel">
                        <tbody>
                            <tr>
                                <td style="width: 317px">
                                    <asp:Label Style="background-color: #354b60" ID="lbldel" runat="server" Width="310px"
                                        Height="30px" CssClass="pop_header" Font-Bold="True" Text="Confirm  Deletion ?"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 317px">
                                    <asp:Button ID="TndrConfirmYes" OnClick="TndrConfirmYes_Click1" runat="server"
                                       Text="Yes" ToolTip="Yes" Style="float:none; margin-left:0px;" CssClass ="submit_butt1"></asp:Button>&nbsp;
                                    <asp:Button ID="BTNDelConfirmNo" Style="float:none;" runat="server" Text="No" ToolTip="No" CssClass="submit_butt1">
                                    </asp:Button>&nbsp;&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="MPDelBlock" runat="server" BackgroundCssClass="modalBg "
                    TargetControlID="hdnfld_del" PopupControlID="Pnldel" CancelControlID="BTNDelConfirmNo">
                </ajaxToolkit:ModalPopupExtender>
                <asp:HiddenField ID="hdnfld_del" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="HFUserlevel" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
