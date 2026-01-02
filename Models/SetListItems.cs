using Anacrusa.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Models
{
    public class SetListScoreItem: ISetListItem 
    {
        public Score Score { get; }
        public string DisplayName => Score.Title;
        public SetListScoreItem(Score score)
        {
            Score = score;
        }
    }

    public class SetListBookmarkItem: ISetListItem 
    {
        public Bookmark Bookmark { get; }
        public string DisplayName => Bookmark.Name;
        public SetListBookmarkItem(Bookmark bookmark)
        {
            Bookmark = bookmark;
        }
    }
}
