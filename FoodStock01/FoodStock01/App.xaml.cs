using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


namespace FoodStock01
{
    public partial class App : Application
    {
        //データベースのパスを格納
        public static string dbPath;

        //コンストラクタの引数にstring型の引数を追加
        public App(string dbPath)
        {

            AppCenter.Start("ios=7fba10fd-ce22-44ca-a1fa-6758764a6a4e;" + "uwp={Your UWP App secret here};" +
                   "android={Your Android App secret here}",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.LogLevel = LogLevel.Verbose;



            //AppのdbPathに引数のパスを設定
            App.dbPath = dbPath;

            // TabbedPageをMainPageとしてセットする
            MainPage = new TabbedPage()
            {
                Children = {
                   new FoodPage1("食材"),
                   new StockPage("保存"),
                   new EntryPage1("登録"),
                   new MemoPage1("メモ"),
                   new SettingPage("設定")
                }
            };
        }
    }
}
