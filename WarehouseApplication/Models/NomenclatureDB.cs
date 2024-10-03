using System.Data.Entity;
using System.Data.SQLite;
using System.IO;

namespace WarehouseApplication.Models
{
    public class NomenclatureDB : DbContext
    {
        public DbSet<ProductTemplate> Templates { get; set; }

        private const string _path = ".\\nomenclature.sqlite";

        private static NomenclatureDB _instance;



        private NomenclatureDB() : base("name=NomenclatureDB") { }



        public static NomenclatureDB GetInstance()
        {
            if(_instance == null)
            {
                if(!File.Exists(_path))
                    SQLiteConnection.CreateFile(_path);
                CreateTableIfNotExist();

                _instance = new NomenclatureDB();
            }

            return _instance;
        }



        private static void CreateTableIfNotExist()
        {
            string connectionString = $"Data Source={_path};";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS ProductTemplates (Id TEXT, Name TEXT);";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
