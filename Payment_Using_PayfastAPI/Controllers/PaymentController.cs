using Microsoft.AspNetCore.Mvc;
using Payment_Using_PayfastAPI.Services;  // Add this using statement

namespace Payment_Using_PayfastAPI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PayFastService _payFastService;

        public PaymentController(PayFastService payFastService)
        {
            _payFastService = payFastService;
        }

        public IActionResult Index()
        {
            decimal amount = 500;  // Example amount
            string itemName = "Test Item";
            string itemDescription = "Payment for Test Item";

            // Generate the PayFast payment URL
            string paymentUrl = _payFastService.CreatePaymentUrl(amount, itemName, itemDescription);
            ViewBag.PaymentUrl = paymentUrl;

            return View();
        }
    }
}
