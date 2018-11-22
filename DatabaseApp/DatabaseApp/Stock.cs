using SQLite;

namespace DatabaseApp
{
    public class Stock
    {   [PrimaryKey, AutoIncrement, Column("_ID")]
        public int ID { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
    }
}