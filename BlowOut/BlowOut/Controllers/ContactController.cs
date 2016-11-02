using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {       
        // GET: Contact
        public String Index()
        {           
            return "Please call Support at <u><strong>801-555-1212</strong></u>. Thank you!";
        }

        public String Email(String Name, String Email)
        {
            return "Thank you " + Name + ". We will send an email to " + Email;
        }
    }
}