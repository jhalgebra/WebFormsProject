using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RWAProject.WebFormsClient
{
    public static class Extensions
    {
        #region Other

        public static T Parse<T>(this object obj) {
            if (typeof(T) == typeof(string))
                return (T)obj;

            try {
                return (T)typeof(T)
                    .GetMethod("Parse", new Type[] { typeof(string) })
                    .Invoke(null, new object[] { obj?.ToString() });
            } catch { return default(T); }
        }

        public static void Run(this Control control, string script, string key)
            => ScriptManager.RegisterStartupScript(control, control.GetType(), key, script, true);

        public static CustomPage Page(this Control control) => control.Page as CustomPage; 

        #endregion

        #region URLs

        public static void GoTo(this Page page, string url)
            => page.Response.Redirect(page.ResolveUrl(url));

        public static void GoToPage(this Page page, string pageName)
            => page.GoTo($"~/Pages/{pageName}.aspx");

        public static void Refresh(this Page page)
            => page.GoTo(page.Request.RawUrl); 

        #endregion

        #region ObjectDataSource helpers

        public static T Get<T>(this System.Web.UI.WebControls.ObjectDataSource dataSource, int index)
            => (dataSource.Select() as IEnumerable<T>).ElementAt(index);

        public static int IndexOf<T>(this System.Web.UI.WebControls.ObjectDataSource dataSource, Func<T, bool> predicate)
        {
            var data = dataSource.Select() as IEnumerable<T>;

            for (int i = 0; i < data.Count(); i++)
                if (predicate(data.ElementAt(i)))
                    return i;

            return -1;
        } 

        #endregion

        #region Base64 int converter

        public static string ToBase64(this int integer)
            => Convert.ToBase64String(BitConverter.GetBytes(integer));

        public static int? FromBase64(this string base64String)
            => base64String == null
                ? null
                : (int?)BitConverter.ToInt32(Convert.FromBase64String(base64String), 0);

        #endregion

        #region Data Persistence

        #region Cookies

        public static void Cookie(this Page page, string name, string value, DateTime expirationDate) {
            if (page.Response.Cookies[name] != null)
                page.Response.Cookies.Remove(name);

            page.Response.Cookies.Add(new HttpCookie(name, value) { Expires = expirationDate });
        }

        public static void Cookie(this Page page, string name, string value)
            => Cookie(page, name, value, DateTime.Now.AddYears(50));

        public static T Cookie<T>(this Page page, string name, bool removeAfter) {
            var data = Parse<T>(HttpContext.Current.Request.Cookies[name]?.Value);

            if (removeAfter)
                HttpContext.Current.Request.Cookies.Remove(name);

            return data;
        }

        #endregion

        #region Session

        public static void Session(this Page page, string name, object value) {
            if (page.Session[name] != null)
                page.Session.Remove(name);

            page.Session[name] = value;
        }

        public static T Session<T>(this Page page, string name, bool removeAfter) {
            var obj = page.Session[name];

            var data = obj is T val ? val : Parse<T>(obj);

            if (removeAfter)
                page.Session.Remove(name);

            return data;
        }

        #endregion

        #region Query

        public static T Query<T>(this Page page, string key)
            => Parse<T>(page.Request.QueryString[key]);

        #endregion 

        #endregion
    }
}