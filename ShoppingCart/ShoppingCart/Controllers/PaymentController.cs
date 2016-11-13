using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class PaymentController : Controller
    {

        // GET: Payment
        public ActionResult Index()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            // A transaction defines the contract of a payment - what is the payment for and who is fulfilling it. 

            CreditCard credtCard = new CreditCard();
            credtCard.type = "visa";
            credtCard.number = "4446283280247004";
            credtCard.expire_month = 11;
            credtCard.expire_year = 2018;
            credtCard.first_name = "Joe";
            credtCard.last_name = "Shopper";

            FundingInstrument fundInstrument = new FundingInstrument();
            fundInstrument.credit_card = credtCard;

            List<FundingInstrument> fundingInstrumentList = new List<FundingInstrument>();
            fundingInstrumentList.Add(fundInstrument);

            Payer payr = new Payer();
            payr.funding_instruments = fundingInstrumentList;
            payr.payment_method = "credit_card";

            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.total = "12";

            Transaction tran = new Transaction();
            tran.description = "creating a direct payment with credit card";
            tran.amount = amnt;

            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(tran);

            Payment pymnt = new Payment();
            pymnt.intent = "sale";
            pymnt.payer = payr;
            pymnt.transactions = transactions;

            // Create a payment using a valid APIContext
            var paymentId = "";
            try
            {
                var createdPayment = pymnt.Create(apiContext);
                ViewBag.PaymentId = createdPayment.id;
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error when processing your request";
                return View("~/Views/Error.cshtml");
            }


            return View();
        }

        [HttpPost]
        public ActionResult ProcessPayment() {
            return Json("Success");
        }
    }
}