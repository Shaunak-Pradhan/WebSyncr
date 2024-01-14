<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prompt.aspx.cs" Inherits="DevPortal.FrontEnd.Prompt" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="/PortalResource/js/Main.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/PortalResource/css/Main.css" />
    <link rel="stylesheet" href="/PortalResource/master page resource/css" />
    <!-- bootstrap core css -->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />

    <!-- fonts style -->
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700;900&display=swap" rel="stylesheet">

    <!--owl slider stylesheet -->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />

    <!-- font awesome style -->
    <link href="css/font-awesome.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet" />
    <!-- responsive style -->
    <link href="css/responsive.css" rel="stylesheet" />
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/snippets.js" type="text/javascript"></script>
    <script src="C:/Users/ShaunakSunilPradhan/Downloads/html/kleon/assets/js/theme.js" type="text/javascript"></script>
</head>
<body style="background-color: #f2f2f2; overflow-x: hidden;" class="sub_page">
    <div class="hero_area">
        <header class="header_section">
            <div class="container-fluid">
                <nav class="navbar navbar-expand-lg custom_nav-container ">
                    <a class="navbar-brand" href="default.aspx">
                        <span>Websyncr
                        </span>
                    </a>

                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class=""></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav">
                            <li class="nav-item ">
                                <a class="nav-link" href="Dashboard.aspx">Dashboard </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="CMS.aspx">CMS</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Optimizer.aspx">Optimizer</a>
                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" href="Prompt.aspx">Prompter <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Default.aspx">Why Us</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Login.aspx"><i class="fa fa-user" aria-hidden="true"></i>Login</a>
                            </li>
                            <form class="form-inline">
                                <button class="btn  my-2 my-sm-0 nav_search-btn" type="submit">
                                    <i class="fa fa-search" aria-hidden="true"></i>
                                </button>
                            </form>
                        </ul>
                    </div>
                </nav>
            </div>
        </header>
    </div>
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
        
        <asp:Label ID="Label1" runat="server" Text="Enter URL" CssClass="label-style" style="margin-right: 10px;margin-bottom:20px;" />
            <asp:TextBox runat="server" TextMode="MultiLine" style="width: 99%; height: 50px; font-family: system-ui; font-size: medium; margin-top: 10px;" CssClass="txt" ClientIDMode="Static" id="prompt"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="SubmitButton" Text="Clone URL" ClientIDMode="Static" CssClass="button-29"/>
        <br>
        <asp:Label ID="Label2" runat="server" Text="Enter HTML" CssClass="label-style" style="margin-right: 10px;margin-bottom:20px;" />
        <asp:TextBox runat="server" TextMode="MultiLine" style="width: 99%; height: 300px; font-family: system-ui; font-size: medium;" CssClass="txt" ClientIDMode="Static" ID="answer"></asp:TextBox>    
        <asp:Button ID="Button1" runat="server" OnClick="SubmitHTMLButton" Text="Clone HTML" ClientIDMode="Static" CssClass="button-29"/>
        <div id="table"></div>

    <style>
       
        /*#answer {
            background-color: #f1f1f1;*/ /* Set a background color to indicate it's read-only */
            /*color: #333;*/ /* Text color */
            /*cursor: not-allowed;*/ /* Change the cursor to indicate it's not selectable */
        /*}*/

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
        &copy; 2024 WebSyncr. All rights reserved.
    </footer>
</body>
</html>
