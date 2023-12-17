using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DevPortal.Services.Interface;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace DevPortal.Services.Implementation
{
    public class FeaturesService : IFeaturesService
    {
        public void URLRewrite(string URL, string NewURL)
        {
            string originalUrl = HttpContext.Current.Request.Url.ToString();
            if (originalUrl.Contains(URL))
            {
                string newUrl = originalUrl.Replace(URL, NewURL);
            }
        }
        //public async Task<string> GetPaymentURL()
        //{
        //    try
        //    {
        //        StreamReader reader = new StreamReader(HttpContext.Request.Body);
        //        string JsonData = reader.ReadToEnd();
        //        dynamic PaymentID = JsonConvert.DeserializeObject(JsonData);
        //        decimal amount = 0;
        //        DPDataReader DPay = da.ExecuteDPReader("Select * from DPEPaymentRequests where RequestID =" + PaymentID);
        //        if (DPay != null && DPay.Read())
        //        {
        //            double TotalAmount = DPay["TotalAmount"] * 100;
        //            amount = decimal.Parse(TotalAmount.ToString());
        //        }
        //        else { }
        //        string access_token = GenerateAccessToken();
        //        using (HttpClient clientCreateOrder = new HttpClient())
        //        {
        //            string NetworkAuthorization = DCXPlatform.DCXPortal.GetSystemProperty("NetworkAuthorization", "MTE0OGQ5OTAtN2M5OC00Njc2LWIxZjMtZGU5OWQyMWExYjc1OjZkZjYxYWZlLTM5NDQtNGI0ZS04NmY4LTNjYWZkN2UzNWUxNg==");
        //            string outletRef = DCXPlatform.DCXPortal.GetSystemProperty("NetworkOutletRef", "2a01170a-9b29-4a65-9868-3cc36848cef1");
        //            string NetworkTokenInfoURL = DCXPlatform.DCXPortal.GetSystemProperty("NetworkTokenInfoURL", "https://api-gateway.sandbox.ngenius-payments.com/identity/auth/access-token");
        //            string NetworkOrderURL = DCXPlatform.DCXPortal.GetSystemProperty("NetworkOrderURL", "https://api-gateway.sandbox.ngenius-payments.com/transactions/outlets/2a01170a-9b29-4a65-9868-3cc36848cef1/orders");
        //            string NetworkRedirectURL = DCXPlatform.DCXPortal.GetSystemProperty("NetworkRedirectURL", "");
        //            string NetworkCancelURL = DCXPlatform.DCXPortal.GetSystemProperty("NetworkCancelURL", "");
        //            string WebSitePath = "https://localhost:44312/portal/page/555";//DCXPlatform.DCXPortal.GetSystemProperty("WebSitePath", "");
        //            string DirectPayReturnURL = "API/V1/HExpress/PaymentStatus";//DCXPlatform.DCXPortal.GetSystemProperty("DirectPayReturnURL", "");
        //            Random rdn = new Random();
        //            Guid merchantOrderReference = Guid.NewGuid(); //rdn.Next().ToString();
        //            string return_url = string.Format("{0}{1}?Orderid={2}", WebSitePath, DirectPayReturnURL, merchantOrderReference);
        //            DPDataReader DPayment = da.ExecuteDPReader("select * from DPEPaymentRequests where RequestID=" + PaymentID);
        //            decimal RelatedRecordID = 0;
        //            if (DPayment.Read())
        //            {
        //                RelatedRecordID = DPayment["RelatedRecordID"];
        //            }
        //            DPDataReader BookingInfo = da.ExecuteDPReader("select * from HEBooking where Id=" + RelatedRecordID);
        //            if (BookingInfo.Read())
        //            {
        //                string UserFullName = BookingInfo["BookUserName"];
        //                string[] nameParts = UserFullName.Split(' ');
        //                string UserEmailAddress = BookingInfo["BookEmail"];
        //                string UserFirstName = nameParts.Length > 0 ? nameParts[0] : "";
        //                string UserLastName = nameParts.Length > 1 ? nameParts[1] : "";
        //                string UserAddress = "UAE";
        //                string UserCity = "Dubai";
        //                string UserCountryCode = "0000";
        //                string strRedirectURL = return_url;
        //                string strCancelURL = return_url;
        //                string PostInfoStatus = PostPaymentInfo(merchantOrderReference, PaymentID.ToString(), UserEmailAddress);
        //                string OrderData =
        //                    "{  " +
        //                    "\"action\": \"SALE\", " +
        //                    "\"merchantOrderReference\": \"" + merchantOrderReference + "\", " +
        //                    "\"emailAddress\": \"" + UserEmailAddress + "\", " +
        //                    "\"language\": \"en\", " +
        //                    "\"amount\" : { \"currencyCode\" : \"AED\", \"value\" : " + ((int)amount).ToString() + " } , " +
        //                    "\"billingAddress\" : { \"firstName\" : \"" + UserFirstName +
        //                    "\", \"lastName\" : \"" + UserLastName +
        //                    "\", \"address1\": \"" + UserAddress +
        //                    "\", \"city\":\"" + UserCity +
        //                    "\", \"countryCode\":\"" + UserCountryCode + "\" } , " +
        //                    "\"shippingAddress\" : { \"firstName\" : \"" + UserFirstName +
        //                    "\", \"lastName\" : \"" + UserLastName + "\", \"address1\": \"" +
        //                    UserAddress + "\", \"city\":\"" +
        //                    UserCity + "\", \"countryCode\":\"" +
        //                    UserCountryCode + "\" } , " +
        //                    "\"merchantAttributes\" : { \"redirectUrl\": \"" + strRedirectURL +
        //                    "\", \"skipConfirmationPage\":true , \"skip3DS\":false, \"cancelUrl\":\"" + strCancelURL + "\"} " + "}";
        //                clientCreateOrder.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
        //                var httpContent = new StringContent(OrderData, Encoding.UTF8, "application/vnd.ni-payment.v2+json");
        //                clientCreateOrder.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaton/vnd.ni-payment.v2+json"));
        //                using (var responseCreateOrder = await clientCreateOrder.PostAsync(DCXPlatform.DCXPortal.GetSystemProperty("NetworkOrderURL", "https://api-gateway.sandbox.ngenius-payments.com/transactions/outlets/2a01170a-9b29-4a65-9868-3cc36848cef1/orders"), httpContent))
        //                {
        //                    if (responseCreateOrder.IsSuccessStatusCode)
        //                    {
        //                        var dataValue_order = JObject.Parse(await responseCreateOrder.Content.ReadAsStringAsync());
        //                        var order_URL = dataValue_order["_links"]["payment"]["href"].ToString();
        //                        return order_URL;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return "";
        //}
        public string PostPaymentInfo(Guid OrderReference, string RequestID, string Email)
        {
            //Perform DB Operation
            return "Success";
        }
        public string GetPaymentStatus(string Orderid, string refno)
        {
            string OnLoadScript = "";
            string PaymentOrderReference = HttpContext.Current.Request.QueryString["Orderid"];
            string ReturnRefId = HttpContext.Current.Request.QueryString["refno"];
            string Result = "Unknown";
            if (PaymentOrderReference == "")
                return ("");
            string NIApiTokenInfoUrl = ("NetworkTokenInfoURL");
            string DPayment = ("Select * from DPEPaymentRequests where TransactionRecords LIKE '%" + PaymentOrderReference + "%'");
            decimal AEDAmount = 0;
            //if (DPayment.Read())
            //    AEDAmount = Convert.ToInt64(DPayment["TotalAmount"]);
            //else
            //    return ("");
            using (HttpClient OrderhttpClient = new HttpClient())
            {
                string access_Token = GenerateAccessToken();
                OrderhttpClient.DefaultRequestHeaders.Accept.Clear();
                OrderhttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_Token);
                string NetworkOrderStatusURLPrefix = "NetworkOrderStatusURLPrefix";
                NetworkOrderStatusURLPrefix = NetworkOrderStatusURLPrefix + ReturnRefId;
                var resposneOrder = OrderhttpClient.GetAsync(NetworkOrderStatusURLPrefix).Result;
                var content = resposneOrder.Content.ReadAsStringAsync().Result;
                if (resposneOrder.IsSuccessStatusCode)
                {
                    var dataValue = JsonConvert.DeserializeObject<dynamic>(content);
                    var paymentArray = dataValue._embedded.payment;
                    if (paymentArray != null && paymentArray.Count > 0)
                    {
                        var payment = paymentArray[0];
                        var responseMessage = (string)payment.state;
                        if (responseMessage == "CAPTURED")
                        {
                            string DPay = "";//get the PaymentOrderReference to cross check in the DB
                                             //if (DPay)
                                             //{
                                             //Save to DB
                            return ("SUCCESS");
                            //}
                        }
                        else
                        {
                            return ("FAILED");
                        }
                    }
                }
            }
            return ("FAILED");
        }
        public string GenerateAccessToken()
        {
            try
            {
                string access_token = "";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {("NetworkAuthorization")}");
                    var resposneAccesstoken = client.PostAsync(("NetworkTokenInfoURL"), null).GetAwaiter().GetResult();
                    var content = resposneAccesstoken.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var dataValue = JObject.Parse(resposneAccesstoken.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    access_token = dataValue.SelectToken("access_token").ToString();
                    return access_token;
                }
            }
            catch (Exception ex)
            {
            }
            return "";
        }
        public const string Host = "pro.turbo-smtp.com";
        public const int SMTPPort = 2525;
        public const string SMTPUser = "noreply@dubaisc.ae";
        public const string SMTPPassword = "M@1lrelay@123";
        public const bool SMTPEnableSSL = false;
        public const bool UseDefaultCredentials = false;
        public const string FromName = "Dubai Sports Council";
        public const string FromEmail = "noreply@dubaisc.gov.ae";
        public async Task<string> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            try
            {
                var client = new SmtpClient(Host, SMTPPort);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(SMTPUser, SMTPPassword);
                client.EnableSsl = true;
                var message = new MailMessage
                {
                    From = new MailAddress(FromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                message.To.Add(new MailAddress(recipientEmail));
                await client.SendMailAsync(message);
                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                return $"Error sending email: {ex.Message}";
            }
        }
        public async Task SendEmailAsync(
            string subject,
            string body,
            List<string> recipientEmails,
            List<string> ccEmails,
            List<string> bccEmails
        )
        {
            try
            {
                var client = new SmtpClient(Host, SMTPPort);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(SMTPUser, SMTPPassword);
                client.EnableSsl = true;
                var message = new MailMessage
                {
                    From = new MailAddress(FromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                foreach (var recipientEmail in recipientEmails)
                {
                    message.To.Add(new MailAddress(recipientEmail));
                }
                if (ccEmails != null)
                {
                    foreach (var ccEmail in ccEmails)
                    {
                        message.CC.Add(new MailAddress(ccEmail));
                    }
                }
                if (bccEmails != null)
                {
                    foreach (var bccEmail in bccEmails)
                    {
                        message.Bcc.Add(new MailAddress(bccEmail));
                    }
                }
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
        static void ConfigureUrlRewriteRule(string siteName, string matchUrl, string rewriteUrl)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetWebConfiguration(siteName);
                ConfigurationSection rewriteSection = config.GetSection("system.webServer/rewrite");
                ConfigurationElementCollection rulesCollection = rewriteSection.GetCollection("rules");
                ConfigurationElement ruleElement = rulesCollection.CreateElement("rule");
                ruleElement["name"] = "RewriteRule";
                ruleElement["stopProcessing"] = true;
                ConfigurationElement matchElement = ruleElement.GetChildElement("match");
                matchElement["url"] = matchUrl;
                ConfigurationElement actionElement = ruleElement.GetChildElement("action");
                actionElement["type"] = "Rewrite";
                actionElement["url"] = rewriteUrl;
                rulesCollection.Add(ruleElement);
                serverManager.CommitChanges();
            }
        }
    }
}
