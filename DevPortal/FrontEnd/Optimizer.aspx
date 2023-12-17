<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Optimizer.aspx.cs" Inherits="DevPortal.FrontEnd.Optimizer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" href="/PortalResource/css/Main.css" />

</head>
<body style="background-color: #f2f2f2;">
    <header>
     <div>
         <div style=" display: flex;">
             <h1 style="text-align: center;font-family: system-ui;position: relative;margin-left: 10px;">WebSyncr</h1>
             <img src="/PortalResource/images/bgpic.jpg" alt="Profile Photo" class="profile-image" onclick="showUserProfile()" />


         </div>
         <nav style="text-align: center;">
             <ul>
                 <li><a class="active" href="/FrontEnd/Dashboard.aspx">Dashboard</a></li>
                 <li><a href="/FrontEnd/CMS.aspx">CMS</a></li>
                 <li><a href="/FrontEnd/Optimizer.aspx">Optimizer</a></li>
                 <li><a href="/FrontEnd/Optimizer.aspx">Features</a></li>
                 <li><a href="/FrontEnd/Prompt.aspx">Prompter</a></li>
                 <li><a href="#about">About</a></li>
             </ul>
         </nav>
     </div>
     <div id="modalBackground" class="modal-background">
         <!-- Modal content -->
         <div class="modal-content">
             <!-- Close button for the modal -->
             <span style="cursor: pointer; float: right;    color: black;" onclick="hideUserProfile()">&times;</span>

             <div class="profile-setting">
             <p >User Name</p>
             <p>Email@example.com</p>

             <!-- Logout link or button -->
             <a href="#" onclick="logout()">Logout</a>
                 </div>
         </div>
     </div>

 </header>







 <div class="developer-mode-label">
     Developer Mode:
     <label class="switch">
         <input type="checkbox" id="developerModeSwitch">
         <span class="slider round"></span>
     </label>
 </div>
 <div style="border-top: 1px solid #ccc; margin-top: 10px; padding-top: 10px; display: flex; justify-content: center;">
 </div>
    <br>
    <form id="form1" runat="server">
        <div>
            <div><asp:Label runat="server" Text="OPTIMIZER" CssClass="label-style"></asp:Label></div>
            <asp:Button ID="Button1" runat="server" Text="List" OnClick="Button1_Click" />


            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" OnRowCommand="OptimizeBtn">
                <Columns>
                    <asp:BoundField DataField="PID" HeaderText="PID" Visible="false" />
                    <asp:BoundField DataField="PageName" HeaderText="Page Name" Visible="false" />
                    <asp:BoundField DataField="DisplayName" HeaderText="Name" />
                    <asp:BoundField DataField="TemplateName" HeaderText="Template Name" />



                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnAction" Text="Optimize" CommandName="DoAction" CommandArgument='<%# Eval("TemplateName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
