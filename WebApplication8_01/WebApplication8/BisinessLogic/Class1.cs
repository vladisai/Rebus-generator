using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebApplication8;
using System.Web.Caching;

namespace WebApplication8.BisinessLogic
{
    public class vocline : IComparable<vocline>
    {
        public string word;
        public string pars;
        public string file;
        public int CompareTo(vocline other)
        {
            return string.Compare(word, other.word);
        }
    }
    public class RebGen : System.Web.UI.Page
    {
        public string[] ss = new string[100];
        public int l = 0, k = 0;
        public int[] ar = new int[100]; 
        public string ss1, ss2, ss3,kk;

        public string[] Files = new string[1000], Pars = new string[1000];
        public string stringS;
        public string stringR;
        public List<vocline> list;
        public int isRead = 0;
        Random rnd = new Random();
        public Image[] img1 = new Image[1000];
            

        public RebGen(string strS, List<vocline> li)
        {
            int m, n, l1, l2, i = 0;

            stringS = strS;
            list = li;
            isRead = 1;

            GenStr(strS);           

            FindP();
        }

        public void GenStr(string strS)
        {
            int m, n, l1, l2, i = 0;
            l1 = strS.Length;
            l2 = 0;
            i = 0;
            while (l2 != l1)
            {
                n = (rnd.Next(1000) % 5) + 1;
                m = Math.Min(l1 - l2, n);
                ss[i] = strS.Substring(l2, m);
                i++;
                l2 += m;
            }
            l = i;
            stringR = "";
            
            
        }

        public void  FindP(){
        
         
                var lines = list;

            for (int i=0; i<l; i++){
                vocline what = list[0];
                what.word = ss[i];
                var rez = lines.BinarySearch(what);
                int left=rez, right=rez;
                if (rez < 0 || rez > lines.Count)
                {
                    GenStr(stringS);
                    FindP();
                    return;
                }
                while (left>3 && lines[left].word == lines[rez].word ) left--;
                while ( right<lines.Count-5 && lines[right].word == lines[rez].word) right++;
                left++;
                right--;
                int num = rnd.Next(right - left);
                Files[i] = lines[left + num].file;
                Pars[i] = lines[left + num].pars;

            }
                     
            for (int i = 0; i < l; i++)
            {
                img1[i] = new Image
                {
                    ImageUrl = string.Format("GetPic.aspx?file={0}&changes={1}", Files[i], Pars[i]),
                    BorderStyle = BorderStyle.None
                };
            }

        }

        
    }
}