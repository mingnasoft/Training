using POCOS.Models;
using Newtonsoft.Json;
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
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        MyContext db = new MyContext();

        public ActionResult Index()
        {

            var listuser = from u in db.Roles
                           where u.IsEnable == 1
                           orderby u.ID
                           select new
                           {
                               ID = u.ID,
                               RoleName = u.RoleName,
                               Brief = u.Brief
                           };

    
            ArrayList al = new ArrayList();
            al.Add(new { RoleName = "总共：", Brief = listuser.Count().ToString() + " 个角色" });
            var ming = new
            {
                total = listuser.Count(),
                rows = listuser,
                footer = al,

            };
            return Content(JsonConvert.SerializeObject(ming, Formatting.Indented), "text/plain");
        }


        public ActionResult loadRole(int roleid = 0)
        {

            Roles role = new Roles();
            if (roleid != 0)
            {
                role = db.Roles.FirstOrDefault(p => p.ID == roleid);
            }
            return PartialView("loadRole", role);
        }
        [HttpPost]
        public ActionResult add(Roles role)
        {
          
            if (role.ID > 0)
            {
              
                db.Entry<Roles>(role).State = EntityState.Modified;
            }
            else
            {
                role.IsEnable = 1;
                db.Roles.Add(role);
            }
            db.SaveChanges();
            return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "提交成功", 1, 1, ""));
            //  return PartialView("loaduser", user);
        }
        public ActionResult del(int Roleid = 0)
        {
            Roles role = db.Roles.FirstOrDefault(p => p.ID == Roleid);
            role.IsEnable = 0;
            try
            {
                db.SaveChanges();
                return Content(JsonConvert.SerializeObject(new { type = 1, msg = "删除成功" }, Formatting.Indented), "text/plain");
            }
            catch (Exception ex)
            {

                return Content(JsonConvert.SerializeObject(new { type = 0, msg = ex.ToString() }, Formatting.Indented), "text/plain");
            }

        }

    }
}
