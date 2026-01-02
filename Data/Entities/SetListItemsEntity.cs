using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Data.Entities
{
    [Table("SetListItems")]
    public class SetListItemsEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int SetListId { get; set; }

        public int Order { get; set; }

        // Implementations can have either a Score or a Bookmark
        [Indexed]
        public int? ScoreId { get; set; }
        [Indexed]
        public int? BookmarkId { get; set; }
    }
}
