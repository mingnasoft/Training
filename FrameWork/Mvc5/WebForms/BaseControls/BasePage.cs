using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace System.Web.UI
{
    public class BasePage : System.Web.UI.Page
    {     public dynamic ViewBag { get; set; }
        public BasePage()
        {

            if (ViewBag == null)
            {
                ViewBag = new ExpandoObject();

            }
        }
    }
}