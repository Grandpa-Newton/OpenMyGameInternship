namespace App.Scripts.Scenes.SceneFillwords.Features.FillwordModels
{
    public class ContainerGrid
    {
        public GridFillWords Grid { get; private set; }
        public int LevelId { get; private set; }

        public void SetupGrid(GridFillWords gridFillWords, int levelNumber)
        {
            LevelId = levelNumber;
            Grid = gridFillWords;
        }
    }
}