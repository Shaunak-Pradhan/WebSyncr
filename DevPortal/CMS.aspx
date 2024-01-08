<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMS.aspx.cs" Inherits="DevPortal.FrontEnd.CMS1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" href="/PortalResource/css/Main.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha384-GLhlTQ8iUNnJTmPVVy0M6FnxJ2Nl/bi0zwn1RnbcvNUw5J46E6K/iT5n5FsaUCG2" crossorigin="anonymous" />
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha512-...." crossorigin="anonymous" />
 <%-- <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
 <style>
     .service-section .icon-box {
         margin-bottom: 20px;
         padding: 30px;
         border-radius: 6px;
         background-color: #f8f9fa;
     }
         .service-section .icon-box:hover .service-title a {
             color: #003781;
         }
         .service-section .icon-box .service-icon {
             float: left;
             color: #003781;
             font-size: 40px;
         }
         .service-section .icon-box .service-title {
             margin-left: 70px;
             font-weight: 700;
             margin-bottom: 15px;
             font-size: 18px;
             line-height: 1.2;
         }
             .service-section .icon-box .service-title a {
                 color: #003781;
                 transition: 0.3s;
                 text-decoration: none;
             }
         .service-section .icon-box .service-para {
             margin-left: 70px;
             line-height: 24px;
             font-size: 14px;
         }
     .service-section .service-main-heading {
         color: #556270;
         padding: 0;
         margin-bottom: 20px;
         line-height: 1;
         font-size: 60px;
         font-weight: 600;
     }
 </style>
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
        <section class="service-section py-5">
            <div class="container" style="font-family: system-ui;">
                <%-- <div class="row justify-content-center py-3">
                <div class="col-md-8 col-12 text-center">
                    <p class="service-main-heading">Features</p>
                </div>
            </div>--%>
                <div class="row" style="display: flex; gap: 20px;">
                    <div class="col-md-6 col-lg-6 col-12">
                        <div class="icon-box" style="display: flex; align-items: center; margin-bottom: 20px; border-bottom: groove;">
                            <i class="fa-solid fa-file-code" style="font-size: xx-large; color: #2a5298;"></i>
                            <div>
                                <asp:LinkButton runat="server" ID="lnkManagePage" OnClick="lnkManagePage_Click">
                                <p class="service-title">Manage Page</p>
                                </asp:LinkButton>
                                <p class="service-para">Edit the page content.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-12 mt-4 mt-md-0">
                        <div class="icon-box" style="display: flex; align-items: center; margin-bottom: 20px;border-bottom: groove;">
                            <i class="fas fa-palette" style="font-size: xx-large; color: #2a5298;"></i>
                            <div>
                                <asp:LinkButton runat="server" ID="lnkManageDesign" OnClick="lnkManageDesign_Click">
                            <p class="service-title">Manage Design</p>
                                </asp:LinkButton>
                                <p class="service-para">Edit the page Design.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-12 mt-4 mt-md-0">
                        <div class="icon-box" style="display: flex; align-items: center; margin-bottom: 20px;border-bottom: groove;">
                            <i class="fa-solid fa-gears" style="font-size: xx-large; color: #2a5298;"></i>
                            <div>
                                <asp:LinkButton runat="server" ID="lnkManageLogic" OnClick="lnkManageLogic_Click">
                            <p class="service-title">Manage Logic</p>
                                </asp:LinkButton>
                                <p class="service-para">Edit the page Logic.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div id="pagesection">
            <div>
                <%--<asp:Label ID="Label3" runat="server" Text="Page Info" CssClass="label-style" />--%>
                <asp:GridView runat="server" ID="GridView" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="PageName" HeaderText="PageName" />
                        <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" />
                        <asp:TemplateField HeaderText="Edit Link">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink2" Text='Edit' NavigateUrl='<%# Eval("EditLink") %>' Target="_blank"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Link">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="HyperLink1" Text='Browse' NavigateUrl='<%# Eval("PageURL") %>' Target="_blank"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br>
                <%--<asp:Label ID="Label1" runat="server" Text="Heading" CssClass="label-style"/>            
            <asp:TextBox runat="server" ID="heading" TextMode="MultiLine" style="width: 100%;height: 100px;" CssClass="txt"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="HeaderOnClick" Text="Submit" />
            <asp:Label ID="Label2" runat="server" Text="Footer" CssClass="label-style"/>  <br>
            <asp:TextBox runat="server" ID="footer" TextMode="MultiLine" style="width: 100%;height: 100px;" CssClass="txt"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="FooterOnClick" Text="Submit" />--%>
            </div>
        </div>
    </form>
    <script>
        /*  window.onload = function () {
              $('#pagesection').hide();
              $('#designsection').hide();
              $('#logicsection').hide();
          };
          function page() {
              $('#pagesection').show();
              $('#designsection').hide();
              $('#logicsection').hide();
          }
          function design() {
              $('#pagesection').hide();
              $('#designsection').show();
              $('#logicsection').hide();
          }
          function logic() {
              $('#pagesection').hide();
              $('#designsection').hide();
              $('#logicsection').show();
          }
          */
    </script>
</body>
</html>
