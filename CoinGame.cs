using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    enum Coin
    {
        face = 0,
        flower = 1,
    }
    class Player
    {
        public string Name{ get; set; }
        public string ID { get; set; }
        public Player(string id, string name)
        {
            Name = name;
            ID = id;
        }
        
        public Coin getChoice()
        {
            return Coin.face;
        }
    }



    class CoinGame
    {
        private static CoinGame game;
        private Coin coin;
        private Player p1;
        private Player p2;
        private Random seed = new Random();
        private CoinGame()
        {
            coin = new Coin();
        }
        public static CoinGame getGame()
        {
            if (game == null)
            {
                game = new CoinGame();
            }
            return game;
        }

        public void addPlayer()
        {

        }

        public void removePlayer(string id)
        {

        }

        public bool start()
        {
            Player currentPlay = p1;
            Coin cp = p1.getChoice();
            coin = getFlip();
            if (coin == cp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Coin getFlip()
        {
            var value = seed.Next(0, 1);
            return (Coin)value;
        }
    }
}
