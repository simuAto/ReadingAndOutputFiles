using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧтениеФайлаИВыводВКонсоль
{
    public class NoteStorage
    {
        private readonly string _baseDirectory;

        public NoteStorage(string rootFolderName = "Library")
        {
            _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootFolderName);
        }

        public string AddNote(EpisodeNote note)
        {
            string seasonFolderPath = Path.Combine(_baseDirectory, note.Series, $"Season_{note.Season}");

            // Если нет папки - создаст, если есть - пропустит.
            Directory.CreateDirectory(seasonFolderPath);

            string filePath = Path.Combine(seasonFolderPath, $"Episode_{note.Episode}.txt");

            File.WriteAllText(filePath, note.Thought);

            return filePath;
        }
    }
}
