using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        private string levelFilePath = Path.Combine("Fillwords", "pack_0");

        private string dictionaryFilePath = Path.Combine("Fillwords", "words_list");

        private static List<int> validIndexes; // список с индексами валидных уровней


        public GridFillWords LoadModel(int index)
        {
            GridFillWords model;

            int startIndex = index; // индекс, переданный в качестве параметра

            if (index == 1) // инициализая списка
            {
                validIndexes = new List<int>();
            }
            if (index - 1 < validIndexes.Count) // если в списке находится меньше, чем текущий индекс, значений
            {
                return GetLevel(validIndexes[index - 1]);
            }
            else if (validIndexes.Count > 0) // если список не пустой
            {
                index = validIndexes.Max() + 1;

            }

            model = GetLevel(index);

            while (validIndexes.Count < startIndex) // загрузка моделей до переданного индекса
            {
                index++;
                model = GetLevel(index);
            }

            return model;
        }

        private GridFillWords GetLevel(int index)
        {
            string[] currentLevel;

            try
            {
                currentLevel = Resources.Load<TextAsset>(levelFilePath).text.Split("\r\n").Skip(index - 1).First().Split(' ');
            }
            catch
            {
                throw new Exception("Impossible to load the level!");
            }

            int wordCount = currentLevel.Length / 2; // количество слов в уровне

            char[] currentWord;

            int numberOfWord; // номер слова в словаре

            int[] currentLetters; // массив с индексами букв слова

            SortedDictionary<int, CharGridModel> charsGrid = new SortedDictionary<int, CharGridModel>();

            for (int i = 0; i < wordCount; i++)
            {
                numberOfWord = Convert.ToInt32(currentLevel[i * 2]);

                currentWord = Resources.Load<TextAsset>(dictionaryFilePath).text.Split("\r\n").Skip(numberOfWord).First().ToCharArray();

                currentLetters = currentLevel[i * 2 + 1].Split(';').Select(int.Parse).ToArray();

                if (currentLetters.Length != currentWord.Length) // количество букв слова в уровне и словаре не совпадают
                {
                    return null;
                }

                for (int j = 0; j < currentLetters.Length; j++)
                {
                    try
                    {
                        charsGrid.Add(currentLetters[j], new CharGridModel(currentWord[j])); 
                    }
                    catch
                    {
                        return null; // два одинаковых индекса в уровне
                    }
                }
            }

            int charsCount = charsGrid.Count;

            Vector2Int size = new Vector2Int();

            if (Math.Sqrt(charsCount) % 1 != 0 || charsGrid.Keys.Min() != 0 || charsGrid.Keys.Max() != charsGrid.Count - 1) // некорректный индекс в уровне или не получается квадратная сетка
            {
                return null;
            }

            size = new Vector2Int(Convert.ToInt32(Math.Sqrt(charsCount)), Convert.ToInt32(Math.Sqrt(charsCount)));

            GridFillWords gridFillWords = new GridFillWords(size);

            int countX = 0; // номер столбца
            int countY = 0; // номер строки

            foreach (var item in charsGrid)
            {
                if (countX >= size.x)
                {
                    countX = 0;
                    countY++;
                }
                gridFillWords.Set(countY, countX, item.Value);
                countX++;
            }

            validIndexes.Add(index);

            return gridFillWords;
        }
    }
}