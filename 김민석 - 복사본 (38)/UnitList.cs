using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STS.Card;
using static STS.Program;
using static STS.MainPlace;
using static STS.UnitList;

namespace STS
{


    public class UnitList
    {

        public abstract class Unit
        {
            public abstract string UnitName { get; set; }
            public abstract int UnitHp { get; set; }
            public abstract int UnitAtk { get; set; }
            public abstract int UnitCost { get; set; }
            public abstract int CardDMG { get; set; }


        }

        public class Monster : Unit //Unit이라는 부모클래스로부터 상속받아 Player 이라는 자식클레스를 생성
        {
            public override string UnitName { get; set; }
            public override int UnitHp { get; set; }
            public override int UnitAtk { get; set; }
            public override int UnitCost { get; set; }
            public override int CardDMG { get; set; }

            public int OriginalAtk { get; }
            public Monster(string UnitName, int UnitHp, int UnitAtk, int UnitCost, int CardDMG, int OriginalAtk)
            {
                this.UnitName = UnitName;
                this.UnitHp = UnitHp;
                this.UnitAtk = UnitAtk;
                this.UnitCost = UnitCost;
                this.CardDMG = CardDMG;
                this.OriginalAtk = UnitAtk;
            }

            public void MonsterSTS(Monster monster) //플레잉어의 상태를 보여줌
            {
                int x = 70;
                int y = 0;
                Console.SetCursorPosition(x + 2, y + 3);
                Console.Write($"{monster.UnitName}");
                Console.SetCursorPosition(x + 2, y + 4);
                Console.Write($" HP : {monster.UnitHp} , ATK : {monster.UnitAtk}");
                Console.SetCursorPosition(x + 2, y + 5);
                Console.Write($" 남은 Cost : {monster.UnitCost}");

            }


        }

        public class Player : Unit //Unit이라는 부모클래스로부터 상속받아 Player 이라는 자식클레스를 생성
        {
            public Player(string UnitName, int UnitHp, int UnitAtk, int UnitCost, int CardDMG, int OriginalHp)
            {
                this.UnitName = UnitName;
                this.UnitHp = UnitHp;
                this.UnitAtk = UnitAtk;
                this.UnitCost = UnitCost;
                this.CardDMG = CardDMG;
                this. OriginalHp=OriginalHp;

            }
            public override string UnitName { get; set; }
            public override int UnitHp { get; set; }
            public override int UnitAtk { get; set; }
            public override int UnitCost { get; set; }
            public override int CardDMG { get; set; }
            public int OriginalHp { get; set; } 


            public void PlayerSTS(Player player1) //플레잉어의 상태를 보여줌
            {
                int x = 0;
                int y = 0;
                Console.SetCursorPosition(x + 2, y + 3);
                Console.Write($"{player1.UnitName}");
                Console.SetCursorPosition(x + 2, y + 4);
                Console.Write($" HP : {player1.UnitHp} , ATK : {player1.UnitAtk}");
                Console.SetCursorPosition(x + 2, y + 5);
                Console.Write($" 남은 Cost : {player1.UnitCost}");
            }

            public LinkedList<Card> _PlayerCardlist = new LinkedList<Card>(); //디폴트가 됄 덱리스트생성
            public LinkedList<Card> _TempCardList = new LinkedList<Card>(); //묘지,셔플에 사용할 Temp리스트를 생성

            public void CopyTempCard() // playerCardList에서 tempCard로 임시적으로 복사
            {
                _TempCardList.Clear();
                foreach (var card in _PlayerCardlist)
                {
                    _TempCardList.AddLast(card);
                }
            }


            public void ShuffleTempCard() //임시 카드를 셔플
            {
                Random rand = new Random();
                Card[] tempArray = _TempCardList.ToArray();
                int a = tempArray.Length;
                while (a > 1)
                {
                    a--;
                    int b = rand.Next(a + 1);
                    Card value = tempArray[b];
                    tempArray[b] = tempArray[a];
                    tempArray[a] = value;
                }
                _TempCardList.Clear(); //임시 카드에 든 내용을 초기화
                foreach (var card in tempArray)//
                {
                    _TempCardList.AddLast(card); //temmp Array의 배열의 값을 TempCardList에다시 할당
                }
            }
            public LinkedList<Card> _HandCard = new LinkedList<Card>();

            //public void DrowHand1() //4장만큼 핸드를 드로우하고 덱에서 제거함
            //{
            //    int numCardsToDraw = Math.Min(4, _TempCardList.Count);
            //    for (int i = 0; i < numCardsToDraw; i++)//아하 마지막노드가없을때도 가져오려해서오류가쳐 났구나 ㅆㅂ?
            //    {
            //        _HandCard.AddLast(_TempCardList.Last);
            //        _TempCardList.RemoveLast();
            //    }
            //}

            public void DrowHand()
            {
                _HandCard.Clear(); //패를초기화

                for (int i = 0; i < 4; i++) //4회반복함 (패가4장이최대니까)
                {
                    if (_TempCardList.Count <= 0) //만약 TempCardList의 카드가 0장일시 덱에서 카드를복사해온뒤에 카드를섞음
                    {
                        CopyTempCard();
                        ShuffleTempCard();
                    }
                    LinkedListNode<Card> lastNode = _TempCardList.Last; //그뒤에 TempCardList에 마지막 카드를 LastNode에 값을할당함

                    if (lastNode != null)
                    {
                        _HandCard.AddLast(lastNode.Value);
                        _TempCardList.RemoveLast();
                    }

                }
            }


            public void UseSelcetCard(int Selet, Player player, Monster monster, ref bool F1, ref int debuffc)
            //어떤카트들 사용하는지 정보를 확정,넘겨주는과정
            {

                //if(Selet>=0 && Selet >=3)
                //{
                LinkedListNode<Card> selectedNode = _HandCard.First;
                for (int S = 0; S < Selet; S++)
                {
                    selectedNode = selectedNode.Next;
                }
                Card selectedCard = selectedNode.Value;

                UseCard(selectedCard, player, monster, ref F1, ref debuffc);

                //}
            }
            public void UseCard(Card card, Player player, Monster monster, ref bool F1, ref int debuffc)
            //카드를 사용함을 통한 연산페이즈
            {
                Random random = new Random();
                int monsteDice = random.Next(monster.UnitAtk / 2, monster.UnitAtk);



                if (player.UnitCost >= card.CardCost && card.Type <= 0) // 일반 공격타입의 카드가 발동조건을 충족할시
                {
                    //몬스터의 공격력의50퍼~몬스터의최대공격력
//                    Console.Clear();

                    
                    monster.MonsterSTS(monster);
                    player.PlayerSTS(player);
                    CardClear();
                    Console.SetCursorPosition(40, 14);
                    Console.WriteLine($"나의 합 : {card.CardDMG + player.UnitAtk}");
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine($"몬스터의 합 : {monsteDice}");
                    Console.ReadKey();
                    if (card.CardDMG + player.UnitAtk > monsteDice) //유저의 합이 이겼을시
                    {
                        monster.UnitHp = monster.UnitHp - (card.CardDMG + player.UnitAtk);
                        player.UnitCost = player.UnitCost - card.CardCost;
                        Centermentnew(1);
                        Console.Write("                                                   ");
                        Centermentnew(2);
                        Console.Write("                                                   ");
                        monster.MonsterSTS(monster);
                        player.PlayerSTS(player);
                        Printscreen();
                        Console.SetCursorPosition(40, 14);
                        Console.Write($"{monster.UnitName} 에게 {card.CardDMG + player.UnitAtk} 만큼의 데미지! ");
                        player.UnitCost++;
                        if (card.Efchak == 1) //1번효과로 인한 1코스트반환
                        {
                            player.UnitCost++;
                        }
                        if (card.Efchak == 2) // 2번효과로 인한 카드의 위력만큼 흡혈
                        {
                            player.UnitHp = player.UnitHp + (card.CardDMG + player.UnitAtk);
                            Console.SetCursorPosition(40, 15);
                            Console.Write($"{card.CardDMG + player.UnitAtk} 만큼 체력을 회복했다.");
                        }
                        Console.ReadKey();
                        Console.SetCursorPosition(40, 14);
                        Console.Write("                                                   ");
                        Console.SetCursorPosition(40, 15);
                        Console.Write("                                                   ");

                    }
                    else if (monsteDice > card.CardDMG + player.UnitAtk && card.Type == 0)//유저일방공격,몬스터와의 합에서 패배할시
                    {
                        player.UnitHp = player.UnitHp - monsteDice;
                        CardClear();
                        Printscreen();
                        Centerment();
                        Console.Write("합에서 패배해버렸다.. ");
                        Centerment1();
                        Console.Write($"{monster.UnitName} 의 공격 !! {monsteDice} 만큼의 데미지");
                        Console.ReadKey();
                        player.PlayerSTS(player);
                        monster.MonsterSTS(monster);
                        Centerment();
                        Console.Write("                                                   ");
                        Centerment1();
                        Console.Write("                                                   ");
                        player.UnitCost++;
                    }
                }

                else if (player.UnitCost >= card.CardCost && card.Type > 0) //마법카드일시 실행
                {

                    CardClear();
                    if (card.Efchak == 1) // 종류1 코스트 회복카드일시
                    {
                        player.UnitCost = player.UnitCost - card.CardCost;
                        player.UnitCost = player.UnitCost + card.CardDMG;
                        Centerment();
                        Console.Write("코스트를 회복하였다.");
                    }
                    else if (card.Efchak == 2) // 종류 2 회복카드일시
                    {
                        player.UnitCost = player.UnitCost - card.CardCost;
                        player.UnitHp = player.UnitHp + (card.CardDMG + player.UnitAtk);
                        Centerment();
                        Console.Write($"{card.CardDMG + player.UnitAtk} 만큼 체력을 회복 하였다.");
                    }
                    else if (card.Efchak == 3)
                    {

                        monster.UnitAtk = monster.UnitAtk - card.CardDMG;
                        player.UnitCost = player.UnitCost - card.CardCost;
                        Centerment();
                        Console.Write($"{card.CardDMG} 만큼 위력을 잠시감소시켰다.");
                        debuffc = 0;
                    }
                    else//일방 마법공격
                    {
                        player.UnitCost = player.UnitCost - card.CardCost;
                        Centerment();
                        Console.Write($"{monster.UnitName} 에게 {card.CardDMG + player.UnitAtk} 만큼의 데미지! ");
                        monster.UnitHp = monster.UnitHp - (card.CardDMG + player.UnitAtk);
                    }
                    Printscreen();
                    Centerment1();
                    Console.Write($"{monster.UnitName} 의 공격 !! {monsteDice} 만큼의 데미지");
                    player.UnitHp = player.UnitHp - monsteDice;
                    player.UnitCost++;
                    Console.ReadKey();
                    CardClear();
                    Centerment1();
                    Console.Write("                                                   ");
                    Centerment();
                    Console.Write("                                                   ");
                }



                else
                {
                    LowCost(ref F1);
                }
            }

            public void LowCost(ref bool F1) //로우코스트
            {
                Printscreen();
                Centerment();
                Console.Write("코스트가 부족 합니다.");
                F1 = false;
                Console.ReadKey();
                Centerment();
                Console.Write("                                                   ");
            }

            public void Viewhandcard(int Selet, int turn)

            {
                int x = 2;

                int maxhand = 4;
                int count = 0;
                foreach (var card in _HandCard)
                {
                    int y = 20;
                    // 최대 4장의 카드만 출력
                    if (count >= maxhand)
                        break;

                    if (Selet == count && Selet >= 0)
                    {
                        y = y - 5;
                        for (int i = 0; i < 13; i++)
                        {
                            Console.SetCursorPosition(x - 1, y + i);
                            Console.Write("                  ");

                        }
                    }
                    else
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            Console.SetCursorPosition(x - 1, y - 7 + i);
                            Console.Write("                  ");
                        }
                    }


                
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
                    if(card.Type==4)
                    {
                        Console.SetCursorPosition(x + 1, y + 4);
                        Console.Write("  덱이 빌시");
                        Console.SetCursorPosition(x + 1, y + 5);
                        Console.Write("  위력 증가");
                    }
                    if (card.Type == 5)
                    {
                        Console.SetCursorPosition(x + 1, y + 4);
                        Console.Write("  턴 마다 ");
                        Console.SetCursorPosition(x + 1, y + 5);
                        Console.Write("  위력 증가");
                    }
                    Console.SetCursorPosition(x + 3, y + 6);
                    card.Cardtype();

                    Console.SetCursorPosition(x, y);
                    Console.Write("===============");
                    Console.SetCursorPosition(x, y + 7);
                    Console.Write("===============");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.SetCursorPosition(x - 1, y + i);
                        Console.Write('|');
                        Console.SetCursorPosition(x + 15, y + i);
                        Console.Write('|');
                    }
                    x += 20;
                    count++;
                    if (card.Type == 4)
                    {
                        if (_TempCardList.Count <= 0)
                        {
                            card.CardDMG = 50;
                        }
                        else
                        {
                            card.CardDMG = 0;
                        }
                    }
                    if (card.Type == 5)
                    {
                        card.CardDMG = turn*1;
                    }

                }
            }

            public void GetCard(Card card) // PlayerCardList 에 카드를 추가
            {
                _PlayerCardlist.AddLast(card);
            }
            public void RemovedCard(Card card) //PlayerCardList에 카드를 제거 
            {
                _PlayerCardlist.Remove(card);
            }

            public void F1CardList()
            {
                int x = 0;
                int y = 0;
                LinkedList<Card> _ViewRandDeckCard = new LinkedList<Card>();
                Random rand = new Random();
                Card[] tempArray = _TempCardList.ToArray();

                Console.SetCursorPosition(x + 4, 0);
                Console.WriteLine($"전체 덱의 카드 목록 ");
                foreach (var card in _PlayerCardlist)
                {
                    y++;
                    Console.SetCursorPosition(x + 4, y + 2);
                    Console.WriteLine($"{card.CardName} // 코스트 : {card.CardCost}");
                }


                Console.SetCursorPosition(x + 50, 0);
                Console.WriteLine($"남은 덱 의 카드 목록 ");

                y = 0;
                foreach (var card in _TempCardList)
                {
                    y++;
                    Console.SetCursorPosition(x + 50, y + 2);
                    Console.WriteLine($"{card.CardName} // 코스트 : {card.CardCost}");
                }



            }

        }
    }
}