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
        private int attepmts = 0;
        public string[] ss = new string[100];
        public int l = 0, k = 0,p1 = 0;
        public int[] ar = new int[100]; 
        public string ss1, ss2, ss3,kk;
        public string[] Files = new string[1000], Pars = new string[1000], MFiles = new string[1000], MPars = new string[1000];
        public string stringS;
        public string stringR;
        public List<vocline> list;
        Random rnd = new Random(DateTime.Now.Millisecond);
        public Image img1 = new Image();
        private int kol = 0, mind = 100500,ml = 0,CountPeaces = 2;
        private bool EM = true;
        string str_to_make;


        private int GetDif(string s1){
            int res = 0;
            var words = s1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (s1.IndexOf("strikeot") >= 0)
                res++;
            if (words[0] == "over")
                res++;
            if (s1.IndexOf("switch") >= 0 && words[5] != "0")
                res++;
            if (words[1][5] != '0')
                res++;
            if (words[2][6] != '0')
                res++;
            if (words.Length == 1)
                res = 100500;

            return res;
        }


        private bool CheckS(string cs)
        {
            var lines = list;
            vocline what = new vocline();
            what.word = cs;
            var rez = lines.BinarySearch(what);
            if (rez < 0 || rez > lines.Count)
            {
                return false;
            }else{
                return true;
            }

        }

        private int Count_Space(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == ' ') res++;
            return res;
        }

        public RebGen(string strS, List<vocline> li)
        {
            int m, n, l1, l2, i = 0;

            stringS = strS;
            list = li;
            if (Session["Easy_mode"] == "1"){
                EM = true;
            }

            str_to_make = GenStr(strS);           
            FindP();
        }

        public string GenStr(string strS)
        {
           
                if (CheckS(strS) == true && (EM==true || strS.Length <=4) && p1 !=-13)
                {
                    return strS;
                }

                p1 = 1;
                if (EM == true)
                {
                    string ms = "";
                    int m_space = 1000000;

                    for (int i = 1; i < strS.Length - 1; i++)
                    {
                        string s1 = strS.Substring(0, i);
                        string s2 = strS.Substring(i, strS.Length - i);
                        string sr = GenStr(s1) + " " + GenStr(s2);
                        int cur_sp = Count_Space(sr);
                        
                        if (cur_sp < m_space)
                        {
                            m_space = cur_sp;
                            ms = sr;                     
                        }
                    }
                    return ms;
                }else{
                    string ms = "";
                    int m_space = -1;
                    for (int j = 0; j < 5; j++)
                    {
                        int i = rnd.Next(strS.Length - 2) + 1;
                        string s1 = strS.Substring(0, i);
                        string s2 = strS.Substring(i, strS.Length - i);
                        string sr = GenStr(s1) + " " + GenStr(s2);
                        int cur_sp = Count_Space(sr);

                        if (cur_sp > m_space)
                        {
                            m_space = cur_sp;
                            ms = sr;
                        }
                    }
                    return ms;
                }
            
        }

        public void  FindP(){         
            
            var words = str_to_make.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            bool is_strike = false;
            var lines = list;
            foreach (var word in words)
            {
                vocline what = list[0];
                what.word = word;
                var rez = lines.BinarySearch(what);
                int left = rez, right = rez;
                if (rez < 0 || rez > lines.Count)
                {
                    GenStr(stringS);
                    FindP();
                    return;
                }
                while (left > 3 && lines[left].word == lines[rez].word) left--;
                while (right < lines.Count - 5 && lines[right].word == lines[rez].word) right++;
                left++;
                right--;
                int num = 0;
                if (is_strike == false)
                {
                    int s_out = -1;
                    for (int f = left; f < right; f++)
                    {
                        if (lines[f].pars.IndexOf("strikeout") != -1)
                        {
                            s_out = f;
                            is_strike = true;
                            num = s_out;
                        }
                    }
                    if (num == 0) num = left + rnd.Next(right - left);

                }
                else if (EM == true)
                {
                    int minf = 0, min_ch = 10000000;

                    for (int f = left; f < right; f++)
                    {
                        int cur_ch = GetDif(lines[f].pars);
                        if (cur_ch < minf)
                        {
                            min_ch = cur_ch;
                            minf = f;
                        }
                    }
                    num = minf;
                }else
                    num = left + rnd.Next(right - left);

                Files[i] = lines[num].file;
                Pars[i] = lines[num].pars;
                
                i++;
            }

            /*if (EM == false && is_strike == false)
            {
                p1 = 0;
                attepmts++;
                str_to_make = GenStr(stringS);
                FindP();
                return;
            }*/

            Session["len"] = i;
            Session["Files"] = Files;
            Session["Pars"] = Pars;

            img1 = new Image
                {
                    ImageUrl = string.Format("GetPic.aspx"),
                    BorderStyle = BorderStyle.None
                };
        }        
    }
}