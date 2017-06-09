using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using iTalk;

namespace Algol_card
{
    public partial class Form1 : Form
    {
        string Excel1_fileName, Excel1_fileFullName, Excel1_filePath;
        string Excel2_fileName, Excel2_fileFullName, Excel2_filePath;
        string Excel3_fileName, Excel3_fileFullName, Excel3_filePath;

        List<int> Excel_Won;
        List<string> Excel_Use;
        int AVG;

        //국민
        KB_Chungchundaero chungchundarto;
        KB_Hoon hoon;
        KB_Min min;
        KB_Jung jung;
        KB_Eum eum;
        KB_Gaon gaon;
        KB_Star star;
        KB_Juniorlife juniorlife;
        KB_Between between;

        //우리
        UR_Hangbok hangbok;
        UR_Naman naman;
        UR_Uri uri;
        UR_Baedal baedal;
        UR_Hyundae hyundae;
        UR_Lotte lotte;
        UR_Lg lg;
        UR_Pop pop;
        UR_Uni uni;
        UR_Wibee wibee;

        //신한
        SH_Sline sline;
        SH_Schoice_shopping schoice_shopping;
        SH_Schoice_coffee schoice_coffe;
        SH_Schoice_traffic schoice_traffic;
        SH_BigPluse bigpluse;
        SH_S20 s20;
        SH_S20Pink s20pink;
        SH_2030 s2030;
        SH_yogiyo yogiyo;

        //하나
        HN_toXalpha toxalpha;
        HN_wingp wingp;

        //기업
        IBK_myAlpha myalpha;
        IBK_savezone savezone;
        IBK_enjoy_everyday_life enjoy_everyday;
        IBK_culture_Yungsung culture_yungsung;
        IBK_daiso daiso;


        private void Won_LastMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
             * char.IsDigit(e.KeyChar) : 텍스트박스에 입력된 문자가 10진수인지 확인
             * e.Keychar == Convert.ToChar(Keys.Back) : 백스페이스가 예외처리
            */
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void Won_LastMonth_TextChanged(object sender, EventArgs e)
        {
            
        }


        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            Application.Run(form);
        }

        public Form1()
        {
            InitializeComponent();
            select_excel.Items.Add("1개");
            select_excel.Items.Add("2개");
            select_excel.Items.Add("3개");
            button_excel1.Visible = false;
            button_excel2.Visible = false;
            button_excel3.Visible = false;
            excel1_Name.Visible = false;
            excel1_Path.Visible = false;
            excel2_Path.Visible = false;
            excel2_Name.Visible = false;
            excel3_Path.Visible = false;
            excel3_Name.Visible = false;
            ProgressIndicator.Visible = false;
            button_start.Visible = false;
            card_Name.Visible = false;
            card_Discount.Visible = false;
            iTalk_Label2.Visible = false;
            iTalk_Label3.Visible = false;
            iTalk_Label4.Visible = false;
            iTalk_TextBox_Small1.Visible = false;
            iTalk_TextBox_Small2.Visible = false;
            iTalk_TextBox_Small3.Visible = false;
            Excel_Won = new List<int>();
            Excel_Use = new List<string>();
            Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iTalk_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = select_excel.SelectedIndex;       
            string txt = select_excel.SelectedItem as String;
            button_start.Visible = true;
            if (select == 0)
            {
                button_excel1.Visible = true;
                button_excel2.Visible = false;
                button_excel3.Visible = false;
                excel1_Name.Visible = true;
                excel1_Path.Visible = true;
                excel2_Path.Visible = false;
                excel2_Name.Visible = false;
                excel3_Path.Visible = false;
                excel3_Name.Visible = false;
            }
            else if (select == 1)
            {
                button_excel1.Visible = true;
                button_excel2.Visible = true;
                button_excel3.Visible = false;
                excel1_Name.Visible = true;
                excel1_Path.Visible = true;
                excel2_Path.Visible = true;
                excel2_Name.Visible = true;
                excel3_Path.Visible = false;
                excel3_Name.Visible = false;
            }
            else //select == 2
            {
                button_excel1.Visible = true;
                button_excel2.Visible = true;
                button_excel3.Visible = true;
                excel1_Name.Visible = true;
                excel1_Path.Visible = true;
                excel2_Path.Visible = true;
                excel2_Name.Visible = true;
                excel3_Path.Visible = true;
                excel3_Name.Visible = true;
            }
        }

        private void card_Discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void iTalk_Listview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {

        }

        private void button_excel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Excel1 = new OpenFileDialog();
            Excel1.Title = "첫번째 Excel을 선택해주세요";
            //Excel1.Filter = "Excel 파일(*.xlsx)|*.xlsx;";

            DialogResult Excel1_result = Excel1.ShowDialog();

            if(Excel1_result== DialogResult.OK)            //파일 선택 시
            {
                //File명과 확장자를 가지고 온다
                Excel1_fileName = Excel1.SafeFileName;
                //File경로와 File명을 모두 가지고 온다
                Excel1_fileFullName = Excel1.FileName;
                //File경로만 가지고 온다
                Excel1_filePath = Excel1_fileFullName.Replace(Excel1_fileName, "");

                excel1_Name.Text = "파일 이름 : " + Excel1_fileName;
                excel1_Path.Text = "파일 경로 : " + Excel1_filePath;
                button_excel1.Text = check_filename(excel1_Name.Text);
                if (button_excel1.Text == "ERROR")
                {
                    MessageBox.Show("잘못된 파일입니다. 다시 선택해주세요");
                    button_excel1_Click(sender, e);
                }
            }

            else if (Excel1_result == DialogResult.Cancel)//취소버튼 또는 ESC로 파일 창 종료시
            {

            }
        }

        private void button_excel2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Excel2 = new OpenFileDialog();
            Excel2.Title = "두번째 Excel을 선택해주세요";
            //Excel2.Filter = "Excel 파일(*.xlsx)|*.xlsx;";

            DialogResult Excel2_result = Excel2.ShowDialog();

            if (Excel2_result == DialogResult.OK)            //파일 선택 시
            {
                //File명과 확장자를 가지고 온다
                Excel2_fileName = Excel2.SafeFileName;
                //File경로와 File명을 모두 가지고 온다
                Excel2_fileFullName = Excel2.FileName;
                //File경로만 가지고 온다
                Excel2_filePath = Excel2_fileFullName.Replace(Excel2_fileName, "");

                excel2_Name.Text = "파일 이름 : " + Excel2_fileName;
                excel2_Path.Text = "파일 경로 : " + Excel2_filePath;
                button_excel2.Text = check_filename(excel2_Name.Text);
                if (button_excel2.Text == "ERROR")
                {
                    MessageBox.Show("잘못된 파일입니다. 다시 선택해주세요");
                    button_excel2_Click(sender, e);
                }
            }

            else if (Excel2_result == DialogResult.Cancel)//취소버튼 또는 ESC로 파일 창 종료시
            {

            }
        }

        private void button_excel3_Click(object sender, EventArgs e)
        {
            OpenFileDialog Excel3 = new OpenFileDialog();
            Excel3.Title = "세번째 Excel을 선택해주세요";
            //Excel3.Filter = "Excel 파일(*.xlsx)|*.xlsx;";

            DialogResult Excel3_result = Excel3.ShowDialog();

            if (Excel3_result == DialogResult.OK)            //파일 선택 시
            {
                //File명과 확장자를 가지고 온다
                Excel3_fileName = Excel3.SafeFileName;
                //File경로와 File명을 모두 가지고 온다
                Excel3_fileFullName = Excel3.FileName;
                //File경로만 가지고 온다
                Excel3_filePath = Excel3_fileFullName.Replace(Excel3_fileName, "");

                excel3_Name.Text = "파일 이름 : " + Excel3_fileName;
                excel3_Path.Text = "파일 경로 : " + Excel3_filePath;
                button_excel3.Text = check_filename(excel3_Name.Text);
                if (button_excel3.Text == "ERROR")
                {
                    MessageBox.Show("잘못된 파일입니다. 다시 선택해주세요");
                    button_excel3_Click(sender, e);
                }
            }

            else if (Excel3_result == DialogResult.Cancel)//취소버튼 또는 ESC로 파일 창 종료시
            {

            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            int index_num = 0; double max = 0; double[] discount = new double[100];
            if (Won_LastMonth.Text == "" || Convert.ToInt32(Won_LastMonth.Text) < 0)
            {
                MessageBox.Show("전월실적을 입력해주세요"); return;
            }
            ProgressIndicator.Visible = true;
            if (button_excel2.Visible == false)//excel 1개
                Save_Data_Excel(1, 0, 0);
            else if (button_excel3.Visible == false)//excel 2개
                Save_Data_Excel(1, 1, 0);
            else//excel 3개
                Save_Data_Excel(1, 1, 1);
            AVG = Convert.ToInt32(Won_LastMonth.Text);

            //객체 생성
            //국민
            chungchundarto = new KB_Chungchundaero(AVG);
            hoon = new KB_Hoon(AVG);
            min = new KB_Min(AVG);
            jung = new KB_Jung(AVG);
            eum = new KB_Eum(AVG);
            gaon = new KB_Gaon(AVG);
            star = new KB_Star(AVG);
            juniorlife = new KB_Juniorlife(AVG);
            between = new KB_Between(AVG);

            //우리
            hangbok = new UR_Hangbok(AVG);
            naman = new UR_Naman(AVG);
            uri = new UR_Uri(AVG);
            baedal = new UR_Baedal(AVG);
            hyundae = new UR_Hyundae(AVG);
            lotte = new UR_Lotte(AVG);
            lg = new UR_Lg(AVG);
            pop = new UR_Pop(AVG);
            uni = new UR_Uni(AVG);
            wibee = new UR_Wibee(AVG);

            //신한
            sline = new SH_Sline(AVG);
            schoice_shopping = new SH_Schoice_shopping(AVG);
            schoice_traffic = new SH_Schoice_traffic(AVG);
            schoice_coffe = new SH_Schoice_coffee(AVG);
            bigpluse = new SH_BigPluse(AVG);
            s20 = new SH_S20(AVG);
            s20pink = new SH_S20Pink(AVG);
            s2030 = new SH_2030(AVG);
            yogiyo = new SH_yogiyo(AVG);

            //하나
            toxalpha = new HN_toXalpha(AVG);
            wingp = new HN_wingp(AVG);

            //기업
            myalpha = new IBK_myAlpha(AVG);
            savezone = new IBK_savezone(AVG);
            enjoy_everyday = new IBK_enjoy_everyday_life(AVG);
            culture_yungsung = new IBK_culture_Yungsung(AVG);
            daiso = new IBK_daiso(AVG);

            //문자열 탐색을 이용해 새로운 list 생성
            CARD card = FIND(Excel_Use, Excel_Won);
            

            //card 객체를 Map_Dictionary로 보내어 모든 리스트를 읽게 한다.
            for(int i = 0; i < card.BUYLIST.Count; i++)
            {
                judge_cate(card.BUYLIST[i], card.MONEY[i]);
            }


            //객체별 배열 저장
            discount[0] = chungchundarto.discount();
            discount[1] = hoon.discount();
            discount[2] = min.discount();
            discount[3] = jung.discount();
            discount[4] = eum.discount();
            discount[5] = gaon.discount();
            discount[6] = star.discount();
            discount[7] = juniorlife.discount();
            discount[8] = between.discount();
            discount[9] = hangbok.discount();
            discount[10] = naman.discount();
            discount[11] = uri.discount();
            discount[12] = baedal.discount();
            discount[13] = hyundae.discount();
            discount[14] = lotte.discount();
            discount[15] = lg.discount();
            discount[16] = pop.discount();
            discount[17] = uni.discount();
            discount[18] = wibee.discount();
            discount[19] = sline.discount();
            discount[20] = schoice_shopping.discount();
            discount[21] = schoice_traffic.discount();
            discount[22] = schoice_coffe.discount();
            discount[23] = bigpluse.discount();
            discount[24] = s20.discount();
            discount[25] = s20pink.discount();
            discount[26] = s2030.discount();
            discount[27] = yogiyo.discount();
            discount[28] = toxalpha.discount();
            discount[29] = wingp.discount();
            discount[30] = myalpha.discount();
            discount[31] = savezone.discount();
            discount[32] = enjoy_everyday.discount();
            discount[33] = culture_yungsung.discount();
            discount[34] = daiso.discount();

            //for문으로 가장 할인 값이 큰 배열을 찾은 후 해당 인덱스 저장
            for(int i = 0; i < 35; i++)
            {
                if (discount[i] > max) { max = discount[i]; index_num = i; }
            }

            ProgressIndicator.Visible = false;
            card_Name.Visible = true;
            card_Discount.Visible = true;
            switch (index_num)
            {
                case 0:
                    card_Name.Text = chungchundarto.name;
                    card_Discount.Text = chungchundarto.print();
                    break;
                case 1:
                    card_Name.Text = hoon.name;
                    card_Discount.Text = hoon.print();
                    break;
                case 2:
                    card_Name.Text = min.name;
                    card_Discount.Text = min.print();
                    break;
                case 3:
                    card_Name.Text = jung.name;
                    card_Discount.Text = jung.print();
                    break;
                case 4:
                    card_Name.Text = eum.name;
                    card_Discount.Text = eum.print();
                    break;
                case 5:
                    card_Name.Text = gaon.name;
                    card_Discount.Text = gaon.print();
                    break;
                case 6:
                    card_Name.Text = star.name;
                    card_Discount.Text = star.print();
                    break;
                case 7:
                    card_Name.Text = juniorlife.name;
                    card_Discount.Text = juniorlife.print();
                    break;
                case 8:
                    card_Name.Text = between.name;
                    card_Discount.Text = between.print();
                    break;
                case 9:
                    card_Name.Text = hangbok.name;
                    card_Discount.Text = hangbok.print();
                    break;
                case 10:
                    card_Name.Text = naman.name;
                    card_Discount.Text = naman.print();
                    break;
                case 11:
                    card_Name.Text = uri.name;
                    card_Discount.Text = uri.print();
                    break;
                case 12:
                    card_Name.Text = baedal.name;
                    card_Discount.Text = baedal.print();
                    break;
                case 13:
                    card_Name.Text = hyundae.name;
                    card_Discount.Text = hyundae.print();
                    break;
                case 14:
                    card_Name.Text = lotte.name;
                    card_Discount.Text = lotte.print();
                    break;
                case 15:
                    card_Name.Text = lg.name;
                    card_Discount.Text = lg.print();
                    break;
                case 16:
                    card_Name.Text = pop.name;
                    card_Discount.Text = pop.print();
                    break;
                case 17:
                    card_Name.Text = uni.name;
                    card_Discount.Text = uni.print();
                    break;
                case 18:
                    card_Name.Text = wibee.name;
                    card_Discount.Text = wibee.print();
                    break;
                case 19:
                    card_Name.Text = sline.name;
                    card_Discount.Text = sline.print();
                    break;
                case 20:
                    card_Name.Text = schoice_shopping.name;
                    card_Discount.Text = schoice_shopping.print();
                    break;
                case 21:
                    card_Name.Text = schoice_traffic.name;
                    card_Discount.Text = schoice_traffic.print();
                    break;
                case 22:
                    card_Name.Text = schoice_coffe.name;
                    card_Discount.Text = schoice_coffe.print();
                    break;
                case 23:
                    card_Name.Text = bigpluse.name;
                    card_Discount.Text = bigpluse.print();
                    break;
                case 24:
                    card_Name.Text = s20.name;
                    card_Discount.Text = s20.print();
                    break;
                case 25:
                    card_Name.Text = s20pink.name;
                    card_Discount.Text = s20pink.print();
                    break;
                case 26:
                    card_Name.Text = s2030.name;
                    card_Discount.Text = s2030.print();
                    break;
                case 27:
                    card_Name.Text = yogiyo.name;
                    card_Discount.Text = yogiyo.print();
                    break;
                case 28:
                    card_Name.Text = toxalpha.name;
                    card_Discount.Text = toxalpha.print();
                    break;
                case 29:
                    card_Name.Text = wingp.name;
                    card_Discount.Text = wingp.print();
                    break;
                case 30:
                    card_Name.Text = myalpha.name;
                    card_Discount.Text = myalpha.print();
                    break;
                case 31:
                    card_Name.Text = savezone.name;
                    card_Discount.Text = savezone.print();
                    break;
                case 32:
                    card_Name.Text = enjoy_everyday.name;
                    card_Discount.Text = enjoy_everyday.print();
                    break;
                case 33:
                    card_Name.Text = culture_yungsung.name;
                    card_Discount.Text = culture_yungsung.print();
                    break;
                case 34:
                    card_Name.Text = daiso.name;
                    card_Discount.Text = daiso.print();
                    break;
            }
            iTalk_Label2.Visible = true;
            iTalk_Label3.Visible = true;
            iTalk_Label4.Visible = true;
            iTalk_TextBox_Small1.Text = Convert.ToString(card.kmp_get());
            iTalk_TextBox_Small2.Text = Convert.ToString(card.sunday_get());
            iTalk_TextBox_Small3.Text = Convert.ToString(card.brute_get());
            iTalk_TextBox_Small1.Visible = true;
            iTalk_TextBox_Small2.Visible = true;
            iTalk_TextBox_Small3.Visible = true;
        }
    }
}
