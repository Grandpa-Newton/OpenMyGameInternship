namespace App.Scripts.Scenes.SceneChess.Features.ChessField.Container
{
    public class ContainerChessLevel
    {
        public GridMatrix.ChessGrid Grid { get; private set; }

        public void SetupGrid(GridMatrix.ChessGrid grid)
        {
            Grid = grid;
        }
    }
}