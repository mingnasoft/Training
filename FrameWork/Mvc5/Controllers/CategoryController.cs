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
    public class CategoryController : Controller
    {
        MyContext db = new MyContext();

        public ActionResult datagrid(string parentRowID)
        {

            var list = from u in db.Category
                       where ( u.IsEnable == true) 
                       where (u.ParentRowID ==  parentRowID)
                       orderby u.SeqNo  descending

                       select new
                       {
                         
                           u.RowID,
                           u.SeqNo,
                           u.title,
                           u.ltime,
                           u.IsEnable,
                           u.ParentRowID
                         
                       };


            ArrayList al = new ArrayList();
          //  al.Add(new { CustomreName = "共：", ShortName = list.Count().ToString() + " 个分类" });
            var ming = new
            {
                total = list.Count(),
                rows = list,
                footer = al,

            };
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(ming, Newtonsoft.Json.Formatting.Indented, timeFormat), "text/plain");
        }


        public ActionResult combotree(string parentRowID)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
           
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            var mm = getdt(parentRowID);
            return Content(JsonConvert.SerializeObject(mm, Newtonsoft.Json.Formatting.Indented, timeFormat), "text/plain");
        }
        private object getdt(string parentRowid)
        {

            var list = (from u in db.Category.ToList()
                        where u.ParentRowID == parentRowid
                        where (u.IsEnable == true)
                        orderby u.SeqNo
                        select new combotreeData
                            {
                                id = u.RowID.ToString(),
                                text = u.title
                            }).ToList();
            
          
            if (list.Count() == 0) return null;
            if (list.Count() > 0)
            {
                foreach (combotreeData i in list)
                {
                    i.children = (List<combotreeData>)getdt(i.id);

                }
                return list.ToList();
            }
            return null;
        }

        public class combotreeData
        {

            public string  id { get; set; }
            public string text { get; set; }
            public List<combotreeData> children { get; set; }
        }

        public ActionResult loadItem(string  rowid="" )
        {
            var roles = from r in db.Category
                        where (r.ParentRowID == "1111" || r.ParentRowID ==null) && r.IsEnable == true
                        orderby r.SeqNo   descending
                        select new
                        {
                            r.RowID,
                            r.title 
                        };
         // var  roles = clist.ToList();
         // roles.Add(new { RowID = new Guid("00000000-0000-0000-0000-000000000000"), title = "顶级分类" });
            ViewBag.roles = roles.ToArray().Select(m => new SelectListItem() { Text = m.title, Value = m.RowID.ToString() });
            Category item = new Category();
                
            if (rowid != "")
            {

                item = db.Category.FirstOrDefault(p => p.RowID == rowid);
            }
            return PartialView("item", item);
        }
        [HttpPost]
        public ActionResult save(Category item)
        {
            item.ltime = DateTime.Now;

            if (!string.IsNullOrEmpty(item.RowID))
            {

                db.Entry<Category>(item).State = EntityState.Modified;
            }
            else
            {
                item.ctime = DateTime.Now;
                item.RowID = System.Guid.NewGuid().ToString();
                item.IsEnable = true;
                db.Category.Add(item);
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
        public ActionResult del(string rowid )
        {
            Category item = db.Category.FirstOrDefault(p => p.RowID == rowid);
            item.IsEnable = false;
            try
            {
                db.SaveChanges();
                return Json(new { type = 1, msg = "删除成功" }); 
              //  return Content(JsonConvert.SerializeObject(new { type = 1, msg = "删除成功" }, Formatting.Indented), "text/plain");
            }
            catch (Exception ex)
            {
                return Json(new { type = 0, msg = ex.ToString() }); ;
              //  return Content(JsonConvert.SerializeObject(new { type = 0, msg = ex.ToString() }, Formatting.Indented), "text/plain");
            }

        }

    }
}
