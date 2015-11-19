using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Game
    {
        Player p1 = new Player();
        Player p2 = new Player();
        Deck deck = new Deck();


        public Game()
        {
            deck = new Deck();
            p1 = new Player();
            p2 = new Player();
            Console.WriteLine("Enter to play");
            deck.shuffle();
            deal();
            play();
            
        }

        public void deal()
        {
            for (int i = 0; i < 26; i++)
            {
                p1.addPCard(deck.draw());
                p2.addPCard(deck.draw());
            }
            Console.WriteLine("Cards dealed.");
        }

        void play()
        {
            while (true)
            {

                if (!p1.isLeft())
                {
                    if (p1.getScore() > p2.getScore())
                        Console.WriteLine("P1 WIN");
                    else if (p1.getScore() < p2.getScore())
                        Console.WriteLine("P2 WIN");
                    else Console.WriteLine("DRAWN");
                    Console.WriteLine("P1 score : " + p1.getScore() + "   P2 score : " + p2.getScore());
                    Console.WriteLine("EXIT");
                    Console.ReadKey();
                    break;
                }
                Console.ReadKey();
                int s1, s2;
                s1 = p1.drawFight();
                s2 = p2.drawFight();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine("\nP1 :" + getPoint(s1) + getType(s1) + " VS P2 :" + getPoint(s2) + getType(s2));
                s1 %= 13; s1++;
                s2 %= 13; s2++;

                if (s1 < s2)
                {
                    p1.sumScore(1);
                    Console.WriteLine("P1 Scored.\n");
                }
                else if (s2 < s1)
                {
                    p2.sumScore(1);
                    Console.WriteLine("P2 Scored.\n");
                }
                else
                {
                    Console.WriteLine("DRAWN, 2nd FIGHT!");

                    int p = p1.getCard();
                    if (p > s1) p = s1;
                    s1 = p1.fight2(s1);
                    s2 = p2.fight2(s2);

                    Console.WriteLine("P1 :" + getPoint(s1) + getType(s1) + " VS P2 :" + getPoint(s2) + getType(s2));

                    s1 %= 13; s1++;
                    s2 %= 13; s2++;

                    if (s1 < s2)
                    {
                        p1.sumScore(p);
                        Console.WriteLine("P1 Scored x" + p + ".");
                    }
                    else if (s2 < s1)
                    {
                        p2.sumScore(p);
                        Console.WriteLine("P2 Scored x" + p + ".");
                    }
                    else
                    {
                        Console.WriteLine("Point drawn again, restart everything.");
                        continue;
                    }

                }
            }
        }

        string getType(int n)
        {
            int temp = (n - 1) / 13;
            return Convert.ToString(Convert.ToChar(temp + 3));
        }

        string getPoint(int n)
        {
            while (n > 13) n = n - 13;
            if (n == 1) return "A";
            else if (n == 11) return "J";
            else if (n == 12) return "Q";
            else if (n == 13) return "K";
            else return "" + n;
        }
    }
}
