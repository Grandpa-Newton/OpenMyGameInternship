using System.Collections.Generic;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel
{
    public class FactoryLevelModel : IFactory<LevelModel, LevelInfo, int>
    {
        public LevelModel Create(LevelInfo value, int levelNumber)
        {
            var model = new LevelModel();

            model.LevelNumber = levelNumber;

            model.Words = value.words;
            model.InputChars = BuildListChars(value.words);

            return model;
        }

        private List<char> BuildListChars(List<string> words)
        {
            List<char> charList = new List<char>();

            List<char> comparingList;

            char[] currentWord;

            foreach (var word in words)
            {
                currentWord = word.ToCharArray();

                comparingList = charList.GetRange(0, charList.Count); // для клонирования листа, а не копирования ссылки

                foreach (var letter in currentWord)
                {
                    if (!comparingList.Contains(letter))
                    {
                        charList.Add(letter);
                    }
                    else
                    {
                        comparingList.Remove(letter);
                    }
                }
            }

            return charList;
        }
    }
}