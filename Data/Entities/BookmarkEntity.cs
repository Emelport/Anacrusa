using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Anacrusa.Data.Entities
{
    [Table("Bookmarks")]
    public class BookmarkEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Indexed]
        public int ScoreId { get; set; }

        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
