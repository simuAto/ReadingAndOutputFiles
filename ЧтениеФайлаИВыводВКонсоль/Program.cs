namespace ЧтениеФайлаИВыводВКонсоль
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Суть:
            //Чтение файла по ссылке.
            //Нахождение тегов.
            //Вывод текста без тегов.

            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            // Очищаем путь от кавычек (работает, даже если кавычек нет).
            filePath = filePath.Trim('"');
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файла по указанному пути не существует!");
                return;
            }

            Console.Clear();
            NoteFileReader reader = new NoteFileReader();
            EpisodeNote note = reader.ReadFromFile(filePath);

            Console.WriteLine("Укажите имя для главной папки (по умолчанию \"Library\"):");
            string rootFolderPath = Console.ReadLine();
            NoteStorage storage = new NoteStorage(rootFolderPath);

            Console.Clear();
            string savedPath = storage.AddNote(note);

            Console.WriteLine($"Заметка по {note.Series} (S{note.Season}E{note.Episode}) сохранена по пути:\n{savedPath}");
        }
    }
}
