using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Player
    {
        private Deck pdeck;
        private int score;

        public void addPCard(int n)
        {
            pdeck.add(n);
        }

        public int drawFight()
        {
            return pdeck.draw();
        }

        public int fight2(int n)
        {
            int point = 0;
            for(int i=0; i<n; i++)
            {
                if (isLeft())
                {
                    point = drawFight();
                }
                else break;
            }
            return point;
        }

        public bool isLeft()
        {
            return pdeck.isLeft();
        }

        public int getCard()
        {
            return pdeck.getCard();
        }

        public int getScore()
        {
            return score;
        }

        public void sumScore(int n)
        {
            score = score + n;
        }

        public Player()
        {
            pdeck = new Deck();
        }

    }
}
