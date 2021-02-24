using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    interface Rule
    {
        bool compare(Card card1, Card card2);
    }

    class Game: Rule
    {
        bool Rule.compare(Card card1, Card card2)
        {
            return card1.Number > card2.Number;
        }
    }

    enum color
    {
        red = 0,
        blue = 1,
        green = 2,
        black = 3
    }

    interface IDeck
    {
        
        public void Say()
        {
            Console.WriteLine("I am a Deck.");
        }

        void getCards();

        Card dispatch();

        void shuffle();

    }

    class Card
    {
        public int Number { get; set; }
        public color Color { get; set; }
        public Card(color col, int num)
        {
            Color = col;
            Number = num;
        }
    }

    class BlackJack: IDeck
    {
        private static BlackJack blackJack;
        private List<Card> cards;
        private int index;
        private BlackJack()
        {

        }

        public void start()
        {
            if (cards == null)
            {
                cards = new List<Card>();
                getCards();
            }
        }

        public static BlackJack getBlackJack()
        {
            if (blackJack == null)
            {
                blackJack = new BlackJack();
            }
            return blackJack;
        }

        public void shuffle()
        {
            var value = cards[cards.Count - 1];
            cards[cards.Count - 1] = cards[0];
            cards[0] = value;
        }

        public void getCards()
        {
            for(int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    cards.Add(new Card((color)i, j));
                    Console.WriteLine($"{cards[cards.Count - 1].Number}, {cards[cards.Count - 1].Color}");
                }
            }
            index = cards.Count - 1;
        }

        public Card dispatch()
        {
            if (index >= 0)
            {
                return cards[index--];
            }
            throw new Exception("Deck has no value.");
        }

    }

}
