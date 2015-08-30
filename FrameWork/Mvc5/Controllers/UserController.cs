using POCOS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        MyContext db = new MyContext();

        public ActionResult Index()
        {

            var listuser = from u in db.Users  where u.IsEnable ==1  orderby u.RoleID
                           select new
                           {   ID=u.ID,
                               Name = u.Name,
                               DisplayName = u.DisplayName ,
                               RoleName= u.Roles.RoleName
                           };
 
          // JArray ja = new JArray() { new { Name = "mm", Psword = "100" } };
           // dynamic ViewBag = new ExpandoObject();

        
            ArrayList al = new ArrayList();
            al.Add(new { Name = "总共：", DisplayName = listuser.Count().ToString()+" 个账号" });
            var ming = new
            {
                total = listuser.Count(),
                rows = listuser,
                footer = al,

            };
            return Content(JsonConvert.SerializeObject(ming, Formatting.Indented), "text/plain");
        }
        [HttpPost]
        public ActionResult login(string UserName, string Password, string ValidateCode)
        {
        
            if (Session["Code"] == null)
            {

                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "请重新刷新验证码", 2, 8, ""));
            }

            if (!string.Equals(Session["Code"].ToString(), ValidateCode, StringComparison.InvariantCultureIgnoreCase))
            {

                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "验证码错误", 2, 8, ""));
            }

            

            var user = db.Users.FirstOrDefault(p => p.Name == UserName);
            if (user == null)
            {
                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "账号或密码错误", 2, 8, ""));

            }
            else
            {
                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "登录成功", 1, 1, "../index.aspx"));

            }
        }
        [HttpGet]
        public ActionResult loginOut(string userid)
        {

            
            CookieHelper.ClearCookie("UserID");
            Session.Clear();
            return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "注销成功", 1, 1, "./user/Login.aspx"));

        }
         [HttpGet]
        public ActionResult ChangePassword(string pw,string pw2)
        {
             if(!string.Equals(pw,pw2))
             {
                 return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "两次输入密码不一样", 2, 8, ""));
             }
            var user = db.Users.FirstOrDefault(p => p.Name == "ming123");
            if (user != null)
            {
                user.Psword = pw;
                db.SaveChanges();
                return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "修改成功", 1, 1, ""));
            }
            return Content(""); 
        }
        public ActionResult GetPartialHtml(int count = 0)
        {
            System.Threading.Thread.Sleep(2000);
            List<Users> listuser = new List<Users>();
            for (int i = 0; i < count; i++)
            {
                listuser.Add(new Users() { Name = "ming" + i.ToString(), Psword = "111" + i.ToString() });
            }

            return PartialView(listuser);
        }
        public ActionResult loaduser(int userid = 0)
        {
            var roles = from  r in db.Roles   orderby r.ID 
                        select new {
                         r.ID,
                         r.RoleName
                        } ;
              ViewBag.roles = roles.ToArray().Select(m => new SelectListItem() { Text = m.RoleName, Value = m.ID.ToString() });

              Users user = new Users();
              if (userid !=0)
            {
                user = db.Users.FirstOrDefault(p => p.ID == userid);
            }
              return PartialView("loaduser", user);
        }
        [HttpPost]
        public ActionResult add(Users user)
        {
            user.Ltime = DateTime.Now;
            if (user.ID > 0)
            {
                db.Entry<Users>(user).State = EntityState.Modified;
            }
            else
            {
                user.Psword = "111111";
                user.Ctime = DateTime.Now;
                db.Users.Add(user);
            }
            db.SaveChanges();
            return JavaScript(string.Format("msgV2('{0}',{1},{2},'{3}')", "提交成功", 1, 1, ""));
          //  return PartialView("loaduser", user);
        }
        public ActionResult del(int userid=0)
        {
          Users user =  db.Users.FirstOrDefault(p => p.ID == userid);
             user.IsEnable = 0;
             try
             {
                 db.SaveChanges();
                 return Content(JsonConvert.SerializeObject(new { type = 1, msg = "删除成功" }, Formatting.Indented), "text/plain");
             }
             catch (Exception ex)
             {

                 return Content(JsonConvert.SerializeObject(new { type=0,msg=ex.ToString()}, Formatting.Indented), "text/plain");
             }

        }
    }
}
