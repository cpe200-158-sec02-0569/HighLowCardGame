using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Deck
    {
        private int[] card;
        private Random rnd;
        private int num;

        public void shuffle()
        {
            int i;
            bool[] check;
            check = new bool[53];
            for(i = 0; i < 53; i++)
            {
                check[i] = false;
            }
            
            for(i = 0; i < 52; i++)
            {
                int tmp = rnd.Next(52) + 1;
                while(check[tmp] == true )
                {
                    tmp = rnd.Next(52) + 1;
                }
                check[tmp] = true;
                card[i] = tmp;
            }
            num = 52;
            Console.WriteLine("Shuffle");
        }

        public int draw()
        {
            num--;
            return card[num];
        }

        public void add(int c)
        {
            this.card[num] = c;
            num++;
        }

        public bool isLeft()
        {
            return !(num == 0);
        }

        public int getCard()
        {
            return num;
        }

        public Deck()
        {
            card = new int[52];
            rnd = new Random();
            num = 0;

        }
    }
}
