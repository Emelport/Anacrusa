using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Models
{
    public class Score
    {
        public int Id { get; private set; }

        // PDF
        public string FilePath { get; }
        public string FileName { get; }

        // Metadata
        public string Title { get; }
        public string Composer { get; }
        public int PageCount { get; }

        // App metadata
        public int LastOpenedPage { get; private set; }
        public DateTime? LastOpenedAt { get; private set; }

        // Relations
        /*
        public List<Annotation> Annotations { get; set; } = new();
        public List<Bookmark> Bookmarks { get; set; } = new();
        */

        public Score(
           string filePath,
           string fileName,
           string title,
           int pageCount,
           string composer = "")
        {
            FilePath = filePath;
            FileName = fileName;
            Title = title;
            PageCount = pageCount;
            Composer = composer;

            LastOpenedPage = 1;
        }

        internal Score(
            int id,
            string filePath,
            string fileName,
            string title,
            int pageCount,
            string composer,
            int lastOpenedPage,
            DateTime? lastOpenedAt)
        {
            Id = id;
            FilePath = filePath;
            FileName = fileName;
            Title = title;
            Composer = composer;
            PageCount = pageCount;
            LastOpenedPage = lastOpenedPage;
            LastOpenedAt = lastOpenedAt;
        }


        public void UpdateLastOpened(int page) {
            LastOpenedPage = page;
            LastOpenedAt = DateTime.Now;
        }


    }
}
