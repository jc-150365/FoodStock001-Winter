﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


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
            /*
            if (FoodModel.SelectFood() != null)
            {
                var query = FoodModel.SelectFood();

                
                foreach (var food in query)
                {
                    Analytics.TrackEvent("food name=" + food.F_name + "  food date=" + food.F_date);

                    Magics = new ObservableCollection<Magic>{
                        new Magic
                        {
                            F_name = food.F_name,
                            F_date = food.F_date
                        }
                    };
                }             
            }
            */
            if(FoodModel.SelectFood() != null)
            {
                Magics = new ObservableCollection<Magic>(FoodModel.SelectFood());
            }
            else
            {
                Magics = new ObservableCollection<Magic> {
                    new Magic {
                       F_name = "NoData",
                       F_date = new DateTime(1970,1,1)
                    }
                };
            }
        }
    }
    

    public class Magic
    {
        public string F_name { get; set; }
        public DateTime F_date { get; set; }
    }
    
}
