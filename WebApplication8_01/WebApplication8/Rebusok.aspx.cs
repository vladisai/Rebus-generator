using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebApplication8.BisinessLogic;

namespace WebApplication8
{
    public partial class Rebus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["voc"]==null){
                var rootPath = Server.MapPath("~");
                var fileName = Path.Combine(rootPath, "voc.txt");
                FileStream Stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var lines = File.ReadAllLines(fileName);
                var li = new List<vocline>();
                     
                foreach (string line in lines)
                {
                    var words = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var l = new vocline();      
                    l.word = words[0];
                    l.file = words[2];
                    l.pars = "";
                    for (int i = 3; i < words.Length; i++)
                    {
                        l.pars += words[i] + " " ;
                    }
                    li.Add(l);
                }

                li.Sort(
                    (x, y) => string.Compare(x.word, y.word)
                );

                li.Sort();
                Cache["voc"] = li;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                Session["Word"] = TextBox1.Text.ToString();
                Response.Redirect("make.aspx");
            }
        }
    }
}