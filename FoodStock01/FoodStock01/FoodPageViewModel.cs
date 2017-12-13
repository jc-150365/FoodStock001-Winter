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
            if (FoodModel.SelectFood() != null)
            {
                var query = FoodModel.SelectFood();//

                foreach (var food in query)
                {
                    Magics = new ObservableCollection<Magic> {
                        new Magic {
                            F_name = food.F_name,
                            F_Date = food.F_date
                        },
                  　};
                }
            }
            else
            {
                Magics = new ObservableCollection<Magic> {
                    new Magic {
                       F_name = "NoData",
                       F_Date = "NoData"
                    }
                };
            }
        }
    }
    

    public class Magic
    {
        public string F_name { get; set; }
        public DateTime F_Date { get; set; }
    }

}
