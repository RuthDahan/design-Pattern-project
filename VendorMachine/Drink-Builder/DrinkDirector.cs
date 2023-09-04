using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class DrinkDirector
    {
        public Product ConstructDrink(DrinkBuilder drinkBuilder)
        {
            drinkBuilder.Pour();
            drinkBuilder.AddIngredient();
            return drinkBuilder.GetDrink();
        }
    }

}
