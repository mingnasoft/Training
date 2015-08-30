using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Web.UI;
using System.Data;
using System.Net.Mail;

/// <summary>
/// Util 的摘要说明
/// </summary>
public class Util
{
	public Util()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string  GetCurrentCartID()
    {
       // return "c914311c-61eb-4d31-9019-3bc3b6f6d002";
        if (HttpContext.Current.Session["cartid"] != null)
        {
            return (string)HttpContext.Current.Session["cartid"];
        }
        else
        {
         string cartid=   System.Guid.NewGuid().ToString();
         HttpContext.Current.Session["cartid"] = cartid;
         return cartid;
        }
     }

 
    public static void JSAlert(Page Page, string msg)
    {
        string jscript = ("<script type='text/javascript'>" + Environment.NewLine + "alert('" + msg.Replace("'", "''") + "');") + Environment.NewLine + "</script>";
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "JSAlert", jscript);
    }

    public static void JSAlertRedirect(Page Page, string msg, string url)
    {
        string jscript = "<script type='text/javascript'>" + Environment.NewLine + "alert('" + msg.Replace("'", "''") + "');" + Environment.NewLine + "location.href = '" + url + "';" + Environment.NewLine + "</script>";
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "JSAlertRedirect", jscript);
    }
    public static string Substr(object o, Int32 lenth)
    {

        return "";
    }
    //public static ChongWuEntities CurrentContext
    //{
    //    get { 
    //      //  return HttpContext.Current.Items["MyContext"] as ChongWuEntities;
    //        return ContextUtil.CurrentContext;
    //    }
    //}

    //public UserHelper userHelper
    //{
    //    get
    //    {
    //        UserHelper _userhelper = new UserHelper();
    //        return _userhelper;
    //    }
    //}
 
    public static Util Current
    {
        get {

            if (HttpContext.Current.Items["CurrentUtil"] != null)
            {
                return HttpContext.Current.Items["CurrentUtil"] as Util;
            }
            else
            {
                Util _Util = new Util();
                HttpContext.Current.Items["CurrentUtil"] = _Util;
                return _Util;
            }
       
        }
           
        
        
       
    }

    public static string GetDemain()
    {
        var _with1 = HttpContext.Current;
        string url = string.Format("http://{0}{1}{2}", _with1.Request.ServerVariables["SERVER_NAME"], (_with1.Request.ServerVariables["SERVER_PORT"] == "80" ? "" : ":" + _with1.Request.ServerVariables["SERVER_PORT"]), (HttpRuntime.AppDomainAppVirtualPath == "/" ? "" : HttpRuntime.AppDomainAppVirtualPath));
        return url;
    
    }
  
    public static void OutJson(HttpContext context, Hashtable hash)
    {

        string strSerializeJSON = JsonConvert.SerializeObject(hash);
        context.Response.Write(strSerializeJSON);
        context.Response.End();

    }
   

  
}