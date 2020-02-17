using System;
using System.IO;
using SATasks.DAL;

[assembly: Xamarin.Forms.Dependency(typeof(SATasks.iOS.DAL.SQLite_iOS))]
namespace SATasks.iOS.DAL
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            // определяем путь к бд
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, sqliteFilename);

            return path;
        }
    }
}