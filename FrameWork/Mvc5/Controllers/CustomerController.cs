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
using common;

namespace Mvc5.Controllers
{
    public class CustomerController : Controller
    {
      //  MyContext db = new MyContext();
        [OutputCache(Duration = 1)]
        public ActionResult Index(string name, string contact)
        {

            //var list = from u in MyContext.Current.Customer
            //           where u.IsEnable == 1
            //           && u.CustomreName.Contains(name)
            //           && u.Contact1.Contains(contact)
            //           orderby u.ID
            //           select new
            //           {
            //               u.ID,
            //               u.CustomreName,
            //               u.ShortName,
            //               u.CustomreNo,
            //               u.Address,
            //               u.Contact1,
            //               u.Contact2,
            //               u.Tel1,
            //               u.Tel2,
            //               u.ctime
            //           };

         //   var list = MyContextX.Current.Customer.SqlQuery("select *   from customer where isenable=1 order by id");
            //var ming = new
            //{
            //    total = list.Count(),
            //    rows = list,
            //    footer = new { CustomreName = "总共：", ShortName = list.Count().ToString() + " 个客户" }

            //};
          //  DataTable dt = SqlHelper.GetDataTableBySQL("select *   from customer where isenable=1 order by id");

            DataTable dt = SqlHelper.GetDataTableBySQL("select *   from customer where isenable=1 and CustomreName like '%{0}%'  order by id", name);
            var ming = new
            {
                total = dt.Rows.Count,
                rows = dt,              
            };
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd"};
            
            return Content(JsonConvert.SerializeObject(ming, Newtonsoft.Json.Formatting.Indented, timeFormat), "text/json");
        }


        public ActionResult loadItem(int ID = 0)
        {

            Customer customer = new Customer();
            if (ID != 0)
            {
                    customer = MyContext.Current.Customer.FirstOrDefault(p => p.ID == ID);
            }
            return PartialView("item", customer);
        }
        [HttpPost]
        public ActionResult save([Bind(Exclude = "IsEnable")]Customer customer)
        {
        // 如果用存sql的话
            List<string> sql = new List<string>();
            sql.Add("insert into table values ()");
            //或者
            sql.Add(" update table set ....");
            SqlHelper.ExecuteNonQuery("conn", sql);
            customer.ltime = DateTime.Now;
            customer.IsEnable = 1;
     
            if (customer.ID > 0)
            {

               MyContext.Current.Entry<Customer>(customer).State = EntityState.Modified;
              
            }
            else
            {
                customer.ctime = DateTime.Now;
             MyContext.Current.Customer.Add(customer);
            }
            try
            {
                MyContext.Current.SaveChanges();
                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "提交成功", 1, 1, ""));
            }
            catch (Exception ex)
            {

                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", ex.ToString(), 1, 8, ""));
            }
     
    
        }
        public ActionResult del(int ID =0)
        {
            try
            {
                SqlHelper.ExeSql("update customer set isenable=0 where id={0}", ID);
                return Json(new { type = 1, msg = "删除成功" }); ;
           
            }
            catch (Exception ex)
            {
                return Json(new { type = 0, msg = ex.ToString() }); ;
         
            }

        }

    }
}
