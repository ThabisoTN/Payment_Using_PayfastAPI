using Microsoft.AspNetCore.Mvc;
using Payment_Using_PayfastAPI.Services;

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

            // Generating the PayFast payment URL
            string paymentUrl = _payFastService.CreatePaymentUrl(amount, itemName, itemDescription);
            ViewBag.PaymentUrl = paymentUrl;

            return View();
        }
    }
}
