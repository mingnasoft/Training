using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CookieHelper 的摘要说明
/// </summary>
public class CookieHelper
{
    /// <summary>  
    /// 清除指定Cookie  
    /// </summary>  
    /// <param name="cookiename">cookiename</param>  
    public static void ClearCookie(string cookiename)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddYears(-3);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
    /// <summary>  
    /// 获取指定Cookie值  
    /// </summary>  
    /// <param name="cookiename">cookiename</param>  
    /// <returns></returns>  
    public static string GetCookieValue(string cookiename)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
        string str = string.Empty;
        if (cookie != null)
        {
            str = cookie.Value;
        }
        return str;
    }
    /// <summary>  
    /// 添加一个Cookie（24小时过期）  
    /// </summary>  
    /// <param name="cookiename"></param>  
    /// <param name="cookievalue"></param>  
    public static void SetCookie(string cookiename, string cookievalue)
    {
        //SetCookie(cookiename, cookievalue, DateTime.Now.AddDays(1));
        SetCookie(cookiename, cookievalue, DateTime.Now.AddMinutes(2));
    }
    /// <summary>  
    /// 添加一个Cookie  
    /// </summary>  
    /// <param name="cookiename">cookie名</param>  
    /// <param name="cookievalue">cookie值</param>  
    /// <param name="expires">过期时间 DateTime</param>  
    public static void SetCookie(string cookiename, string cookievalue, DateTime expires)
    {
        HttpCookie cookie = new HttpCookie(cookiename)  ;
        //{
        //    Value = cookievalue,
        //    Expires = expires
        //};
        cookie.Value = cookievalue;
     //   DateTime dt = DateTime.Now;
       // TimeSpan ts = new TimeSpan(0, 1, 1, 0, 0);//过期时间为1分钟
      //  cookie.Expires = dt.Add(ts);//设置过期时间
       cookie.Expires = expires;
        HttpContext.Current.Response.Cookies.Add(cookie);
    }  
}