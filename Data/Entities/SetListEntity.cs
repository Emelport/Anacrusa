using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Anacrusa.Data.Entities
{
    [Table("SetLists")]
    public class SetListEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
