<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prompt.aspx.cs" Inherits="DevPortal.FrontEnd.Prompt" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-3.6.4.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="stylesheet" href="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/css/main.css" />
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/snippets.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/theme.js" type="text/javascript"></script>

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
    <br>
    <form id="form1" runat="server">
        
        <asp:Label ID="Label1" runat="server" Text="Enter URL" CssClass="label-style" style="margin-right: 10px;margin-bottom:20px;" />
            <asp:TextBox runat="server" TextMode="MultiLine" style="width: 99%; height: 50px; font-family: system-ui; font-size: medium; margin-top: 10px;" CssClass="txt" ClientIDMode="Static" id="prompt"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="SubmitButton" Text="Clone" ClientIDMode="Static" CssClass="button-29"/>
        <asp:TextBox runat="server" TextMode="MultiLine" style="width: 99%; height: 300px; font-family: system-ui; font-size: medium;" CssClass="txt" ClientIDMode="Static" ID="answer" ReadOnly="true" Enabled="false"></asp:TextBox>    
        <div id="table"></div>

    <style>
       
        #answer {
            background-color: #f1f1f1; /* Set a background color to indicate it's read-only */
            color: #333; /* Text color */
            cursor: not-allowed; /* Change the cursor to indicate it's not selectable */
        }

    /* Style the table */
    .styled-gridview {
        width: 100%;
        border-collapse: collapse;
        border: 1px solid #ddd;
    }

    /* Style table header */
    .styled-gridview th {
        background-color: #10468de0;
        color: #fff;
        text-align: left;
        padding: 10px;
    }

    /* Style table rows */
    .styled-gridview tr {
        border: 1px solid #ddd;
    }

    /* Style even and odd rows differently */
    .styled-gridview tr:nth-child(even) {
        background-color: #f2f2f2;
    }

    /* Style the "Delete" button */
    .delete-button {
        background-color: #808080;
        color: #fff;
        border: none;
        padding: 5px 10px;
        cursor: pointer;
        background-image: radial-gradient(100% 100% at 100% 0, #5aa3b8 0, #535fb8 100%);
    }

    /* Style hyperlinks */
    .styled-gridview a {
        color: #007bff;
        text-decoration: none;
    }
</style>

       
        <script>
            debugger;
            var value = document.getElementById('TextBox1');
            var value2 = document.getElementById('TextBox2')
            function GeneratePage()
            {
                debugger;
                $.ajax({
                    type: 'Get',                    
                    url: '/GeneratePage()',
                    success: function (result) {
                        var keys = Object.keys(result[0]);
                        var html = "<table class='table'><thread><tr>";

                        for(var key in keys)
                        {
                            html+= "<th>"+keys[key]+"</th>";
                        }
                        html+="</tr></thread><tbody>";

                        for(var res in result)
                        {
                            html+="<tr>";
                            var values = Object.values(result[res]);
                            for(var val in values)
                            {
                                html+= "<td>"+ values[val] +"</td>";
                            }
                            html+="</tr>";
                        }
                        html+= "</tbody></table>";
                        $("#table").append(html);
                    },
                    error: function () {
                        alert('Failed to receive the Data');
                        console.log('Failed ');
                    }
                })
            }
        </script>
        <script>
            const developerModeSwitch = document.getElementById('developerModeSwitch');

            developerModeSwitch.addEventListener('change', function () {
                // Add your code here to toggle developer-related features on or off
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
        </script>

    </form>
    <footer>
        &copy; 2023 WebSyncr. All rights reserved.
    </footer>
</body>
</html>
