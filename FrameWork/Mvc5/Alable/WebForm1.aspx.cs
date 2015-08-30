using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mvc5.WebForms.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //  [{"id":14},{"id":13},{"id":15,"children":[{"id":16},{"id":17},{"id":18}]}]
            string json3 = @"{
  'Name': 'Bad Boys',
  'ReleaseDate': '1995-4-7T00:00:00',
  'Genres': [
    'Action',
    'Comedy'
  ]
}";

            string json = @"{'k':'88','cont':[{'id':14},{'id':13},{'id':15,children:[{'id':16},{'id':17},{'id':18}]}]}";

var m = JsonConvert.DeserializeObject<ming1>(json);

        }
    }

    public class ming1
    {

        public string  k { get; set; }

        public List<ming> cont { get; set; }
    }
    public class ming
    {

        public int  id { get; set; }

        public List<ming> children { get; set; }
    }
}