using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;
using WebApplication8.BisinessLogic;


namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "image/jpeg";


            var Files = (string[])Session["Files"];
            var Pars = (string[])Session["Pars"];
            Int32 len = (Int32)Session["len"];
            int width = 0;
            var res = new Bitmap(len * 300 + 40, 400, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(res);

            for (int ind = 0; ind < len; ind++)
            {

                String rootPath = Server.MapPath("~");
                string fileNum = Files[ind];
                

                string changes = Pars[ind];
                var words = changes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                if (words.Length == 1)
                {
                    string word = words[0];
                    if (word.Length == 5)
                    {
                        if (word[0] == 'н')
                        {
                            string c1 = System.Convert.ToString(word[4]);
                            string c2 = System.Convert.ToString(word[3]);
                            graphics.DrawString(c1, new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 10, 20);
                            graphics.DrawString(c2, new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 10, 120);
                            graphics.DrawLine(new Pen(Color.Red, 10), new System.Drawing.Point(width + 10, 130), new System.Drawing.Point(width + 90, 130));
                            width += 200;
                        }
                        else
                        {
                            string c1 = System.Convert.ToString(word[3]);
                            string c2 = System.Convert.ToString(word[4]);
                            graphics.DrawString(c1, new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 10, 20);
                            graphics.DrawString(c2, new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 10, 120);
                            graphics.DrawLine(new Pen(Color.Red, 10), new System.Drawing.Point(width + 10, 130), new System.Drawing.Point(width + 90, 130));
                            width += 200;
                        }
                    }
                    else
                    {
                        string c1 = System.Convert.ToString(word[3]);
                        string c2 = System.Convert.ToString(word[2]);
                        graphics.DrawString(c1, new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 10, 20);
                        graphics.DrawString(c2, new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 10, 120);
                        graphics.DrawLine(new Pen(Color.Red, 10), new System.Drawing.Point(width + 10, 130), new System.Drawing.Point(width + 90, 130));
                        width += 200; 
                    }
                    continue;
                }

                var fileName = Path.Combine(rootPath, string.Format(@"img\{0}", fileNum));
                var img = Image.FromFile(fileName);

                  

                string curparam = "";
                int k = 0;

                curparam = words[1];
                k = System.Convert.ToInt32(words[1].Substring(5, 1));

                for (int i = 0; i < k; i++)
                {
                    graphics.DrawString(",", new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 20, -40);
                    width += 15;
                }

                if (words[0] == "over")
                {
                    img.RotateFlip(RotateFlipType.Rotate180FlipX);
                }

                if (words[5] != "0" && words[3] == "switch")
                {
                    graphics.DrawString(words[4] + "=" + words[5], new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), Math.Max(width + (img.Width - 180) / 2, 0), 290);
                }

                if (words[3] == "strikeout")
                {
                    graphics.DrawString(words[4], new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width + 30, 290);
                    graphics.DrawLine(new Pen(Color.Red, 10), new System.Drawing.Point(width + 40, 330), new System.Drawing.Point(width + 100, 380));

                }



                curparam = words[2];
                k = System.Convert.ToInt32(words[2].Substring(6, 1));
                graphics.DrawImage(img, width, 100);
                width += img.Width;


                for (int i = 0; i < k; i++)
                {
                    graphics.DrawString(",", new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width - 40, -40);
                    width += 15;
                }

                width += 70;
            }

            res.Save(Server.MapPath("~") + "rebus.png", ImageFormat.Png);
            Response.AppendHeader("Content-Disposition", "attachment; filename= rebus.png");

            res.Save(Response.OutputStream, ImageFormat.Png);
        }
    }
}