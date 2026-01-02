using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Data.Entities
{
    [Table("Scores")]
    public class ScoreEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Composer { get; set; } = string.Empty;

        public int PageCount { get; set; }

        public int LastOpenedPage { get; set; }
        public DateTime? LastOpenedAt { get; set; }
    }
}
