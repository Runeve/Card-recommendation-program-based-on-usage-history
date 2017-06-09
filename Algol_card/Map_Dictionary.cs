using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Algol_card
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> cate = new Dictionary<string, int>();

        public enum cate_type
        {
            /*편의점*/
            GS25, CU,seven,by,

            /*쇼핑(온라인)*/
            Gmarket, Auction, road_11, Qoopang, Wemape, Interpark, Maxmovie, Tmon, ZeroToSeven, WebeeMarket,
            TicketMonster, Yogiyo, CJMall, LotteDotCom, Allcanto, eight,LF,

            /*해외*/
            Google, App, VISA, Master,

            /*교통*/
            bus,metro,taxi,TM,

            /*뷰티*/
            OliveYoung, ParkHairStudio, Watsons,Aritaum,espoir,etude,
            
            /*홈쇼핑*/
            GSShopping, CJShopping,

            /*여행*/
            daemyung,bearsresort,sheraton,tourvis, hanatour, modutour,

            /*의료*/
            hospi,

            /*패스트푸드*/
            Mr,King,KFC,bulgogiBro,

            /*대형마트*/
            LotteMart, EMart, Homeplus, Shinsegye, Hyundae, Galleria, daiso,
            LotteSuper,GSSuper,Hanaro,Shilla,ABC, Lotte,

            /*영화*/
            LotteCinema, CGV, Megabox, Cinecube, PrimusCinema,Seoul,MaxMovie,interpark,yes24movie,

            /*외식*/
            Outback, VIPS, TGIF, Sevensprings, Venigence, Uno, baemin,

            /*커피*/
            Starbucks, Coffeebin, Cafebene, Twosomeplace, Ediya,
            beansbeans,Hollys,Tiamo,zoo,palombini,arista,coffine,pass,Tam,
            droptop, angelinus,

            /*놀이공원*/
            EverLand, LotteWorld, SeoulLand, EWorld, GyeonjuWorld, TongdoFantasia,
            CarribeanBay, CalifoniaBeach, HanggukMinsokchon, SeolackWater,gawngjuFamily,

            /*주유*/
            GSOil, SOil, HyundaeOil,E1,speedmate,SK,

            /*서점*/
            GyoboBook, YoungpoongBook, Yes24, BandiAndRoonies,

            /*항공*/
            JejuAir,koreanAir,

            /*가맹점(간식)*/
            ParisBaguette, BeskinRabins, DunkinDonut, MrDonut,osulloc,parnas,
            orga,obong,lohbs,Torejour,

            /*학원*/
            YBM, Pagoda, Hackers,call,

            /*어학시험*/
            TOEIC,OPIC,JPT,HSK,

            /*렌트카*/
            LotteRentcar,

            /*통신사*/
            SKT,KT,LG
        }

        public void Init()
        {
            /*편의점*/
            cate["GS25"] = (int)cate_type.GS25;
            cate["씨유"] = (int)cate_type.CU;
            cate["지에스"] = (int)cate_type.GS25;
            cate["세븐일레븐"] = (int)cate_type.seven;
            cate["바이더웨이"] = (int)cate_type.by;

            /*쇼핑(온라인)*/
            cate["G마켓"] = (int)cate_type.Gmarket;
            cate["옥션"] = (int)cate_type.Auction;
            cate["11번가"] = (int)cate_type.road_11;
            cate["쿠팡"] = (int)cate_type.Qoopang;
            cate["위메프"] = (int)cate_type.Wemape;
            cate["인터파크"] = (int)cate_type.Interpark;
            cate["맥스무비"] = (int)cate_type.Maxmovie;
            cate["티몬"] = (int)cate_type.Tmon;
            cate["제로투세븐"] = (int)cate_type.ZeroToSeven;
            cate["위비마켓"] = (int)cate_type.WebeeMarket;
            cate["티켓몬스터"] = (int)cate_type.TicketMonster;
            cate["요기요"] = (int)cate_type.Yogiyo;
            cate["CJ몰"] = (int)cate_type.CJMall;
            cate["롯데닷컴"] = (int)cate_type.LotteDotCom;
            cate["엘칸토"] = (int)cate_type.Allcanto;
            cate["에잇세컨즈"] = (int)cate_type.eight;
            cate["LF"] = (int)cate_type.LF;

            /*해외*/
            cate["Google"] = (int)cate_type.Google;
            cate["App"] = (int)cate_type.App;
            cate["VISA"] = (int)cate_type.VISA;
            cate["Master"] = (int)cate_type.Master;


            /*교통*/
            cate["버스"] = (int)cate_type.bus;
            cate["지하철"] = (int)cate_type.metro;
            cate["taxi"] = (int)cate_type.taxi;
            cate["교통대금"] = (int)cate_type.TM;

            /*뷰티*/
            cate["올리브영"] = (int)cate_type.OliveYoung;
            cate["박승철헤어"] = (int)cate_type.ParkHairStudio;
            cate["왓슨스"] = (int)cate_type.Watsons;
            cate["아리따움"] = (int)cate_type.Aritaum;
            cate["espoir"] = (int)cate_type.espoir;
            cate["etude"] = (int)cate_type.etude;

            /*홈쇼핑*/
            cate["GS홈쇼핑"] = (int)cate_type.GSShopping;
            cate["CJ홈쇼핑"] = (int)cate_type.CJShopping;

            /*여행*/
            cate["대명"] = (int)cate_type.daemyung;
            cate["베어스타운"] = (int)cate_type.bearsresort;
            cate["쉐라톤"] = (int)cate_type.sheraton;
            cate["투어비스"] = (int)cate_type.tourvis;
            cate["하나투어"] = (int)cate_type.hanatour;
            cate["모두투어"] = (int)cate_type.modutour;

            /*의료*/
            cate["병원"] = (int)cate_type.hospi;

            /*패스트푸드*/
            cate["미스터피자"] = (int)cate_type.Mr;
            cate["버거킹"] = (int)cate_type.King;
            cate["KFC"] = (int)cate_type.KFC;
            

            /*대형마트*/
            cate["롯데마트"] = (int)cate_type.LotteMart;
            cate["이마트"] = (int)cate_type.EMart;
            cate["홈플러스"] = (int)cate_type.Homeplus;
            cate["신세계백화점"] = (int)cate_type.Shinsegye;
            cate["현대백화점"] = (int)cate_type.Hyundae;
            cate["롯데백화점"] = (int)cate_type.Lotte;
            cate["갤러리아"] = (int)cate_type.Galleria;
            cate["다이소"] = (int)cate_type.daiso;
            cate["롯데수퍼"] = (int)cate_type.LotteSuper;
            cate["GS수퍼"] = (int)cate_type.GSSuper;
            cate["하나로"] = (int)cate_type.Hanaro;
            cate["신라면세점"] = (int)cate_type.Shilla;
            cate["ABC"] = (int)cate_type.ABC;


            /*영화*/
            cate["롯데시네마"] = (int)cate_type.LotteCinema;
            cate["CGV"] = (int)cate_type.CGV;
            cate["메가박스"] = (int)cate_type.Megabox;
            cate["cinecube"] = (int)cate_type.Cinecube;
            cate["primuscinema"] = (int)cate_type.PrimusCinema;
            cate["서울극장"] = (int)cate_type.Seoul;
            cate["맥스무비"] = (int)cate_type.MaxMovie;
            cate["인터파크영화"] = (int)cate_type.interpark;
            cate["YES24영화"] = (int)cate_type.yes24movie;

            /*외식*/
            cate["아웃백"] = (int)cate_type.Outback;
            cate["빕스"] = (int)cate_type.VIPS;
            cate["TGIF"] = (int)cate_type.TGIF;
            cate["세븐스프링스"] = (int)cate_type.Sevensprings;
            cate["베니건스"] = (int)cate_type.Venigence;
            cate["우노"] = (int)cate_type.Uno;
            cate["불고기브라더스"] = (int)cate_type.bulgogiBro;
            cate["배달의민족"] = (int)cate_type.baemin;

            /*커피*/
            cate["스타벅스"] = (int)cate_type.Starbucks;
            cate["커피빈"] = (int)cate_type.Coffeebin;
            cate["카페베네"] = (int)cate_type.Cafebene;
            cate["투썸플레이스"] = (int)cate_type.Twosomeplace;
            cate["이디야"] = (int)cate_type.Ediya;
            cate["빈스빈스"] = (int)cate_type.beansbeans;
            cate["할리스"] = (int)cate_type.Hollys;
            cate["띠아모"] = (int)cate_type.Tiamo;
            cate["주커피"] = (int)cate_type.zoo;
            cate["팔롬비니"] = (int)cate_type.palombini;
            cate["아리스타"] = (int)cate_type.arista;
            cate["커핀그루"] = (int)cate_type.coffine;
            cate["파스쿠치"] = (int)cate_type.pass;
            cate["탐앤탐스"] = (int)cate_type.Tam;
            cate["드롭탑"] = (int)cate_type.droptop;
            cate["엔제리너스"] = (int)cate_type.angelinus;

            /*놀이공원*/
            cate["에버랜드"] = (int)cate_type.EverLand;
            cate["롯데월드"] = (int)cate_type.LotteWorld;
            cate["서울랜드"] = (int)cate_type.SeoulLand;
            cate["이월드"] = (int)cate_type.EWorld;
            cate["경주월드"] = (int)cate_type.GyeonjuWorld;
            cate["통도환타지아"] = (int)cate_type.TongdoFantasia;
            cate["캐리비안베이"] = (int)cate_type.CarribeanBay;
            cate["캘리포니아비치"] = (int)cate_type.CalifoniaBeach;
            cate["한국민속촌"] = (int)cate_type.HanggukMinsokchon;
            cate["설악워터피아"] = (int)cate_type.SeolackWater;
            cate["광주패밀리"] = (int)cate_type.gawngjuFamily;

            /*주유*/
            cate["GS칼텍스"] = (int)cate_type.GSOil;
            cate["S-OIL"] = (int)cate_type.SOil;
            cate["현대오일뱅크"] = (int)cate_type.HyundaeOil;
            cate["E1"] = (int)cate_type.E1;
            cate["스피드메이트"] = (int)cate_type.speedmate;
            cate["SK주유소"] = (int)cate_type.SK;

            /*서점*/
            cate["교보문고"] = (int)cate_type.GyoboBook;
            cate["영풍문고"] = (int)cate_type.YoungpoongBook;
            cate["Yes24"] = (int)cate_type.Yes24;
            cate["반디앤루니스"] = (int)cate_type.BandiAndRoonies;

            /*항공*/
            cate["제주항공"] = (int)cate_type.JejuAir;
            cate["대한항공"] = (int)cate_type.koreanAir;

            /*가맹점(간식)*/
            cate["파리바게뜨"] = (int)cate_type.ParisBaguette;
            cate["베스킨라빈스"] = (int)cate_type.BeskinRabins;
            cate["던킨도너츠"] = (int)cate_type.DunkinDonut;
            cate["미스터도넛"] = (int)cate_type.MrDonut;
            cate["오설록"] = (int)cate_type.osulloc;
            cate["파르나스"] = (int)cate_type.parnas;
            cate["올가"] = (int)cate_type.orga;
            cate["오봉"] = (int)cate_type.obong;
            cate["롭스"] = (int)cate_type.lohbs;
            cate["뚜레쥬르"] = (int)cate_type.Torejour;

            /*학원*/
            cate["YBM"] = (int)cate_type.YBM;
            cate["파고다"] = (int)cate_type.Pagoda;
            cate["해커스"] = (int)cate_type.Hackers;
            cate["PAGODA"] = (int)cate_type.Pagoda;
            cate["Happycall"] = (int)cate_type.call;//전화영어

            /*어학시험*/
            cate["TOEIC"] = (int)cate_type.TOEIC;
            cate["OPIC"] = (int)cate_type.OPIC;
            cate["JPT"] = (int)cate_type.JPT;
            cate["HSK"] = (int)cate_type.HSK;

            /*렌트카*/
            cate["롯데렌트카"] = (int)cate_type.LotteRentcar;

            /*통신사*/
            cate["KT"] = (int)cate_type.KT;
            cate["SKT"] = (int)cate_type.SKT;
            cate["LG"] = (int)cate_type.LG;


        }
        
        public void judge_cate(string w, int won)
        {
            switch (cate[w])
            {
                /*편의점*/
                case (int)cate_type.GS25:
                    chungchundarto.convenience(won);
                    gaon.GS25(won);
                    juniorlife.gs25(won);
                    between.gs25(won);
                    pop.snack(won);
                    wibee.convenience_beauty(won);
                    s20.gs25(won);
                    enjoy_everyday.convenience(won);
                    daiso.convience(won);
                    break;
                case (int)cate_type.CU:
                    chungchundarto.convenience(won);
                    wibee.convenience_beauty(won);
                    yogiyo.cu(won);
                    enjoy_everyday.convenience(won);
                    daiso.convience(won);
                    break;
                case (int)cate_type.seven:
                    chungchundarto.convenience(won);
                    enjoy_everyday.convenience(won);
                    daiso.convience(won);
                    break;
                case (int)cate_type.by:
                    chungchundarto.convenience(won);
                    break;

                /*쇼핑(온라인)*/
                case (int)cate_type.Gmarket:
                    jung.onlineshopping(won);
                    star.onlineshopping(won);
                    hangbok.onlineshopping(won);
                    naman.onlineshopping(won);
                    baedal.onlineshopping(won);
                    wibee.onlineshopping(won);
                    s20pink.shopping(won);
                    break;
                case (int)cate_type.Auction:
                    jung.onlineshopping(won);
                    star.onlineshopping(won);
                    hangbok.onlineshopping(won);
                    naman.onlineshopping(won);
                    baedal.onlineshopping(won);
                    s20pink.shopping(won);
                    break;
                case (int)cate_type.road_11:
                    hangbok.onlineshopping(won);
                    naman.onlineshopping(won);
                    wibee.onlineshopping(won);
                    s20pink.shopping(won);
                    break;
                case (int)cate_type.Qoopang:
                    chungchundarto.shopping(won);
                    hangbok.onlineshopping(won);
                    wibee.onlineshopping(won);
                    savezone.social(won);
                    enjoy_everyday.social(won);
                    daiso.social(won);
                    break;
                case (int)cate_type.Wemape:
                    chungchundarto.shopping(won);
                    hangbok.onlineshopping(won);
                    savezone.social(won);
                    enjoy_everyday.social(won);
                    daiso.social(won);
                    break;
                case (int)cate_type.Interpark:
                    s20pink.shopping(won);
                    break;
                case (int)cate_type.Maxmovie:
                    break;
                case (int)cate_type.Tmon:
                    chungchundarto.shopping(won);
                    hangbok.onlineshopping(won);
                    daiso.social(won);
                    break;
                case (int)cate_type.ZeroToSeven:
                    hangbok.onlineshopping(won);
                    break;
                case (int)cate_type.WebeeMarket:
                    baedal.onlineshopping(won);
                    wibee.onlineshopping(won);
                    break;
                case (int)cate_type.TicketMonster:
                    wibee.onlineshopping(won);
                    savezone.social(won);
                    enjoy_everyday.social(won);
                    break;
                case (int)cate_type.Yogiyo:
                    yogiyo.yogiyo(won);
                    break;
                case (int)cate_type.CJMall:
                    wibee.onlineshopping(won);
                    break;
                case (int)cate_type.LotteDotCom:
                    wibee.onlineshopping(won);
                    break;
                case (int)cate_type.Allcanto:
                    break;
                case (int)cate_type.eight:
                    break;
                case (int)cate_type.LF:
                    break;

                /*해외*/
                case (int)cate_type.Google:
                    chungchundarto.foreign(won);
                    sline.foreign(won);
                    break;
                case (int)cate_type.App:
                    chungchundarto.foreign(won);
                    sline.foreign(won);
                    break;
                case (int)cate_type.VISA:
                    chungchundarto.foreign(won);
                    sline.foreign(won);
                    break;
                case (int)cate_type.Master:
                    chungchundarto.foreign(won);
                    sline.foreign(won);
                    break;

                /*대중교통*/
                case (int)cate_type.bus:
                    chungchundarto.traffic(won);
                    hoon.traffic(won);
                    min.traffic(won);
                    jung.traffic(won);
                    eum.traffic(won);
                    gaon.traffic(won);
                    star.traffic(won);
                    between.traffic(won);
                    hangbok.traffic(won);
                    uri.traffic(won);
                    lotte.traffic(won);
                    wibee.traffic(won);
                    sline.traffic(won);
                    schoice_traffic.traffic(won);
                    s20.traffic(won);
                    s20pink.traffic(won);
                    enjoy_everyday.traffic(won);
                    break;
                case (int)cate_type.metro:
                    chungchundarto.traffic(won);
                    hoon.traffic(won);
                    min.traffic(won);
                    jung.traffic(won);
                    eum.traffic(won);
                    gaon.traffic(won);
                    star.traffic(won);
                    between.traffic(won);
                    hangbok.traffic(won);
                    uri.traffic(won);
                    baedal.traffic(won);
                    lotte.traffic(won);
                    wibee.traffic(won);
                    sline.traffic(won);
                    schoice_traffic.traffic(won);
                    s20.traffic(won);
                    s20pink.traffic(won);
                    enjoy_everyday.traffic(won);
                    break;
                case (int)cate_type.taxi:
                    chungchundarto.taxi(won);
                    wibee.taxi(won);
                    sline.traffic(won);
                    schoice_traffic.traffic(won);
                    s20.traffic(won);
                    s20pink.traffic(won);
                    break;
                case (int)cate_type.TM:
                    chungchundarto.traffic(won);
                    hoon.traffic(won);
                    min.traffic(won);
                    jung.traffic(won);
                    eum.traffic(won);
                    gaon.traffic(won);
                    star.traffic(won);
                    between.traffic(won);
                    hangbok.traffic(won);
                    uri.traffic(won);
                    lotte.traffic(won);
                    wibee.traffic(won);
                    sline.traffic(won);
                    schoice_traffic.traffic(won);
                    s20.traffic(won);
                    s20pink.traffic(won);
                    break;

                /*뷰티*/
                case (int)cate_type.OliveYoung:
                    chungchundarto.beauty(won);
                    jung.beauty(won);
                    star.oliveyoung(won);
                    juniorlife.beauty(won);
                    between.beauty(won);
                    wibee.convenience_beauty(won);
                    s20pink.shopping(won);
                    enjoy_everyday.convenience(won);
                    daiso.convience(won);
                    break;
                case (int)cate_type.ParkHairStudio:
                    chungchundarto.beauty(won);
                    jung.beauty(won);
                    juniorlife.beauty(won);
                    between.beauty(won);
                    daiso.hair(won);
                    break;
                case (int)cate_type.Watsons:
                    jung.beauty(won);
                    wibee.convenience_beauty(won);
                    daiso.convience(won);
                    break;
                case (int)cate_type.Aritaum:
                    jung.beauty(won);
                    break;
                case (int)cate_type.espoir:
                    break;
                case (int)cate_type.etude:
                    break;

                /*홈쇼핑*/
                case (int)cate_type.GSShopping:
                    jung.homeshopping(won);
                    sline.home_shopping(won);
                    break;
                case (int)cate_type.CJShopping:
                    jung.homeshopping(won);
                    sline.home_shopping(won);
                    break;

                /*여행*/
                case (int)cate_type.daemyung:
                    break;
                case (int)cate_type.bearsresort:
                    break;
                case (int)cate_type.sheraton:
                    break;
                case (int)cate_type.tourvis:
                    break;
                case (int)cate_type.hanatour:
                    chungchundarto.travle(won);
                    break;
                case (int)cate_type.modutour:
                    chungchundarto.travle(won);
                    break;

                /*의료*/
                case (int)cate_type.hospi:
                    hoon.pharmacy(won);
                    hangbok.hostipal(won);
                    uri.hospital(won);
                    break;

                /*패스트푸드*/
                case (int)cate_type.Mr:
                    min.fastfood(won);
                    pop.snack(won);
                    break;
                case (int)cate_type.King:
                    min.fastfood(won);
                    break;
                case (int)cate_type.KFC:
                    min.fastfood(won);
                    break;
                case (int)cate_type.bulgogiBro:
                    break;

                /*대형마트*/
                case (int)cate_type.LotteMart:
                    min.mart(won);
                    lotte.department(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.EMart:
                    min.mart(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.Homeplus:
                    min.mart(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.Shinsegye:
                    jung.mart(won);
                    naman.mart(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.Hyundae:
                    jung.mart(won);
                    naman.mart(won);
                    hyundae.department(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.Lotte:
                    jung.mart(won);
                    naman.mart(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.Galleria:
                    naman.mart(won);
                    schoice_shopping.shopping(won);
                    break;
                case (int)cate_type.daiso:
                    chungchundarto.daiso(won);
                    daiso.daiso(won);
                    break;
                case (int)cate_type.LotteSuper:
                    break;
                case (int)cate_type.GSSuper:
                    break;
                case (int)cate_type.Hanaro:
                    break;
                case (int)cate_type.Shilla:
                    break;
                case (int)cate_type.ABC:
                    break;

                /*영화*/
                case (int)cate_type.LotteCinema:
                    naman.movie(won);
                    baedal.movie(won);
                    hyundae.movie(won);
                    lotte.movie(won);
                    lg.movie(won);
                    uni.movie(won);
                    savezone.movie(won);
                    enjoy_everyday.movie(won);
                    culture_yungsung.movie(won);
                    daiso.movie(won);
                    break;
                case (int)cate_type.CGV:
                    gaon.CGV(won);
                    star.cgv(won);
                    juniorlife.movie(won);
                    between.movie(won);
                    naman.movie(won);
                    baedal.movie(won);
                    hyundae.movie(won);
                    lotte.movie(won);
                    lg.movie(won);
                    uni.movie(won);
                    myalpha.movie(won);
                    savezone.movie(won);
                    enjoy_everyday.movie(won);
                    culture_yungsung.movie(won);
                    daiso.movie(won);
                    break;
                case (int)cate_type.Megabox:
                    juniorlife.movie(won);
                    between.movie(won);
                    naman.movie(won);
                    baedal.movie(won);
                    hyundae.movie(won);
                    lotte.movie(won);
                    lg.movie(won);
                    uni.movie(won);
                    savezone.movie(won);
                    enjoy_everyday.movie(won);
                    culture_yungsung.movie(won);
                    break;
                case (int)cate_type.Cinecube:
                    naman.movie(won);
                    lotte.movie(won);
                    lg.movie(won);
                    savezone.movie(won);
                    break;
                case (int)cate_type.PrimusCinema:
                    naman.movie(won);
                    lotte.movie(won);
                    lg.movie(won);
                    bigpluse.movie(won);
                    s2030.movie(won);
                    savezone.movie(won);
                    break;
                case (int)cate_type.Seoul:
                    naman.movie(won);
                    lotte.movie(won);
                    lg.movie(won);
                    savezone.movie(won);
                    break;
                case (int)cate_type.MaxMovie:
                    bigpluse.movie(won);
                    s20.movie(won);
                    s20pink.movie(won);
                    s2030.movie(won);
                    savezone.movie(won);
                    break;
                case (int)cate_type.interpark:
                    bigpluse.movie(won);
                    s2030.movie(won);
                    savezone.movie(won);
                    culture_yungsung.movie(won);
                    break;
                case (int)cate_type.yes24movie:
                    bigpluse.movie(won);
                    s2030.movie(won);
                    savezone.movie(won);
                    break;

                /*외식*/
                case (int)cate_type.Outback:
                    gaon.restaurant(won);
                    star.restaurant(won);
                    juniorlife.restaurant(won);
                    between.restaurant(won);
                    hangbok.restaurant(won);
                    uri.restaurant(won);
                    hyundae.restaurant(won);
                    hyundae.restaurant(won);
                    lg.restaurant(won);
                    pop.restaurant(won);
                    uni.restaurant(won);
                    s2030.outback(won);
                    savezone.food(won);
                    break;
                case (int)cate_type.VIPS:
                    gaon.restaurant(won);
                    star.restaurant(won);
                    juniorlife.restaurant(won);
                    between.restaurant(won);
                    hangbok.restaurant(won);
                    hyundae.restaurant(won);
                    lg.restaurant(won);
                    pop.restaurant(won);
                    uni.restaurant(won);
                    savezone.food(won);
                    break;
                case (int)cate_type.TGIF:
                    juniorlife.restaurant(won);
                    between.restaurant(won);
                    hangbok.restaurant(won);
                    uri.restaurant(won);
                    hyundae.restaurant(won);
                    hyundae.restaurant(won);
                    pop.restaurant(won);
                    uni.restaurant(won);
                    savezone.food(won);
                    break;
                case (int)cate_type.Sevensprings:
                    juniorlife.restaurant(won);
                    between.restaurant(won);
                    break;
                case (int)cate_type.Venigence:
                    hyundae.restaurant(won);
                    pop.restaurant(won);
                    uni.restaurant(won);
                    break;
                case (int)cate_type.Uno:
                    hyundae.restaurant(won);
                    pop.restaurant(won);
                    uni.restaurant(won);
                    break;
                case (int)cate_type.baemin:
                    baedal.baemin(won);
                    break;

                /*커피*/
                case (int)cate_type.Starbucks:
                    eum.coffee(won);
                    gaon.starbucks(won);
                    hangbok.coffee(won);
                    uri.coffee(won);
                    baedal.starbucks(won);
                    hyundae.coffee(won);
                    hyundae.coffee(won);
                    lg.coffee(won);
                    pop.coffee(won);
                    uni.coffee(won);
                    schoice_coffe.coffee(won);
                    toxalpha.coffee(won);
                    savezone.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;
                case (int)cate_type.Coffeebin:
                    juniorlife.coffeebin(won);
                    between.coffeebin(won);
                    hangbok.coffee(won);
                    hyundae.coffee(won);
                    lg.coffee(won);
                    pop.coffee(won);
                    uni.coffee(won);
                    schoice_coffe.coffee(won);
                    toxalpha.coffee(won);
                    savezone.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;
                case (int)cate_type.Cafebene:
                    eum.coffee(won);
                    hangbok.coffee(won);
                    schoice_coffe.coffee(won);
                    toxalpha.coffee(won);
                    savezone.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;
                case (int)cate_type.Twosomeplace:
                    eum.coffee(won);
                    uri.coffee(won);
                    hyundae.coffee(won);
                    schoice_coffe.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;
                case (int)cate_type.Ediya:
                    schoice_coffe.coffee(won);
                    yogiyo.ediya(won);
                    break;
                case (int)cate_type.beansbeans:
                    schoice_coffe.coffee(won);
                    break;
                case (int)cate_type.Hollys:
                    schoice_coffe.coffee(won);
                    eum.coffee(won);
                    savezone.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;
                case (int)cate_type.Tiamo:
                    schoice_coffe.coffee(won);
                    toxalpha.coffee(won);
                    break;
                case (int)cate_type.zoo:
                    schoice_coffe.coffee(won);
                    toxalpha.coffee(won);
                    break;
                case (int)cate_type.palombini:
                    break;
                case (int)cate_type.arista:
                    break;
                case (int)cate_type.coffine:
                    schoice_coffe.coffee(won);
                    toxalpha.coffee(won);
                    break;
                case (int)cate_type.pass:
                    break;
                case (int)cate_type.Tam:
                    eum.coffee(won);
                    toxalpha.coffee(won);
                    savezone.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;
                case (int)cate_type.droptop:
                    toxalpha.coffee(won);
                    break;
                case (int)cate_type.angelinus:
                    schoice_coffe.coffee(won);
                    eum.coffee(won);
                    savezone.coffee(won);
                    enjoy_everyday.coffee(won);
                    daiso.coffee(won);
                    break;

                /*놀이공원*/
                case (int)cate_type.EverLand:
                    gaon.ever_lotteworld(won);
                    star.everland(won);
                    juniorlife.amusementpark(won);
                    between.amusementpark(won);
                    naman.amusement(won);
                    uri.amusement(won);
                    lotte.amusement(won);
                    lg.amusement(won);
                    pop.amusement(won);
                    uni.amusement(won);
                    s2030.park(won);
                    wingp.park(won);
                    myalpha.park(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    daiso.park(won);
                    break;
                case (int)cate_type.LotteWorld:
                    gaon.ever_lotteworld(won);
                    juniorlife.amusementpark(won);
                    between.amusementpark(won);
                    naman.amusement(won);
                    uri.amusement(won);
                    pop.amusement(won);
                    uni.amusement(won);
                    bigpluse.park(won);
                    s20.park(won);
                    s20pink.park(won);
                    s2030.park(won);
                    wingp.park(won);
                    myalpha.park(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    daiso.park(won);
                    break;
                case (int)cate_type.SeoulLand:
                    juniorlife.amusementpark(won);
                    between.amusementpark(won);
                    naman.amusement(won);
                    uri.amusement(won);
                    lotte.amusement(won);
                    lg.amusement(won);
                    pop.amusement(won);
                    uni.amusement(won);
                    bigpluse.park(won);
                    s20.park(won);
                    s20pink.park(won);
                    s2030.park(won);
                    wingp.park(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    daiso.park(won);
                    break;
                case (int)cate_type.EWorld:
                    naman.amusement(won);
                    uri.amusement(won);
                    lotte.amusement(won);
                    lg.amusement(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    daiso.park(won);
                    break;
                case (int)cate_type.GyeonjuWorld:
                    naman.amusement(won);
                    uri.amusement(won);
                    lotte.amusement(won);
                    lg.amusement(won);
                    pop.amusement(won);
                    uni.amusement(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    break;
                case (int)cate_type.TongdoFantasia:
                    naman.amusement(won);
                    uri.amusement(won);
                    lotte.amusement(won);
                    lg.amusement(won);
                    pop.amusement(won);
                    uni.amusement(won);
                    wingp.park(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    daiso.park(won);
                    break;
                case (int)cate_type.CarribeanBay:
                    pop.amusement(won);
                    uni.amusement(won);
                    wingp.park(won);
                    break;
                case (int)cate_type.CalifoniaBeach:
                    pop.amusement(won);
                    uni.amusement(won);
                    break;
                case (int)cate_type.HanggukMinsokchon:
                    pop.amusement(won);
                    uni.amusement(won);
                    break;
                case (int)cate_type.SeolackWater:
                    wingp.park(won);
                    break;
                case (int)cate_type.gawngjuFamily:
                    pop.amusement(won);
                    uni.amusement(won);
                    wingp.park(won);
                    savezone.park(won);
                    enjoy_everyday.park(won);
                    daiso.park(won);
                    break;

                /*주유*/
                case (int)cate_type.GSOil:
                    star.gsoil(won);
                    hyundae.oil(won);
                    pop.oil(won);
                    myalpha.oil(won);
                    break;
                case (int)cate_type.SOil:
                    min.oil(won);
                    hyundae.oil(won);
                    uni.oil(won);
                    wibee.oil(won);
                    break;
                case (int)cate_type.HyundaeOil:
                    s2030.oil(won);
                    break;
                case (int)cate_type.E1:
                    break;
                case (int)cate_type.speedmate:
                    break;
                case (int)cate_type.SK:
                    sline.oil(won);
                    break;


                /*서점*/
                case (int)cate_type.GyoboBook:
                    hoon.book(won);
                    gaon.gyobo(won);
                    star.gyobo(won);
                    juniorlife.gyobo(won);
                    between.gyobo(won);
                    hyundae.books(won);
                    pop.books(won);
                    uni.books(won);
                    s20.kyobo(won);
                    culture_yungsung.book(won);
                    break;
                case (int)cate_type.YoungpoongBook:
                    hoon.book(won);
                    hyundae.books(won);
                    pop.books(won);
                    uni.books(won);
                    culture_yungsung.book(won);
                    break;
                case (int)cate_type.Yes24:
                    hoon.book(won);
                    hyundae.books(won);
                    pop.books(won);
                    break;
                case (int)cate_type.BandiAndRoonies:
                    hoon.book(won);
                    s20.kyobo(won);
                    culture_yungsung.book(won);
                    break;

                /*항공*/
                case (int)cate_type.JejuAir:
                    juniorlife.jejuair(won);
                    between.jejuair(won);
                    break;
                case (int)cate_type.koreanAir:
                    break;

                /*가맹점(간식)*/
                case (int)cate_type.ParisBaguette:
                    eum.snack(won);
                    baedal.snack(won);
                    break;
                case (int)cate_type.BeskinRabins:
                    eum.snack(won);
                    baedal.snack(won);
                    break;
                case (int)cate_type.DunkinDonut:
                    eum.snack(won);
                    baedal.snack(won);
                    break;
                case (int)cate_type.MrDonut:
                    break;
                case (int)cate_type.osulloc:
                    break;
                case (int)cate_type.parnas:
                    break;
                case (int)cate_type.orga:
                    break;
                case (int)cate_type.obong:
                    break;
                case (int)cate_type.lohbs:
                    break;
                case (int)cate_type.Torejour:
                    eum.snack(won);
                    break;

                /*학원*/
                case (int)cate_type.YBM:
                    hoon.academe(won);
                    baedal.academe(won);
                    s20.english(won);
                    break;
                case (int)cate_type.Pagoda:
                    hoon.academe(won);
                    baedal.academe(won);
                    s20.english(won);
                    break;
                case (int)cate_type.Hackers:
                    hoon.academe(won);
                    baedal.academe(won);
                    break;
                case (int)cate_type.call:
                    hyundae.call(won);
                    pop.call(won);
                    uni.toeic(won);
                    break;

                /*어학시험*/
                case (int)cate_type.TOEIC:
                    pop.toeic(won);
                    uni.toeic(won);
                    s20.toeic(won);
                    break;
                case (int)cate_type.OPIC:
                    break;
                case (int)cate_type.JPT:
                    break;
                case (int)cate_type.HSK:
                    break;

                /*롯데렌트카*/
                case (int)cate_type.LotteRentcar:
                    myalpha.rentcar(won);
                    break;

                /*통신사*/
                case (int)cate_type.SKT:
                    min.mobile(won);
                    gaon.mobile(won);
                    star.mobile(won);
                    hangbok.mobile(won);
                    baedal.mobile(won);
                    lg.lgu(won);
                    s20.mobile(won);
                    s20pink.mobile(won);
                    toxalpha.mobile(won);
                    break;
                case (int)cate_type.KT:
                    min.mobile(won);
                    gaon.mobile(won);
                    star.mobile(won);
                    hangbok.mobile(won);
                    baedal.mobile(won);
                    s20.mobile(won);
                    s20pink.mobile(won);
                    toxalpha.mobile(won);
                    break;
                case (int)cate_type.LG:
                    min.mobile(won);
                    gaon.mobile(won);
                    star.mobile(won);
                    hangbok.mobile(won);
                    baedal.mobile(won);
                    s20.mobile(won);
                    s20pink.mobile(won);
                    toxalpha.mobile(won);
                    break;
                default:
                    break;
            }
        }
    }
}