using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    public class Solution
    {
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var start = 0;
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[start])
                {
                    Console.WriteLine((i, start));
                    if (i - start > 2)
                    {
                        result.Add(new List<int>() { start, i - 1 });
                        start = i;
                    }
                }
            }
            if (s.Length - start > 3)
            {
                result.Add(new List<int>() { start, s.Length - 1 });
            }
            Console.WriteLine(result);
            return result;
        }
    }
    enum Ingredient
    {
        Coke = 0,
        DietCoke = 1,
        Peppsi = 2,
        DrPepper = 3,
        Spirit = 4,
        Sugar = 5
    }

    enum Beverage
    {
        Coke = 0,
        DietCoke = 1,
        Peppsi = 2,
        DrPepper = 3,
        Spirit = 4,
        Sugar = 5
    }

    class BeverageFormula
    {
        Beverage name;
        List<Usage> Usages;
        public List<Usage> read()
        {
            return Usages;
        }
    }

    interface FillingFormulas
    {
        public BeverageFormula GetFormula(Ingredient ig);
    }

    struct Usage
    {
        Ingredient Ingredient { get; set; }
        int Amount { get; set; }
    }

    interface IngredientBox
    {
        Ingredient Ingredient { get; set; }
        int CurrentAmount { get; set; }
        int Capacity { get; set; }
        public bool NeedToRefill();
        public void Get();
        public void Fill(int amount);
    }

    class CoffeeMachine
    {
        private List<IngredientBox> ingredientBoxes { get; set; }
        private List<IngredientBox> WaitForRefill{ get; set; }
        private FillingFormulas fillingFormulas;
        public void fill(BeverageFormula beverageFormula)
        {

        }

        public List<IngredientBox> Check()
        {
            return new List<IngredientBox>();
        }

        public void Fill(Beverage name)
        {

        }
    }
}
