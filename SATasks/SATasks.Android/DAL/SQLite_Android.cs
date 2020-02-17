using System.IO;
using SATasks.DAL;

[assembly: Xamarin.Forms.Dependency(typeof(SATasks.Droid.DAL.SQLite_Android))]
namespace SATasks.Droid.DAL
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}