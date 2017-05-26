<%@ Page  Language="C#" MasterPageFile="~/PISMasterPage.master" StylesheetTheme="NewTheme" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" EnableEventValidation="false"
Inherits="Dashboard" Title="Dashboard" %>

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
       
    <div style="width:95%; margin-bottom:30px;  margin-right:5px; padding-left:30px; padding-right:30px;">
    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#baffc9; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label1" runat="server" Text="Male" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblmale" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#bae1ff; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label3" runat="server" Text="Female" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblfemale" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#ffffba; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label5" runat="server" Text="Member" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblMember" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#ffdfba; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label7" runat="server" Text="Married" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblmarried" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:100%;">
    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#ffb3ba; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label9" runat="server" Text="UnMarried" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblunmarried" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>


    </div>
    </div>
    <div style="height:100px;">
    </div>
    <div style="width:95%; margin-bottom:30px;  margin-right:5px; padding-left:30px; padding-right:30px;">

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#baffc9; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label2" runat="server" Text="SC" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblsc" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#bae1ff; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label6" runat="server" Text="ST" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblst" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#ffffba; ">
    <div style="width:100%; margin-top:10px; text-align:center ;"> 
    <asp:Label ID="Label12" runat="server" Text="OBC" Font-Bold="True" width="100%"
    ForeColor="black"></asp:Label>
    </div>
    <div style="width:100%; margin-top:10px; text-align:center;">
    <asp:Label ID="lblobc" runat="server" Text="Count" Font-Italic="True" 
    Font-Size="Large" ForeColor="#6699FF"></asp:Label>
    </div>
    </div>

    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#ffdfba; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label14" runat="server" Text="OTHER" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblother" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>

    <div style="width:100%;">
    <div style="width:20%; float:left; box-shadow: 10px 10px 5px #888888; background-color:#ffb3ba; ">
       <div style="width:100%; margin-top:10px; text-align:center ;"> 
                <asp:Label ID="Label16" runat="server" Text="Verified Household" Font-Bold="True" width="100%"
                    ForeColor="black"></asp:Label>
       </div>
       <div style="width:100%; margin-top:10px; text-align:center;">
                 <asp:Label ID="lblvillage" runat="server" Text="Count" Font-Italic="True" 
                     Font-Size="Large" ForeColor="#6699FF"></asp:Label>
        </div>
    </div>


    </div>

    </div>
 
   </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
