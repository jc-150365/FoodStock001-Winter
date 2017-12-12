using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodStock01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage1 : ContentPage
    {
        public EntryPage1(string title)
        {
            //タイトル
            Title = title;

            //アイコン
            Icon = "plus32.png";

            //初期化
            InitializeComponent();
        }
        void SelectSwitch(object sender, ToggledEventArgs args)
        {
            //保存食品
            if (args.Value)
            {
                FoodPicker.IsEnabled = false;
                NumEntry.IsEnabled = true;
                UnitEntry.IsEnabled = true;

            }
            //食材
            else
            {
                NumEntry.IsEnabled = false;
                UnitEntry.IsEnabled = false;
                FoodPicker.IsEnabled = true;
            }
        }
        
        /***************「登録ボタン」が押された時*********************/
        private void Insert01_Clicked(object sender, EventArgs e)
        {
            //Foodテーブルにインサートする
            FoodModel.InsertFood(1, NameEntry.Text, FoodPicker.Date.GetDateTimeFormats("yyyy-mm-dd"));
        }

        /***************「続けて登録ボタン」が押された時********************/
        private void Insert02_Clicked(object sender, EventArgs e)
        {

        }
    }
}