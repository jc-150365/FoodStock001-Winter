using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodStock01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage1 : ContentPage
    {        
        public FoodPage1(string title)
        {

            //タイトル
            Title = title;

            //アイコン
            Icon = "apple32.png";

            InitializeComponent();
     
        }
    }       
}