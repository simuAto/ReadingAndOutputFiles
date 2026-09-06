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

            string TAGSeries = "[Series]";
            string TAGSeason = "[Season]";
            string TAGEpisode = "[Episode]";

            string series = "";
            int season = 1;
            int episode = 1;

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
            string[] allStrings = File.ReadAllLines(filePath);

            foreach (string str in allStrings)
            {
                string trimmedStr = str.Trim();

                if (trimmedStr.StartsWith(TAGSeries))
                {
                    series = trimmedStr.Replace(TAGSeries, "").Trim();
                    continue;
                }
                if (trimmedStr.StartsWith(TAGSeason))
                {
                    // Находим число сезона и превращаем в число.
                    string value = trimmedStr.Replace(TAGSeason, "").Trim();
                    season = int.Parse(value);                
                    continue;
                }
                if (trimmedStr.StartsWith(TAGEpisode))
                {
                    string value = str.Replace(TAGEpisode, "").Trim();
                    episode = int.Parse(value);
                    continue;
                }
                Console.WriteLine(str);
            }
            Console.WriteLine();
            Console.WriteLine($"Это {season} сезон {episode} серия произведения: {series}");
        }
    }
}
