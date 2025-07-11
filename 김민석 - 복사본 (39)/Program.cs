using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static STS.UnitList;
using static STS.Card;
using static STS.MainPlace;
using System.Security.Cryptography.X509Certificates;
namespace STS
{



    public class Program

    {
        public static void Start()
        {

            string[] lines = new string[]
 {
"                                                                             ##    ",
" #### ##               ###### ##           ### ###                           ## ## ",
"##  # ##               # ## # ##            ##  #                               ## ",
"###   ##  ##   ## ##     ##   ####   ###    ## #    ## ## ## ## # ##    #### ## ## ",
" ###  ## # ##  ## ##     ##   ## #  ## #    ####    ## ## ## #  ## ##  ## #  ## ## ",
"  ### ##  ###   ###      ##   ## #  ####    ## ##    ###  ## #  ## ##  ## #  ## ## ",
"#  ## ## #  #   ###      ##   ## #  ##      ## ###   ###  ## #  ## ##   ###  ## ## ",
"####  ## #####   #      ####  ## ##  ###   ###  ###   #    ###  ## ### ##    ## ## ",
"               # #                                  # #                ####        ",
"               ###                                  ###                #  #        ",
"                                                                       ####        "
 };

            int garo = 13;
            int sero = 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(garo, sero);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                sero++;
                if (sero >= Console.BufferHeight)
                    sero = Console.BufferHeight - 1;
                Console.SetCursorPosition(garo, sero);
            }
            Console.ResetColor();

            PrintFrame2();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(45, 20);
            Console.Write("Press any key to continue...");
            
         
            Console.ReadKey();

            garo = 13;
            sero = 5;
            Console.SetCursorPosition(garo, sero);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                sero++;
                if (sero >= Console.BufferHeight)
                    sero = Console.BufferHeight - 1;
                Console.SetCursorPosition(garo, sero);
            }

            Console.ResetColor();

            Console.SetCursorPosition(45, 20);
            Console.Write("                                     ");

            Thread.Sleep(2500);
            Console.Clear();
        } //시작화면
        

        public static void PrintTurn(int turn) //턴표시
        {
            Console.SetCursorPosition(45, 0);
            Console.Write($"{turn} turn ");
        }

        public static void NoobDeck(Player player, Card card1, Card card2, Card card3, Card card4)
        {
            player.GetCard(card1);
            player.GetCard(card2);
            player.GetCard(card3);
            player.GetCard(card4);
            player.GetCard(card1);
            player.GetCard(card3);
            PrintFrame2();

            int waitTimes = 2000;
            string[] messages = {
    "정신을 차려보니..",
    "첨탑 같아보이는 구조물의 어딘가에서 눈이 떠졌다..",
    "여길 벗어나서 집으로 돌아가야해 ..",
    "일단은 모든 것이 보일 높은 곳으로 올라가보자..",
    "깨어난 곳 옆에는 의문의 종이 뭉치가 있었다.",
    "어딘가 쓸 수 있겠지라 믿으며 일단 주머니에 넣었다.." };

            // "높은 곳" 부분만 노란색으로 변경하여 문자열 생성
            string coloredMessage = messages[3].Substring(0, 13) + "\u001b[33m" + messages[3].Substring(13, 4) + "\u001b[0m" + messages[3].Substring(17);





            for (int i = 0; i <= 1; i++)
            {
                Centermentnew(i);
                Console.WriteLine(messages[i]);
                Thread.Sleep(waitTimes);

            }

            for (int i = 0; i < 3; i++) //2줄 제거
            {
                // 화면에 출력
                Centermentnew(i);
                Console.Write("                                                  ");

            }
            Thread.Sleep(1000);
            Centermentnew(0);
            Console.Write(messages[2]);
            Thread.Sleep(1500);
            Centermentnew(1);
            Console.WriteLine(coloredMessage);
            Thread.Sleep(2000);
            for (int i = 0; i < 3; i++) //2줄 제거
            {

                // 화면에 출력
                Centermentnew(i);
                Console.Write("                                                  ");

            }


            for (int i = 0; i < 2; i++)
            {

                Centermentnew(i);
                Console.Write(messages[i + 4]);
            }

            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(45, 20);
            Console.Write("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        //뉴비용 시작덱지급
        public static void Drowingcard(Card card, int x, int y)
        {
            int max = 1;
            for (int R = 0; R < max; R++) //카드그리기 
            {
                PrintFrame();

                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write(card.CardName);
                Console.SetCursorPosition(x + 1, y + 2);
                Console.Write($"코스트 : {card.CardCost}");
                Console.SetCursorPosition(x + 1, y + 3);
                Console.Write($"위력 : {card.CardDMG}");
                if (card.Efchak > 0)
                {
                    Console.SetCursorPosition(x + 1, y + 4);
                    card.EfCard();
                }
                if (card.Type == 1)
                {
                    Console.SetCursorPosition(x + 1, y + 6);
                    Console.Write("마법 카드");
                }

                if (card.Type == 0)
                {
                    Console.SetCursorPosition(x + 1, y + 6);
                    Console.Write("일반 카드");
                }
                if (card.Type == 4)
                {
                    Console.SetCursorPosition(x + 1, y + 4);
                    Console.Write("덱에 카드가");
                    Console.SetCursorPosition(x + 1, y + 5);
                    Console.Write("비면 위력증가");
                }
                if (card.Type == 5)
                {
                    Console.SetCursorPosition(x + 1, y + 4);
                    Console.Write("턴 마다");
                    Console.SetCursorPosition(x + 1, y + 5);
                    Console.Write("위력 증가");
                }

                Console.SetCursorPosition(x, y);
                Console.Write("===============");
                Console.SetCursorPosition(x, y + 7);
                Console.Write("===============");
                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(x - 1, y + i);
                    Console.Write('|');
                    Console.SetCursorPosition(x + 14, y + i);
                    Console.Write('|');
                }


            }
        }
        //카드그리기

        public static void Centerment() //센터에 멘트출력
        {
            Console.SetCursorPosition(40, 13);
        }
        
        public static void Centerment1() //센터에 멘트출력2
        {
            Console.SetCursorPosition(40, 14);
        }

        public static void Centerment2() //센터에 멘트출력3
        {
            Console.SetCursorPosition(40, 15);
        }
        //다음부터는 이딴짓안하고 int형 두개받아다가 작업하겠음..
        public static void Centermentnew(int a)
        {
            int top = 13 + a;
            int maxTop = Console.BufferHeight - 1;
            if (top < 0) top = 0;
            if (top > maxTop) top = maxTop;
            Console.SetCursorPosition(40, top);
        }

        // Player 인스턴스를 받아오는 생성자

        private Player player;
        public Program(Player player)
        {
            this.player = player;
        }


        public static void Newgame(bool triger, bool F1, Program program, Player player, Monster monster, int selectcard)
    
        {


            player.CopyTempCard();  //temp 카드를 새로 생성후 덱의카드를 할당
            player.ShuffleTempCard(); //temp 카드를 섞음
            player.UnitCost = 5;    //게임시작시 유저 코스트는 5로초기화시키겠음.
                                    //회복은안함
            Centerment();
            Console.Write($"탑을 오르던중 {monster.UnitName}와(가) 조우했다..!!!");
            PrintFrame();

            Console.ReadKey();
            int turn = 0;
            int debuffc = 0;
            bool debuff = false;

            F1 = true;
            while (triger)                      // 1층
            {
                program.PlayerDie(player, triger);

                ConsoleKeyInfo input;

                if (monster.UnitAtk < 0)
                {
                    monster.UnitAtk = 0;
                } //몬스터 의 공격력은 0미만이 됄수없음

                if (F1) //F1이 기본적으로 true이며 이걸로 턴을 체크함 이동,도움말등으로 F1의 카운터가 f일때는 턴진행을안함
                {
                    debuffc++;
                    
                    if (debuffc >= 3)
                    {
                        debuff = true;
                    }
                    if (debuff) //기본적으로 fals이며 디버프 카운트가 2이상일시 실행
                                //몬스터의 공격력을 원래 공격력으로 돌려놓음
                    {
                        monster.UnitAtk = monster.OriginalAtk;
                        debuff = false;
                    }
                    turn++;
                    program.Newturn(program, player, monster, selectcard, turn);
                    PrintTurn(turn);
                }
                else
                {
                    
                    Printscreen();
                    PrintTurn(turn);
                    player.PlayerSTS(player);
                    monster.MonsterSTS(monster);
                    player.Viewhandcard(selectcard, turn);
                }


                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (selectcard >= 1)
                        {
                            //Console.Clear();
                            selectcard--;
                            program.seletiedmove(program, player, monster, selectcard,turn);
                            F1 = false;
                            break;
                        }
                        //Console.Clear();
                        program.seletiedmove(program, player, monster, selectcard, turn);
                        F1 = false;
                        break;

                    case ConsoleKey.RightArrow:
                        if (selectcard <= 2)
                        {
                            //Console.Clear();
                            selectcard++;
                            program.seletiedmove(program, player, monster, selectcard, turn);
                            F1 = false;
                            break;
                        }
//                        Console.Clear();
                        program.seletiedmove(program, player, monster, selectcard, turn);
                        F1 = false;
                        break;

                    case ConsoleKey.Enter: // 선택한 카드 시전해서 적 공격하게 짜서 넣을것
                                           //if (selectcard >= 4)
                        {
                            F1 = true;
                            program.EndturnforEnter(program, player, monster, selectcard, ref F1, ref debuffc);
                            break;
                        }


                    case ConsoleKey.F1://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            FrameClear();
                            Printscreen();
                            player.F1CardList();
                            F1 = false;
                            Console.ReadKey();
                            FrameClear();
                            Printscreen();
                            break;
                        }
                    case ConsoleKey.F2://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            FrameClear();
                            Printscreen();
                            Help();
                            F1 = false;
                            Console.ReadKey();
                            FrameClear();
                            Printscreen();
                            break;
                        }


                    case ConsoleKey.Escape://턴 종료에 따른 시퀀스
                        {
                            program.EndturnforEsc(program, player, monster, selectcard);
                            
                            Console.ReadKey();
                            //FrameClear();
                            Centermentnew(0);
                            Console.Write("                                  ");
                            Centermentnew(1);
                            Console.Write("                                  ");
                            F1 = true;
                            break;
                        }

                    default:
                        //Console.Clear();
                        program.seletiedmove(program, player, monster, selectcard, turn);
                        F1 = false;
                        break;


                }
                if (monster.UnitHp <= 0)
                {
                    FrameClear();
                    PrintFrame();
                    Centerment();
                    Console.Write($"{monster.UnitName}가 쓰러졌다..");
                    Console.ReadKey();
                    triger = false;
                }
            }
        }
        //새 게임(데이터에따라 층계로구성)
        public void PlayerDie(Player player, bool triger) 
        {
            if (player.UnitHp <= 0)
            {
                FrameClear();
                //Console.Clear();
                Printscreen();
                Centerment();
                Console.Write("여정이 끝났다..");
                Console.SetCursorPosition(0, 28);
                Environment.Exit(0);
            }


        }
        //플레이어의 생존을 체크
        public static void Reward(Player player, Card card1, Card card2, Card card3)
        {
            player.OriginalHp = player.OriginalHp + 40;

            if (player.UnitHp>player.OriginalHp)
            {
                player.UnitHp = player.OriginalHp;
            }

            box();
            PrintFrame();
            Centerment();
            Console.SetCursorPosition(45, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   전리품을 흭득해보자..!");
            Console.ResetColor();
            Console.ReadKey();
            int max = 1;
            int Selet = 0;
            bool triger = true;
            int trigerch = 0;
            FrameClear();
            while (triger)
            {
               
                int y = 10;
                int x = 20;
                //Console.Clear();
                if (Selet == 0)
                {
                    y = y - 5;
                    for( int i = 0; i<14; i++)
                    {
                        Console.SetCursorPosition(x - 1,y+i);
                        Console.Write("                ");

                    }
                }
                else
                    for( int i = 0;i<14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y-7+ i);
                        Console.Write("                ");
                    }

                Drowingcard(card1, x, y);

                y = 10;
                x = x + 20;
                if (Selet == 1)
                {
                    y = y - 5;
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write("                ");

                    }
                }
                else
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y - 7 + i);
                        Console.Write("                ");
                    }
                Drowingcard(card2, x, y);

                y = 10;
                x = x + 20;
                if (Selet == 2)
                {
                    y = y - 5;
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write("                ");

                    }
                }
                else
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y - 7 + i);
                        Console.Write("                ");
                    }
                Drowingcard(card3, x, y);

                y = 10;
                x = x + 20;
                if (Selet == 3)
                {
                    y = y - 5;
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write("                ");

                    }
                }
                else
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y - 7 + i);
                        Console.Write("                ");
                    }
                for (int R = 0; R < max; R++)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write($"  힘을 1 증가 ");
                    Console.SetCursorPosition(x, y);
                    Console.Write("===============");
                    Console.SetCursorPosition(x, y + 7);
                    Console.Write("===============");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write('|');
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.Write('|');
                    }
                }

                y = 10;
                x = x + 20;
                Console.SetCursorPosition(45, 2);
                {
                    Console.Write($"   보상 기회 {trigerch}/2");
                }

                ConsoleKeyInfo input;
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Selet > 0)
                        {
                            //Console.Clear();
                            Selet--;
                            break;
                        }
                        //Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (Selet < 3)
                        {
                            //Console.Clear();
                            Selet++;
                            break;

                        }
                        //Console.Clear();
                        break;

                    case ConsoleKey.Enter:
                        if (Selet == 0)
                        {
                            Console.Clear();
                            player.GetCard(card1);
                            trigerch++;
                            break;
                        }
                        else if (Selet == 1)
                        {
                            Console.Clear();
                            player.GetCard(card2);
                            trigerch++;
                            break;
                        }
                        else if (Selet == 2)
                        {
                            Console.Clear();
                            player.GetCard(card3);
                            trigerch++;
                            break;
                        }
                        else if (Selet == 3)
                        {
                            Console.Clear();
                            player.UnitAtk++;
                            trigerch++;
                            break;
                        }

                        break;


                    case ConsoleKey.F1://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            Console.Clear();
                            Printscreen();
                            player.F1CardList();

                            Console.ReadKey();
                            Console.Clear();
                            Printscreen();
                            break;
                        }
                    case ConsoleKey.F2://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            Console.Clear();
                            Printscreen();
                            Help();

                            Console.ReadKey();
                            Console.Clear();
                            Printscreen();
                            break;
                        }
                }
                if(trigerch>=2)
                {
                    triger = false;
                }

            }
        }
        //보상페이즈,층계에 맞는 보상으로구성



        public static void CardRemove(bool triger, Player player, int select)
        {
            int x = 5;
            int y = 5;
            select = 0;
            triger = true; //카드제거 페이즈 종료를 위한 트리거

            while (triger)
            {
                x = 5;
                y = 2;
                
                //PrintFrame();
                //Printscreen();
                int checker = 0;
                foreach (var card in player._PlayerCardlist)
                {
                    y = y + 2;

                    //if (select == player._PlayerCardlist.)
                    if (checker == select)
                    {
                        Console.SetCursorPosition(x - 2, y);
                        Console.Write("▶");
                    }
                    else
                    {
                        Console.SetCursorPosition(x - 3, y);
                        Console.Write("    ");

                    }
                    Console.SetCursorPosition(x, y);
                    if (card.Type == 1)
                    {
                        Console.Write($"{card.CardName}  코스트 : {card.CardCost} , 위력 :{card.CardDMG} , 마법카드");
                    }
                    else
                    {
                        Console.Write($"{card.CardName}  코스트 : {card.CardCost} , 위력 :{card.CardDMG} , 일반카드");
                    }
                    checker++;
                }


                ConsoleKeyInfo input;
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (select > 0)
                        {
                            //Console.Clear();
                            select--;
                            break;
                        }
                        //Console.Clear();
                        break;

                    case ConsoleKey.DownArrow:
                        if (select < player._PlayerCardlist.Count - 1)
                        {
                            //Console.Clear();
                            select++;
                            break;
                        }
                        //Console.Clear();
                        break;

                    case ConsoleKey.Enter:

                        if (select >= 0 && select < player._PlayerCardlist.Count)
                        {
                            LinkedListNode<Card> node = player._PlayerCardlist.First;
                            for (int i = 0; i < select; i++)
                            {
                                node = node.Next;
                            }
                            player._PlayerCardlist.Remove(node);
                        }

                        FrameClear();
                        triger = false;
                        break;


                    case ConsoleKey.F1://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            FrameClear();
                            player.F1CardList();
                            Console.ReadKey();
                            FrameClear();
                            Printscreen();
                            break;
                        }
                    case ConsoleKey.F2://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            FrameClear();
                            Help();
                            Console.ReadKey();
                            FrameClear();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Printscreen();
                            triger = false;
                        }
                        break;

                    default:

                        break;
                }
            }
        }
        //카드제거 페이즈
        public static void Shelter(bool triger, bool F1, Program program, Player player, int selectcard)
        {

            if (player.UnitHp > player.OriginalHp)
            {
                player.UnitHp = player.OriginalHp;
            }

            FrameClear(); 

            campfire();
            PrintFrame();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Centerment();
            Console.Write("따듯하고 아늑한 불이다..");
            Centerment1();
            Console.Write("소지품을 태우거나.. 불을 쬐며 잠에 들거나..");
            Centerment2();
            Console.Write("혹은 단련을 할수 있을꺼같다..");
            Console.ResetColor();
            Console.ReadKey();
            FrameClear();
            int y = 0;
            int x = 10;

            int max = 1;
            int Selet = 0;
            triger = true;
            F1 = true;
            int trigerch = 0;
            while (triger)
            {
                Printscreen();
                y = 14;
                x = 30;
                if (Selet == 0)
                {
                    y = y - 5;
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write("                ");

                    }
                }
                else
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y - 7 + i);
                        Console.Write("                ");
                    }
                for (int R = 0; R < max; R++)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write($"  카드 제거");
                    Console.SetCursorPosition(x, y);
                    Console.Write("===============");
                    Console.SetCursorPosition(x, y + 7);
                    Console.Write("===============");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write('|');
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.Write('|');
                    }
                }


                y = 14;
                x = x + 20;
                if (Selet == 1)
                {
                    y = y - 5;
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write("                ");

                    }
                }
                else
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y - 7 + i);
                        Console.Write("                ");
                    }
                for (int R = 0; R < max; R++)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write($"  체력 40회복");
                    Console.SetCursorPosition(x, y);
                    Console.Write("===============");
                    Console.SetCursorPosition(x, y + 7);
                    Console.Write("===============");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write('|');
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.Write('|');
                    }
                }

                y = 14;
                x = x + 20;
                if (Selet == 2)
                {
                    y = y - 5;
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write("                ");

                    }
                }
                else
                    for (int i = 0; i < 14; i++)
                    {
                        Console.SetCursorPosition(x - 1, y - 7 + i);
                        Console.Write("                ");
                    }
                for (int R = 0; R < max; R++)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write($"  힘을 1 증가 ");
                    Console.SetCursorPosition(x, y);
                    Console.Write("===============");
                    Console.SetCursorPosition(x, y + 7);
                    Console.Write("===============");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write('|');
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.Write('|');
                    }
                }
                player.PlayerSTS(player);
                Console.SetCursorPosition(45, 2);
                {
                    Console.Write($"   휴식 기회 {trigerch}/2");
                }
                ConsoleKeyInfo input;
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Selet > 0)
                        {
                            //Console.Clear();
                            Selet--;
                            break;
                        }
                        //Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (Selet < 2)
                        {
                            //Console.Clear();
                            Selet++;
                            break;

                        }
                        //Console.Clear();
                        break;

                    case ConsoleKey.Enter:
                        if (Selet == 0)
                        {
                            if (player._PlayerCardlist.Count > 4)
                            {
                                FrameClear();
                                CardRemove(triger, player, Selet);
                                trigerch++;
                                PrintFrame();
                                Centerment();
                                Console.Write("소지품에서 쓸모 없어 보이는 종이를 태웠다.");
                                Centerment1();
                                Console.Write("이건.. 이제 필요없을꺼야..");
                                Console.ReadKey();
                                FrameClear();
                                break;
                            }
                            else
                            {
                                FrameClear();
                                PrintFrame2();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Centerment();
                                Console.Write("덱은 4장 이상이어야 합니다.");
                                Console.ResetColor();
                                Console.ReadKey();
                                FrameClear();
                            }
                        }
                        else if (Selet == 1)
                        {
                            FrameClear();
                            player.OriginalHp = player.OriginalHp + 40;
                            player.UnitHp = player.UnitHp + 40;
                            trigerch++;
                            Centerment();
                            Console.Write("불가는 정말 따스하며 기분좋았다..");
                            Centerment1();
                            Console.Write("체력이 조금 회복되었다!");
                            PrintFrame();

                            Console.ReadKey();
                            FrameClear();
                            break;
                        }

                        else if (Selet == 2)
                        {
                            FrameClear();
                            player.UnitAtk++;
                            trigerch++;
                            Centerment();
                            Console.Write("건강한 신체에 건강한 정신이라 했던가..");
                            Centerment1();
                            Console.Write("단련으로 몸과 마음을 가다듬었다.");
                            Centerment2();
                            Console.Write("공격력이 증가 하였다.!");
                            PrintFrame();
                            Console.ReadKey();
                            FrameClear();
                            break;
                        }
                        break;

                    case ConsoleKey.F1://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            FrameClear();
                            Printscreen();
                            player.F1CardList();
                            F1 = false;
                            Console.ReadKey();
                            FrameClear();
                            Printscreen();
                            break;
                        }
                    case ConsoleKey.F2://누르면 내가 가진 카드리스트볼수있게해주려고함
                                       // 좌측 전체 카드리스트 우측 묘지 카드리스트 하면 괜찮을듯
                        {
                            //Console.Clear();
                            FrameClear();
                            Printscreen();
                            Help();
                            F1 = false;
                            Console.ReadKey();
                            FrameClear();
                            Printscreen();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {

                        }

                        break;



                }

                if (trigerch >= 2)
                {
                    triger = false;
                    FrameClear();
                    PrintFrame2();
                    Centerment();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("모닥불의 불꽃이 꺼졌다.");
                    Console.ResetColor();
                    Centerment2();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("다시 여정을 시작한다.");
                    Console.ResetColor();
                    Console.ReadKey();
                    FrameClear();

                }
            }

        }
        //휴식페이즈
        public static void Printscreen() //UI 프레임+도움말+조작을 호출
        {
            int x = 0;
            int y = 0;
            int garo = 110;
            int sero = 28;

            for (int i = 0; i < garo; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("=");
                Console.SetCursorPosition(x + i, sero);
                Console.Write("=");
            }
            for (int i = 0; i < sero + 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write('|');
                Console.SetCursorPosition(garo, y + i);
                Console.Write('|');
            }
            Console.SetCursorPosition(98, 1);
            Console.Write("F1 : 내 카드");
            Console.SetCursorPosition(98, 2);
            Console.Write("F2 : 도움말");
            Console.SetCursorPosition(97, 3);
            Console.Write("Esc : 턴 종료");
            Console.SetCursorPosition(97, 26);
            Console.Write("방향키 : 이동");
            Console.SetCursorPosition(97, 27);
            Console.Write("Enter : 확정");
        }
        public static void PrintFrame() //UI 프레임+조작을 호출
        {
            int x = 0;
            int y = 0;
            int garo = 110;
            int sero = 28;

            for (int i = 0; i < garo; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("=");
                Console.SetCursorPosition(x + i, sero);
                Console.Write("=");
            }
            for (int i = 0; i < sero + 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write('|');
                Console.SetCursorPosition(garo, y + i);
                Console.Write('|');
            }
            Console.SetCursorPosition(97, 26);
            Console.Write("방향키 : 이동");
            Console.SetCursorPosition(97, 27);
            Console.Write("Enter : 확정");
        }

        public static void PrintFrame2() //UI 프레임만을 호출
        {
            int x = 0;
            int y = 0;
            int garo = 110;
            int sero = 28;

            for (int i = 0; i < garo; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("=");
                Console.SetCursorPosition(x + i, sero);
                Console.Write("=");
            }
            for (int i = 0; i < sero + 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write('|');
                Console.SetCursorPosition(garo, y + i);
                Console.Write('|');
            }
        }

        public static void FrameClear()
        {
            int x = 0;
            int y = 0;
            int garo = 109;
            int sero = 27;
            for (int i =0;i<garo; i++)
            {
                for(int  j =0;j < sero; j++)
                {
                    Console.SetCursorPosition(1+i, 1+j);
                    Console.Write(" ");
                }
            }
        }

        public static void CardClear()
        {
            
            int garo = 109;
            int sero = 28;
            for (int i = 0; i < garo; i++)
            {
                for (int j = 12; j < sero; j++)
                {
                    Console.SetCursorPosition(1 + i,  j);
                    Console.Write(" ");
                }
            }
        }

        public void Drowcard(int Selet)

        {
            int x = 2;

            int maxhand = 4;
            int count = 0;
            foreach (var card in player._PlayerCardlist)
            {
                int y = 40;
                // 최대 4장의 카드만 출력
                if (count >= maxhand)
                    break;

                if (Selet == count && Selet >= 0)
                {
                    y = y - 5;
                }
                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write(card.CardName);
                Console.SetCursorPosition(x + 1, y + 2);
                Console.Write($"코스트 : {card.CardCost}");
                Console.SetCursorPosition(x + 1, y + 3);
                Console.Write($"데미지 : {card.CardDMG}");
                if (card.Efchak > 0)
                {
                    Console.SetCursorPosition(x + 1, y + 4);
                    Console.Write("특수효과");
                    Console.SetCursorPosition(x + 1, y + 5);
                    card.EfCard();
                    Console.SetCursorPosition(x + 1, y + 5);

                }

                Console.SetCursorPosition(x, y);
                Console.Write("===============");
                Console.SetCursorPosition(x, y + 7);
                Console.Write("===============");
                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(x - 1, y + i);
                    Console.Write('|');
                    Console.SetCursorPosition(x + 14, y + i);
                    Console.Write('|');
                }

                // 다음 카드 출력을 위해 y 좌표 증가 및 카운터 증가
                x += 21;
                count++;
            }
        } //턴시작할때 카드를뽑음
        public static void Help()
        {

            string[] messages = {
            "턴제 TCG 게임입니다",
            "플레이어는 총 3층으로 구성되어있는 첨탑을 오르고 있습니다..",
            "첨탑에는 다양한 괴물이 존재하고 이를 무찌르고 올라가야합니다.",
            "플레이어는 '카드' 라는 수단을 가지고 있습니다.",
            "카드의 경우 매 턴 시작때 덱으로부터 카드를 4장 뽑습니다.",
            "또한 턴 종료시 패에 있는 카드를 모두 묘지로 버립니다.",
            "만약 덱에서 더이상 뽑을 수 있는 카드가 존재 하지 않을시",
            "묘지의 카드를 다시 덱에 섞어넣습니다.",
            "플레이어의 카드 위력은 해당카드의 공격력+플레이어의 위력으로 결정됍니다.",
            "적의 위력은 적의 최대공격력의 50% ~ 최대공격력 100% 사이로 랜덤하게 정해집니다.",
            "카드중 '마법' 태그가 달린 카드는 우선권이 높아 상대와 합을 진행하지 않고 시전합니다.",
            "대신 시전이 끝난후 적도 일방 공격을 하니 주의하세요!",
            " 그럼 첨탑의 끝에서 기다리겠습니다."

};

            for (int i = 0; i < messages[i].Length; i++)
            {
                Console.SetCursorPosition(3, 3 + i);
                Console.WriteLine(messages[i]);
            }


     
        }//도움말 입력시 출력

        public void Newturn(Program program, Player player, Monster monster, int selectcard,int turn) 
        {
            Console.Clear();
            player.ShuffleTempCard(); //덱을섞음
            player.DrowHand();          //핸드를초기화-> 
            Printscreen();
            player.PlayerSTS(player);
            monster.MonsterSTS(monster);
            player.Viewhandcard(selectcard,turn);
        }
        //새로운 턴마다 출력해줄매서드 모음
        public void EndturnforEnter(Program program, Player player, Monster monster, int selectcard, ref bool F1, ref int debuffc) 
        //Enter키를통해 선택으로 턴을 종료했을때
        {
            //Console.Clear();
            player.UseSelcetCard(selectcard, player, monster, ref F1, ref debuffc);
            Printscreen();
            player.PlayerSTS(player);
            monster.MonsterSTS(monster);
        }
        //선택한 카드를 사용하는 페이즈 , 만약 코스트가 적으면 턴을 종료하진않음
        public void EndturnforEsc(Program program, Player player, Monster monster, int selectcard)
        
        {
            
            //player.DrowHand();
            Random random = new Random();
            int monsteDice = random.Next(monster.UnitAtk / 2, monster.UnitAtk);

            player.UnitHp = player.UnitHp - monsteDice;

            Printscreen();
            FrameClear();
            Centerment();
            Console.Write("한턴을 쉬었다.. 코스트 +1..");
            Centerment1();
            Console.Write($"{monster.UnitName} 의 공격 !! {monsteDice} 만큼의 데미지");
            player.PlayerSTS(player);
            monster.MonsterSTS(monster);
            player.UnitCost++;
        }
        //Esc키를 통해 턴을 스킵 하였을때
        public void seletiedmove(Program program, Player player, Monster monster, int selectcard,int turn)
        
        {
            player.Viewhandcard(selectcard, turn);
            player.PlayerSTS(player);
            Printscreen();
            monster.MonsterSTS(monster);
        }
        //좌우 입력등으로 newgame안에서 조작을 하는용도
        public static void campfire()
        {

            // 붉은색 텍스트 출력
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine(@"
                                  .*+
                                  .%%%=
                                -+%%%%#:                                   
                                #*%%%%%%-+:                                
                              +%%%%   +-%%%
                               #%#.   ::#%%*                                
                                -%%   -*#=                                 
                                 .-=.:+= ");

            // 노란색 텍스트 출력
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
                        +%%%%%%%*** :.  ..:-=#%   ***     
                       *****++*&&&&*&&&&*##%%%%%%%%%%##*+.                       
                                 %%%#***&&&^%                                
                    %%%%%%%%%%%%%         = +*#%%%%%%%%%%*.                   
                    -#%##++=-:#%-               ++-=+*##-  ");

            // 기본색상으로 되돌리기
            Console.ResetColor();
        }//휴식때 출력할 그림

        public static void box()
        {
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.SetCursorPosition(15, 10);
                Console.WriteLine(@"
     -=-=+==---------------------------++-==-                
     :+ :+ .............................+. =-               
     -= .+   ------     ------:   ---   =: :=               
     -- :+       .....          ......  =- :+               
     -- :+       :::::.         ::::::  -- :+               
     ==:-+::::::::::::::::::::::::::::::==:-+               
     ==:::::::::::::+========+:::::::::::::-+               
     =- .:::::::::::+:  &&  :+:::::::::::. :+               
     =- :+..........+:  &&  :+..........=- :+               
     =- :+          +:  &&  :+   ----.  -- :+               
     =- :+  ------. +========+   ....   -- :+               
     =- :+          ----------     :--. -- :+               
     =- :+                              -- :+               
     =- :+::::::::::::::::::::::::::::::=- :+               
     =-                                    :+               
     ==:::::::::::::::::::::::::::::::::::::+");

                Console.ResetColor();
            }
        }//보상페이즈때 출력할 그림

        public static void Sea()
        {
            Console.Clear();
            PrintFrame2();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(1, 20);
            Console.Write(@"
                                                                                 =#**+*#*####++####*-*-*##+++
#+*#++#+##:=#**                    :=#                                    #*####:=#**+*#*####++####*-*-*##+++
##+:=#**+++:=+:=#**+++:=#*#*#        #**+                           ++:=#*#*####:=#**+*#*####++####*-*-*##+++
 ##+:=#**+++:=+:=#**+++:=#*#*####:=#**+*#*####+:=#**+++:=#*#*##+:=#**+++:=#*#*####:=#**+*#+*++#!#:=#**+*###++
#*####+:=#**++:=#*#*####:=#**+*#*#+:=#**+++:=#*#*####:=#**+*#*####+:=#**+++:=#*#*####:=#**+*#++####*#-*#-*+++
#*####+:=#**++:=#*#*####:=#**+*#*#+:=#**+++:=#*#*####:=#**+*#*####+:=#**+++:=#*#*####:=#**+*#++####*-*-*##+++
+:=#*#*##+*#++#+*#++#+##:=#**+*#*#+:=#**+++:=#*#*####:=#**+*#*####+:=#**+++:=#*#*####:=#**+*#++####*-*-*#+++");
            Console.ResetColor();

            string[] lines = new string[]
            {
".:....::......:::::.. ",
"................................",
":..........:::::..:::::::::::::::::",
":..........:::::..::::::::::::::::::::::",
":..............................:::::::::::::::",
":................................",
" ::::::::::::::::::::::::",
" ::::::::::::::::::::",
              };
            int initialLeftPosition = 45;
            int initialTopPosition = 16;

            Console.SetCursorPosition(initialLeftPosition, initialTopPosition);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                initialTopPosition++;
                Console.SetCursorPosition(initialLeftPosition, initialTopPosition);
            }

            Console.SetCursorPosition(90, 20);
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("★");
                Console.ResetColor();

            }
            PrintFrame2();
            Centerment();
            Console.Write("이 밖은 이미 재앙과 다를바 없었으며");
            Console.ReadKey();
            Centerment1();
            Console.Write("탑이라고 생각한 이 장소는 거대한 배 였다.");
            Console.ReadKey();
            PrintFrame2();
            Centerment();
            Console.Write("                                                             ");
            Centerment1();
            Console.Write("                                                             ");
            Centerment();
            Console.Write("여정이 끝났다..");
            Console.SetCursorPosition(0, 28);
            Environment.Exit(0);
        }//바다엔딩

        public static void SkyTow()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(1, 1);
            Console.Write(@"
                        ################*+                             ::::#############%%%%%
                        +*############=.                               =#####################
                        :-==*#######=-. ..                              =####################
                        ****#######*.......                              -**+-::=#**+*#*#####
                        ####***+=-:::.::..                                .:....:=*=-=:::+###
                        ***++==:......:::::                                :..::..==-:-=+*###
                        **+-: .==--:::-----.                                -::.:::++******##
                        -..   .:-:-++=--::-.                                -=-+*************
                        ..........::++=-::-                                 -=--++=---++*****
                        -----------=++++++:                                 .-. ...:--=+++***
                        +++++++++++++++++-                                   .     .:=+++++++
                        ++++++++++++++++=                                     :...   .-=+++++
                        +++=============.                                     :=*=-=:::+###++
                        ===============.                                      ..==-:-=+*###++
                        -----------=+++++                                     :::++******##=+
                        +++++++++++++++++                                     *************-+
                        ++++++++++++++++=                                     ++=---++*****-+
                        +++=============.                                     ...:--=+++***:+
                        ===============.                                         .:=+++++++:+
                        ::-=====-:::-=:                                       ..   .-=+++++:+
                        --------------.                                       ........=====++ 
                        :-:---:..:::::                                        .::::::::-===++
");
            Console.ResetColor();
            PrintFrame2();

            string[] lines = new string[]
  {
    "        .          ",
    "        .          ",
    "       ...         ",
    "      . .          ",
    "      . ..         ",
    "        ..  .      ",
    "      . ..  .      ",
    "    ....:..:.      ",
    "    ...::.::.      ",
    "    .: .  .:..     ",
    "    ........:.     ",
    "   . .:::.:::.     ",
    "   ...... .::..    ",
    "   ... ......:.    ",
    "    .....:.::.:.   ",
    "   ..:::.:.:::-:   ",
    "   ..:.... ...:..  ",
    "  .:..........::.  ",
    "  .....:::.:::::.  ",
    " .....::::.:..:.:. ",
    " ...:.:..   :.:... ",
    " ..:..  .... .:... "
  };


            int initialLeftPosition = 45;
            int initialTopPosition = 1;

            Console.SetCursorPosition(initialLeftPosition, initialTopPosition);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                initialTopPosition++;
                Console.SetCursorPosition(initialLeftPosition, initialTopPosition);
            }

            Console.SetCursorPosition(53, 1);
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("★");
                Console.ResetColor();
            }


        }//첨탑그림1
        public static void town()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(1, 1);
            Console.Write(@"
################*+                ::::#############%%%%%
+*############=.                  =#####################
:-==*#######=-. ..                 =####################
****#######*.......                 -**+-::=#**+*#*#####
####***+=-:::.::..                   .:....:=*=-=:::+###
***++==:......:::::                   :..::..==-:-=+*###
**+-: .==--:::-----.                   -::.:::++******##
-..   .:-:-++=--::-.                .:--=-+*************
..........::++=-::-              ......-=--++=---++*****
-----------=++++++:              ------.-. ...:--=+++***
+++++++++++++++++-               ++++++ .     .:=+++++++
++++++++++++++++=                ++++++  :...   .-=+++++
+++=============.                ======  :=*=-=:::+###++
===============.                 ======  ..==-:-=+*###++
-----------=+++++                ------  :::++******##=+
+++++++++++++++++                ++++++  *************-+
++++++++++++++++=                ++++++  ++=---++*****-+
+++=============.                ======  ...:--=+++***:+
===============.                 ======     .:=+++++++:+
::-=====-:::-=:                  =====-  ..   .-=+++++:+
--------------.                  ------  ........=====++ 
:-:---:..:::::                    +:.:.-=+   .::::::::-===++");
            Console.ResetColor();
            Console.SetCursorPosition(1, 10);
            Console.WriteLine(@"
                                                       
                          .
                         ...
                        . . 
                        . ..
                          ..  .
                        . ..  .
                      ....:..:.
                      ...::.::.
                      .: .  .:..
                      ........:.
                     . .:::.:::.
                     ...... .::..
                     ... ......:.
                      .....:.::.:.
                     ..:::.:.:::-:
                     ..:.... ...:..
                    .:..........::. 
                    .....:::.:::::. 
                   .....::::.:..:.:.
                   ...:.:..   :.:...
                   ..:..  .... .:...");


        }//첨탑그림2

        public static void Ending()//엔딩
        {
            PrintFrame2();
            Centerment();
            Console.Write("여정이 끝나가는게 느껴진다.. 꼭대기로 가보자..");
            Console.ReadKey();
            SkyTow();
            Console.SetCursorPosition(53, 1);
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.CursorVisible = false;
            Centerment();
            Console.Write("하늘의 끝에 서서 내려다 보니 보인것은 ..");
            Console.ReadKey();
            FrameClear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Centerment();
            Console.Write("흘러 넘쳐버린 바다가 보였다.");
            Console.ResetColor();
            Console.ReadKey();
            FrameClear();
            Sea();
        }



        //        public static void Ending1()
        //        {
        ////        %%%%%%%%####*#######%%%                            "
        ////      #%%%#######*+-***==*##***#######                     "
        ////    #***#**%#**#**+*++++===-:-==--=++*+==*#                "
        ////   *+=-===-------=:::.:::..:--:..:=+******##               "
        ////  += -:::-:--------:....::.::::...::-- === +*#             "   
        //// -----::-- ==== ++*=== -::::::--:..:- -=== +*##            "
        ////  --=+= ---=== ++**+++++= -:::-= -...:-:::::= **           "
        //// ====+= -:=== **#**** ++=-::=+:..==+=-...:----==#          "
        ////+==== -:::::+*###*****+=:::-:..::=:==+++**++==+==#         "
        ////+= +++=:...:+= +++=+= *+=:........:=#*#*#+**++++=#         "
        ////######*++*#*#*#*++++=:...  ...::-=+####****+++++=#         "
        ////######***#*#####*=+***+..   ...:+*+####**#*++=++=#         "
        //// #%####+*#########+**#++:    ..:::*###########*++#         "
        ////  %###############*+*     *+--:=+*+--*##*+*##**###          "
        ////  #############***++=-**++**+-:=*++++++****#####            "
        ////  *#########**#*+*+=-+*#++**++:-++**+=++=+*=##              "
        ////   #####**###*##*=:=*****+**+==-=+*******=+#                "
        ////      ####**#**#=-++**##******+-=++***#**##                 "



        ////        %                    %%                            "
        ////      #%%        #           #      ##                     "
        ////    #***#         ##       #  # #       =*#                "
        ////   *+=-==          # #       #  #       **##               "
        ////  += -:::           ##       #    #        +*#             "   
        //// -----::-            # #     #   #       = +*##            "
        ////  --=+= -            # #        #           = **           "
        //// ====+= -  ########## # ###    #               =#          "
        ////+==== -::          #   #####  #                  #         "
        ////+= +++=:.        #   #    # ### # ##  # # #    +=#         "
        ////######*++            #    #                   ++=#         "
        ////######***       #   #       #                   =#         "
        //// #%####+*          #          #                 +#         "
        ////  %######      #  #             #              ###          "
        ////  #######        #                #         ####            "
        ////  *######     # #                   #       ##              "
        ////   #####*    # #                    #      #                "
        ////      ###                           #   *##                 "






        //        }

        //    }

    }
}
