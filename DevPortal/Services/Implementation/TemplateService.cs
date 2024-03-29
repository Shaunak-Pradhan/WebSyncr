﻿using DevPortal.DTOs;
using DevPortal.Models;
using DevPortal.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace DevPortal.Services.Implementation
{
    public class TemplateService : ITemplateService
    {
        ISQLService sQLService = new SQLService();
        IUtilityService utilityService = new UtilityService();
        IWriteFileService writeFileService = new WriteFileService();
        IGridViewService gridViewService = new GridViewService();
        IWebHostService webHostService = new WebHostService();
        public static List<Template> GetNames()
        {
            List<Template> Template = new List<Template>();
            Template.Add(new Template { ID = 0, Name = "Select" });
            Template.Add(new Template { ID = 1, Name = "Default Design", HTML = "" });
            Template.Add(new Template { ID = 2, Name = "Design 1", HTML = "" });
            Template.Add(new Template { ID = 3, Name = "Design 2", HTML = "" });
            return Template;
        }
        public void BindTemplate(int TemplateID, string PageName, string DisplayName, string extension)
        {
            Placeholderdto placeholderdto = new Placeholderdto();
            placeholderdto.TemplateName = "Template 1";
            placeholderdto.Title = DisplayName;
            placeholderdto.Heading1 = "Welcome to Websyncr";
            placeholderdto.Heading2 = "SIMPLE WEB PAGE";
            placeholderdto.Heading3 = "SIMPLE WEB PAGE H3";
            placeholderdto.Paragraph1 = "This is Using Simple HTML Code By Websyncr p1";
            placeholderdto.Paragraph2 = "This is Using Simple HTML Code By Websyncr p2";
            placeholderdto.Paragraph3 = "This is Using Simple HTML Code By Websyncr p3";
            placeholderdto.ContactNo = "+971 55885588";
            placeholderdto.WebsiteName = "Websyncr";
            placeholderdto.HTML = "<b> <font face='cinzel' size='4'> <a href ='#'>About Us| <a href ='#'>Contact Us | <a href ='#'> Privacy Policy | <a href ='#'> Terms | <a href ='#'>Media Kit | <a href ='#'> Sitemap | <a href ='#'> Report a Bug | <a href ='#'> FAQ Partners</a><br/> <a href ='#'>C# Tutorials| <a href ='#'> Common Interview Questions| <a href ='#'> Stories | <a href ='#'>Consultants | <a href ='#'> Ideas | <a href ='#'> Certifications </a><br/><br/> <font color='#FF0000'>all@copyrights 2020</font> </font> </b>";
            string[] Template = new string[4];
            Template[0] = "";
            Template[1] = DefaultTemplate(placeholderdto);
            Template[2] = Template1(placeholderdto);
            Template[3] = Template2(placeholderdto);
            writeFileService.WriteIntoPage(PageName, Template[TemplateID]);
        }
        public void SwitchTemplate(string selectedValue, string PID, string TemplateName, GridView gridview)
        {
            sQLService.UpdateTableSQL("Pages", "PID", Int32.Parse(PID), "TemplateID", selectedValue);
            sQLService.UpdateTableSQL("Pages", "PID", Int32.Parse(PID), "TemplateName", TemplateName);
            gridViewService.GridViewForTable("Pages", gridview);
            BindTemplate(Int32.Parse(selectedValue), "Page" + PID, sQLService.GetValueForID("Pages", "DisplayName", "PID", Int32.Parse(PID)).ToString(), ".html");
        }
        public void CustomTemplateHTML(int TemplateID, string filename)
        {
            SqlCommand sqlcmd3 = new SqlCommand("select CustomTemplate from Template where TID = " + TemplateID, sQLService.SqlConnectionObj());
            var IndexObj = sqlcmd3.ExecuteReader();
            if (IndexObj.Read())
            {
                var temp = IndexObj["TemplateHTML"];
                System.IO.File.WriteAllText(webHostService.Directory(filename), temp.ToString());
            }
        }
        private string DefaultTemplate(Placeholderdto data)
        {
            return $@"<!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='utf-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1'>
                        <title>{data.Title}</title>
                        <!-- Include Bootstrap CSS -->
                        <link href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css' rel='stylesheet'>
                        <style>
                            body {{font - family: 'Lato', sans-serif;
                                background-color: #F8F8FF;
                                color: #333;
                                padding-top: 70px; /* Adjust the top padding to accommodate the fixed navbar */
                            }}

                            .navbar {{background - color: #F0B27A;
        
                                }}

                            #heading {{color: #F0B27A;
                            }}

                            #footer {{margin - top: 30px;
                                padding: 20px;
                                background-color: #333;
                                color: #fff;
                            }}
                        </style>
                    </head>
                    <body>
                        <!-- Navigation Bar -->
                        <nav class='navbar navbar-expand-lg navbar-dark fixed-top'>
                            <a class='navbar-brand' href='#'>
                                <img src='CUsers\vijayakumarPictureslogo.jpg' height='50px' width='100px' alt='Logo'>
                            </a>
                            <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarNav' aria-controls='navbarNav' aria-expanded='false' aria-label='Toggle navigation'>
                                <span class='navbar-toggler-icon'></span>
                            </button>
                            <div class='collapse navbar-collapse' id='navbarNav'>
                                <ul class='navbar-nav ml-auto'>
                                    <li class='nav-item'><a class='nav-link' href='#' style='color:black;'>HOME</a></li>
                                    <li class='nav-item'><a class='nav-link' href='#' style='color:black;'>VIDEOS</a></li>
                                    <li class='nav-item'><a class='nav-link' href='#' style='color:black;'>ARTICLES</a></li>
                                    <li class='nav-item'><a class='nav-link' href='#' style='color:black;'>BLOG</a></li>
                                    <li class='nav-item'><a class='nav-link' href='#' style='color:black;'>ABOUT US</a></li>
                                </ul>
                            </div>
                        </nav>

                        <div class='container'>
                            <div class='mt-5'>
                                <h1 class='text-center' id='heading'>{data.WebsiteName}</h1>
                                <h3 class='text-center text-danger'>{data.Paragraph1}</h3>
                            </div>
                            <hr class='mt-5'>
                        </div>

                        <footer class='text-center' id='footer'>
                            {data.HTML}
                        </footer>

                        <!-- Include Bootstrap JS and Popper.js -->
                        <script src='https://code.jquery.com/jquery-3.2.1.slim.min.js'></script>
                        <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js'></script>
                        <script src='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js'></script>
                    </body>
                    </html>
                    ";
        }
        private string Template1(Placeholderdto data)
        {
            return $@"<!DOCTYPE html>
                    <html style='font-size: 16px;' lang='en'>
                       <head>
                          <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                          <meta charset='utf-8'>
                          <meta name='keywords' content='​Wanna workwith us?, Contact Us'>
                          <meta name='description' content=''>
                          <title>{data.Title}</title>
                          <link rel='stylesheet' href='/Resource/{data.TemplateName}/nicepage.css' media='screen'>
                          <link rel='stylesheet' href='/Resource/{data.TemplateName}/Home.css' media='screen'>
                          <script class='u-script' type='text/javascript' src='/Resource/{data.TemplateName}/jquery.js' defer=''></script> <script class='u-script' type='text/javascript' src='/Resource/{data.TemplateName}/nicepage.js' defer=''></script> 
                          <meta name='generator' content='Nicepage 5.12.7, nicepage.com'>
                          <link id='u-theme-google-font' rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i'>
                          <script type='application/ld+json'>{{'@context': 'http://schema.org','@type': 'Organization','name': '','logo': 'images/default-logo.png'}}</script> 
                          <meta name='theme-color' content='#478ac9'>
                          <meta property='og:title' content='Home'>
                          <meta property='og:type' content='website'>
                          <meta data-intl-tel-input-cdn-path='intlTelInput/'>
                       </head>
                       <body data-home-page='Home.html' data-home-page-title='Home' class='u-body u-xl-mode' data-lang='en'>
                          <header class='u-clearfix u-header u-header' id='sec-edb7'>
                             <div class='u-clearfix u-sheet u-valign-middle u-sheet-1'>
                                <a href='https://nicepage.com' class='u-image u-logo u-image-1'> <img src='/Resource/{data.TemplateName}/images/default-logo.png' class='u-logo-image u-logo-image-1'> </a> 
                                <nav class='u-menu u-menu-dropdown u-offcanvas u-menu-1'>
                                   <div class='menu-collapse' style='font-size: 1rem; letter-spacing: 0px;'>
                                      <a class='u-button-style u-custom-left-right-menu-spacing u-custom-padding-bottom u-custom-top-bottom-menu-spacing u-nav-link u-text-active-palette-1-base u-text-hover-palette-2-base' href='#'>
                                         <svg class='u-svg-link' viewBox='0 0 24 24'>
                                            <use xmlns:xlink='http://www.w3.org/1999/xlink' xlink:href='#menu-hamburger'></use>
                                         </svg>
                                         <svg class='u-svg-content' version='1.1' id='menu-hamburger' viewBox='0 0 16 16' x='0px' y='0px' xmlns:xlink='http://www.w3.org/1999/xlink' xmlns='http://www.w3.org/2000/svg'>
                                            <g>
                                               <rect y='1' width='16' height='2'></rect>
                                               <rect y='7' width='16' height='2'></rect>
                                               <rect y='13' width='16' height='2'></rect>
                                            </g>
                                         </svg>
                                      </a>
                                   </div>
                                   <div class='u-nav-container'>
                                      <ul class='u-nav u-unstyled u-nav-1'>
                                         <li class='u-nav-item'><a class='u-button-style u-nav-link u-text-active-palette-1-base u-text-hover-palette-2-base' href='Home.html' style='padding: 10px 20px;'>Home</a></li>
                                         <li class='u-nav-item'><a class='u-button-style u-nav-link u-text-active-palette-1-base u-text-hover-palette-2-base' href='About.html' style='padding: 10px 20px;'>About</a></li>
                                         <li class='u-nav-item'><a class='u-button-style u-nav-link u-text-active-palette-1-base u-text-hover-palette-2-base' href='Contact.html' style='padding: 10px 20px;'>Contact</a></li>
                                      </ul>
                                   </div>
                                   <div class='u-nav-container-collapse'>
                                      <div class='u-black u-container-style u-inner-container-layout u-opacity u-opacity-95 u-sidenav'>
                                         <div class='u-inner-container-layout u-sidenav-overflow'>
                                            <div class='u-menu-close'></div>
                                            <ul class='u-align-center u-nav u-popupmenu-items u-unstyled u-nav-2'>
                                               <li class='u-nav-item'><a class='u-button-style u-nav-link' href='Home.html'>Home</a></li>
                                               <li class='u-nav-item'><a class='u-button-style u-nav-link' href='About.html'>About</a></li>
                                               <li class='u-nav-item'><a class='u-button-style u-nav-link' href='Contact.html'>Contact</a></li>
                                            </ul>
                                         </div>
                                      </div>
                                      <div class='u-black u-menu-overlay u-opacity u-opacity-70'></div>
                                   </div>
                                </nav>
                             </div>
                          </header>
                          <section class='u-align-center u-clearfix u-image u-valign-bottom-xl u-valign-middle-lg u-section-1' id='carousel_855f' data-image-width='1980' data-image-height='1320'>
                             <div class='u-clearfix u-layout-wrap u-layout-wrap-1'>
                                <div class='u-layout'>
                                   <div class='u-layout-row'>
                                      <div class='u-align-left u-container-style u-image u-image-default u-layout-cell u-size-38-lg u-size-41-xl u-size-60-md u-size-60-sm u-size-60-xs u-image-1' data-image-width='1644' data-image-height='1140' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='250'>
                                         <div class='u-container-layout u-container-layout-1'></div>
                                      </div>
                                      <div class='u-align-left u-container-align-center-md u-container-align-center-sm u-container-align-center-xs u-container-align-left-lg u-container-align-left-xl u-container-style u-layout-cell u-size-19-xl u-size-22-lg u-size-60-md u-size-60-sm u-size-60-xs u-layout-cell-2' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='0'>
                                         <div class='u-container-layout u-valign-middle u-container-layout-2'>
                                            <h2 class='u-align-center-md u-align-center-sm u-align-center-xs u-align-left-lg u-align-left-xl u-text u-text-1'> {data.Heading1} </h2>
                                            <p class='u-align-center-md u-align-center-sm u-align-center-xs u-align-left-lg u-align-left-xl u-text u-text-2'> {data.Paragraph1}</p>
                                            <p class='u-align-center-md u-align-center-sm u-align-center-xs u-align-left-lg u-align-left-xl u-text u-text-3'>{data.Paragraph2} </p>
                                            <a href='https://nicepage.com/website-builder' class='u-active-palette-2-base u-align-center-md u-align-center-sm u-align-center-xs u-align-left-lg u-align-left-xl u-black u-border-2 u-border-active-palette-2-base u-border-black u-border-hover-palette-2-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-10 u-text-active-white u-text-hover-white u-btn-2' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='500'>contact Us</a> 
                                         </div>
                                      </div>
                                   </div>
                                </div>
                             </div>
                          </section>
                          <section class='u-black u-clearfix u-section-2' id='carousel_430b'>
                             <div class='u-clearfix u-sheet u-sheet-1'>
                                <div class='u-clearfix u-expanded-width u-layout-wrap u-layout-wrap-1'>
                                   <div class='u-layout'>
                                      <div class='u-layout-row'>
                                         <div class='u-container-align-center-sm u-container-align-center-xs u-container-style u-layout-cell u-size-20-lg u-size-20-xl u-size-26-md u-size-26-sm u-size-26-xs u-white u-layout-cell-1' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='500'>
                                            <div class='u-container-layout u-valign-top-lg u-valign-top-md u-valign-top-sm u-valign-top-xs u-container-layout-1'>
                                               <div class='u-image u-image-circle u-image-1' alt='' data-image-width='626' data-image-height='417' data-animation-name='customAnimationIn' data-animation-duration='1250' data-animation-delay='250'></div>
                                               <span class='u-icon u-icon-circle u-palette-2-base u-text-white u-icon-1'>
                                                  <svg class='u-svg-link' preserveAspectRatio='xMidYMin slice' viewBox='0 0 60 60' style=''>
                                                     <use xmlns:xlink='http://www.w3.org/1999/xlink' xlink:href='#svg-3c31'></use>
                                                  </svg>
                                                  <svg class='u-svg-content' viewBox='0 0 60 60' x='0px' y='0px' id='svg-3c31' style='enable-background:new 0 0 60 60;'>
                                                     <g>
                                                        <path d='M42.595,0H17.405C14.977,0,13,1.977,13,4.405v51.189C13,58.023,14.977,60,17.405,60h25.189C45.023,60,47,58.023,47,55.595V4.405C47,1.977,45.023,0,42.595,0z M15,8h30v38H15V8z M17.405,2h25.189C43.921,2,45,3.079,45,4.405V6H15V4.405C15,3.079,16.079,2,17.405,2z M42.595,58H17.405C16.079,58,15,56.921,15,55.595V48h30v7.595C45,56.921,43.921,58,42.595,58z'></path>
                                                        <path d='M30,49c-2.206,0-4,1.794-4,4s1.794,4,4,4s4-1.794,4-4S32.206,49,30,49z M30,55c-1.103,0-2-0.897-2-2s0.897-2,2-2s2,0.897,2,2S31.103,55,30,55z'></path>
                                                        <path d='M26,5h4c0.553,0,1-0.447,1-1s-0.447-1-1-1h-4c-0.553,0-1,0.447-1,1S25.447,5,26,5z'></path>
                                                        <path d='M33,5h1c0.553,0,1-0.447,1-1s-0.447-1-1-1h-1c-0.553,0-1,0.447-1,1S32.447,5,33,5z'></path>
                                                        <path d='M56.612,4.569c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414c3.736,3.736,3.736,9.815,0,13.552c-0.391,0.391-0.391,1.023,0,1.414c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293C61.128,16.434,61.128,9.085,56.612,4.569z'></path>
                                                        <path d='M52.401,6.845c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414c1.237,1.237,1.918,2.885,1.918,4.639s-0.681,3.401-1.918,4.638c-0.391,0.391-0.391,1.023,0,1.414c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293c1.615-1.614,2.504-3.764,2.504-6.052S54.017,8.459,52.401,6.845z'></path>
                                                        <path d='M4.802,5.983c0.391-0.391,0.391-1.023,0-1.414s-1.023-0.391-1.414,0c-4.516,4.516-4.516,11.864,0,16.38c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293c0.391-0.391,0.391-1.023,0-1.414C1.065,15.799,1.065,9.72,4.802,5.983z'></path>
                                                        <path d='M9.013,6.569c-0.391-0.391-1.023-0.391-1.414,0c-1.615,1.614-2.504,3.764-2.504,6.052s0.889,4.438,2.504,6.053c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293c0.391-0.391,0.391-1.023,0-1.414c-1.237-1.237-1.918-2.885-1.918-4.639S7.775,9.22,9.013,7.983C9.403,7.593,9.403,6.96,9.013,6.569z'></path>
                                                     </g>
                                                  </svg>
                                               </span>
                                            </div>
                                         </div>
                                         <div class='u-container-align-left-xs u-container-style u-layout-cell u-size-34-md u-size-34-sm u-size-34-xs u-size-40-lg u-size-40-xl u-white u-layout-cell-2' data-animation-name='customAnimationIn' data-animation-duration='1500'>
                                            <div class='u-container-layout u-valign-bottom-xs u-valign-middle-lg u-valign-middle-md u-valign-middle-sm u-valign-middle-xl u-container-layout-2'>
                                               <h5 class='u-align-left-xs u-text u-text-default u-text-1'> {data.Heading2}</h5>
                                               <p class='u-text u-text-default u-text-2'>{data.Paragraph3} </p>
                                               <a href='https://nicepage.online' class='u-active-none u-align-left-xs u-btn u-button-style u-hover-none u-none u-text-active-palette-2-base u-text-hover-palette-2-base u-btn-2' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='500'>
                                                  <span class='u-icon u-text-palette-2-base'>
                                                     <svg class='u-svg-content' viewBox='0 0 405.333 405.333' x='0px' y='0px' style='width: 1em; height: 1em;'>
                                                        <path d='M373.333,266.88c-25.003,0-49.493-3.904-72.704-11.563c-11.328-3.904-24.192-0.896-31.637,6.699l-46.016,34.752 c-52.8-28.181-86.592-61.952-114.389-114.368l33.813-44.928c8.512-8.512,11.563-20.971,7.915-32.64 C142.592,81.472,138.667,56.96,138.667,32c0-17.643-14.357-32-32-32H32C14.357,0,0,14.357,0,32 c0,205.845,167.488,373.333,373.333,373.333c17.643,0,32-14.357,32-32V298.88C405.333,281.237,390.976,266.88,373.333,266.88z'></path>
                                                     </svg>
                                                  </span>
                                                  &nbsp;{data.ContactNo}
                                               </a>
                                            </div>
                                         </div>
                                      </div>
                                   </div>
                                </div>
                             </div>
                          </section>
                          <section class='u-align-center u-black u-clearfix u-valign-bottom-xl u-section-3' id='carousel_4c15'>
                             <h2 class='u-text u-text-default u-text-1' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='500'>{data.Heading3}</h2>
                             <p class='u-text u-text-2' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='500'>{data.Paragraph4} </p>
                             <div class='u-expanded-width u-list u-list-1'>
                                <div class='u-repeater u-repeater-1'>
                                   <div class='u-align-center u-black u-container-style u-list-item u-repeater-item u-list-item-1' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='750'>
                                      <div class='u-container-layout u-similar-container u-valign-top u-container-layout-1'>
                                         <span class='u-file-icon u-icon u-text-palette-2-base u-icon-1' data-animation-name='' data-animation-duration='0' data-animation-delay='0' data-animation-direction=''><img src='/Resource/{data.TemplateName}/images/483947-b70949e6.png' alt=''></span> 
                                         <h5 class='u-text u-text-3'>Call today</h5>
                                         <p class='u-text u-text-4'> <a class='u-active-none u-border-2 u-border-active-palette-2-base u-border-hover-palette-2-base u-border-no-left u-border-no-right u-border-no-top u-border-white u-btn u-button-link u-button-style u-hover-none u-none u-text-active-palette-2-base u-text-body-alt-color u-text-hover-palette-2-base u-btn-2' href='tel:+12345678910' data-animation-name='' data-animation-duration='0' data-animation-delay='0' data-animation-direction=''>+1 (234) 567-8910</a> </p>
                                      </div>
                                   </div>
                                   <div class='u-align-center u-black u-container-style u-list-item u-repeater-item u-list-item-2' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='750'>
                                      <div class='u-container-layout u-similar-container u-valign-top u-container-layout-2'>
                                         <span class='u-file-icon u-icon u-text-palette-2-base u-icon-2' data-animation-name='' data-animation-duration='0' data-animation-delay='0' data-animation-direction=''><img src='/Resource/{data.TemplateName}/images/450016-b576cfae.png' alt=''></span> 
                                         <h5 class='u-text u-text-5'>Address</h5>
                                         <p class='u-text u-text-6'> Alexandria, 32 Washingtorn str, 22303</p>
                                      </div>
                                   </div>
                                   <div class='u-align-center u-black u-container-style u-list-item u-repeater-item u-list-item-3' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='750'>
                                      <div class='u-container-layout u-similar-container u-valign-top u-container-layout-3'>
                                         <span class='u-file-icon u-icon u-text-palette-2-base u-icon-3'><img src='/Resource/{data.TemplateName}/images/2099199-d9cef023.png' alt=''></span> 
                                         <h5 class='u-text u-text-7'>Email Us</h5>
                                         <p class='u-text u-text-8'> <a class='u-active-none u-border-2 u-border-active-palette-2-base u-border-hover-palette-2-base u-border-no-left u-border-no-right u-border-no-top u-border-white u-btn u-button-link u-button-style u-hover-none u-none u-text-active-palette-2-base u-text-body-alt-color u-text-hover-palette-2-base u-btn-3' href='mailto:info@sample.com' data-animation-name='' data-animation-duration='0' data-animation-delay='0' data-animation-direction=''> info@sample.com</a> </p>
                                      </div>
                                   </div>
                                   <div class='u-align-center u-black u-container-style u-list-item u-repeater-item u-list-item-4' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='750'>
                                      <div class='u-container-layout u-similar-container u-valign-top u-container-layout-4'>
                                         <span class='u-file-icon u-icon u-text-palette-2-base u-icon-4' data-animation-name='' data-animation-duration='0' data-animation-delay='0' data-animation-direction=''><img src='/Resource/{data.TemplateName}/images/2794624-8ee42f0f.png' alt=''></span> 
                                         <h5 class='u-text u-text-9'> Opening hours<br> </h5>
                                         <p class='u-text u-text-10'> Mon — Fri 10:00 – 23:00<br>Sut-Sun- 10:00 – 19:00 </p>
                                      </div>
                                   </div>
                                </div>
                             </div>
                             <img class='u-expanded-width u-image u-image-default u-image-1' src='/Resource/{data.TemplateName}/images/ss.jpg' alt='' data-image-width='1666' data-image-height='1080' data-animation-name='customAnimationIn' data-animation-duration='1500' data-animation-delay='750'> 
                          </section>
                          <footer class='u-align-center u-clearfix u-footer u-grey-80 u-footer' id='sec-c18f'>
                             <div class='u-clearfix u-sheet u-sheet-1'>
                                <p class='u-small-text u-text u-text-variant u-text-1'>Sample text. Click to select the Text Element.</p>
                             </div>
                          </footer>
                          <section class='u-backlink u-clearfix u-grey-80'>
                             <a class='u-link' href='https://nicepage.com/website-templates' target='_blank'> <span>Website Templates</span> </a> 
                             <p class='u-text'> <span>created with</span> </p>
                             <a class='u-link' href='' target='_blank'> <span>Website Builder Software</span> </a>. 
                          </section>
                       </body>
                    </html>";
        }
        private string Template2(Placeholderdto data)
        {
            return $@"<!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <meta charset='utf-8'>
                        <meta name='keywords' content='Wanna work with us?, Contact Us'>
                        <meta name='description' content=''>
                        <title>{data.Title}</title>
                        <link rel='stylesheet' href='/Resource/{data.TemplateName}/style.css' media='screen'>
                        <script type='text/javascript' src='/Resource/{data.TemplateName}/script.js' defer=''></script>
                        <meta name='generator' content='Your Website Generator'>
                        <link id='u-theme-google-font' rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i'>
                        <script type='application/ld+json'>{{'@context': 'http://schema.org','@type': 'Organization','name': '','logo': 'images/default-logo.png'}}</script>
                        <meta name='theme-color' content='#478ac9'>
                        <meta property='og:title' content='Home'>
                        <meta property='og:type' content='website'>
                        <meta data-intl-tel-input-cdn-path='intlTelInput/'>
                    <style>/* Reset some default styles */
                    body, h1, h2, h3, p, ul, li {{
                        margin: 0;
                        padding: 0;
                    }}

                    body {{
                        font-family: 'Roboto', sans-serif;
                        font-size: 16px;
                        line-height: 1.6;
                    }}

                    /* Header Styles */
                    header {{
                        background-color: #478ac9;
                        color: #fff;
                        padding: 20px;
                        text-align: center;
                    }}

                    /* Main Content Section Styles */
                    .u-section-1, .u-section-2 {{
                        padding: 40px 0;
                        text-align: center;
                    }}

                    .u-section-2 {{
                        background-color: #000;
                        color: #fff;
                    }}

                    /* Footer Styles */
                    .u-footer {{
                        background-color: #333;
                        color: #fff;
                        padding: 20px;
                        text-align: center;
                    }}

                    /* Backlink Styles */
                    .u-backlink {{
                        background-color: #333;
                        color: #fff;
                        text-align: center;
                        padding: 10px;
                    }}

                    /* Navigation Styles */
                    .u-menu {{
                        background-color: #478ac9;
                    }}

                    .u-nav-link {{
                        color: #fff !important;
                    }}

                    /* Link Styles */
                    a {{
                        color: #478ac9;
                        text-decoration: none;
                    }}

                    a:hover {{
                        text-decoration: underline;
                    }}
                    </style>
                    </head>
                    <body data-home-page='Home.html' data-home-page-title='Home' class='u-body u-xl-mode' data-lang='en'>
                        <!-- Header Section -->
                        <header class='u-clearfix u-header u-header' id='sec-edb7'>
                            <!-- Your header content here -->
                            <h1>{data.Heading1}</h1>
                            <p>{data.Paragraph1}</p>
                        </header>

                        <!-- About Section -->
                        <section class='u-align-center u-clearfix u-section-1' id='about'>
                            <h2>{data.Heading2}</h2>
                            <p>{data.Paragraph2}</p>
                            <!-- Add more about section content as needed -->
                        </section>

                        <!-- Contact Section -->
                        <section class='u-black u-clearfix u-section-2' id='contact'>
                            <h2>{data.Heading3}</h2>
                            <p>{data.Paragraph3}</p>
                            <!-- Add contact form or details as needed -->
                        </section>

                        <!-- Additional Sections (customize as needed) -->
                        <!-- ...

                        <!-- Footer Section -->
                        <footer class='u-align-center u-clearfix u-footer u-grey-80 u-footer' id='sec-c18f'>
                            <div class='u-clearfix u-sheet u-sheet-1'>
                                <p class='u-small-text u-text u-text-variant u-text-1'>Sample text. Click to select the Text Element.</p>
                            </div>
                        </footer>

                        <!-- Backlink Section -->
                        <section class='u-backlink u-clearfix u-grey-80'>
                            <a class='u-link' href='https://nicepage.com/website-templates' target='_blank'>
                                <span>Website Templates</span>
                            </a>
                            <p class='u-text'>
                                <span>created with</span>
                            </p>
                            <a class='u-link' href='' target='_blank'>
                                <span>Website Builder Software</span>
        </a>
    </section>
</body>
</html>
";
        }
    }
}