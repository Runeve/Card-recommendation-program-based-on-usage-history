using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algol_card
{
    public class CARD
    {
        public List<string> BUYLIST = new List<string>();//사용한 곳
        public List<int> MONEY = new List<int>();//금액
        /*문자열비교횟수*/
        int kmp;
        int sunday;
        int brute;
       
        public int kmp_get() { return kmp; }
        public int sunday_get() { return sunday; }
        public int brute_get() { return brute; }
        public void kmp_set(int k) { kmp = k; }
        public void sunday_set(int s) { sunday = s; }
        public void brute_set(int b) { brute = b; }
        public List<string> BUY_GET()
        {
            return BUYLIST;
        }
        public List<int>MONEY_GET()
        {
            return MONEY;
        }
        public void BUY_SET(List<string>l)
        {
            BUYLIST = l;
        }
        public void MONEY_SET(List<int>l)
        {
            MONEY = l;
        }
    }
    
    public partial class Form1 : Form
    {
        List<string> templist=new List<string>();
        List<int> tempmoney = new List<int>();
        int []SP;
        string[] list = new string[136] {"GS25","지에스","씨유","세븐일레븐","바이더웨이","G마켓","옥션",
        "11번가","쿠팡", "위메프","인터파크","맥스무비","티몬","제로투세븐","위비마켓","티켓몬스터","요기요",
        "CJ몰","롯데닷컴","엘칸토","에잇세컨즈","LF","Google","App","VISA","Master","버스","지하철","taxi",
        "교통대금","올리브영","박승철헤어","왓슨스","아리따움","espoir","etude","대명","베어스타운","쉐라톤","하나투어","모두투어",
        "투어비스","병원","미스터피자","버거킹","KFC",
        "롯데마트","이마트","홈플러스","신세계백화점","신세계","현대","갤러리아","다이소","롯데수퍼","롯데백화점",
        "GS수퍼","하나로","신라면세점","ABC","GS홈쇼핑","CJ홈쇼핑","배달의민족",
        "롯데시네마","CGV","메가박스","cinecube","primuscinema","서울극장","아웃백","빕스","TGIF","세븐스프링스",
        "베니건스","우노","불고기브라더스","스타벅스","커피빈","카페베네","투썸플레이스","이디야","빈스빈스",
        "할리스","띠아모","주커피","팔롬비니","아리스타","커핀그루","파스쿠치","탐앤탐스","드롭탑",
        "에버랜드","롯데월드","서울랜드","설악워터피아","광주패밀리",
        "이월드","경주월드","통도환타지아","캐리비안베이","캘리포니아비치","한국민속촌","GS칼텍스",
        "S-OIL","E1","현대오일뱅크","스피드메이트","교보문고","영풍문고","Yes24","반디앤루니스",
        "제주항공","대한항공","파리바게뜨","올가","오봉","롭스","뚜레쥬르",
        "베스킨라빈스","던킨도너츠","미스터도넛","오설록","파르나스","파고다","PAGODA","YBN",
        "해커스","Happycall","KT","SKT","LG","sk주요소","맥스무비","인터파크영화","YES24영화", "롯데렌트카"};

        int k, b, s;
        int []SkipTable=new int[256];

        public CARD FIND(List<string>E_U,List<int>E_W)
        {//조건에 맞는 문자열을 찾아서 카드를 반환
            bool flag=false;

            List<CARD>cardlist= new List<CARD>();
            CARD c = new Algol_card.CARD();
            k = 0;b = 0;s = 0;int cc=0;
            foreach (string use in E_U)
            {//찾기
                flag = false;
                for(int t=0;t<136;t++)
                {
                    flag = KMP(use,list[t]);
                    flag = sunday(use, list[t]);
                    flag = BRUTE(use,list[t]);
                    if(flag)
                    {
                        templist.Add(list[t]);
                        tempmoney.Add(E_W[cc]);
                        break;
                    }
                }
                cc++;
            }
            c.kmp_set(k);
            c.sunday_set(s);
            c.brute_set(b);
            c.BUY_SET(templist);
            c.MONEY_SET(tempmoney);
            return c;
        }
        public bool KMP(string a, string p)
        {
            int i, j, m = p.Length, n = a.Length;
            SP = new int[m];
            initSP(p);//미리 패턴의정보를 처리
            for (i = 0, j = -1; i <= n - 1; i++)
            {
                while ((j >= 0) && (p[j + 1] != a[i]))
                {//패턴정보를 사용해 중간단계를 뛰어넘음
                    k++;
                    j = SP[j];
                }
               
                if (p[j + 1] == a[i]) { j++;k++; }
                if (j == m - 1)
                {// 일치!
                    return true;
                }
            }
            return false;
        }
        public void initSP(string p)
        {
            int i, j, m = p.Length;
            SP[0] = -1;
            for (i = 1, j = -1; i <= m - 1; i++)
            {
                while ((j >= 0) && (p[j + 1] != p[i]))
                {
                    j = SP[j];
                }
                if (p[j + 1] == p[i]) j++;
                SP[i] = j;
            }
        }

        public bool BRUTE(string a, string p)
        {  //p : Pattern String, a : Text String
            int i, j, m = p.Length, n = a.Length;
            for (i = 0; i <= n - m; i++)
            {
                for (j = 0; j < m; j++)
                {//그냥다탐색
                    b++;
                    if (a[i + j] != p[j]) break;
                }
                if (j == m)
                {
                    return true;
                }
            }
            return false;
        }

        public bool sunday(string sentence, string pattern)
        {
            if (pattern.Length == 0) return false;
            if (pattern.Length > sentence.Length) return false;

            int i = 0;
            while (i < sentence.Length)
            {
                int j = 0;
                while (j < pattern.Length && i + j < sentence.Length && sentence[i + j] == pattern[j])
                { //match
                    j++;s++;
                }
                if (j == pattern.Length) return true;
                else
                { //shift
                    if (i + pattern.Length < sentence.Length)
                    {
                        for (j = pattern.Length - 1; j >= 0; j--)
                        {
                          
                            if (pattern[j] == sentence[i + pattern.Length])
                            {
                                break;
                            }
                        }
                    }
                    i += pattern.Length - j;
                }
            }
            return false;
        }

    }

}
