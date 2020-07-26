using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.Models
{
    public class Requirements
    {
        public int Id { get; set; }
        public string Components { get; set; }
        public string ImagesIngredients { get; set; }

        public string Instructions { get; set; }

        public Meals Meals { get; set; }
        public int MealsId { get; internal set; }
    }
}
