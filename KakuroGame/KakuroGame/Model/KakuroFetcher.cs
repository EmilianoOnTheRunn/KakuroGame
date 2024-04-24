using System;
using KakuroGame.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace KakuroGame.Model
{
	public static class KakuroFetcher
	{
        public static Kakuro FetchKakuro(EDifficulty difficulty)
        {
            List<Kakuro> kakuros;

            string jsonFileName = "Levels.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var streamReader = new StreamReader(stream))
            {
                string json = streamReader.ReadToEnd();
                kakuros = JsonConvert.DeserializeObject<List<Kakuro>>(json);
            }

            var filterList = kakuros.Where(k => k.Difficulty == difficulty);


            return filterList.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}

