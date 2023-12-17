<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMS.aspx.cs" Inherits="DevPortal.FrontEnd.CMS1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/PortalResource/css/Main.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha384-GLhlTQ8iUNnJTmPVVy0M6FnxJ2Nl/bi0zwn1RnbcvNUw5J46E6K/iT5n5FsaUCG2" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha512-...." crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
