using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POCOS.Models;
namespace Mvc5.WebForms
{
    public partial class _default : BasePage
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){

               
                ViewBag.name = "9000000";

                List<Users> userlist = new List<Users>();
                 ViewBag.userlist = userlist;
        


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }
    }
}