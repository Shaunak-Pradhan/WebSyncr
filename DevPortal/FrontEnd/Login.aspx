<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DevPortal.FrontEnd.Login" %>

<!DOCTYPE html>
<html>
<head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans:wght@200;300;400;500;600;700&display=swap" rel="stylesheet">

    <title>Login Page</title>


    <style>
        
        * {
          margin: 0;
          padding: 0;
          box-sizing: border-box;
        }
        .login-container {
          font-family: "system-ui";
          font-size: 20px;
          width: 164vw;
          height: 100vh;
          display: flex;
          justify-content: center;
          align-items: center;          
        }
        .login-container form {
          width: 360px;
          height: auto;
          background-color: rgb(255, 255, 255);
          border-radius: 10px;
        }
        .form-container {
          margin: 20px 20px;
            background: #0000001f;
  padding: 20px;
  box-shadow: -1px 2px 3px 2px #0000003b;
  border-radius: 15px;
        }
        .mb {
          margin-bottom: 30px;
        }
        .form-sections {
          display: flex;
          flex-direction: column;
          gap: 10px;
        }
        .heading-container {
          display: flex;
          align-items: center;
          justify-content: center;
        }
        .heading {
          font-size: 1.5rem;
          color:white;
          /*text-transform: uppercase;*/
          font-weight:100;
        }
        .form-fields {
          display: flex;
          flex-direction: column;
          gap: 10px;
          padding: 5px 10px;
          color:white;
        }
        label {
          font-size: 20px;
          font-weight:100;
        }
        .form-fields input {
          height: 40px;
          width: 100%;
          font-size: 20px;
          outline: none;
          border-radius: 5px;
          padding: 5px;
          border: 1px solid rgb(122, 115, 115);
            font-family: system-ui;

        }
        .form-fields input:hover,
        input:focus {
          border: 1px solid rgb(137, 5, 170);
        }

        #pass-field-container {
          position: relative;
        }
        #pass {
          padding-right: 35px;
        }
        input[type="checkbox"] {
          position: absolute;
          right: 10px;
          top: 13px;
          accent-color: rgb(204, 0, 255);
          height: 15px;
          width: 15px;
          padding: 5px;
          cursor: pointer;
        }
        .form-fields input[type="submit"] {
          height: 40px;
          font-size: 1rem;
          background-color: #1c92a2e0;
          outline: none;
          border: none;
          color: white;
          font-weight: 100;
          cursor: pointer;
        }
        .forgot-password{
            text-align:center;
        }
        .forgot-password a {
          color: rgb(255, 255, 255);
          font-weight: 100;
          text-decoration-line: none;
          font-size: medium;
          
        }
                 body {
    background-image: url('/portalresource/images/bgpic.jpg');
    background-size: cover;
    background-repeat: no-repeat;
    background-attachment: fixed;
    overflow-x:hidden;
    /* Other styles as needed */
}
                 #errorMessage{
                     font-family:unset;
                     font-weight: 100;
                    text-decoration-line: none;
                    font-size: medium;
                    color:white;
                    text-align:center;
                 }


    </style>
     <script>
         // JavaScript code to update the error message
         function updateErrorMessage(message) {
             var errorMessageElement = document.getElementById('errorMessage');
             errorMessageElement.textContent = message;
         }
     </script>

</head>
<body>
    <form id="formLogin" runat="server">
        <div>
           
            
 


            <div class="login-container">

    <div class="form-container">
      <div class="form-sections mb">
        <div class="heading-container">
          <h1 class="heading">Welcome Back!</h1>
        </div>
      </div>
      <div class="form-sections">
        <div class="form-fields">
          <label for="email">Email</label>
          <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field"></asp:TextBox>
        </div>
        <div class="form-fields">
          <label for="pass">Password</label>
          <div id="pass-field-container">

             <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password"></asp:TextBox>
            <input type="checkbox" id="see" class="input-field" title="Click to view password" tabindex="3" />
          </div>
        </div>
          <div id="errorMessage"></div>
        <div class="form-fields">
          <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-btn" OnClick="btnLogin_Click" AutoPostBack="false"/>
        </div>
      </div>
      <div class="form-sections">
        <div class="forgot-password"><a href="#">Forgot Password?</a> <a href="#">Register</a></div>
        
      </div>
    </div>

</div>

        </div>
    </form>
   
</body>
</html>

