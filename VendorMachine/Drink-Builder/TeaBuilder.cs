using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    internal class TeaBuilder : DrinkBuilder
    {
        public TeaBuilder(Drink drink) : base(drink)
        {
        }

        public override void AddIngredient()
        {
            drink.Description += "Adding cammomil";
        }

        public override void Pour()
        {
            drink.Description+="Pouring Hot Water";
        }

        //public override void SetName()
        //{
        //    drink.Name="Tea";
        //}

        //public override void SetPrice()
        //{
        //    drink.Price = 10; ;
        //}
    }
}
