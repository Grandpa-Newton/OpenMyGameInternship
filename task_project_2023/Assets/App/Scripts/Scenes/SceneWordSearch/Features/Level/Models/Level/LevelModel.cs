using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level
{
    public class LevelModel
    {
        public List<char> InputChars = new();
        public List<string> Words = new();
        public int LevelNumber { get; set; }
    }
}