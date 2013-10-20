using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication8.BisinessLogic;
namespace WebApplication8
{
    public partial class make : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Word"] != null)
                {
                    string s1 = Session["Word"].ToString();
                    if (Cache["voc"] == null) Response.Redirect("Rebusok.aspx");
                    RebGen r1 = new RebGen(s1, Cache["voc"] as List<vocline>);
                    /*for (int i = 0; i < r1.l; i++)
                    {
                        Label1.Text += r1.ss[i];
                        Label1.Text += " ";
                    }*/
                    int l = r1.l;

                    /*for (int i = 0; i < l; i++)
                    {
                        TextBox1.Text += r1.Files[i] + "&" + r1.Pars[i] + "&" + r1.ss[i] + "&";                 
                    }*/
                    id1.Controls.Add(r1.img1);


                }
                else
                {
                    Label1.Text = "No word found! =(";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (TextBox1.Text!=null)
            Response.Redirect("Rebusok.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("make.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //if (TextBox1.Text!=null)
            Response.Redirect("GetPic.aspx");
        }
    }
}