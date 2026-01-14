using Anacrusa.Models;
using Anacrusa.Repository;
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

        private readonly IScoreRepository _repo;

        public LibraryViewModel(IScoreRepository repo)
        {
            _repo = repo;

            Scores.Add(new Score("a", "a", "Autumn Leaves", 2, "Joseph Kosma"));
            Scores.Add(new Score("b", "b", "Bohemian Rhapsody", 12, "Queen"));
            Scores.Add(new Score("c", "c", "Claro de Luna", 8, "Debussy"));
        }

        public async Task ImportAsync(IEnumerable<FileResult> files)
        {
            foreach (var file in files)
            {
                // usar _repo aquí
                // Copiar archivo a AppDataDirectory
                var destDir = FileSystem.AppDataDirectory;
                var destFileName = file.FileName ?? Guid.NewGuid().ToString() + ".pdf";
                var destPath = Path.Combine(destDir, destFileName);

                using (var source = await file.OpenReadAsync())
                using (var dest = File.Create(destPath))
                {
                    await source.CopyToAsync(dest);
                }

                // Abrir modal para completar metadatos (asegúrate de tener ImportPdfModal)
                var modal = new Anacrusa.Views.Library.ImportPdfModal(file.FileName ?? destFileName);
                await Navigation.PushModalAsync(modal);
                var score = await modal.GetResultAsync();

                if (score is null)
                {
                    // usuario canceló, eliminar copia si no la necesitarás
                    try { File.Delete(destPath); } catch { }
                    continue;
                }

                // Asignar ruta/filename reales y delegar al ViewModel
                score.FilePath = destPath;
                score.FileName = destFileName;

                await _vm.ImportScoreAsync(score);
            }
        }
    }

}
