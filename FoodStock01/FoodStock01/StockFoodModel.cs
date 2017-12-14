using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FoodStock01
{
    [Table("StockFood")]//テーブル名を指定
    public class StockFoodModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int S_no { get; set; } //食材No

        public string S_name { get; set; } //食材名

        public DateTime S_date { get; set; } //消費期限

        public string S_limit { get; set; } //現在時刻との差（後で使うかも）

        public TimeSpan S_span { get; set; } //現在日時との差（後で使うかも）

        public int S_result { get; set; } //現在日時との差（後で使うかも）

        /********************インサートメソッド**********************/
        /*public static void InsertFood(int f_no, string f_name,DateTime f_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<FoodModel>();

                    db.Insert(new FoodModel() { F_no = f_no, F_name = f_name, F_date = f_date });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }*/

        /********************インサートメソッド**********************/
        public static void InsertStockFood(int s_no, string s_name, int s_result)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<StockFoodModel>();

                    db.Insert(new StockFoodModel() { S_no = s_no, S_name = s_name, S_result = s_result });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<StockFoodModel> SelectStockFood()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースに指定したSQLを発行
                    return db.Query<StockFoodModel>("SELECT * FROM [StockFood] ORDER BY [S_result]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /********************デリートメソッド*************************************/
        public static void DeleteStockFood(int s_no)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<StockFoodModel>();

                    db.Delete<StockFoodModel>(s_no);//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************オールデリートメソッド*************************************/
        public static void DeleteAllStockFood()
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<StockFoodModel>();

                    db.DeleteAll<StockFoodModel>();//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************アップデートメソッド（試し）**************************************/
        public static List<StockFoodModel> UpdateStockFood()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースに指定したSQLを発行
                    return db.Query<StockFoodModel>("UPDATE [StockFood] SET S_result = S_result+1 ");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
