using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace FoodStock01
{
    public partial class App : Application
    {
        //データベースのパスを格納
        public static string dbPath;

        //コンストラクタの引数にstring型の引数を追加
        public App(string dbPath)
        {
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
