using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.FillwordModels
{
    public class GridFillWords
    {
        private readonly CharGridModel[][] grid;

        public GridFillWords(Vector2Int size)
        {
            Size = size;
            grid = new CharGridModel[size.y][];

            for (var i = 0; i < size.y; i++) grid[i] = new CharGridModel[size.x];
        }

        public Vector2Int Size { get; }

        public CharGridModel Get(int i, int j)
        {
            return grid[i][j];
        }

        public void Set(int i, int j, CharGridModel charGridModel)
        {
            grid[i][j] = charGridModel;
        }
    }
}