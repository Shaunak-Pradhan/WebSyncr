using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevPortal.Models
{
    public class PaymentJson
    {
        public class Rootobject
        {
            public string _id { get; set; }
            public _Links _links { get; set; }
            public string type { get; set; }
            public Merchantdefineddata merchantDefinedData { get; set; }
            public string action { get; set; }
            public Amount amount { get; set; }
            public string language { get; set; }
            public Merchantattributes merchantAttributes { get; set; }
            public string emailAddress { get; set; }
            public string reference { get; set; }
            public string outletId { get; set; }
            public DateTime createDateTime { get; set; }
            public Paymentmethods paymentMethods { get; set; }
            public Billingaddress billingAddress { get; set; }
            public Shippingaddress shippingAddress { get; set; }
            public string referrer { get; set; }
            public string formattedAmount { get; set; }
            public Formattedordersummary formattedOrderSummary { get; set; }
            public _Embedded _embedded { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
            public TenantBrand tenantbrand { get; set; }
            public MerchantBrand merchantbrand { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class TenantBrand
        {
            public string href { get; set; }
        }

        public class MerchantBrand
        {
            public string href { get; set; }
        }

        public class Merchantdefineddata
        {
        }

        public class Amount
        {
            public string currencyCode { get; set; }
            public int value { get; set; }
        }

        public class Merchantattributes
        {
            public string cancelUrl { get; set; }
            public string redirectUrl { get; set; }
            public string skipConfirmationPage { get; set; }
            public string skip3DS { get; set; }
        }

        public class Paymentmethods
        {
            public string[] card { get; set; }
        }

        public class Billingaddress
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string address1 { get; set; }
            public string city { get; set; }
            public string countryCode { get; set; }
        }

        public class Shippingaddress
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string address1 { get; set; }
            public string city { get; set; }
            public string countryCode { get; set; }
        }

        public class Formattedordersummary
        {
        }

        public class _Embedded
        {
            public Payment[] payment { get; set; }
        }

        public class Payment
        {
            public string _id { get; set; }
            public _Links1 _links { get; set; }
            public Paymentmethod paymentMethod { get; set; }
            public string state { get; set; }
            public Amount1 amount { get; set; }
            public DateTime updateDateTime { get; set; }
            public string outletId { get; set; }
            public string orderReference { get; set; }
            public Authresponse authResponse { get; set; }
            public _3Ds _3ds { get; set; }
            public _Embedded1 _embedded { get; set; }
        }

        public class _Links1
        {
            public Self1 self { get; set; }
            public Cury[] curies { get; set; }
        }

        public class Self1
        {
            public string href { get; set; }
        }

        public class Cury
        {
            public string name { get; set; }
            public string href { get; set; }
            public bool templated { get; set; }
        }

        public class Paymentmethod
        {
            public string expiry { get; set; }
            public string cardholderName { get; set; }
            public string name { get; set; }
            public string pan { get; set; }
        }

        public class Amount1
        {
            public string currencyCode { get; set; }
            public int value { get; set; }
        }

        public class Authresponse
        {
            public string authorizationCode { get; set; }
            public bool success { get; set; }
            public string resultCode { get; set; }
            public string resultMessage { get; set; }
            public string mid { get; set; }
            public string rrn { get; set; }
        }

        public class _3Ds
        {
            public string status { get; set; }
            public string eci { get; set; }
            public string eciDescription { get; set; }
        }

        public class _Embedded1
        {
            public CnpCapture[] cnpcapture { get; set; }
        }

        public class CnpCapture
        {
            public _Links2 _links { get; set; }
            public Amount2 amount { get; set; }
            public DateTime createdTime { get; set; }
            public string state { get; set; }
        }

        public class _Links2
        {
            public CnpRefund cnprefund { get; set; }
        }

        public class CnpRefund
        {
            public string href { get; set; }
        }

        public class Amount2
        {
            public string currencyCode { get; set; }
            public int value { get; set; }
        }

    }

}