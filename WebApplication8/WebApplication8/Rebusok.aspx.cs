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
       
                if (Cache["voc"] == null)
                {
                    var rootPath = Server.MapPath("~");
                    var fileName = Path.Combine(rootPath, "voc.txt");
                    FileStream Stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    var lines = File.ReadAllLines(fileName);
                    var li = new List<vocline>();

                    foreach (string line in lines)
                    {
                        var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length > 2)
                        {
                            var l = new vocline();
                            l.word = words[0];
                            l.file = words[2];
                            l.pars = "";
                            for (int i = 3; i < words.Length; i++)
                            {
                                l.pars += words[i] + " ";
                            }
                            li.Add(l);
                        }
                        else
                        {
                            var l = new vocline();
                            l.word = words[0];
                            l.file = "letter";
                            l.pars = words[0];
                            li.Add(l);
                        }
                    }

                    li.Sort(
                        (x, y) => string.Compare(x.word, y.word)
                    );

                    li.Sort();
                    Cache["voc"] = li;
                }
                Session["Easy_mode"] = "0";
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                Label2.Text = "";
                Session["Word"] = TextBox1.Text.ToString();
                string word = TextBox1.Text.ToString();
                int l = word.Length, pom = 0;
                for (int i = 0; i<l; i++){
                    if (!((word[i] >= 'а' && word[i] <= 'я') || (word[i] >= 'А' && word[i] <= 'Я')))
                    {
                        pom = 1;
                    }
                }
                if (pom == 0)
                {
                    Response.Redirect("make.aspx");
                }
                else
                {
                    Label2.Text = "Слово может состоять только из русских букв";
                }
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                Session["Easy_mode"] = "1";
            }
            else
            {
                Session["Easy_mode"] = "0";
            }
        }
    }
}