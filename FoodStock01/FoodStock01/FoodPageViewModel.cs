using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FoodStock01
{
    class FoodPageViewModel
    {
        public ObservableCollection<Magic> Magics
        {
            get;
            private set;
        }

        public FoodPageViewModel()
        {
            var query = FoodModel.SelectFood();//

            //Magics = new ObservableCollection<Magic> {
                foreach (var food in query) {
                Magics = new ObservableCollection<Magic> {
                    new Magic {
                       F_name = food.F_name,
                       F_Date = food.F_date.ToString()
                    }
                };    
               }
        }
    }

    public class Magic
    {
        public string F_name { get; set; }
        public string F_Date { get; set; }
    }

}
