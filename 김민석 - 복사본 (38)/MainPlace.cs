using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static STS.UnitList;
using static STS.Card;
using static STS.Program;
using static STS.MainPlace;
namespace STS
{
    


    public class MainPlace
    {




        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);

            Card A1 = new Card("공격", 7, 1, 0,0); //카드의 이름,데미지,코스트,특수효과종류,타입
            Card A2 = new Card("움츠러들기", 14, 2, 2,1); //특수효과 1->코스트회복
            Card A3 = new Card("강타", 12, 2, 0,0);        //특수효과 2->HP회복
            Card A4 = new Card("동전 두 닢", 2, 0, 1,1);    

            Card B1 = new Card("정신자극", 3, 0, 1,1);    //타입0->일반카드
            Card B2 = new Card("저주", 5, 3, 3, 1);     //타입1->마법카드
            Card B3 = new Card("얼음 화살",15,1,0,1);       //실제로 플레이해보니깐 마법카드 일방적 사용하면 서로 주고받는딜이 존나아픈데?

            Card C1 = new Card("번개 화살", 17, 2, 1,0);    
            Card C2 = new Card("흡혈", 20, 4, 2, 0);
            Card C3 = new Card("운명의 여로", 0,1, 0, 5);

            Card D1 = new Card("급속 성장", 5, 1, 1, 1);    
            Card D2 = new Card("원망", 10, 5, 3, 1);
            Card D3 = new Card("고통의 메아리", 20, 1, 2, 0);

            Card E1 = new Card("선조의 치유", 100, 10, 2, 1);   
            Card E2 = new Card("대단원의 막 ", 0, 0, 0, 4);
            Card E3 = new Card("남극", 50, 10, 0, 0);


            Player player = new Player("펭귄", 100,1, 5, 0,100); // 이름 체력 공격력 코스트  CDMG

            Monster monster1 = new Monster("오리너구리", 80, 10, 0, 0,10);
            Monster monster2 = new Monster("칼치", 140, 15, 0, 0, 15);
            Monster monster3 = new Monster("북극곰", 200, 19, 0, 0,19);
            Monster monster4 = new Monster("범고래", 250, 22, 0, 0,22);
            Monster monster5 = new Monster("마지막 인간", 300, 25, 0, 0,25);

            Program program = new Program(player);

            int selectcard = 0;
            bool triger = true;
            bool F1 = false;




            //Newgame(triger, F1, program, player, monster1, selectcard); //1층
            //Reward(player, B1, B2, B3);//보상 B테이블
            //  Shelter(triger, F1, program, player, selectcard);
            //Ending();

            Start();//시작화면

            NoobDeck(player, A1, A2, A3, A4); //뉴비용 덱 지급
            
            Newgame(triger, F1, program, player, monster1, selectcard); //1층
            
            Reward(player, B1, B2, B3);//보상 B테이블

            Shelter(triger, F1, program, player, selectcard);

            Newgame(triger, F1, program, player, monster2, selectcard);//2층

            Reward(player, C1,C2,C3);//보상 C테이블

            Shelter(triger, F1, program, player, selectcard);

            Newgame(triger, F1, program, player, monster3, selectcard);//3층

            Reward(player, D1, D2, D3);//보상 D테이블

            Shelter(triger, F1, program, player, selectcard);

            Newgame(triger, F1, program, player, monster4, selectcard);//4층

            Reward(player, E1, E2, E3);//보상E테이블

            Shelter(triger, F1, program, player, selectcard);

            Newgame(triger, F1, program, player, monster5, selectcard);//5층

            Ending();//엔딩


        }
    }
}
