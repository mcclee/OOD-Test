using System.Collections.Generic;
using System;

namespace myApp
{
    enum Category{
        food = 0,
        beverage = 1
    }
    class Item{
        string ID;
        string ItemName;
        Category category;
        float price;
    }

    class Product{
        Item item;
        string serialNumber{ get;set; }
        public Product(Item it, string sn){
            item = it;
            serialNumber = sn;
        }
    }

    class Location{
        int row;
        int col;
    }

    class Card{
        string number{ get; set; }
        DateTime startDate{ get; set; }
        DateTime endDate{ get; set; }
        string svn{ get; set; }
        private static Card card;
        private Card(){
            
        }
        public static Card GetCard(){
            if (card == null){
                card = new Card();
            }
            return card;
        }
    }

    interface Selector{
        Grid GetLocation(Dictionary<Item, List<Grid>> grids, Item item);
    }

    class NewSelector: Selector{
        public Grid GetLocation(Dictionary<Item, List<Grid>> grids, Item item){
            foreach(Grid grid in grids[item]){
                if (grid.Amount > 0){
                    return grid;
                }
            }
            return null;
        }
    }

    class Grid{
        public Item item;
        public int Amount;
        public List<Product> products;
        public Product pop(){
            if (Amount == 0){
                return null;
            }
            var product = products[products.Count - 1];
            products.RemoveAt(products.Count - 1);
            return product;
        }
    }
    class VendingMachine{
        Selector selector;
        float payment { get; set; }
        public Card card{ get; set; }
        private static VendingMachine vendingMachine;
        private VendingMachine(){
            selector = new NewSelector();
        }
        Dictionary<Item, List<Grid>> grids;
        public void take(Location location){

        }
        public void read(Card c){
            card = c;
        }
        public void Charge(float amount){
            
        }

        public Product buy(Item item){
            var grid = selector.GetLocation(grids, item);
            return grid.pop();
        }
    }


}