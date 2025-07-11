using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static STS.UnitList;
using static STS.Program;
using static STS.MainPlace;

namespace STS
{
    public class Card //카드라는 양식으로 카드를 생성

    {
        
        public string CardName { get; }
        public int CardDMG { get; set; }
        public int CardCost { get; }
        public int Efchak { get; }

        public int Type {  get; }

        public void EfCard() //특수카드인지 체크
        {
            if (Efchak == 1) //1번 특수카드일시 cost를  회복한다는 문구를 출력
            {
                Ef_Costrecovery();
            }
            if (Efchak == 2)
            {
                Ef_Hprecovery(); //2번 특수카드일시 Hp를 회복한다는 문구를 출력
            }
            if (Efchak == 3)
            {
                Ef_Debuff(); //3번 디버프카드
            }

        }

        public void Cardtype()
        {
            if(Type ==0)
            {
                Console.Write("일반 카드");
            }
            if (Type == 1)
            {
                Console.Write("마법 카드");
            }
            if (Type == 4)
            {
                Console.Write("특수 카드");
            }
            
        }

        public void Ef_Debuff()
        {
            Console.Write($"위력 {CardDMG} 감소");
        }
        public void Ef_Costrecovery()
        {
            if (Type == 0)
            {
                Console.Write("코스트 1반환");
            }
            else
            {
                Console.Write("코스트를 회복");
            }
        }
        public void Ef_Hprecovery()
        {
            if (Type == 0)
            {
                Console.Write("체력을 흡혈");
            }
            else
            {
                Console.Write("체력을 회복");
            }
        }

        public Card(string name, int Cost, int DMG, int Ef,int type)
        {
            CardName = name;
            CardDMG = Cost;
            CardCost = DMG;
            Efchak = Ef;
            Type = type;


        }
    }
}
