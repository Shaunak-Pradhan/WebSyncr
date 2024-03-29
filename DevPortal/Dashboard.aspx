﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DevPortal.FrontEnd.WebForm1" Async="true" %>

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
                            <li class="nav-item active">
                                <a class="nav-link" href="Dashboard.aspx">Dashboard <span class="sr-only">(current)</span> </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="CMS.aspx">CMS</a>
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
                                <asp:DropDownList runat="server" ID="ddlName" DataSource='<%# DevPortal.Services.Implementation.TemplateService.GetNames() %>' DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" AutoPostBack="true" CommandArgument='<%# Container.DataItemIndex %>'></asp:DropDownList>
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
                window.location.href = '/Login.aspx';
            }
        </script>
    </form>


    <section class="info_section layout_padding2">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-lg-3 info_col">
                    <div class="info_contact">
                        <h4>Address
                        </h4>
                        <div class="contact_link_box">
                            <a href="">
                                <i class="fa fa-map-marker" aria-hidden="true"></i>
                                <span>Al Nahda, Sharjah
                                </span>
                            </a>
                            <a href="">
                                <i class="fa fa-phone" aria-hidden="true"></i>
                                <span>Call +971 561280452
                                </span>
                            </a>
                            <a href="">
                                <i class="fa fa-envelope" aria-hidden="true"></i>
                                <span>websyncr@gmail.com
                                </span>
                            </a>
                        </div>
                    </div>
                    <div class="info_social">
                        <a href="">
                            <i class="fa fa-facebook" aria-hidden="true"></i>
                        </a>
                        <a href="">
                            <i class="fa fa-twitter" aria-hidden="true"></i>
                        </a>
                        <a href="">
                            <i class="fa fa-linkedin" aria-hidden="true"></i>
                        </a>
                        <a href="">
                            <i class="fa fa-instagram" aria-hidden="true"></i>
                        </a>
                    </div>
                </div>
                <div class="col-md-6 col-lg-3 info_col">
                    <div class="info_detail">
                        <h4>Info
                        </h4>
                        <p>
                            Unlock the potential of your online presence effortlessly with our cutting-edge Content Management System (CMS). Revamping your website has never been this easy and quick. Whether you're a seasoned web developer or a business owner looking to refresh your online identity, our CMS is designed to make the entire process seamless, efficient, and enjoyable.
                        </p>
                    </div>
                </div>
                <div class="col-md-6 col-lg-2 mx-auto info_col">
                    <div class="info_link_box">
                        <h4>Links
                        </h4>
                        <div class="info_links">
                            <a class="active" href="Dashboard.aspx">Dashboard
                            </a>
                            <a class="" href="CMS.aspx">CMS
                            </a>
                            <a class="" href="Optimizer.aspx">Optimizer
                            </a>
                            <a class="" href="Prompt.aspx">Prompter
                            </a>
                            <a class="" href="default.aspx">Why Us
                            </a>
                        </div>
                    </div>
                </div>
                <div id="contactSection" class="col-md-6 col-lg-3 info_col ">
                    <h4>Contact us for more info
                    </h4>
                    <form action="#">
                        <input type="text" placeholder="Enter email" />
                        <button type="submit">
                            submit
                        </button>
                    </form>
                </div>
            </div>
        </div>
    </section>

    <!-- end info section -->
    <!-- jQery -->
    <script type="text/javascript" src="js/jquery-3.4.1.min.js"></script>
    <!-- popper js -->
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous">
    </script>
    <!-- bootstrap js -->
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <!-- owl slider -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js">
    </script>
    <!-- custom js -->
    <script type="text/javascript" src="js/custom.js"></script>
    <!-- Google Map -->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCh39n5U-4IoWpsVGUHWdqB6puEkhRLdmI&callback=myMap">
    </script>
    <!-- End Google Map -->
    <script>
        function scrollToContactSection() {
            // Adjust the duration and offset as needed
            $('html, body').animate({
                scrollTop: $('#contactSection').offset().top - 100 // Offset to leave some space
            }, 1000); // Duration in milliseconds
        }
    </script>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script type="text/javascript">
        function logBaseDirectory() {
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/AccessCheck",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Project Directory: " + response.d);
                },
                error: function (error) {
                    console.error("Error getting base directory from server.");
                }
            });
        }

        // Example usage
        logBaseDirectory();
    </script>

    <footer>
        &copy; 2024 WebSyncr. All rights reserved.
    </footer>
</body>
</html>
