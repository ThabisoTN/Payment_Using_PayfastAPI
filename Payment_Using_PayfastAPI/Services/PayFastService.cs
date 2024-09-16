using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Payment_Using_PayfastAPI.Services
{
    public class PayFastService
    {
        private readonly string _merchantId = "10035175"; 
        private readonly string _merchantKey = "x7tvzzvr33paf";  
        private readonly string _returnUrl = "https://www.yoursite.com/return";  // Replace with your actual return URL
        private readonly string _cancelUrl = "https://www.yoursite.com/cancel";  // Replace with your actual cancel URL
        private readonly string _notifyUrl = "https://www.yoursite.com/notify";  // Replace with your actual notify URL

        public string CreatePaymentUrl(decimal amount, string itemName, string itemDescription)
        {
            // Sandbox URL
            var baseUrl = "https://sandbox.payfast.co.za/eng/process?";  
            var data = new Dictionary<string, string>
        {
            {"merchant_id", _merchantId},
            {"merchant_key", _merchantKey},
            {"return_url", _returnUrl},
            {"cancel_url", _cancelUrl},
            {"notify_url", _notifyUrl},
            {"amount", amount.ToString("F2")},
            {"item_name", itemName},
            {"item_description", itemDescription}
        };

            var queryString = string.Join("&", data.Select(d => $"{d.Key}={WebUtility.UrlEncode(d.Value)}"));
            return $"{baseUrl}{queryString}";
        }
    }

}
