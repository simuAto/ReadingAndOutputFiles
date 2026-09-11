using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧтениеФайлаИВыводВКонсоль
{
    public class NoteFileReader
    {
        private const string TAGSERIES = "[Series]";
        private const string TAGSEASON = "[Season]";
        private const string TAGEPISODE = "[Episode]";

        public EpisodeNote ReadFromFile(string filePath)
        {
            EpisodeNote note = new EpisodeNote();
            string[] allLines = File.ReadAllLines(filePath);
            List<string> thoughtBuilder = new List<string>();

            foreach (string line in allLines)
            {
                string trimmedLine = line.Trim();
                
                if(trimmedLine.StartsWith(TAGSERIES))
                {
                    note.Series = trimmedLine.Replace(TAGSERIES, "").Trim();
                    continue;
                }
                if (trimmedLine.StartsWith(TAGSEASON))
                {
                    string value = trimmedLine.Replace(TAGSEASON, "").Trim();
                    if (int.TryParse(value, out int season))
                        note.Season = season;
                    continue;
                }
                if (trimmedLine.StartsWith(TAGEPISODE))
                {
                    string value = trimmedLine.Replace(TAGEPISODE, "").Trim();
                    if (int.TryParse(value, out int episodde))
                        note.Episode = episodde;
                    continue;
                }

                thoughtBuilder.Add(trimmedLine);
            }

            note.Thought = string.Join(Environment.NewLine, thoughtBuilder).Trim();
            
            return note;
        }
    }
}
