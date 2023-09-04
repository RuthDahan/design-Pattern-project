using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    internal class IceCofeeBuilder : DrinkBuilder
    {
        public IceCofeeBuilder(Drink drink) : base(drink)
        {
        }

        public override void AddIngredient()
        {
            drink.Description+="Adding Coffee flavor and whip on top";
        }

        public override void Pour()
        {
            drink.Description += "Pouring Ice Cubes"; ;
        }

        //public override void SetName()
        //{
        //    drink.Name= "IceCoffee";
        //}

        //public override void SetPrice()
        //{
        //    drink.Price=15;
        //}
    }
}
