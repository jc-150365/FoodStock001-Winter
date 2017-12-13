using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.ObjectModel;

namespace FoodStock01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage1 : ContentPage
    {
        /***ここから追加***/
        public ObservableCollection<Magic> Magics
        {
            get;
            private set;
        }
        /***ここまで追加***/

        public FoodPage1(string title)
        {

            //タイトル
            Title = title;

            //アイコン
            Icon = "apple32.png";

            InitializeComponent();

            /***ここから追加***/
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
                       F_Date = new DateTime(1970,1,1)
                    }
                };
            }
            /***ここまで追加***/


        }
    }
    
    /***ここから追加***/
    public class Magic
    {
        public string F_name { get; set; }
        public DateTime F_Date { get; set; }
    }
    /***ここまで追加***/
}