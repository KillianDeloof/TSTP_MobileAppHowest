using SQLite;

namespace MobileAppHowest.Models
{
    public class BaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}