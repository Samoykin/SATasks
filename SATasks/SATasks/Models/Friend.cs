using SQLite;
using System.ComponentModel;

namespace SATasks.Models
{
    [Table("Friends")]
    public class Friend : INotifyPropertyChanged
    {
        /// <summary>Событие изменения свойства.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}