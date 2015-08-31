using POCOS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class CustomerController : Controller
    {
        MyContext db = new MyContext();
        [OutputCache(Duration = 1)]
        public ActionResult Index(string name, string contact)
        {

            //var list = from u in db.Customer
            //           where u.IsEnable == 1
            //           && u.CustomreName.Contains(name)
            //           && u.Contact1.Contains(contact)
            //           orderby u.ID
            //               select new
            //               {
            //                   u.ID,
            //                   u.CustomreName,
            //                   u.ShortName,
            //                   u.CustomreNo,
            //                   u.Address,
            //                   u.Contact1,
            //                   u.Contact2,
            //                   u.Tel1,
            //                   u.Tel2,
            //                   u.ctime
            //               };

            var list = db.Customer.SqlQuery("select *   from customer where isenable=1 order by id");
            ArrayList al = new ArrayList();
            al.Add(new { CustomreName = "总共：", ShortName = list.Count().ToString() + " 个客户" });
            var ming = new
            {
                total = list.Count(),
                rows = list,
                footer = new { CustomreName = "总共：", ShortName = list.Count().ToString() + " 个客户" }

            };
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(ming, Newtonsoft.Json.Formatting.Indented, timeFormat), "text/plain");
        }


        public ActionResult loadItem(int ID = 0)
        {

            Customer customer = new Customer();
            if (ID != 0)
            {
                customer = db.Customer.FirstOrDefault(p => p.ID == ID);
              
            }
            return PartialView("item", customer);
        }
        [HttpPost]
        public ActionResult save([Bind(Exclude = "IsEnable")]Customer customer)
        {
            customer.ltime = DateTime.Now;
            customer.IsEnable = 1;
            if (customer.ID > 0)
            {
               
                db.Entry<Customer>(customer).State = EntityState.Modified;
            }
            else
            {
                customer.ctime = DateTime.Now;
                db.Customer.Add(customer);
            }
            try
            {
                     db.SaveChanges();
                     return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "提交成功", 1, 1, ""));
            }
            catch (Exception ex)
            {

                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", ex.ToString(), 1, 8, ""));
            }
     
    
        }
        public ActionResult del(int ID =0)
        {
            Customer customer = db.Customer.FirstOrDefault(p => p.ID == ID);
          //  Customer customer = db.Customer.Find(ID);
            customer.IsEnable = 0;
            try
            {
                db.SaveChanges();
                return Json(new { type = 1, msg = "删除成功" }); ;
               // return Content(JsonConvert.SerializeObject(new { type = 1, msg = "删除成功" }, Formatting.Indented), "text/json");
            }
            catch (Exception ex)
            {
                return Json(new { type = 0, msg = ex.ToString() }); ;
               // return Content(JsonConvert.SerializeObject(new { type = 0, msg = ex.ToString() }, Formatting.Indented), "text/json");
            }

        }

    }
}
