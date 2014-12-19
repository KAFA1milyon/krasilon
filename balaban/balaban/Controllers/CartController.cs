using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using balaban.DAL;
using balaban.Models;

namespace balaban.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //public ActionResult Index()
        //{
        //    return View();
        //}
        bContext storeDB = new bContext();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            Session["SepetAdet"] = cart.GetCartItems().Count;
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(string id,string count)
        {
            int uId, uCount = 0;
            int.TryParse(id, out uId);
            int.TryParse(count, out uCount);

             //Retrieve the album from the database
            var addedAlbum = storeDB.Urunler.Single(x => x.ID == uId);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum, uCount);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCart(string id, string count)
        {
            int uId, uCount = 0;
            int.TryParse(id, out uId);
            int.TryParse(count, out uCount);

            //Retrieve the album from the database
            var addedAlbum = storeDB.Urunler.Single(x => x.ID == uId);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.UpdateCart(addedAlbum, uCount);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }


        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = storeDB.Carts
                .Single(item => item.RecordId == id).Urun.UrunAdi;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            Session["SepetAdet"] = cart.GetCartItems().Count;

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }


        public ActionResult AddressAndPayment()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            return View(cart);
        }
        public ActionResult Send(string mail, string contactname)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            string style = @" 
<style>
    button, input[type='submit'], input[type='reset'], input[type='button'] { font-family: 'Open Sans', sans-serif; font-size: 13px; margin: 0 0 20px 0; padding: 6px 12px; color: #fff; background-color: #2299dd; border: 1px solid #2299dd; text-decoration: none; border-radius: 2px; moz-border-radius: 2px; -webkit-border-radius: 2px; -ms-border-radius: 2px; outline: none; cursor: pointer; }
    span.wpcf7-form-control-wrap { position: relative; }
    p { line-height: 21px; margin: 10px 0 21px 0; padding: 0 0 0 0; margin-left: 10px; }
    input[type='text'], input[type='password'], input[type='email'], textarea, select { font-family: 'Open Sans', sans-serif; font-size: 13px; color: #2f2f2f; background: #fff; border: 1px solid #e7e7e7; -moz-border-radius: 2px; -webkit-border-radius: 2px; border-radius: 2px; padding: 6px 4px; width: 95%; max-width: 300px; display: block; margin: 10px 0 20px 0; outline: none; }
</style>";


            StringBuilder sb = new StringBuilder();
            sb.AppendLine(style);
            sb.AppendLine("<div class='wpcf7' id='wpcf7-f291-p361-o1' lang='en-US' dir='ltr'>");
            sb.AppendLine("    <div class='screen-reader-response'></div>");
            sb.AppendLine("         <p>");
            sb.AppendLine("            E-mail <br>");
            sb.AppendLine("            <span class='wpcf7-form-control-wrap mail'><input type='email' name='mail' size='40' class='wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email' aria-required='true' aria-invalid='false' disabled='disabled' value='" + mail + "'></span>");
            sb.AppendLine("        </p>");
            sb.AppendLine("        <p>");
            sb.AppendLine("            Ad<br>");
            sb.AppendLine("            <span class='wpcf7-form-control-wrap konu'><input type='text' name='contactname' size='40' class='wpcf7-form-control wpcf7-text' aria-invalid='false' disabled='disabled' value='" + contactname + "'></span>");
            sb.AppendLine("        </p>");
            sb.AppendLine("        <div class='wpcf7-response-output wpcf7-display-none'></div>");
            sb.AppendLine("</div>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("<table style='width: 100%;text-align:left;'>");
            sb.AppendLine("    <tr><th width='20%'>Urun Adı</th><th width='20%'>Fiyat</th><th width='20%'>Adet</th><th width='20%'></th></tr>");
            foreach (var item in cart.GetCartItems())
            {
                sb.AppendLine("            <tr><td width='20%'>");
                sb.AppendLine("" + item.Urun.UrunAdi);
                sb.AppendLine("            </td><td width='20%'>");
                sb.AppendLine("" + item.UrunFiyat.Fiyat);
                sb.AppendLine("            </td><td width='20%'>");
                sb.AppendLine("" + item.Count);
                sb.AppendLine("            </td><td width='20%'></td></tr>");
            }
            sb.AppendLine("    <tr><td width='20%'>Total</td><td width='20%'></td><td width='20%'></td><td width='20%' id='cart-total'>" + cart.GetTotal() + "</td></tr>");
            sb.AppendLine("</table>"); 
            //return Content(sb.ToString());





            //if (string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(konu) && string.IsNullOrEmpty(ileti))
            //    return View();
            try
            {
                int port = 587;
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["mailPort"], out port);
                string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailServer"];
                string mailTo = System.Configuration.ConfigurationManager.AppSettings["mailTo"];
                string mailUsername = System.Configuration.ConfigurationManager.AppSettings["mailUsername"];
                string mailPassword = System.Configuration.ConfigurationManager.AppSettings["mailPassword"];
                 


                MailMessage msgMail = new MailMessage();

                MailMessage myMessage = new MailMessage();
                myMessage.From = new MailAddress(mailUsername, "Global Link");
                myMessage.To.Add(mailTo);
                myMessage.Subject ="Sipariş"  + " - " + DateTime.Now.Date.ToString().Split(' ')[0];
                myMessage.IsBodyHtml = true;

                myMessage.Body = sb.ToString() + "<br>";// +ileti.Replace("\r\n", "<br>");


                SmtpClient mySmtpClient = new SmtpClient();
                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(mailUsername, mailPassword);
                mySmtpClient.Host = mailServer;
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Credentials = myCredential;
                mySmtpClient.ServicePoint.MaxIdleTime = 1;
                mySmtpClient.Timeout = (60 * 5 * 1000);//300000

                //mySmtpClient.EnableSsl = true;

                mySmtpClient.Send(myMessage);
                myMessage.Dispose();



                ViewBag.Success = "<script>alert('Sent Succesfully');</script>";
                //return View("Contact");
            }
            catch (Exception ex)
            {
                ViewBag.Success = "<script>alert('" + ex.Message + "');</script>";
                // ViewData.ModelState.AddModelError("_HATA", ex.Message);
            }
           return View("Index"); 

        }
    }
}