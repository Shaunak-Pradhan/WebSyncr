<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Optimizer.aspx.cs" Inherits="DevPortal.FrontEnd.Optimizer" %>

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
                    <a class="navbar-brand" href="index.html">
                        <span>Websyncr
                        </span>
                    </a>

                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class=""></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav">
                            <li class="nav-item active">
                                <a class="nav-link" href="index.html">Dashboard <span class="sr-only">(current)</span> </a>
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
