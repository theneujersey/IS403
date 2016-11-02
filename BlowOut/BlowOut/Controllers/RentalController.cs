using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Rentals()
        {
            return View();
        }

        public ActionResult RentalDetails(string instrument, string condition)
        {
            switch (instrument)
            {
                case "Trumpet":
                    ViewBag.instrument = "Trumpet";
                    ViewBag.image = "trumpet.jpg";
                    ViewBag.newPrice = "New Price: $55.00/month";
                    ViewBag.usedPrice = "Used Price: $25.00/month";
                    break;
                case "Trombone":
                    ViewBag.instrument = "Trombone";
                    ViewBag.image = "trombone.jpg";
                    ViewBag.newPrice = "New Price: $60.00/month";
                    ViewBag.usedPrice = "Used Price: $35.00/month";
                    break;
                case "Tuba":
                    ViewBag.instrument = "Tuba";
                    ViewBag.image = "tuba.jpg";
                    ViewBag.newPrice = "New Price: $70.00/month";
                    ViewBag.usedPrice = "Used Price: $50.00/month";
                    break;
                case "Flute":
                    ViewBag.instrument = "Flute";
                    ViewBag.image = "flute.jpg";
                    ViewBag.newPrice = "New Price: $40.00/month";
                    ViewBag.usedPrice = "Used Price: $25.00/month";
                    break;
                case "Clarinet":
                    ViewBag.instrument = "Clarinet";
                    ViewBag.image = "clarinet.jpg";
                    ViewBag.newPrice = "New Price: $35.00/month";
                    ViewBag.usedPrice = "Used Price: $27.00/month";
                    break;
                case "Saxophone":
                    ViewBag.instrument = "Saxophone";
                    ViewBag.image = "saxophone.jpg";
                    ViewBag.newPrice = "New Price: $42.00/month";
                    ViewBag.usedPrice = "Used Price: $30.00/month";
                    break;
                default:
                    ViewBag.instrument = "Chuck Norris";
                    ViewBag.image = "RentToOwn.jpg";
                    ViewBag.newPrice = "New Price: $1000.00/month";
                    ViewBag.usedPrice = "Used Price: $999.00/month";
                    break;
            }

            if (condition == "new")
            {
                ViewBag.price = ViewBag.newPrice;
            }
            else if (condition == "used")
            {
                ViewBag.price = ViewBag.usedPrice;
            }

            return View();
        }
    }
}