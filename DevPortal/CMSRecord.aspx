<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMSRecord.aspx.cs" Inherits="DevPortal.FrontEnd.CMS" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/PortalResource/css/Main.css" />
    <!-- Basic -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Mobile Metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Site Metas -->
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="images/favicon.png" type="">

    <title>Websyncr </title>

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
</head>
<body class="sub_page">



    <div class="hero_area">

        <div class="hero_bg_box">
            <div class="bg_img_box">
                <img src="images/hero-bg.png" alt="">
            </div>
        </div>

        <!-- header section strats -->
        <header class="header_section">
            <div class="container-fluid">
                <nav class="navbar navbar-expand-lg custom_nav-container ">
                    <a class="navbar-brand" href="index.html">
                        <span>Websyncr
                        </span>
                    </a>

                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class=""></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav  ">
                            <li class="nav-item ">
                                <a class="nav-link" href="Dashboard.aspx">Dashboard  </a>
                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" href="CMS.aspx">CMS  <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Optimizer.aspx">Optimizer</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Prompt.aspx">Prompter</a>
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
                    /* ... (existing styles) */
                    width: 25%; /* Set width to 25% to make four buttons occupy the row */
                    box-sizing: border-box; /* Include padding and border in the width */
                }

                /* Add a clearfix to clear the float and start a new line after every four buttons */
                .clearfix::after {
                    content: "";
                    clear: both;
                    display: table;
                }

                /* Apply clearfix to the container of buttons */
                #Labels {
                    display: flex;
                    flex-wrap: wrap;
                    margin-left: 15px;
                    justify-content: flex-start;
                }

                /* Additional styling for better visual separation */
                .label-container {
                    margin-bottom: 10px; /* Add margin between rows of buttons */
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
                    height: 84px;
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
                    margin-right: 25px;
                    margin-bottom: 15px;
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
                    <%-- <asp:Label ID="Label1" runat="server" Text="Header" CssClass="button-29" ClientIDMode="Static" onclick="expandLabel('headingLabel', 'headingField', 'Button2')" />
                    <div id="headingLabel"></div>
                    <asp:Label ID="Label2" runat="server" Text="Footer" CssClass="button-29" ClientIDMode="Static" onclick="expandLabel('footerLabel', 'footerField', 'Button1')" />
                    <div id="footerLabel"></div>
                    <asp:Label ID="Label4" runat="server" Text="New" CssClass="button-29" ClientIDMode="Static" onclick="expandLabel('elementLabel', 'elementField', 'Button3')" />
                    <div id="elementLabel"></div>--%>
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
