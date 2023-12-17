<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DevPortal.FrontEnd.WebForm1" Async="true" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="/PortalResource/js/Main.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/PortalResource/css/Main.css" />
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/snippets.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/theme.js" type="text/javascript"></script>
</head>
<body style="background-color: #f2f2f2;overflow-x: hidden;">
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
        <div style="text-align: center; display: flex; flex-wrap: wrap; justify-content: center;">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Name" CssClass="label-style" Style="margin-right: 10px;" />
                <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" CssClass="input-style" />
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Format" CssClass="label-style" Style="margin-right: 10px;" />
                <asp:DropDownList ID="ddlType" runat="server" CssClass="dropdown-style" AutoPostBack="true">
                    <asp:ListItem Text="Page" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Design" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Logic" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div style="border-top: 1px solid #ccc; margin-top: 10px; padding-top: 10px; display: flex; justify-content: center;">
            <asp:Button ID="Button2" runat="server" OnClick="Generate" Text="Generate" CssClass="button-29" Style="margin-right: 10px;" />
             <asp:Button ID="Button3" runat="server" OnClick="ShowGridView" Text="List" CssClass="button-29" Style="margin-left: 10px;" />
        </div>
        <div>
            <br>
            <br>
            <br>
            <div>
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" OnRowCommand="DeleteButton" CssClass="styled-gridview">
                    <Columns>
                        <asp:BoundField DataField="PID" HeaderText="Sr No" />
                        <asp:BoundField DataField="PageName" HeaderText="Page Name" Visible="false" />
                        <asp:BoundField DataField="DisplayName" HeaderText="Name" />
                        <asp:BoundField DataField="TemplateName" HeaderText="Design" />
                        <asp:TemplateField HeaderText="Attach Design">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlName" DataSource='<%# DevPortal.Services.Implementation.CreateFileService.GetNames() %>' DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" AutoPostBack="true" CommandArgument='<%# Container.DataItemIndex %>'></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Link">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1" Text='Browse' NavigateUrl='<%# Eval("PageURL") %>' Target="_blank"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Edit Link">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLink2" Text='Edit' NavigateUrl='<%# Eval("EditLink") %>' Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnAction" Text="Delete" CssClass="delete-button" CommandName="DoAction" CommandArgument='<%# Eval("PID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<asp:GridView ID="GridView2" runat="server"></asp:GridView>--%>
                <br>
            </div>
            <%--x = Parameter names in the table--%>
        </div>
        <div id="table"></div>
        <script>
            const developerModeSwitch = document.getElementById('developerModeSwitch');
            developerModeSwitch.addEventListener('change', function () {
                debugger;
                if (developerModeSwitch.checked) {
                    // Developer mode is ON
                    alert('Developer Mode is ON');
                    // Add your developer-related actions here
                } else {
                    // Developer mode is OFF
                    alert('Developer Mode is OFF');
                    // Remove or disable developer-related actions here
                }
            });
            function showUserProfile() {
                var userInfo = document.getElementById('userInfo');
                userInfo.style.display = userInfo.style.display === 'none' ? 'block' : 'none';
            }
            function showUserProfile() {
                var modalBackground = document.getElementById('modalBackground');
                modalBackground.style.display = 'flex';
            }
            function hideUserProfile() {
                var modalBackground = document.getElementById('modalBackground');
                modalBackground.style.display = 'none';
            }
            function logout() {
                window.location.href = '/FrontEnd/Login.aspx';
            }
        </script>
    </form>
    <footer>
        &copy; 2023 WebSyncr. All rights reserved.
    </footer>
</body>
</html>
