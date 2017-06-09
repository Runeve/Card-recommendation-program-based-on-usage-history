using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Algol_card
{
    public partial class Form1 : Form
    {
        static int oil_price = 1200;

        public class KB_Chungchundaero
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 청춘대로 싱글 체크카드"; public string print_Card = "";
            public KB_Chungchundaero(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 9; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  편의점   - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "  다이소   - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "소셜커머스 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += " 해외결제  - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   택시    - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += " 대중쿄통  - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += "올리브영, 박철 - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += " 동물병원  - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                print_Card += "여행, 투어 - 할인액 : " + total[8] + "원 / 할인 회수 : " + total_count[8] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 9; i++) won += total[i]; return won; }
            public void convenience(int won)//편의점 - total[0]
            {
                if (won < 10000) return;
                if (AVG < 300000) return;
                else if (AVG < 500000) { if (total[0] < 5000) { if (won > 10000) { if (won < 20000) total[0] += won * 0.05; else total[0] += 1000; total_count[0]++; } } if (total[0] > 5000) total[0] = 5000; }
                else { if (total[0] < 10000) { if (won > 10000) { if (won < 20000) total[0] += won * 0.05; else total[0] += 1000; total_count[0]++; } } if (total[0] > 10000) total[0] = 10000; }
            }
            public void daiso(int won)//다이소 - total[1]
            {
                if (won < 10000) return; if (AVG < 300000) return;
                else if (AVG < 500000) { if (total[1] < 5000) { if (won < 20000) total[1] += won * 0.05; else total[1] += 1000; total_count[1]++; } if (total[1] > 5000) total[1] = 5000; }
                else { if (total[1] < 10000) { if (won < 20000) total[1] += won * 0.05; else total[1] += 1000; total_count[1]++; } if (total[1] > 10000) total[1] = 10000; }
            }
            public void shopping(int won)//쿠팡, 티몬, 위메프 - total[2]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                else if (AVG < 500000) { if (total[2] < 5000) { if (won < 50000) total[2] += won * 0.05; else total[2] += 2500; total_count[2]++; } if (total[2] > 5000) total[2] = 5000; }
                else { if (total[2] < 10000) { if (won < 50000) total[2] += won * 0.05; else total[2] += 2500; total_count[2]++; } if (total[2] > 10000) total[2] = 10000; }
            }
            public void foreign(int won)//해외 - total[3]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (total[3] < 5000) { total[3] += won * 0.05; }
                if (total[3] > 5000) total[2] = 5000; total_count[3]++;
            }
            public void taxi(int won)//택시 - total[4]
            {
                if (AVG < 300000) return; if (won < 5000) return;
                if (total[4] < 3000) { if (won < 20000) total[4] += won * 0.05; else total[4] += 1000; total_count[4]++; }
                if (total[4] > 2000) total[4] = 2000;
            }
            public void traffic(int won)//대중교통 - total[5]
            {
                if (AVG < 300000) return;
                if (total[5] < 20000) { total[5] += won * 0.05; total_count[5]++; }
                if (total[5] > 2000) total[5] = 2000;
            }
            public void beauty(int won)//올리브영, 박승철헤어스튜디오 - total[6]
            {
                if (won < 30000) return; if (AVG < 500000) return;
                if (total[6] < 10000) { if (won < 50000) total[6] += won * 0.1; else total[6] += 50000; total_count[6]++; if (total[6] > 10000) total[6] = 10000; }
            }
            public void pet(int won)//동물병원/애완동물 - total[7]
            {
                if (won < 30000) return; if (AVG < 500000) return;
                if (total[7] < 10000) { if (won < 50000) total[7] += won * 0.1; else total[7] += 50000; total_count[7]++; if (total[7] > 10000) total[7] = 10000; }
            }
            public void travle(int won)//여행(하나투어, 모두투어) - total[8]
            {
                total[8] += won * 0.03; total_count[8]++;
            }
        }


        public class KB_Hoon
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 훈체크카드"; public string print_Card = "";
            public KB_Hoon(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  학원   - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "  서점   - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "동물병원 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "  약국   - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "대중교통 - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void academe(int won)//학원 - total[0]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[0] < 5000) { total[0] += won * 0.07; total_count[0]++; } if (total[0] > 5000) total[0] = 5000; }
                else { if (total[0] < 10000) { total[0] += won * 0.07; total_count[0]++; } if (total[0] > 10000) total[0] = 10000; }
            }
            public void book(int won)//서점 - total[1]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[1] < 5000) { total[1] += won * 0.05; total_count[1]++; } if (total[1] > 5000) total[1] = 5000; }
                else { if (total[1] < 10000) { total[1] += won * 0.05; total_count[1]++; } if (total[1] > 10000) total[1] = 10000; }
            }
            public void pet(int won)//동물별원 - total[2]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[2] < 5000) { total[2] += won * 0.05; total_count[2]++; } if (total[2] > 5000) total[2] = 5000; }
                else { if (total[2] < 10000) { total[2] += won * 0.05; total_count[2]++; } if (total[2] > 10000) total[2] = 10000; }
            }
            public void pharmacy(int won)//약국 - total[3]
            {
                if (won < 30000) return; if (AVG < 500000) return;
                if (total[3] < 5000) { total[3] += won * 0.05; total_count[3]++; if (total[3] > 5000) total[3] = 5000; }
            }
            public void traffic(int won)//대중쿄통 - total[4]
            {
                if (AVG < 300000) return;
                if (total[4] < 1500) { total[4] += won * 0.05; total[4]++; if (total[4] > 1500) total[4] = 1500; }
            }
        }

        public class KB_Min
        {
            List<double> total; int AVG;
            List<int> total_count; List<double> use_limit;
            public string name = "국민 민체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public KB_Min(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                use_limit = new List<double>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); use_limit.Add(0); }
                AVG = avg;
                if (AVG > 300000 && AVG < 500000) limit = 10000; else if (AVG > 500000) limit = 20000;
            }
            public string print()
            {
                print_Card += " 대형마트  - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "   주유    - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "패스트푸드 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += " 통신요금  - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += " 대중교통  - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void mart(int won)//대형마트 - total[0]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (use_limit[0] < 100000 && use_limit[0] + won < 100000)
                    {
                        if (pre_limit + won * 0.05 <= limit) { total[0] += won * 0.05; use_limit[0] += won; pre_limit += won * 0.05; total_count[0]++; }
                        else { total[0] += limit - pre_limit; use_limit[0] += (limit - pre_limit) * 20; total_count[0]++; }
                    }
                    else if (use_limit[0] < 100000 && use_limit[0] + won > 100000)
                    {
                        if (pre_limit + (100000 - use_limit[0]) * 0.05 < limit) { total[0] += (100000 - use_limit[0]) * 0.05; use_limit[0] = 100000; pre_limit += (100000 - use_limit[0]) * 0.05; total_count[0]++; }
                        else { total[0] += limit - pre_limit; use_limit[0] += (limit - pre_limit) * 20; total_count[0]++; }
                    }
                }
            }
            public void oil(int won)//주유 - total[1]
            {
                if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (use_limit[1] < 300000 && use_limit[1] + won < 300000)
                    {
                        if (pre_limit + (won / oil_price) * 60 <= limit) { total[1] += (won / oil_price) * 60; use_limit[1] += won; pre_limit += (won / oil_price) * 60; total_count[1]++; }
                        else { total[1] += limit - pre_limit; use_limit[1] += (limit - pre_limit) * 20; total_count[1]++; }
                    }
                    else if (use_limit[1] < 300000 && use_limit[1] + won > 300000)
                    {
                        if (pre_limit + ((300000 - use_limit[1]) / oil_price) * 60 < limit) { total[1] += ((300000 - use_limit[1]) / oil_price) * 60; use_limit[1] = 300000; pre_limit += ((300000 - use_limit[1]) / oil_price) * 60; total_count[1]++; }
                        else { total[1] += limit - pre_limit; use_limit[1] += (limit - pre_limit) * 20; total_count[1]++; }
                    }
                }

            }
            public void fastfood(int won)//패스트푸드 - total[2]
            {
                if (won < 10000) return; if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (use_limit[2] < 100000 && use_limit[2] + won < 100000)
                    {
                        if (pre_limit + won * 0.1 <= limit) { total[2] += won * 0.1; use_limit[2] += won; pre_limit += won * 0.1; total_count[2]++; }
                        else { total[2] += limit - pre_limit; use_limit[2] += (limit - pre_limit) * 20; total_count[2]++; }
                    }
                    else if (use_limit[2] < 100000 && use_limit[2] + won > 100000)
                    {
                        if (pre_limit + (100000 - use_limit[2]) * 0.1 < limit) { total[2] += (100000 - use_limit[2]) * 0.1; use_limit[2] = 100000; pre_limit += (100000 - use_limit[2]) * 0.1; total_count[2]++; }
                        else { total[2] += limit - pre_limit; use_limit[2] += (limit - pre_limit) * 10; total_count[2]++; }
                    }
                }
            }
            public void mobile(int won)//이동통신요금 - total[3]
            {
                if (won < 50000) return; if (AVG < 300000) return;
                if (use_limit[3] < 50000) { total[3] += 2500; total_count[3]++; use_limit[3] = 50000; }
            }
            public void traffic(int won)//대중교통 - total[4]
            {
                if (AVG < 300000) return;
                if (use_limit[4] < 30000) { total[3] += won * 0.05; total_count[4]++; use_limit[4] += won; }
            }
        }

        public class KB_Jung
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 정체크카드"; public string print_Card = "";
            public KB_Jung(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 6; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += " 대형마트  - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "   홈쇼핑  - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "온라인쇼핑 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "    해외   - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "    뷰티   - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += " 대중교통  - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 6; i++) won += total[i]; return won; }
            public void mart(int won)//대형마트 - total[0]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[0] < 5000) { if (won > 100000) won = 100000; total[0] += won * 0.07; total_count[0]++; if (total[0] > 5000) total[0] = 5000; } }
                else { if (total[0] < 10000) { if (won > 100000) won = 100000; total[0] += won * 0.07; total_count[0]++; if (total[0] > 10000) total[0] = 10000; } }
            }
            public void homeshopping(int won)//홈쇼핑 - total[1]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[1] < 5000) { if (won > 100000) won = 100000; total[1] += won * 0.05; total_count[1]++; if (total[1] > 5000) total[1] = 5000; } }
                else { if (total[1] < 10000) { if (won > 100000) won = 100000; total[1] += won * 0.05; total_count[1]++; if (total[1] > 10000) total[1] = 10000; } }
            }
            public void onlineshopping(int won)//온라인쇼핑 - total[2]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[2] < 5000) { if (won > 50000) won = 50000; total[2] += won * 0.05; total_count[2]++; if (total[2] > 5000) total[2] = 5000; } }
                else { if (total[2] < 10000) { if (won > 50000) won = 50000; total[2] += won * 0.05; total_count[2]++; if (total[2] > 10000) total[2] = 10000; } }
            }
            public void foreign(int won)//해외 - total[3]
            {
                if (won < 30000) return; if (AVG < 300000) return;
                if (total[3] < 5000) { if (won > 100000) won = 100000; total[3] += won * 0.05; total_count[3]++; if (total[3] > 5000) total[3] = 5000; }
            }
            public void beauty(int won)//뷰티 - total[4]
            {
                if (won < 30000) return; if (AVG < 500000) return;
                if (total[4] < 10000) { if (won > 100000) won = 100000; total[4] += won * 0.05; total_count[4]++; if (total[4] > 10000) total[4] = 10000; }
            }
            public void traffic(int won)//대중교통 - total[5]
            {
                if (AVG < 300000) return;
                if (won > 30000) won = 30000;
                if (total[5] < 1500) { total[5] += won * 0.05; total_count[5]++; }
            }
        }

        public class KB_Eum
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "음 체크카드"; public string print_Card = "";
            public KB_Eum(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 3; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  커피   - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "  제과   - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "대중교통 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 3; i++) won += total[i]; return won; }
            public void coffee(int won)//커피 - total[0]
            {
                if (won < 10000) return; if (AVG < 300000) return;
                if (AVG < 500000) { if (total[0] < 5000) { if (won > 50000) won = 50000; total[0] += won * 0.05; total_count[0]++; if (total[0] > 5000) total[0] = 5000; } }
                else { if (total[0] < 10000) { if (won > 50000) won = 50000; total[0] += won * 0.05; total_count[0]++; if (total[0] < 10000) total[0] = 10000; } }
            }
            public void snack(int won)//제과, 아이스크림 - total[1]
            {
                if (won < 10000) return; if (AVG < 500000) return;
                if (total[1] < 10000) { if (won > 50000) won = 50000; total[1] += won * 0.05; total_count[1]++; if (total[1] > 10000) total[1] = 10000; }
            }
            public void traffic(int won)//대중교통 - total[2]
            {
                if (AVG < 300000) return;
                if (total[2] < 1500) { total[2] += won * 0.05; total_count[2]++; if (total[2] > 1500) total[2] = 1500; }
            }
        }


        public class KB_Gaon
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 가온체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public KB_Gaon(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 8; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 300000) limit = 10000; else if (AVG < 500000) limit = 20000; else if (AVG < 1000000) limit = 30000; else limit = 50000;
            }
            public string print()
            {
                print_Card += "      CGV      - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += " 아웃백, VIPS  - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "   스타벅스    - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += " 에버,롯데월드 - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "     GS25      - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "   교보문고    - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += "   대중교통    - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += "   통신요금    - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 8; i++) won += total[i]; return won; }
            public void CGV(int won)
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.35 < limit) { total[0] += won * 0.35; total_count[0]++; pre_limit += won * 0.35; }
                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void restaurant(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.2 < limit) { total[1] += won * 0.2; total_count[1]++; pre_limit += won * 0.2; }
                    else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void starbucks(int won)
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.2 < limit) { total[2] += won * 0.2; total_count[2]++; pre_limit += won * 0.2; }
                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void ever_lotteworld(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.5 < limit) { total[3] += won * 0.5; total_count[3]++; pre_limit += won * 0.5; }
                    else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void GS25(int won)
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[4] += won * 0.05; total_count[4]++; pre_limit += won * 0.05; }
                    else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
            public void gyobo(int won)
            {
                if (won < 20000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.05 < limit) { total[5] += won * 0.05; total_count[5]++; pre_limit += won * 0.05; }
                    else { total[5] += limit - pre_limit; total_count[5]++; pre_limit = limit; }
                }
            }
            public void traffic(int won)
            {
                if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (total[6] * 10 < 20000)
                    {
                        if (pre_limit + won * 0.1 < limit) { total[6] += won * 0.1; total_count[6]++; pre_limit += won * 0.1; }
                        else { total[6] += limit - pre_limit; total_count[6]++; pre_limit = limit; }
                    }
                }
            }
            public void mobile(int won)
            {
                if (won < 50000) return; if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + 2500 < limit) { total[7] = 2500; total_count[7]++; pre_limit += 2500; }
                    else { total[7] = limit - pre_limit; total_count[7]++; pre_limit = limit; }
                }
            }
        }

        public class KB_Star
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 스타체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public KB_Star(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 9; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 300000) limit = 5000; else if (AVG < 500000) limit = 10000; else if (AVG < 1000000) limit = 20000; else limit = 50000;
            }
            public string print()
            {
                print_Card += "  GS칼텍스  - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "  에버랜드  - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "아웃백,vips - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "    CGV     - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "  교보문고  - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "  올리브영  - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += " 온라인쇼핑 - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += "  대중교통  - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                print_Card += "  이동통신  - 할인액 : " + total[8] + "원 / 할인 회수 : " + total_count[8] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 9; i++) won += total[i]; return won; }
            public void gsoil(int won)
            {
                if (total[0] * 70000 > 300000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 100000) won = 100000; if (pre_limit + (won / oil_price) * 50 < limit) { total[0] += won / oil_price * 50; total_count[0]++; pre_limit += won / oil_price * 50; }
                                                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void everland(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.5 < limit) { total[1] += won * 0.5; total_count[1]++; pre_limit += won * 0.5; }
                                                  else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void restaurant(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 100000) won = 100000; if (pre_limit + won * 0.1 < limit) { total[2] += won * 0.1; total_count[1]++; pre_limit += won * 0.1; }
                                                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void cgv(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + 3000 < limit) { total[3] += 3000; total_count[3]++; pre_limit += 3000; } else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void gyobo(int won)
            {
                if (won < 20000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.03 < limit) { total[4] += won * 0.03; total_count[4]++; pre_limit += won * 0.03; }
                                                  else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
            public void oliveyoung(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.05 < limit) { total[5] += won * 0.05; total_count[5]++; pre_limit += won * 0.05; }
                                                  else { total[5] += limit - pre_limit; total_count[5]++; pre_limit = limit; }
                }
            }
            public void onlineshopping(int won)
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 100000) won = 100000; if (pre_limit + won * 0.03 < limit) { total[6] += won * 0.03; total_count[6]++; pre_limit += won * 0.03; }
                                                    else { total[6] += limit - pre_limit; total_count[6]++; pre_limit = limit; }
                }
            }
            public void traffic(int won)
            {
                if (AVG < 300000) return; if (total[7] * 20 > 20000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.05 < limit) { total[7] += won * 0.05; total_count[7]++; pre_limit += won * 0.05; }
                    else { total[7] = limit - pre_limit; total_count[7]++; pre_limit = limit; }
                }
            }
            public void mobile(int won)
            {
                if (won < 50000) return; if (AVG < 300000) return; if (total[8] != 0) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + 2500 < limit) { total[8] = 2500; total_count[8]++; pre_limit += 2500; }
                    else { total[8] = limit - pre_limit; total_count[8]++; pre_limit = limit; }
                }
            }
        }

        public class KB_Juniorlife
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 주니어라이프체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public KB_Juniorlife(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 8; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 300000) limit = 10000; else limit = 20000;
            }
            public string print()
            {
                print_Card += "   레스토랑   - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "     영화     - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "   놀이공원   - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "    커피빈    - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   제주항공   - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "올리브영,박철 - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += "   교보문고   - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += "     GS25     - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 8; i++) won += total[i]; return won; }
            public void restaurant(int won)//아웃백, vips, TGIF, 세븐스프링스
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.1 < limit) { total[0] += won * 0.1; total_count[0]++; pre_limit += won * 0.1; }
                                                  else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void movie(int won)//cgv, 메가박스
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.2 < limit) { total[1] += won * 0.2; total_count[1]++; pre_limit += won * 0.2; }
                                                  else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void amusementpark(int won)//에버랜드, 롯데월드, 서울랜드
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.3 < limit) { total[2] += won * 0.3; total_count[1]++; pre_limit += won * 0.3; }
                                                  else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void coffeebin(int won)//커피빈
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[3] += won * 0.05; total_count[3]++; pre_limit += won * 0.05; }
                                                  else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void jejuair(int won)//제주항공
            {
                if (won < 50000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 100000) won = 100000; if (pre_limit + won * 0.1 < limit) { total[4] += won * 0.1; total_count[4]++; pre_limit += won * 0.1; }
                                                    else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
            public void beauty(int won)//올리브영, 박철헤어스투디오
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.1 < limit) { total[5] += won * 0.1; total_count[5]++; pre_limit += won * 0.1; }
                                                  else { total[5] += limit - pre_limit; total_count[5]++; pre_limit = limit; }
                }
            }
            public void gyobo(int won)//교보문고
            {
                if (won < 20000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.03 < limit) { total[6] += won * 0.03; total_count[6]++; pre_limit += won * 0.03; }
                                                  else { total[6] += limit - pre_limit; total_count[6]++; pre_limit = limit; }
                }
            }
            public void gs25(int won)//gs25
            {
                if (won < 10000) return; if (AVG < 200000) return; 
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[7] += won * 0.05; total_count[7]++; pre_limit += won * 0.05; }
                                                  else { total[7] = limit - pre_limit; total_count[7]++; pre_limit = limit; }
                }
            }
        }

        public class KB_Between
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "국민 비트윈체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public KB_Between(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 9; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 300000) limit = 10000; else limit = 20000;
            }
            public string print()
            {
                print_Card += "   레스토랑   - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "     영화     - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "   놀이공원   - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "    커피빈    - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   제주항공   - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "올리브영,박철 - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += "   교보문고   - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += "     GS25     - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                print_Card += "   대중교통   - 할인액 : " + total[8] + "원 / 할인 회수 : " + total_count[8] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 9; i++) won += total[i]; return won; }
            public void restaurant(int won)//아웃백, vips, TGIF, 세븐스프링스
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.1 < limit) { total[0] += won * 0.1; total_count[0]++; pre_limit += won * 0.1; }
                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void movie(int won)//cgv, 메가박스
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.2 < limit) { total[1] += won * 0.2; total_count[1]++; pre_limit += won * 0.2; }
                    else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void amusementpark(int won)//에버랜드, 롯데월드, 서울랜드
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.3 < limit) { total[2] += won * 0.3; total_count[1]++; pre_limit += won * 0.3; }
                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void coffeebin(int won)//커피빈
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[3] += won * 0.05; total_count[3]++; pre_limit += won * 0.05; }
                    else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void jejuair(int won)//제주항공
            {
                if (won < 50000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 100000) won = 100000; if (pre_limit + won * 0.1 < limit) { total[4] += won * 0.1; total_count[4]++; pre_limit += won * 0.1; }
                    else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
            public void beauty(int won)//올리브영, 박철헤어스투디오
            {
                if (won < 30000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.1 < limit) { total[5] += won * 0.1; total_count[5]++; pre_limit += won * 0.1; }
                    else { total[5] += limit - pre_limit; total_count[5]++; pre_limit = limit; }
                }
            }
            public void gyobo(int won)//교보문고
            {
                if (won < 20000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.03 < limit) { total[6] += won * 0.03; total_count[6]++; pre_limit += won * 0.03; }
                    else { total[6] += limit - pre_limit; total_count[6]++; pre_limit = limit; }
                }
            }
            public void gs25(int won)//gs25
            {
                if (won < 10000) return; if (AVG < 200000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[7] += won * 0.05; total_count[7]++; pre_limit += won * 0.05; }
                    else { total[7] = limit - pre_limit; total_count[7]++; pre_limit = limit; }
                }
            }
            public void traffic(int won)//대중교통
            {
                if (AVG < 300000) return; if (total[8] * 20 > 20000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.05 < limit) { total[8] += won * 0.05; total_count[8]++; pre_limit += won * 0.05; }
                    else { total[8] += limit - pre_limit; total_count[8]++; pre_limit = limit; }
                }
            }
        }

        public class UR_Hangbok
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 행복체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public UR_Hangbok(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 6; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 600000) limit = 5000; else if (AVG < 1200000) limit = 7000; else limit = 10000;
            }
            public string print()
            {
                print_Card += "   병원    - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "온라인쇼핑 - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "   커피    - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += " 레스토랑  - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += " 이동통신  - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += " 대중교통  - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 6; i++) won += total[i]; return won; }
            public void hostipal(int won)//병원 - total[0]
            {
                if (AVG < 300000) return; if (total[0] >= 15000) return; if (total_count[0] > 1) return;
                if (pre_limit < limit)
                {
                    if (won > 500000) won = 500000; if (pre_limit + won * 0.1 < limit) { total[0] += won * 0.1; total_count[0]++; pre_limit += won * 0.1; }
                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void onlineshopping(int won)//온라인쇼핑 - total[1]
            {
                if (won < 30000) return; if (AVG < 300000) return; if (total_count[1] > 1) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.03 < limit) { total[1] += won * 0.03; total_count[1]++; pre_limit += won * 0.03; }
                    else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void coffee(int won)//커피 - total[2]
            {
                if (won < 10000) return; if (AVG < 300000) return; if (total_count[2] > 3) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.1 < limit) { total[2] += won * 0.1; total_count[2]++; pre_limit += won * 0.1; }
                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void restaurant(int won)//레스토랑 - total[3]
            {
                if (total_count[3] > 0) return; if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.05 < limit) { total[3] += won * 0.05; total_count[3]++; pre_limit += won * 0.05; }
                    else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void mobile(int won)//이동통신할인 - total[4]
            {
                if (total_count[4] > 0) return; if (AVG < 300000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + 1000 < limit) { total[4] += 1000; total_count[4]++; pre_limit += 1000; }
                    else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
            public void traffic(int won)//대중교통 - total[5]
            {
                if (AVG < 300000) return; if (total[5] >= 1500) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.05 < limit) { total[5] += won * 0.05; total_count[5]++; pre_limit += won * 0.05; if (total[5] > 1500) total[5] = 1500; }
                    else { total[5] += limit - pre_limit; total_count[5]++; pre_limit = limit; if (total[5] > 1500) total[5] = 1500; }
                }
            }
        }

        public class UR_Naman
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 나만의체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public UR_Naman(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 1000000) limit = 10000; else if (AVG < 2000000) limit = 20000; else limit = 30000;
            }
            public string print()
            {
                print_Card += " 대형마트  - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "  백화점   - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "온라인쇼핑 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "  영화관   - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += " 놀이공원  - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void mart(int won)//대형마트 - total[0]
            {
                if (AVG < 500000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.1 < limit) { total[0] += won * 0.1; total_count[0]++; pre_limit += won * 0.1; }
                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void department(int won)//백화점 - total[1]
            {
                if (AVG < 500000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.1 < limit) { total[1] += won * 0.1; total_count[1]++; pre_limit += won * 0.1; }
                    else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void onlineshopping(int won)//온라인쇼핑- total[2]
            {
                if (AVG < 500000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.1 < limit) { total[2] += won * 0.1; total_count[2]++; pre_limit += won * 0.1; }
                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void movie(int won)//영화관 - total[3]
            {
                if (total_count[3] > 0) return; if (AVG < 500000) return; if (won < 12000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + 3000 < limit) { total[3] += 3000; total_count[3]++; pre_limit += 3000; }
                    else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void amusement(int won)//놀이공원 - total[4]
            {
                if (total_count[4] > 0) return; if (AVG < 500000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.5 < limit) { total[4] += won * 0.5; total_count[4]++; pre_limit += won * 0.5; }
                    else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
        }

        public class UR_Uri
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 아이행복체크카드"; public string print_Card = "";
            public UR_Uri(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                if (total[1] >= 30000) { total[1] = 1500; }
                print_Card += "  병원   - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "대중교통 - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "놀이공원 - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "레스토랑 - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "  커피   - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void hospital(int won)//병원 - total[0]
            {
                if (total_count[0] > 1) return; if (won < 10000) return;
                total[0] += won * 0.05; total_count[0]++;
            }
            public void traffic(int won)//대중교통 - total[1]
            {
                if (total[1] >= 30000) return;
                total[1] += won; total_count[1]++;
            }
            public void amusement(int won)//놀이공원- total[2]
            {
                if (total_count[2] > 0) return;
                total[2] += won * 0.5; total[2]++;
            }
            public void restaurant(int won)//레스토랑 - total[3]
            {
                if (total[3] >= 20000) return;
                total[3] += won * 0.1; total_count[3]++; if (total[3] > 20000) total[3] = 20000;
            }
            public void coffee(int won)//커피 - total[4]
            {
                if (total_count[4] > 1) return; if (total[4] >= 5000) return;
                total[4] += won * 0.2; total_count[4]++; if (total[4] > 5000) total[4] = 5000;
            }
        }

        public class UR_Baedal
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 배달의민족체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public UR_Baedal(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 8; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 500000) limit = 11000; else if (AVG < 700000) limit = 20000; else limit = 30000;
            }
            public string print()
            {
                print_Card += "배달의민족 - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "온라인쇼핑 - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += " 스타벅스  - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "   제과    - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   영화    - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "   학원    - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += " 대중교통  - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += " 이동통신  - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                return print_Card;
            }
            public double discount() {
                if (total[6] >= 50000) { if (pre_limit < limit) { if (pre_limit + 2000 < limit) total[6] = 2000; else total[6] = limit - pre_limit; } else { total[6] = 0; total_count[6] = 0; } }
                if (total[7] >= 50000) { if (pre_limit < limit) { if (pre_limit + 3000 < limit) total[7] = 3000; else total[7] = limit - pre_limit; } else { total[7] = 0; total_count[7] = 0; } }
                double won = 0; for (int i = 0; i < 8; i++) won += total[i]; return won; }
            public void baemin(int won)//배달의 민족 - total[0]
            {
                if (AVG < 250000) return; if (total_count[0] > 2) return; if (total[0] >= 11000) return;
                if (pre_limit < limit)
                {
                    if (pre_limit + won * 0.2 < limit) { total[0] += won * 0.2; total_count[0]++; pre_limit += won * 0.2; if (total[0] >= 11000) total[0] = 11000; }
                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; if (total[0] >= 11000) total[0] = 11000; }
                }
            }
            public void onlineshopping(int won)//온라인쇼핑 - total[1]
            {
                if (AVG < 250000) return; if (won < 20000) return; if (total_count[1] > 1) return;
                if (pre_limit < limit)
                {
                    if (won > 30000) won = 30000; if (pre_limit + won * 0.1 < limit) { total[1] += won * 0.1; total_count[1]++; pre_limit += won * 0.1; }
                    else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void starbucks(int won)//스타벅스- total[2]
            {
                if (AVG < 250000) return; if (total_count[2] > 1) return; if (won < 10000) return;
                if (pre_limit < limit)
                {
                    if (won > 15000) won = 15000; if (pre_limit + won * 0.2 < limit) { total[2] += won * 0.2; total_count[2]++; pre_limit += won * 0.2; }
                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void snack(int won)//가맹점(간식) - total[3]
            {
                if (total_count[3] > 1) return; if (AVG < 250000) return; if (won < 10000) return;
                if (pre_limit < limit)
                {
                    if (won > 30000) won = 30000; if (pre_limit + won * 0.1 < limit) { total[3] += won * 0.1; total_count[3]++; pre_limit += won * 0.1; }
                    else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void movie(int won)//영화 - total[4]
            {
                if (total_count[4] > 0) return; if (AVG < 250000) return; if (won < 10000) return;
                if (pre_limit < limit)
                {
                    if (won > 30000) won = 30000; if (pre_limit + won * 0.1 < limit) { total[4] += won * 0.1; total_count[4]++; pre_limit += won * 0.1; }
                    else { total[4] += limit - pre_limit; total_count[4]++; pre_limit = limit; }
                }
            }
            public void academe(int won)//학원 - total[5]
            {
                if (total_count[5] > 0) return; if (AVG < 250000) return;
                if (pre_limit < limit)
                {
                    if (won > 50000) won = 50000; if (pre_limit + won * 0.1 < limit) { total[5] += won * 0.1; total_count[5]++; pre_limit += won * 0.1; }
                    else { total[5] += limit - pre_limit; total_count[5]++; pre_limit = limit; }
                }
            }
            public void traffic(int won)//대중교통 - total[6]
            {
                if (AVG < 250000) return;
                if (pre_limit < limit) { total[6] += won;  total_count[6]++; }
            }
            public void mobile(int won)//이동통신 - total[7]
            {
                if (AVG < 250000) return;
                if (pre_limit < limit) { total[7] += won; total_count[7]++; }
            }
        }

        public class UR_Hyundae
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 현대백화점체크카드"; public string print_Card = "";
            public UR_Hyundae(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 7; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "현대백화점 - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += " 레스토랑  - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "   주유    - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "   서점    - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += " 전화영어  - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "   커피    - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += "   영화    - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 7; i++) won += total[i]; return won; }
            public void department(int won)//현대백화점 - total[0]
            {
                total[0] += won * 0.05; total_count[0]++;
            }
            public void restaurant(int won)//레스토랑 - total[1]
            {
                if (total_count[1] > 1) return; if (won > 100000) won = 10000;
                total[1] += won * 0.1; total_count[1]++;
            }
            public void oil(int won)//주유- total[2]
            {
                if (total_count[2] > 5) return; if (total[2] >= 100000) return;
                total[2] += won / oil_price * 40; total[2]++; if (total[2] > 100000) total[2] = 100000;
            }
            public void books(int won)//서점 - total[3]
            {
                if (won < 30000) return; if (total_count[3] > 0) return;
                total[3] += 3000; total_count[3]++;
            }
            public void call(int won)//전화영어 - total[4]
            {
                total[4] += won * 0.5; total_count[4]++;
            }
            public void coffee(int won)//커피 - total[5]
            {
                if (total_count[5] > 1) return; if (won > 25000) won = 25000; if (total[5] >= 5000) return;
                total[5] += won * 0.2; total_count[5]++; if (total[5] > 5000) total[5] = 5000;
            }
            public void movie(int won)//영화 - total[6]
            {
                if (total_count[4] > 0) return;
                if (won < 10000) { total[6] += 3000; total_count[6]++; }
                else { total[6] += 6000; total_count[6]++; }
            }
        }

        public class UR_Lotte
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 롯데라서즐거운체크카드"; public string print_Card = "";
            public UR_Lotte(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 7; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "롯데백화점 - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "   주유    - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += " 놀이공원  - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += " 레스토랑  - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   커피    - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "   영화    - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += " 대중교통  - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                return print_Card;
            }
            public double discount() {
                if (total[6] >= 30000) total[6] = 1500; else { total[6] = 0; total_count[6] = 0; }
                double won = 0; for (int i = 0; i < 7; i++) won += total[i]; return won; }
            public void department(int won)//롯데백화점 - total[0]
            {
                if (AVG < 300000) return; if (total[0] > 1) return; if (won < 10000) return;
                if (won > 50000) won = 50000; total[0] += won * 0.1; total_count[0]++;
            }
            public void oil(int won)//주유 - total[1]
            {
                if (AVG < 300000) return; if (total_count[1] > 5) return; if (won > 50000) return;
                total[1] += won / oil_price * 40; total_count[1]++;
            }
            public void amusement(int won)//놀이공원 - total[2]
            {
                if (total_count[2] > 0) return; if (AVG < 300000) return;
                total[2] += won * 0.5; total[2]++;
            }
            public void restaurant(int won)//레스토랑 - total[3]
            {
                if (AVG < 300000) return; if (total_count[3] > 1) return;
                if (won > 100000) won = 100000; total[3] += won * 0.1; total_count[3]++;
            }
            public void coffee(int won)//커피 - total[4]
            {
                if (AVG < 300000) return; if (total_count[4] > 1) return; if (won < 10000) return;
                if (won > 20000) won = 20000; total[4] += won * 0.2; total_count[4]++;
            }
            public void movie(int won)//영화 - total[5]
            {
                if (total_count[5] > 0) return; if (won < 12000) return; if (AVG < 300000) return;
                total[5] += 3000; total_count[5]++;
            }
            public void traffic(int won)//대중교통 - total[6]
            {
                if (AVG < 300000) return;
                total[6] += won; total_count[6]++;
            }
        }

        public class UR_Lg
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 LGU+라서즐거운체크카드"; public string print_Card = "";
            public UR_Lg(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  LG U+  - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "레스토랑 - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "  커피   - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "  영화   - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "놀이공원 - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void lgu(int won)//이동통신 - total[0]
            {
                if (AVG < 300000) return;
                if (AVG < 700000) { total[0] += 3000; total_count[0]++; } else { total[0] += 7000; total_count[0]++; }
            }
            public void restaurant(int won)//레스토랑 - total[1]
            {
                if (AVG < 300000) return; if (total_count[1] > 1) return;
                if (won > 100000) won = 100000; total[1] += won * 0.1; total_count[1]++;
            }
            public void coffee(int won)//커피 - total[2]
            {
                if (total_count[2] > 1) return; if (AVG < 300000) return;
                if (won > 30000) won = 30000; total[2] += won * 0.1; total[2]++;
            }
            public void movie(int won)//영화 - total[3]
            {
                if (AVG < 300000) return; if (total_count[3] > 0) return; if (won < 12000) return;
                total[3] += won + 2000; total_count[3]++;
            }
            public void amusement(int won)//놀이공원 - total[4]
            {
                if (AVG < 300000) return; if (total_count[4] > 0) return;
                total[4] += won * 0.5; total_count[4]++;
            }
        }

        public class UR_Pop
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 POP 우리V체크카드"; public string print_Card = "";
            public UR_Pop(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 8; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "토익응시료 - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += " 전화영어  - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += " 레스토랑  - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "   주유    - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   커피    - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += " 놀이공원  - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += "인터넷서점 - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += "   제과    - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 8; i++) won += total[i]; return won; }
            public void toeic(int won)//토익응시료 - total[0]
            {
                if (total[0] > 0) return;
                total[0] += won + 3000; total_count[0]++;
            }
            public void call(int won)//전화영어 - total[1]
            {
                total[1] += won * 0.5; total_count[1]++;
            }
            public void restaurant(int won)//레스토랑 - total[2]
            {
                if (total_count[2] > 1) return; if (total[2] >= 10000) return;
                if (won > 100000) won = 100000; total[2] += won * 0.5; total[2]++; if (total[2] >= 10000) total[2] = 10000;
            }
            public void oil(int won)//주유 - total[3]
            {
                if (AVG < 200000) return; if (total_count[3] > 5) return; if (total[3] >= 100000) return;
                total[3] += won / oil_price * 40; total_count[3]++; if (total[3] >= 100000) total[3] = 100000;
            }
            public void coffee(int won)//커피 - total[4]
            {
                if (AVG < 200000) return; if (total_count[4] > 1) return; if (total[4] >= 5000) return;
                total[4] += won * 0.2; total_count[4]++; if (total[4] >= 5000) total[4] = 5000;
            }
            public void amusement(int won)//놀이공원 - total[5]
            {
                if (total_count[5] > 0) return; if (AVG < 200000) return;
                total[5] += won*0.5; total_count[5]++;
            }
            public void books(int won)//서점 - total[6]
            {
                if (won < 30000) return; if (total_count[6] > 0) return;
                total[6] += 3000; total_count[6]++;
            }
            public void snack(int won)//제과 - total[7]
            {
                total[7] += won * 0.05; total_count[7]++;
            }
        }

        public class UR_Uni
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 UNI 우리V체크카드"; public string print_Card = "";
            public UR_Uni(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 8; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "토익응시료 - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += " 전화영어  - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += " 레스토랑  - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "   주유    - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += "   커피    - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                print_Card += "   영화    - 할인액 : " + total[5] + "원 / 할인 회수 : " + total_count[5] + "회\r\n";
                print_Card += " 놀이공원  - 할인액 : " + total[6] + "원 / 할인 회수 : " + total_count[6] + "회\r\n";
                print_Card += "   제과    - 할인액 : " + total[7] + "원 / 할인 회수 : " + total_count[7] + "회\r\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 8; i++) won += total[i]; return won; }
            public void toeic(int won)//토익응시료 - total[0]
            {
                if (total[0] > 0) return;
                total[0] += won + 3000; total_count[0]++;
            }
            public void call(int won)//전화영어 - total[1]
            {
                total[1] += won * 0.5; total_count[1]++;
            }
            public void restaurant(int won)//레스토랑 - total[2]
            {
                if (total_count[2] > 1) return; if (total[2] >= 10000) return;
                if (won > 100000) won = 100000; total[2] += won * 0.5; total[2]++; if (total[2] >= 10000) total[2] = 10000;
            }
            public void oil(int won)//주유 - total[3]
            {
                if (AVG < 200000) return; if (total_count[3] > 5) return; if (total[3] >= 100000) return;
                total[3] += won / oil_price * 40; total_count[3]++; if (total[3] >= 100000) total[3] = 100000;
            }
            public void coffee(int won)//커피 - total[4]
            {
                if (AVG < 200000) return; if (total_count[4] > 1) return; if (total[4] >= 5000) return;
                total[4] += won * 0.2; total_count[4]++; if (total[4] >= 5000) total[4] = 5000;
            }
            public void movie(int won)//영화 - total[5]
            {
                if (total_count[5] > 0) return;
                if (won < 10000) { total[5] += 3000; total_count[5]++; }
                else { total[5] += 6000; total_count[6]++; }
            }
            public void amusement(int won)//놀이공원 - total[6]
            {
                if (total_count[5] > 0) return; if (AVG < 200000) return;
                total[5] += won * 0.5; total_count[5]++;
            }
            public void books(int won)//제과 - total[7]
            {
                if (won < 30000) return; if (total_count[7] > 0) return;
                total[7] += 3000; total_count[7]++;
            }
        }

        public class UR_Wibee
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "우리 위비 five체크카드"; public string print_Card = "";
            double limit, pre_limit = 0;// limit = 월간 통합할인한도, pre_limit = 현재까지 사용한 월간 할인한도 내의 금액
            public UR_Wibee(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
                if (AVG < 600000) limit = 10000; else if (AVG < 1200000) limit = 20000; else limit = 40000;
            }
            public string print()
            {
                print_Card += "온라인쇼핑  - 할인액 : " + total[0] + "원 / 할인 회수 : " + total_count[0] + "회\r\n";
                print_Card += "편의점&뷰티 - 할인액 : " + total[1] + "원 / 할인 회수 : " + total_count[1] + "회\r\n";
                print_Card += "   주유     - 할인액 : " + total[2] + "원 / 할인 회수 : " + total_count[2] + "회\r\n";
                print_Card += "   택시     - 할인액 : " + total[3] + "원 / 할인 회수 : " + total_count[3] + "회\r\n";
                print_Card += " 대중교통   - 할인액 : " + total[4] + "원 / 할인 회수 : " + total_count[4] + "회\r\n";
                return print_Card;
            }
            public double discount() {
                if (total[4] > 40000) total[4] = 40000;
                if (pre_limit < limit) { if (pre_limit + total[4] * 0.05 < limit) total[4] = total[4] * 0.05; else total[4] = limit - pre_limit; }
                double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void onlineshopping(int won)//온라인쇼핑 - total[0]
            {
                if (won < 10000) return; 
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[0] += won * 0.05; total_count[0]++; pre_limit += won * 0.05;}
                    else { total[0] += limit - pre_limit; total_count[0]++; pre_limit = limit; }
                }
            }
            public void convenience_beauty(int won)//편의점&뷰티 - total[1]
            {
                if (won < 10000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[1] += won * 0.05; total_count[1]++; pre_limit += won * 0.05; }
                    else { total[1] += limit - pre_limit; total_count[1]++; pre_limit = limit; }
                }
            }
            public void oil(int won)//주유 - total[2]
            {
                if (won < 30000) return;
                if (pre_limit < limit)
                {
                    if (won > 40000) won = 40000; if (pre_limit + won * 0.05 < limit) { total[2] += won * 0.05; total_count[2]++; pre_limit += won * 0.05; }
                    else { total[2] += limit - pre_limit; total_count[2]++; pre_limit = limit; }
                }
            }
            public void taxi(int won)//택시 - total[3]
            {
                if (won < 10000) return;
                if (pre_limit < limit)
                {
                    if (won > 20000) won = 20000; if (pre_limit + won * 0.05 < limit) { total[3] += won * 0.05; total_count[3]++; pre_limit += won * 0.05; }
                    else { total[3] += limit - pre_limit; total_count[3]++; pre_limit = limit; }
                }
            }
            public void traffic(int won)//대중교통 - total[4]
            {
                if (pre_limit < limit) { total[4] += won;  total_count[4]++; }
            }
        }

        //-------------------------신한카드(혜린)-----------------------

        public class SH_Sline
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 S-Line 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public SH_Sline(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "요식업종 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "대중교통 - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "  주유   - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                print_Card += " 홈쇼핑  - 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n";
                print_Card += "해외결제 - 할인액 : " + total[4] + " / 할인 회수 : " + total_count[4] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void food(int won)//요식업종 - total[0]
            {
                if (won > 10000 && total_count[0] < 5 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[0];

                    total[0] += won * 0.05;
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            public void traffic(int won)//대중교통 - total[1]
            {
                if (total[1] < 5000 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[1];

                    total[1] += won * 0.05;
                    total_count[1]++;
                    if (total[1] >= 5000)
                    {
                        total[1] = 5000;
                    }
                    if (isMax())
                    {
                        total[1] = temp + total_sale - temp_total;
                    }
                }
            }
            public void oil(int won)//주유 - total[2]
            {
                double temp_total = total_sale;
                double temp = total[2];

                int limit = 300000 / oil_price * 40;
                if (total[2] < limit && !isMax())
                {
                    total[2] += won / oil_price * 0.05;
                    total_count[2]++;
                    if (total[2] >= limit)
                    {
                        total[1] = limit;
                    }
                    if (isMax())
                    {
                        total[2] = temp + total_sale - temp_total;
                    }
                }
            }
            public void home_shopping(int won)//홈쇼핑 - total[3]
            {
                double temp_total = total_sale;
                double temp = total[3];

                if (total_count[3] < 2 && !isMax())
                {
                    if (won * 0.05 >= 2500)
                    {
                        total[3] += 2500;
                    }
                    else
                    {
                        total[3] += won * 0.05;
                    }
                    total_count[3]++;
                    if (isMax())
                    {
                        total[3] = temp + total_sale - temp_total;
                    }
                }
            }
            public void foreign(int won)//해외결제 - total[4]
            {
                double temp_total = total_sale;
                double temp = total[4];

                if (total_count[4] < 2 && !isMax())
                {
                    if (won * 0.05 >= 2500)
                    {
                        total[4] += 2500;
                    }
                    else
                    {
                        total[4] += won * 0.05;
                    }
                    total_count[4]++;
                    if (isMax())
                    {
                        total[4] = temp + total_sale - temp_total;
                    }
                }
            }
            bool isMax()
            {
                for (int i = 0; i < 5; i++)
                    total_sale += total[i];

                if (AVG < 300000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 600000)
                {
                    if (total_sale > 5000)
                    {
                        total_sale = 5000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1000000)
                {
                    if (total_sale > 10000)
                    {
                        total_sale = 10000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 20000)
                    {
                        total_sale = 20000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public class SH_Schoice_shopping
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 S-Choice 체크카드(쇼핑 선택)"; public string print_Card = "";
            double total_sale = 0;
            public SH_Schoice_shopping(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 1; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  쇼핑   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 1; i++) won += total[i]; return won; }
            public void shopping(int won)//쇼핑 - total[0]
            {
                double temp_total = total_sale;
                double temp = total[0];

                if (total_count[0] < 3 && !isMax())
                {
                    if (won * 0.1 >= 10000)
                    {
                        total[0] += 10000;
                    }
                    else
                    {
                        total[0] += won * 0.1;
                    }
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            bool isMax()
            {
                for (int i = 0; i < 1; i++)
                    total_sale += total[i];

                if (AVG < 200000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 300000)
                {
                    if (total_sale > 2000)
                    {
                        total_sale = 2000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 500000)
                {
                    if (total_sale > 3000)
                    {
                        total_sale = 3000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 800000)
                {
                    if (total_sale > 5000)
                    {
                        total_sale = 5000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1200000)
                {
                    if (total_sale > 8000)
                    {
                        total_sale = 8000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 12000)
                    {
                        total_sale = 12000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public class SH_Schoice_traffic
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 S-Choice 체크카드(교통 선택)"; public string print_Card = "";
            double total_sale = 0;
            public SH_Schoice_traffic(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 1; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "대중교통 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 1; i++) won += total[i]; return won; }
            public void traffic(int won)//대중교통 - total[0]
            {
                double temp_total = total_sale;
                double temp = total[0];

                if (!isMax())
                {
                    total[0] += won * 0.1;
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            bool isMax()
            {
                for (int i = 0; i < 1; i++)
                    total_sale += total[i];

                if (AVG < 200000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 300000)
                {
                    if (total_sale > 2000)
                    {
                        total_sale = 2000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 500000)
                {
                    if (total_sale > 3000)
                    {
                        total_sale = 3000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 800000)
                {
                    if (total_sale > 5000)
                    {
                        total_sale = 5000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1200000)
                {
                    if (total_sale > 8000)
                    {
                        total_sale = 8000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 12000)
                    {
                        total_sale = 12000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


        public class SH_Schoice_coffee
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 S-Choice 체크카드(커피 선택)"; public string print_Card = "";
            double total_sale = 0;
            public SH_Schoice_coffee(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 1; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  커피   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 1; i++) won += total[i]; return won; }
            public void coffee(int won)//커피 - total[0]
            {
                double temp_total = total_sale;
                double temp = total[0];

                if (total_count[0] < 5 && !isMax())
                {
                    total[0] += won * 0.2;
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            bool isMax()
            {
                for (int i = 0; i < 1; i++)
                    total_sale += total[i];

                if (AVG < 200000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 300000)
                {
                    if (total_sale > 2000)
                    {
                        total_sale = 2000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 500000)
                {
                    if (total_sale > 3000)
                    {
                        total_sale = 3000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 800000)
                {
                    if (total_sale > 5000)
                    {
                        total_sale = 5000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1200000)
                {
                    if (total_sale > 8000)
                    {
                        total_sale = 8000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 12000)
                    {
                        total_sale = 12000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public class SH_BigPluse
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 빅플러스 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public SH_BigPluse(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 3; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "놀이동산 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "  영화   - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += " 스포츠  - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 3; i++) won += total[i]; return won; }
            public void park(int won)//놀이동산 - total[0]
            {
                if (total_count[0] < 3 && AVG > 100000)
                {
                    total[0] += won * 0.5;
                    total_count[0]++;
                }
            }
            public void movie(int won)//영화 - total[1]
            {
                if (total_count[1] < 4 && AVG > 100000)
                {
                    total[1] += 1500;
                    total_count[1]++;
                }
            }
            public void sports(int won)//스포츠 - total[2]
            {
                total[2] += 20000;
                total_count[2]++;
            }
        }

        public class SH_S20
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 S20 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public SH_S20(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 8; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "대중교통 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n"; 
                print_Card += "통신요금 - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n"; 
                print_Card += "  GS25   - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n"; 
                print_Card += "교보문고 - 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n"; 
                print_Card += " YBM시사&파고다어학원   - 할인액 : " + total[4] + " / 할인 회수 : " + total_count[4] + "\n"; 
                print_Card += "  TOEIC  - 할인액 : " + total[5] + " / 할인 회수 : " + total_count[5] + "\n"; 
                print_Card += "놀이동산 - 할인액 : " + total[6] + " / 할인 회수 : " + total_count[6] + "\n"; 
                print_Card += "맥스무비 - 할인액 : " + total[7] + " / 할인 회수 : " + total_count[7] + "\n"; 
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 8; i++) won += total[i]; return won; }
            public void traffic(int won)//대중교통 - total[0]
            {
                int limit;

                if (AVG < 200000) limit = 0;
                else if (AVG < 300000) limit = 2000;
                else if (AVG < 500000) limit = 3000;
                else if (AVG < 1000000) limit = 5000;
                else limit = 7000;

                if (total[0] < limit)
                {
                    total[0] += won * 0.1;
                    total_count[0]++;
                    if (total[0] > limit)
                    {
                        total[0] = limit;
                    }
                }
            }
            public void mobile(int won)//통신요금 - total[1]
            {
                int limit = 3000;

                if (total[1] < limit)
                {
                    total[1] += won;
                    total_count[1]++;
                    if (total[1] > limit)
                    {
                        total[1] = limit;
                    }
                }
            }
            public void gs25(int won)//GS 25 - total[2]
            {
                int limit;
                double rate;

                if (AVG < 200000)
                {
                    limit = 0;
                    rate = 0.00;
                }
                else if (AVG < 300000)
                {
                    limit = 2000;
                    rate = 0.02;
                }
                else if (AVG < 500000)
                {
                    limit = 3000;
                    rate = 0.03;
                }
                else if (AVG < 1000000)
                {
                    limit = 5000;
                    rate = 0.05;
                }
                else
                {
                    limit = 7000;
                    rate = 0.07;
                }
                if (total[2] < limit && won >= 10000)
                {
                    total[2] += won * rate;
                    total_count[2]++;
                    if (total[2] > limit)
                    {
                        total[2] = limit;
                    }
                }
            }
            public void kyobo(int won)//교보문고 - total[3]
            {
                int limit = 3000;

                if (total[3] < limit && total_count[3] < 3 && won >= 20000)
                {
                    total[3] += won * 0.05;
                    total_count[3]++;
                    if (total[3] > limit)
                    {
                        total[3] = limit;
                    }
                }
            }
            public void english(int won)//YBM시사&파고다어학원 - total[4]
            {
                if (total_count[4] < 1 && won >= 100000)
                {
                    total[4] += 5000;
                    total_count[4]++;
                }
            }
            public void toeic(int won)//토익 - total[5]
            {
                if (total_count[5] < 1 && won >= 30000)
                {
                    total[5] += 2000;
                    total_count[5]++;
                }
            }
            public void park(int won)//놀이동산 - total[6]
            {
                if (total_count[6] < 3 && AVG >= 100000)
                {
                    total[6] += won * 0.5;
                    total_count[6]++;
                }
            }
            public void movie(int won)//맥스무비 - total[7]
            {
                if (total_count[7] < 2 && AVG >= 100000)
                {
                    total[7] += 1000;
                    total_count[7]++;
                }
            }
        }
        public class SH_S20Pink
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 S20 Pink 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public SH_S20Pink(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "대중교통 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "통신요금 - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "4대온라인몰&올리브영- 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n"; 
                print_Card += "놀이동산 - 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n"; 
                print_Card += "맥스무비 - 할인액 : " + total[4] + " / 할인 회수 : " + total_count[4] + "\n"; 
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void traffic(int won)//대중교통 - total[0]
            {
                int limit;

                if (AVG < 200000) limit = 0;
                else if (AVG < 300000) limit = 2000;
                else if (AVG < 500000) limit = 3000;
                else if (AVG < 1000000) limit = 5000;
                else limit = 7000;

                if (total[0] < limit)
                {
                    total[0] += won * 0.1;
                    total_count[0]++;
                    if (total[0] > limit)
                    {
                        total[0] = limit;
                    }
                }
            }
            public void mobile(int won)//통신요금 - total[1]
            {
                int limit = 3000;

                if (total[1] < limit)
                {
                    total[1] += won;
                    total_count[1]++;
                    if (total[1] > limit)
                    {
                        total[1] = limit;
                    }
                }
            }
            public void shopping(int won)//4대온라인몰&올리브영 - total[2]
            {
                int limit;
                double rate;

                if (AVG < 200000)
                {
                    limit = 0;
                    rate = 0.00;
                }
                else if (AVG < 300000)
                {
                    limit = 2000;
                    rate = 0.02;
                }
                else if (AVG < 500000)
                {
                    limit = 3000;
                    rate = 0.03;
                }
                else if (AVG < 1000000)
                {
                    limit = 5000;
                    rate = 0.05;
                }
                else
                {
                    limit = 7000;
                    rate = 0.07;
                }
                if (total[2] < limit)
                {
                    total[2] += won * rate;
                    total_count[2]++;
                    if (total[2] > limit)
                    {
                        total[2] = limit;
                    }
                }
            }
            public void park(int won)//놀이동산 - total[3]
            {
                if (total_count[3] < 3 && AVG >= 100000)
                {
                    total[3] += won * 0.5;
                    total_count[3]++;
                }
            }
            public void movie(int won)//맥스무비 - total[4]
            {
                if (total_count[4] < 2 && AVG >= 100000)
                {
                    total[4] += 1000;
                    total_count[4]++;
                }
            }
        }
        public class SH_2030
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "신한 2030 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public SH_2030(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 4; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "현대오일 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += " 아웃백  - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "놀이동산 - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n"; 
                print_Card += "영화(맥스무비, YES24, 인터파크) - 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 4; i++) won += total[i]; return won; }
            public void oil(int won)//현대오일 - total[0]
            {
                int limit = 300000;

                if (total[0] < limit && AVG >= 200000)
                {
                    if (won > 100000)
                        won = 100000;

                    total[0] += won / oil_price * 40;
                    total_count[0]++;
                    if (total[0] > limit)
                    {
                        total[0] = limit;
                    }
                }
            }
            public void outback(int won)//아웃백 - total[1]
            {

                if (total_count[1] < 4 && AVG > 100000)
                {
                    if (won > 200000)
                        won = 200000;

                    total[1] += won * 0.2;
                    total_count[1]++;
                }
            }
            public void park(int won)//놀이동산 - total[2]
            {
                if (total_count[2] < 3 && AVG >= 100000)
                {
                    total[2] += won * 0.5;
                    total_count[2]++;
                }
            }
            public void movie(int won)//맥스무비 - total[3]
            {
                if (total_count[3] < 2 && AVG >= 100000)
                {
                    total[3] += 1500;
                    total_count[3]++;
                }
            }
        }
        public class SH_yogiyo
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "요기요 신한카드 체크"; public string print_Card = "";
            double total_sale = 0;
            public SH_yogiyo(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 3; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += " 요기요 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += " 이디야  - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "CU편의점- 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 3; i++) won += total[i]; return won; }
            public void yogiyo(int won)//요기요 - total[0]
            {
                double temp_total = total_sale;
                double temp = total[0];

                if (total_count[0] < 4 && !isMax())
                {
                    if ((won * 0.15) > 2000)
                        total[0] += 2000;
                    else
                        total[0] += won * 0.15;
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            public void ediya(int won)//이디야 - total[1]
            {
                int limit = 3000;
                double temp_total = total_sale;
                double temp = total[1];

                if (total_count[1] < 3 && !isMax() && won >= 7000 && total[1] < limit)
                {
                    total[1] += won * 0.1;
                    total_count[1]++;
                    if (isMax())
                    {
                        total[1] = temp + total_sale - temp_total;
                    }
                }
            }
            public void cu(int won)//CU편의점 - total[2]
            {
                int limit = 5000;
                double temp_total = total_sale;
                double temp = total[2];

                if (total_count[2] < 3 && !isMax() && won >= 10000 && total[2] < limit)
                {
                    total[2] += won * 0.1;
                    total_count[2]++;
                    if (isMax())
                    {
                        total[2] = temp + total_sale - temp_total;
                    }
                }
            }
            bool isMax()
            {
                for (int i = 0; i < 3; i++)
                    total_sale += total[i];

                if (AVG < 200000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 500000)
                {
                    if (total_sale > 6000)
                    {
                        total_sale = 6000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 800000)
                {
                    if (total_sale > 8000)
                    {
                        total_sale = 8000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1000000)
                {
                    if (total_sale > 10000)
                    {
                        total_sale = 10000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 15000)
                    {
                        total_sale = 15000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        //-------------------------하나카드(혜린)-----------------------

        public class HN_toXalpha
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "하나 투엑알파 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public HN_toXalpha(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 2; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  커피   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "통신요금 - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 2; i++) won += total[i]; return won; }
            public void coffee(int won)//커피 - total[0]
            {
                int limit = 2000;

                if (total[0] < limit && AVG >= 250000)
                {
                    total[0] += won * 0.1;
                    total_count[0]++;
                    if (total[0] > limit)
                    {
                        total[0] = limit;
                    }
                }
            }
            public void mobile(int won)//통신요금 - total[1]
            {
                int limit = 1000;

                if (total[1] < limit && AVG >= 250000)
                {
                    total[1] += won * 0.03;
                    total_count[1]++;
                    if (total[1] > limit)
                    {
                        total[1] = limit;
                    }
                }
            }
        }
        public class HN_wingp
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "하나 한국장학제단 wingo 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public HN_wingp(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 2; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "놀이동산 - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "통신요금 - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 2; i++) won += total[i]; return won; }
            public void park(int won)//놀이동산 - total[0]
            {
                if (total_count[0] < 6 && AVG >= 100000)
                {
                    total[0] += won * 0.5;
                    total_count[0]++;
                }
            }
            public void mobile(int won)//통신요금 - total[1]
            {
                int limit;
                if (AVG < 100000)
                    limit = 0;
                else if (AVG < 300000)
                    limit = 1000;
                else
                    limit = 2000;

                if (total[1] < limit)
                {
                    total[1] += won;
                    total_count[1]++;
                    if (total[1] > limit)
                    {
                        total[1] = limit;
                    }
                }
            }
        }

        //-------------------------기업카드(혜린)-----------------------

        public class IBK_myAlpha
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "IBK기업 나의 알파 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public IBK_myAlpha(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 4; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  주유   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "  영화   - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "놀이동산 - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n"; 
                print_Card += "롯데렌터가- 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 4; i++) won += total[i]; return won; }
            public void oil(int won)//주유 - total[0]
            {
                int limit = 300000;

                if (total[0] < limit && AVG >= 200000 && total_count[0] < 4)
                {
                    double sale = won / oil_price * 40;
                    if (sale > 100000)
                        sale = 100000;
                    total[0] += sale;
                    total_count[0]++;
                    if (total[0] > limit)
                    {
                        total[0] = limit;
                    }
                }
            }
            public void movie(int won)//영화 - total[1]
            {
                if (total_count[1] < 6 && AVG >= 200000)
                {
                    total[1] += 1500;
                    total_count[1]++;
                }
            }
            public void park(int won)//놀이동산 - total[2]
            {
                if (total_count[2] < 1 && AVG >= 200000)
                {
                    total[2] += won * 0.5;
                    total_count[2]++;
                }
            }
            public void rentcar(int won)//롯데렌터카 - total[3]
            {
                total[3] += won * 0.35;
                total_count[3]++;
            }
        }

        public class IBK_savezone
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "세이브 존IBK 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public IBK_savezone(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 5; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  외식   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "  영화   - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "  커피   - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                print_Card += "소셜커머스- 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n";
                print_Card += "놀이동산 - 할인액 : " + total[4] + " / 할인 회수 : " + total_count[4] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 5; i++) won += total[i]; return won; }
            public void food(int won)//외식(아웃백, 빕스, 블랙스미스, 토다이 TGIF) - total[0]
            {
                double temp_total = total_sale;
                double temp = total[0];

                if (total_count[0] < 1 && !isMax())
                {
                    double sale = won * 0.1;
                    if (sale > 100000)
                        sale = 100000;
                    total[0] += sale;
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            public void movie(int won)//영화 - total[1]
            {
                double temp_total = total_sale;
                double temp = total[1];

                if (total_count[1] < 6 && won >= 10000 && !isMax())
                {
                    total[1] += 2000;
                    total_count[1]++;
                    if (isMax())
                    {
                        total[1] = temp + total_sale - temp_total;
                    }
                }
            }
            public void coffee(int won)//커피(스타벅스, 커피빈, 카페배네, 탐앤탐스, 할리스, 엔젤리너스) - total[2]
            {
                double temp_total = total_sale;
                double temp = total[2];

                if (won > 20000)
                    won = 20000;
                if (total_count[2] < 3 && !isMax())
                {
                    total[2] += won * 0.1;
                    total_count[2]++;
                    if (isMax())
                    {
                        total[2] = temp + total_sale - temp_total;
                    }
                }
            }
            public void social(int won)//소셜커머스 - total[3]
            {
                if (won > 20000)
                    won = 20000;

                if (total_count[3] < 3 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[3];

                    total[3] += won * 0.1;
                    total_count[3]++;
                    if (isMax())
                    {
                        total[3] = temp + total_sale - temp_total;
                    }
                }
            }
            public void park(int won)//놀이동산 - total[4]
            {
                if (total_count[4] < 1 && AVG >= 200000)
                {
                    total[4] += won * 0.5;
                    total_count[4]++;
                }
            }
            bool isMax()
            {
                //통합할인 한도가 4가지만 적용돼 4가지만 더함
                for (int i = 0; i < 4; i++)
                    total_sale += total[i];

                if (AVG < 200000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 500000)
                {
                    if (total_sale > 5000)
                    {
                        total_sale = 5000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1000000)
                {
                    if (total_sale > 10000)
                    {
                        total_sale = 10000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 20000)
                    {
                        total_sale = 20000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public class IBK_enjoy_everyday_life
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "IBK 일상의 기쁨 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public IBK_enjoy_everyday_life(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 6; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  커피   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "  영화   - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "대중교통 - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                print_Card += "소셜커머스- 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n";
                print_Card += "  편의점 - 할인액 : " + total[4] + " / 할인 회수 : " + total_count[4] + "\n";
                print_Card += "놀이공원 - 할인액 : " + total[5] + " / 할인 회수 : " + total_count[5] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 6; i++) won += total[i]; return won; }
            public void coffee(int won)//커피 - total[0]
            {
                if (total_count[0] < 2)
                {
                    if (won > 100000)
                        won = 100000;
                    total[0] += won * 0.1;
                    total_count[0]++;
                }
            }
            public void movie(int won)//영화 - total[1]
            {
                if (total_count[1] < 1 && won >= 10000)
                {
                    total[1] += 4000;
                    total_count[1]++;
                }
            }
            public void traffic(int won)//대중교통 - total[2]
            {
                int limit = 2000;

                if (total[2] < limit)
                {
                    double temp_total = total_sale;
                    double temp = total[2];

                    total[2] += won * 0.1;
                    total_count[2]++;
                    if (total[2] < limit)
                    {
                        total[2] = temp + total_sale - temp_total;
                    }
                }
            }
            public void social(int won)//소셜커머스 - total[3]
            {
                if (total_count[3] < 2)
                {
                    if (won > 100000)
                        won = 100000;
                    total[3] += won * 0.1;
                    total_count[3]++;
                }
            }
            public void convenience(int won)//편의점(GS25, CU, 세븐일레븐 올리브영) - total[4]
            {
                if (total_count[4] < 2)
                {
                    if (won > 100000)
                        won = 100000;
                    total[4] += won * 0.05;
                    total_count[4]++;
                }
            }
            public void park(int won)//놀이동산 - total[5]
            {
                if (total_count[5] < 1 && AVG >= 300000)
                {
                    total[5] += won * 0.5;
                    total_count[5]++;
                }
            }
        }
        public class IBK_culture_Yungsung
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "IBK 문화 융성 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public IBK_culture_Yungsung(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 3; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += "  도서   - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "  영화   - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += " 스포츠  - 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 3; i++) won += total[i]; return won; }
            public void book(int won)//도서 - total[0]
            {
                if (AVG >= 100000)
                {
                    if (total_count[0] < 1)
                    {
                        double sale = won * 0.15;
                        if (sale > 5000)
                            sale = 5000;
                        total[0] += sale;
                        total_count[0]++;
                    }
                }
                else if (AVG >= 300000)
                {
                    if (total_count[0] < 2)
                    {
                        double sale = won * 0.15;
                        if (sale > 5000)
                            sale = 5000;
                        total[0] += sale;
                        total_count[0]++;
                    }
                }
            }
            public void movie(int won)//영화 - total[1]
            {
                if (total_count[1] < 1 && AVG >= 300000)
                {
                    total[1] += 2000;
                    total_count[1]++;
                }
            }
            public void sports(int won)//스포츠 - total[2]
            {
                if (total_count[2] < 1 && AVG >= 300000)
                {
                    total[2] += 2000;
                    total_count[2]++;
                }
            }
        }
        public class IBK_daiso
        {
            List<double> total; int AVG;
            List<int> total_count;
            public string name = "IBK 참! 좋은 다이소 체크카드"; public string print_Card = "";
            double total_sale = 0;
            public IBK_daiso(int avg)
            {
                total = new List<double>();
                total_count = new List<int>();
                for (int i = 0; i < 7; i++) { total.Add(0); total_count.Add(0); }
                AVG = avg;
            }
            public string print()
            {
                print_Card += " 다이소  - 할인액 : " + total[0] + " / 할인 회수 : " + total_count[0] + "\n";
                print_Card += "  헤어   - 할인액 : " + total[1] + " / 할인 회수 : " + total_count[1] + "\n";
                print_Card += "소셜커머스- 할인액 : " + total[2] + " / 할인 회수 : " + total_count[2] + "\n";
                print_Card += " 편의점  - 할인액 : " + total[3] + " / 할인 회수 : " + total_count[3] + "\n";
                print_Card += "  영화   - 할인액 : " + total[4] + " / 할인 회수 : " + total_count[4] + "\n";
                print_Card += "  커피   - 할인액 : " + total[5] + " / 할인 회수 : " + total_count[5] + "\n";
                print_Card += "놀이공원 - 할인액 : " + total[6] + " / 할인 회수 : " + total_count[6] + "\n";
                return print_Card;
            }
            public double discount() { double won = 0; for (int i = 0; i < 7; i++) won += total[i]; return won; }
            public void daiso(int won)//다이소 - total[0]
            {
                if (won > 5000 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[0];

                    total[0] += won * 0.2;
                    total_count[0]++;
                    if (isMax())
                    {
                        total[0] = temp + total_sale - temp_total;
                    }
                }
            }
            public void hair(int won)//헤어 - total[1]
            {
                if (total_count[1] < 1 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[1];

                    if (won >= 50000)
                        won = 50000;
                    total[1] += won * 0.1;
                    total_count[1]++;
                    if (isMax())
                    {
                        total[1] = temp + total_sale - temp_total;
                    }
                }
            }
            public void social(int won)//소셜커머스(쿠팡, 티몬, 위메프) - total[2]
            {
                if (total_count[2] < 2 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[2];

                    if (won >= 10000)
                        won = 10000;
                    total[2] += won * 0.1;
                    total_count[2]++;
                    if (isMax())
                    {
                        total[2] = temp + total_sale - temp_total;
                    }
                }
            }
            public void convience(int won)//편의점 - total[3]
            {
                if (total_count[3] < 2 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[3];

                    if (won >= 10000)
                        won = 10000;
                    total[3] += won * 0.05;
                    total_count[3]++;
                    if (isMax())
                    {
                        total[3] = temp + total_sale - temp_total;
                    }
                }
            }
            public void movie(int won)//영화 - total[4]
            {
                if (total_count[4] < 1 && won >= 10000 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[4];

                    total[4] += 2000;
                    total_count[4]++;
                    if (isMax())
                    {
                        total[4] = temp + total_sale - temp_total;
                    }
                }
            }
            public void coffee(int won)//커피 - total[5]
            {
                if (total_count[5] < 3 && !isMax())
                {
                    double temp_total = total_sale;
                    double temp = total[5];

                    if (won >= 20000)
                        won = 20000;
                    total[5] += won * 0.1;
                    total_count[5]++;
                    if (isMax())
                    {
                        total[5] = temp + total_sale - temp_total;
                    }
                }
            }
            public void park(int won)//놀이동산 - total[6]
            {
                if (total_count[6] < 1)
                {
                    total[6] += won * 0.5;
                    total_count[6]++;
                }
            }
            bool isMax()
            {
                for (int i = 0; i < 7; i++)
                    total_sale += total[i];

                if (AVG < 300000)
                {
                    total_sale = 0;
                    return true;
                }
                else if (AVG < 600000)
                {
                    if (total_sale > 5000)
                    {
                        total_sale = 5000;
                        return true;
                    }
                    else
                        return false;
                }
                else if (AVG < 1000000)
                {
                    if (total_sale > 10000)
                    {
                        total_sale = 10000;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (total_sale > 20000)
                    {
                        total_sale = 20000;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

    }
}