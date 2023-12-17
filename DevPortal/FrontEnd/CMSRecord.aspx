<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMSRecord.aspx.cs" Inherits="DevPortal.FrontEnd.CMS" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/PortalResource/css/Main.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body style="background-color: #f2f2f2;">
    <header>
        <div>
            <div style="display: flex;">
                <h1 style="text-align: center; font-family: system-ui; position: relative; margin-left: 10px;">WebSyncr</h1>
                <img src="/PortalResource/images/bgpic.jpg" alt="Profile Photo" class="profile-image" onclick="showUserProfile()" />
            </div>
            <nav style="text-align: center;">
                <ul>
                    <li><a class="active" href="/FrontEnd/DevPortal.aspx">Dashboard</a></li>
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
                <span style="cursor: pointer; float: right; color: black;" onclick="hideUserProfile()">&times;</span>
                <div class="profile-setting">
                    <p>User Name</p>
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
            <asp:GridView runat="server" ID="GridView" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="PageName" HeaderText="PageName" Visible="false" />
                    <asp:BoundField DataField="DisplayName" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Link">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLink1" Text='Browse' NavigateUrl='<%# Eval("PageURL") %>' Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br>
            <style>
                .label-button {
                    display: inline-block;
                    padding: 10px 20px;
                    background-color: #007BFF;
                    color: #fff;
                    cursor: pointer;
                    border: 1px solid #007BFF;
                    border-radius: 5px;
                }
                .label-container {
                    display: flex;
                    flex-direction: column;
                    justify-content: flex-start;
                    align-items: flex-start;
                }
                .input-container {
                    display: flex;
                    flex-direction: column;
                    justify-content: flex-start;
                    align-items: flex-start;
                }
            </style>
            <style>
                /* CSS */
                .button-29 {
                    align-items: center;
                    appearance: none;
                    background-image: radial-gradient(100% 100% at 100% 0, #5adaff 0, #5468ff 100%);
                    border: 0;
                    border-radius: 6px;
                    box-shadow: rgba(45, 35, 66, .4) 0 2px 4px,rgba(45, 35, 66, .3) 0 7px 13px -3px,rgba(58, 65, 111, .5) 0 -3px 0 inset;
                    box-sizing: border-box;
                    color: #fff;
                    cursor: pointer;
                    display: inline-flex;
                    font-family: "JetBrains Mono",monospace;
                    height: 48px;
                    justify-content: center;
                    line-height: 1;
                    list-style: none;
                    overflow: hidden;
                    padding-left: 16px;
                    padding-right: 16px;
                    position: relative;
                    text-align: left;
                    text-decoration: none;
                    transition: box-shadow .15s,transform .15s;
                    user-select: none;
                    -webkit-user-select: none;
                    touch-action: manipulation;
                    white-space: nowrap;
                    will-change: box-shadow,transform;
                    font-size: 18px;
                    font-family: system-ui;
                    text-align: center;
                    padding: 20px;
                    margin-right: 10px;
                }
                    .button-29:focus {
                        box-shadow: #3c4fe0 0 0 0 1.5px inset, rgba(45, 35, 66, .4) 0 2px 4px, rgba(45, 35, 66, .3) 0 7px 13px -3px, #3c4fe0 0 -3px 0 inset;
                    }
                    .button-29:hover {
                        box-shadow: rgba(45, 35, 66, .4) 0 4px 8px, rgba(45, 35, 66, .3) 0 7px 13px -3px, #3c4fe0 0 -3px 0 inset;
                        transform: translateY(-2px);
                    }
                    .button-29:active {
                        box-shadow: #3c4fe0 0 3px 7px inset;
                        transform: translateY(2px);
                    }
            </style>
            <div id="Labels">
                <asp:PlaceHolder runat="server" ID="dynamicLabelsPlaceholder"></asp:PlaceHolder>
                <div style="display: flex; align-items: center;">
                    <asp:Label ID="Label1" runat="server" Text="Header" CssClass="button-29" ClientIDMode="Static" onclick="expandLabel('headingLabel', 'headingField', 'Button2')" />
                    <div id="headingLabel"></div>
                    <asp:Label ID="Label2" runat="server" Text="Footer" CssClass="button-29" ClientIDMode="Static" onclick="expandLabel('footerLabel', 'footerField', 'Button1')" />
                    <div id="footerLabel"></div>
                    <asp:Label ID="Label4" runat="server" Text="New" CssClass="button-29" ClientIDMode="Static" onclick="expandLabel('elementLabel', 'elementField', 'Button3')" />
                    <div id="elementLabel"></div>
                    <br>
                </div>
            </div>
            <br>
            <asp:TextBox runat="server" TextMode="MultiLine" Style="width: 99%; height: 300px; display: none; font-family: system-ui; font-size: medium;" CssClass="txt" ClientIDMode="Static" ID="headingField" ViewStateMode="Enabled"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="HeaderOnClick" Text="Submit" ClientIDMode="Static" Style="display: none" CssClass="button-29" />
            <asp:TextBox runat="server" TextMode="MultiLine" Style="width: 99%; height: 300px; display: none; font-family: system-ui; font-size: medium;" CssClass="txt" ClientIDMode="Static" ID="footerField"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="FooterOnClick" Text="Submit" ClientIDMode="Static" Style="display: none" />
            <asp:TextBox runat="server" TextMode="MultiLine" Style="width: 99%; height: 300px; display: none; font-family: system-ui; font-size: medium;" CssClass="txt" ClientIDMode="Static" ID="elementField"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="FooterOnClick" Text="Submit" ClientIDMode="Static" Style="display: none" />
        </div>
    </form>
    <style>
        .label-button {
            display: inline-block;
            padding: 10px 20px; /* Adjust the padding as needed */
            background-color: #10468de0; /* Button background color */
            color: #fff; /* Button text color */
            cursor: pointer;
            border: 1px solid #ffffff; /* Button border color */
            border-radius: 5px; /* Rounded corners */
        }
    </style>
</body>
<script type="text/javascript">
    function expandLabel(labelId, fieldId, buttonId) {
        var label = document.getElementById(labelId);
        var field = document.getElementById(fieldId);
        var button = document.getElementById(buttonId);
        if (field.style.display === "none") {
            field.style.display = "block";
            label.style.display = "block";
            button.style.display = "block"; // Hide the submit button
        } else {
            field.style.display = "none";
            label.style.display = "none";
            button.style.display = "none"; // Show the submit button
        }
    }
</script>
</html>
