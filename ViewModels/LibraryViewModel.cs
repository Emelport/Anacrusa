using Anacrusa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anacrusa.ViewModels
{
    public class LibraryViewModel
    {
        public ObservableCollection<Score> Scores { get; } = new();

        public string TotalCountText =>
            $"{Scores.Count} scores in your Collection";

        public LibraryViewModel()
        {
            Scores.Add(new Score("a", "a", "Autumn Leaves", 2, "Joseph Kosma"));
            Scores.Add(new Score("b", "b", "Bohemian Rhapsody", 12, "Queen"));
            Scores.Add(new Score("c", "c", "Claro de Luna", 8, "Debussy"));
        }
    }

}
