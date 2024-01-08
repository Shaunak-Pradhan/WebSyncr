<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DevPortal.FrontEnd.AboutUs" %>

<!DOCTYPE html>
<html>

<head>
    <!-- Basic -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Mobile Metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Site Metas -->
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="images/WebsyncrLogo.png" type="">

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
                      <a class="navbar-brand" href="Default.aspx">
                        <span>Websyncr
                        </span>
                    </a>
                    <%--<a class="navbar-brand" href="Default.aspx">
                        <img src="images/websyncrlogo.png" alt="Websyncr Logo">
                    </a>--%>


                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class=""></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav  ">
                            <li class="nav-item ">
                                <a class="nav-link" href="Dashboard.aspx">Dashboard  </a>
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
                            <li class="nav-item active">
                                <a class="nav-link" href="Default.aspx">Why Us <span class="sr-only">(current)</span></a>
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
        <!-- end header section -->
        <!-- slider section -->
        <section class="slider_section ">
            <div id="customCarousel1" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <div class="container ">
                            <div class="row">
                                <div class="col-md-6 ">
                                    <div class="detail-box">
                                        <h1>Customization Without 
                                            <br>
                                            Limits
                                        </h1>
                                        <p>
                                            Tailor your website to perfection. Our CMS provides extensive customization options, from color schemes and typography to layout and functionality.
                                        </p>
                                        <div class="btn-box">
                                            <a class="btn1" onclick="scrollToContactSection()">Read More</a>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="img-box">
                                        <img src="images/slider-img.png" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item ">
                        <div class="container ">
                            <div class="row">
                                <div class="col-md-6 ">
                                    <div class="detail-box">
                                        <h1>Rapid Website
                                            <br>
                                            Revamp
                                        </h1>
                                        <p>
                                            Say goodbye to lengthy revamp processes. With our CMS, you can execute changes swiftly. 
                                        </p>
                                        <div class="btn-box">
                                            <a href="" class="btn1" onclick="scrollToContactSection()">Read More
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="img-box">
                                        <img src="images/slider-img.png" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="container ">
                            <div class="row">
                                <div class="col-md-6 ">
                                    <div class="detail-box">
                                        <h1>SEO 
                                            <br>
                                            Optimization
                                        </h1>
                                        <p>
                                            Stay visible in search engine results. Our CMS comes equipped with built-in SEO tools, helping you optimize content, meta tags, and URLs effortlessly. 
                                        </p>
                                        <div class="btn-box">
                                            <a href="" class="btn1" onclick="scrollToContactSection()">Read More
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="img-box">
                                        <img src="images/slider-img.png" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="container ">
                            <div class="row">
                                <div class="col-md-6 ">
                                    <div class="detail-box">
                                        <h1>AI 
                        <br>
                                            Integration
                                        </h1>
                                        <p>
                                            Experience the next frontier of web design with our AI integration. Our CMS harnesses the power of artificial intelligence to offer dynamic design personalization.
                                        </p>
                                        <div class="btn-box">
                                            <a href="" class="btn1" onclick="scrollToContactSection()">Read More
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="img-box">
                                        <img src="images/slider-img.png" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <ol class="carousel-indicators">
                    <li data-target="#customCarousel1" data-slide-to="0" class="active"></li>
                    <li data-target="#customCarousel1" data-slide-to="1"></li>
                    <li data-target="#customCarousel1" data-slide-to="2"></li>
                    <li data-target="#customCarousel1" data-slide-to="3"></li>
                </ol>
            </div>

        </section>
        <!-- end slider section -->
    </div>

    <!-- service section -->

    <section class="service_section layout_padding">
        <div class="service_container">
            <div class="container ">
                <div class="heading_container heading_center">
                    <h2>Our <span>Services</span>
                    </h2>
                    <p>
                        Websyncr provides its users a wide range of flexible website management options along with enhancement features.
                    </p>
                </div>


                <div class="row">
                    <div class="col-md-4 ">
                        <div class="box ">
                            <div class="img-box">
                                <img src="images/s1.png" alt="">
                            </div>
                            <div class="detail-box">
                                <h5>Emails
                                </h5>
                                <p>
                                    fact that a reader will be distracted by the readable content of a page when looking at its layout.
                  The
                  point of using
                                </p>
                                <a onclick="scrollToContactSection()">Read More
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 ">
                        <div class="box ">
                            <div class="img-box">
                                <img src="images/s2.png" alt="">
                            </div>
                            <div class="detail-box">
                                <h5>Analytics and Reports
                                </h5>
                                <p>
                                    fact that a reader will be distracted by the readable content of a page when looking at its layout.
                  The
                  point of using
                                </p>
                                <a onclick="scrollToContactSection()">Read More
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 ">
                        <div class="box ">
                            <div class="img-box">
                                <img src="images/s3.png" alt="">
                            </div>
                            <div class="detail-box">
                                <h5>Payment Integration
                                </h5>
                                <p>
                                    fact that a reader will be distracted by the readable content of a page when looking at its layout.
                  The
                  point of using
                                </p>
                                <a onclick="scrollToContactSection()">Read More
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 ">
                        <div class="box ">
                            <div class="img-box">
                                <img src="images/s4.png" alt="">
                            </div>
                            <div class="detail-box">
                                <h5>Data Encryption
                                </h5>
                                <p>
                                    fact that a reader will be distracted by the readable content of a page when looking at its layout.
   The
   point of using
                                </p>
                                <a onclick="scrollToContactSection()">Read More
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 ">
                        <div class="box ">
                            <div class="img-box">
                                <img src="images/s5.png" alt="">
                            </div>
                            <div class="detail-box">
                                <h5>SEO Optimization
                                </h5>
                                <p>
                                    fact that a reader will be distracted by the readable content of a page when looking at its layout.
   The
   point of using
                                </p>
                                <a onclick="scrollToContactSection()">Read More
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 ">
                        <div class="box ">
                            <div class="img-box">
                                <img src="images/s6.png" alt="">
                            </div>
                            <div class="detail-box">
                                <h5>Database Integration
                                </h5>
                                <p>
                                    fact that a reader will be distracted by the readable content of a page when looking at its layout.
   The
   point of using
                                </p>
                                <a onclick="scrollToContactSection()">Read More
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="btn-box">
                    <a href="">View All
                    </a>
                </div>--%>
            </div>
        </div>
    </section>

    <!-- end service section -->

    <!-- info section -->

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
                            <a class="" href="AboustUs.aspx">Why Us
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

    <!-- footer section -->
    <section class="footer_section">
        <div class="container">
            <p>
                &copy; <span id="displayYear"></span>All Rights Reserved By
        <a href="https://websyncr.com/">Websyncr</a>
            </p>
        </div>
    </section>
    <!-- footer section -->

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

</body>

</html>
