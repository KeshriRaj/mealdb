using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.Request
{
    public class AddMealRequest
    {
        public string  Name { get; set; }
        public string Image { get; set; }

        public int IngredientsId { get; set; }
        public int  CountryId { get; set; }

        public string components { get; set; }

        public string ImageIngredients { get; set; }
        public string  Instructions{ get; set; }

    }
}
