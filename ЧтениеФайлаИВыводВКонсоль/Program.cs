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
            Console.Clear();

            // Очищаем путь от кавычек (работает, даже если кавычек нет).
            filePath = filePath.Trim('"');
            string[] allStrings = File.ReadAllLines(filePath);
            
            foreach (string str in allStrings)
            {
                if (str.Trim().StartsWith(TAGSeries))
                {
                    series = str.Replace(TAGSeries, "").Trim();
                    continue;
                }
                if (str.Trim().StartsWith(TAGSeason))
                {
                    // Находим число сезона и превращаем в число.
                    string t = str.Replace(TAGSeason, "").Trim();
                    season = int.Parse(t);                
                    continue;
                }
                if (str.Trim().StartsWith(TAGEpisode))
                {
                    string t = str.Replace(TAGEpisode, "").Trim();
                    episode = int.Parse(t);
                    continue;
                }
                Console.WriteLine(str);
            }
            Console.WriteLine();
            Console.WriteLine($"Это {season} сезон {episode} серия произведения: {series}");
        }
    }
}
