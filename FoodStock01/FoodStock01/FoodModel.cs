using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FoodStock01
{
    [Table("Food")]//テーブル名を指定
    public class FoodModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int F_no { get; set; } //食材No

        public string F_name { get; set; } //食材名

        public DateTime F_date { get; set; } //消費期限

        /********************インサートメソッド*********************/
        public static void InsertFood(int f_no, string f_name,DateTime f_date)
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
                    Console.WriteLine(f_name);//
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<FoodModel> SelectFood()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行
                    return db.Query<FoodModel>("SELECT * FROM [Food]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /********************デリートメソッド*************************************/
        public static void DeleteFood(int f_no)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<FoodModel>();

                    db.Delete<FoodModel>(f_no);//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
    }
}
