using Anacrusa.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Models
{
    public class SetList
    {

        public int Id { get; private set; }
        public string Name { get; }
        public List<ISetListItem> Items { get; } = new();

        public SetList(string name)
        {
            Name = name;
        }

        public void AddScore(Score score)
        {
            Items.Add(new SetListScoreItem(score));
        }

        public void AddBookmark(Bookmark bookmark)
        {
            Items.Add(new SetListBookmarkItem(bookmark));
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            if (oldIndex == newIndex)
                return;

            var item = Items[oldIndex];
            Items.RemoveAt(oldIndex);
            Items.Insert(newIndex, item);
        }

        public void RemoveItem(int index)
        {
            Items.RemoveAt(index);
        }

        public void DeleteSetList()
        {
            // Placeholder for deletion logic, e.g., removing from database
        }

        public void ShareSetList()
        {
            // Placeholder for sharing logic, e.g., exporting or sending the set list

        }
    }
}
