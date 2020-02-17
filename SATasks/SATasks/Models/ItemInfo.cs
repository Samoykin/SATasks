using System.ComponentModel;

namespace SATasks.Models
{
    public class ItemInfo : INotifyPropertyChanged
    {
        /// <summary>Событие изменения свойства.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEditItem { get; set; }
        public Friend Item { get; set; }
    }
}