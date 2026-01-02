using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Models
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string Name { get; }
        public Score Score { get; }
        public int StartPage { get; }
        public int EndPage { get; }

        public Bookmark(string name, Score score, int startPage, int endPage)
        {
            Name = name;
            Score = score;
            StartPage = startPage;
            EndPage = endPage;
        }   
    }
}
