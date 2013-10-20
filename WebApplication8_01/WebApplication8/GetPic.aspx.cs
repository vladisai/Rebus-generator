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

    
namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "image/jpeg";
            String rootPath = Server.MapPath("~");
            string fileNum = Request["file"];
            string fileName = Path.Combine(rootPath, string.Format(@"img\{0}", fileNum));
            string changes = Request["changes"];
            var img = Image.FromFile(fileName);

     

            

            var res = new Bitmap(img.Width + 200,img.Height+200, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(res);

            var words = changes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            string curparam = "";
            int k = 0, width = 0;

            curparam = words[1];
            k = System.Convert.ToInt32(words[1].Substring(5,1));
            width = 0;

            for (int i = 0; i < k; i++)
            {
                graphics.DrawString(",", new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width, -40);
                width += 30;
            }

            if (words[0] == "over")
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
            }

            if (words[5] != "0" && words[3]=="switch")
            {
                graphics.DrawString(words[4] + "=" + words[5], new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), img.Width / 2 - 40, 0);
            }

            if (words[3] == "strikeout")
            {
                graphics.DrawString(words[4], new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), img.Width / 2 - 40, 0);
                graphics.DrawLine(new Pen(Color.Red, width = 10), new System.Drawing.Point(img.Width / 2 - 30, 90), new System.Drawing.Point(img.Width / 2 + 30, 30));

            }

            graphics.DrawImage(img, 0, 100);

            curparam = words[2];
            k = System.Convert.ToInt32(words[2].Substring(6,1));
            width = img.Width;


            for (int i = 0; i < k; i++)
            {
                graphics.DrawString(",", new Font(FontFamily.GenericSerif, 70), new SolidBrush(Color.Black), width, -40);
                width += 30;
            }


            res.Save(Response.OutputStream, ImageFormat.Png);
        }
    }
}