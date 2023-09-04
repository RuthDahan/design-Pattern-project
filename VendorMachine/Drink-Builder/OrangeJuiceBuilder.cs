using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    internal class OrangeJuiceBuilder : DrinkBuilder
    {
        public OrangeJuiceBuilder(Drink drink) : base(drink)
        {
        }

        public override void AddIngredient()
        {
            drink.Description+="Adding Orange juice";
        }

        public override void Pour()
        {
            drink.Description += "Pouring ice cubes";
        }

        
    }
}
