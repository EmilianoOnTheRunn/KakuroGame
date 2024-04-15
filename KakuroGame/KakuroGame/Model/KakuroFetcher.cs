using System;
using KakuroGame.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace KakuroGame.Model
{
	public static class KakuroFetcher
	{
        public static Kakuro FetchKakuro(EDifficulty difficulty)
        {
            List<Kakuro> kakuros;

            using (StreamReader file = new StreamReader(@"./levels.json"))
            {
                string json = file.ReadToEnd();
                kakuros = JsonConvert.DeserializeObject<List<Kakuro>>(json);
            }

            var filterList = kakuros.Where(k => k.Difficulty == difficulty);


            return filterList.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}

