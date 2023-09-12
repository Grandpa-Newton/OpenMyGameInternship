using System;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.Execeptions
{
    public class ExceptionChessGrid : Exception
    {
        public ExceptionChessGrid(string message) : base(message)
        {
        }
    }
}